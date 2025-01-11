using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    // Справочники - Тестиоование
    public partial class ReferencesService : IReferencesService
    {

        /// <summary>
        /// Получить список Направлений
        /// </summary>
        public async Task<(List<TestDirectionDto>, int, int)> GetDirections(IDataTablesRequest request)
        {
            var results = _context.STestDirections
                .AsNoTracking()
                .Where(x => !x.IsRemove);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new TestDirectionDto()
                {
                    Id = x.Id,
                    Name = x.DirectionName,
                    DateAdd = x.DateAdd.ToShortDateString(),
                    EmployeesFioAdd = x.EmployeesFioAdd
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Получить список Направлений
        /// </summary>
        public async Task<List<TestDirectionDto>> GetAllDirectionsAsync()
        {
            return await _context.STestDirections
                .AsNoTracking()
                .Where(x => !x.IsRemove)
                .Select(x => new TestDirectionDto()
                {
                    Id = x.Id,
                    Name = x.DirectionName
                }).ToListAsync();
        }

        /// <summary>
        /// Получить список Направлений
        /// </summary>
        public async Task<List<TestDirectionDto>> GetAllDirectionsAsync(List<int> jobsId)
        {
            return await _context.STestDirections
                .AsNoTracking()
                .Where(x => !x.IsRemove && (jobsId.Contains(0) || x.STestDirectionJobs.Any(a => jobsId.Contains(a.SEmployeesJobPositionId))))
                .GroupBy(g => new { g.Id, g.DirectionName })
                .Select(x => new TestDirectionDto()
                {
                    Id = x.Key.Id,
                    Name = x.Key.DirectionName
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для редактирования направления
        /// </summary>
        public async Task<TestDirectionModelDto?> GetDirectionsDtoAsync(Guid? Id)
        {
            try
            {
                if (Id is null)
                    throw new ArgumentNullException(nameof(Id));

                return await _context.STestDirections
                    .Where(w => !w.IsRemove && w.Id == Id)
                    .Select(s => new TestDirectionModelDto
                    {
                        Id = s.Id,
                        DirectionName = s.DirectionName,
                        STestDirectionJobsId = s.STestDirectionJobs.Select(s => s.SEmployeesJobPositionId).ToList()
                    }).FirstOrDefaultAsync() ?? throw new InvalidOperationException("Данные не найдены!");
            }

            catch
            {
                return null;
            }
        }

        public async Task AddDirectionsAsync(TestDirectionModelDto model)
        {
            var entity = _mapper.Map<STestDirection>(model);

            if (model.STestDirectionJobsId.Count == 0) throw new InvalidOperationException("Не выбраны должности");

            if (model.STestDirectionJobsId.Any(a => a == 0))
            {
                model.STestDirectionJobsId = await _context.SEmployeesJobPositions.Where(w => !w.IsRemove).Select(s => s.Id).ToListAsync();
            }

            model.STestDirectionJobsId.ForEach(f =>
            {
                entity.STestDirectionJobs.Add(new STestDirectionJob
                {
                    SEmployeesJobPositionId = f,
                    EmployeesFioAdd = model.EmployeesFioAdd,
                    DateAdd = model.DateAdd,
                });

            });

            await _context.STestDirections.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDirectionsAsync(TestDirectionModelDto model)
        {
            if (model.STestDirectionJobsId.Count == 0) throw new InvalidOperationException("Не выбраны должности");

            var entity = await _context.STestDirections.Include(i => i.STestDirectionJobs).FirstOrDefaultAsync(f => f.Id == model.Id) ?? throw new InvalidOperationException("Данные не найдены!");
            _mapper.Map<TestDirectionModelDto, STestDirection>(model, entity);


            entity.STestDirectionJobs.Clear();

            if (model.STestDirectionJobsId.Any(a => a == 0))
            {
                model.STestDirectionJobsId = await _context.SEmployeesJobPositions.Where(w => !w.IsRemove).Select(s => s.Id).ToListAsync();
            }

            model.STestDirectionJobsId.ForEach(f =>
            {
                entity.STestDirectionJobs.Add(new STestDirectionJob
                {
                    SEmployeesJobPositionId = f,
                    EmployeesFioAdd = model.EmployeesFioAdd,
                    DateAdd = model.DateAdd,
                });

            });

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление (удалить?) напрвления
        /// </summary>
        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveDirectionsAsync(Guid Id, string comment)
        {
            var entity = await _context.STestDirections.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");
            entity.IsRemove = true;

            await _context.SaveChangesAsync();
        }
    }
}
