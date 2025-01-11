using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using Clave.Expressionify;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;

namespace AisLogistics.App.Service
{
    // Справочники - Офисы
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Поучить список офисов
        /// </summary>
        /// <param name="request">Запрос</param>
        public async Task<(List<OfficeParentsDto>, int, int)> GetOffices(IDataTablesRequest request, int type)
        {
            try
            {
                var results = _context.SOffices
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Expressionify()
                    .Where(x => !x.IsRemove && x.SOfficesTypeId == type);

                int totalCount = await results.CountAsync();
                var filteredResult = string.IsNullOrEmpty(request.Search.Value)
                   ? results
                   : results.Search(s => s.OfficeName.ToLower(),
                                    s => s.OfficeNameSmall.ToLower())
                   .Containing(request.Search.Value.ToLower().Split(""));

                int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                    .OrderBy(x => x.OfficeName)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(x => new OfficeParentsDto()
                    {
                        Id = x.Id,
                        OfficeName = x.OfficeNameSmall,
                        ParentOfficeId = x.ParentId,
                    }).ToListAsync();

                dataPage?.ForEach(x =>
                {
                    if (x.ParentOfficeId is not null && x.ParentOfficeId != Guid.Empty)
                    {
                        x.ParentOfficeName = _context.SOffices.AsNoTracking().Where(w => w.Id == x.ParentOfficeId).Select(s => s.OfficeName).First();
                    }
                });

                return (dataPage, totalCount, filteredCount);
            }
            catch(Exception ex)
            {
                return (new List<OfficeParentsDto>(), 0, 0);
            }
        }

        public async Task<(List<OfficeTypeDto>, int, int)> GetOfficesType(IDataTablesRequest request)
        {
            try
            {
                var results = _context.SOfficesTypes
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Expressionify();

                int totalCount = await results.CountAsync();
                var filteredResult = string.IsNullOrEmpty(request.Search.Value)
                   ? results
                   : results;

                int filteredCount = string.IsNullOrEmpty(request.Search.Value) ? totalCount : await filteredResult.CountAsync();

                var dataPage = await filteredResult
                    .OrderBy(x => x.Id)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(x => new OfficeTypeDto()
                    {
                        Id = x.Id,
                        Name = x.TypeName,
                        Count = x.SOffices.Count(c=>!c.IsRemove),
                    }).ToListAsync();

                return (dataPage, totalCount, filteredCount);
            }
            catch (Exception ex)
            {
                return (new List<OfficeTypeDto>(), 0, 0);
            }
        }

        /// <summary>
        /// Модель для добавления / редактирования офиса
        /// </summary>
        public async Task<List<OfficeParentsDto>> GetOfficesParentAllAsync()
        {
            var data = await _context.SOffices.Where(w => !w.IsRemove).Select(s => new OfficeParentsDto { Id = s.Id, OfficeName = s.OfficeName, ParentOfficeId = s.ParentId }).ToListAsync();

            data?.ForEach(x =>
            {
                x.CountChild = data.Count(c => c.ParentOfficeId == x.Id);
            });

            return data;
        }

        /// <summary>
        /// Модель для добавления / редактирования офиса
        /// </summary>
        public async Task<OfficeModelDto> GetOfficeModelDtoAsync(Guid? Id)
        {
            if (Id is null)
                throw new ArgumentNullException(nameof(Id));

            var result = await _context.SOffices
                .Include(i => i.SOfficesType)
                .Include(i => i.SFtp)
                .FirstOrDefaultAsync(f => f.Id == Id);
            if (result == null)
                throw new InvalidOperationException("Данные не найдены!");

            var model = _mapper.Map<OfficeModelDto>(result);

            if (result.ParentId != Guid.Empty)
            {
                model.OffcesParentName = await _context.SOffices.Where(w => w.Id == result.ParentId).Select(s => s.OfficeName).FirstAsync();
            }

            return model;
        }

        /// <summary>
        /// Краткая информация об офисе
        /// </summary>
        public async Task<OfficeDto?> GetOfficeDtoAsync(Guid Id)
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(w => w.Id == Id)
                .Select(s => new OfficeDto { Id = s.Id, OfficeName = s.OfficeName })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Краткая информация об офисе Спс
        /// </summary>
        public async Task<OfficeSpsDto?> GetSpsOfficeDtoAsync(int Id)
        {
            HttpClient httpClient = new();

            try
            {
                var url = $"{_spsSettings.SpsConnection}offices/";

                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode) throw new InvalidOperationException();

                var data = await response.Content.ReadFromJsonAsync<List<OfficeSpsDto>>() ?? throw new InvalidOperationException();

                return data.FirstOrDefault(f => f.Id == Id);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                httpClient.Dispose();
            }

        }

        /// <summary>
        /// Список офисов при авторизации
        /// </summary>
        public async Task<List<OfficeDto>> GetActiveEmployeeOfficesDtoAsync(Guid id)
        {
            var date = DateTime.Today;
            return await _context.SEmployeesOfficesJoins
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SEmployees.AspNetUserId == id &&
                w.DateStart <= date && (w.DateStop == null || date >= w.DateStop))
                .Select(s => new OfficeDto { Id = s.SOfficesId, OfficeName = s.SOffices.OfficeName })
                .ToListAsync();
        }

        /// <summary>
        /// Список офисов при авторизации
        /// </summary>
        public async Task<OfficeDto?> GetActiveEmployeeOfficeDtoAsync(Guid id)
        {
            var date = DateTime.Today;
            return await _context.SEmployeesOfficesJoins
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SEmployees.AspNetUserId == id &&
                w.DateStart <= date && (w.DateStop == null || date <= w.DateStop))
                .Select(s => new OfficeDto { Id = s.SOfficesId, OfficeName = s.SOffices.OfficeName })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Список Тосп для Офисов
        /// </summary>
        public async Task<List<OfficeDto>> GetTospForMfcDtoAsync(Guid id)
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.ParentId == id && x.SOfficesTypeId == (int)OfficeType.Tosp)
                .Select(x => new OfficeDto
                {
                    Id = x.Id,
                    OfficeName = x.OfficeName
                }).ToListAsync();
        }


        /// <summary>
        /// Список Тосп для Офисов
        /// </summary>
        public async Task<List<OfficeDto>> GetOfficesProvidersDepartement(Guid id)
        {
            try
            {
                return await _context.SOffices
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && (id == x.Id || id == x.ParentId))
                    .Select(x => new OfficeDto
                    {
                        Id = x.Id,
                        OfficeName = x.OfficeName
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<OfficeDto>();
            }
        }

        /// <summary>
        /// Список Тосп для Офисов
        /// </summary>
        public async Task<List<OfficeDto>> GetOfficesProvidersDepartement(List<Guid> id)
        {
            try
            {
                return await _context.SOffices
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && (id.Any(a => a == x.Id) || (id.Any(a => a == x.ParentId))))
                    .Select(x => new OfficeDto
                    {
                        Id = x.Id,
                        OfficeName = x.OfficeName
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<OfficeDto>();
            }
        }

        public async Task<Dictionary<string, string>> GetOfficeTypesAsync()
        {
            return await _context.SOfficesTypes
                .ToDictionaryAsync(x => x.Id.ToString(), x => x.TypeName);
        }

        /// <summary>
        /// Добавить офис
        /// </summary>
        public async Task AddOfficeAsync(OfficeModelDto model)
        {
            try
            {
                var entity = _mapper.Map<SOffice>(model);

                await _context.SOffices.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }

        /// <summary>
        /// Обновить основные данные  офиса
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateOfficeAsync(OfficeModelDto model)
        {
            var entity = await _context.SOffices.FindAsync(model.Id);
            if (entity == null)
                throw new InvalidOperationException("Данные не найдены!");

            _mapper.Map<OfficeModelDto, SOffice>(model, entity);

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление офис
        /// </summary>
        /// <param name="Id">Id офиса</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveOfficeAsync(Guid Id, string comment)
        {
            var entity = await _context.SOffices.FindAsync(Id);
            if (entity == null)
                throw new InvalidOperationException("Запись не найдена!");

            entity.IsRemove = true;
            entity.Commentt = comment;

            await _context.SaveChangesAsync();
        }

        public async Task<List<OfficeDto>> GetEmployeesForMfc(List<Guid> offices)
        {
            var date = DateTime.Today;
            var employee = await _context.SEmployeesOfficesJoins.Where(w => offices.Contains(w.SOfficesId) &&
                        !w.IsRemove && w.DateStart <= date && (!w.DateStop.HasValue || w.DateStop > date))
                .AsNoTracking()
                .Select(s => new OfficeDto
                {
                    Id = s.SEmployeesId,
                    OfficeName = s.SEmployees.EmployeeName
                })
                .ToListAsync();

            return employee;
        }

        public async Task<List<OfficeDto>> GetEmployeesForMfc(Guid officeId, List<int> jobsId)
        {
            var date = DateTime.Today;
            var employee = await _context.SEmployeesOfficesJoins.Where(w => w.SOfficesId == officeId && (jobsId.Contains(0) || jobsId.Contains(w.SEmployeesJobPositionId)) &&
                        !w.IsRemove && w.DateStart <= date && (!w.DateStop.HasValue || w.DateStop > date))
                .AsNoTracking()
                .Select(s => new OfficeDto
                {
                    Id = s.SEmployeesId,
                    OfficeName = s.SEmployees.EmployeeName
                })
                .ToListAsync();

            return employee;
        }

        public async Task<List<EmployeeJobDto>> GetEmployeesForMfcV2(Guid officeId, List<int> jobsId)
        {
            var date = DateTime.Today;
            var employee = await _context.SEmployeesOfficesJoins.Where(w => w.SOfficesId == officeId && (jobsId.Contains(0) || jobsId.Contains(w.SEmployeesJobPositionId)) &&
                        !w.IsRemove && w.DateStart <= date && (!w.DateStop.HasValue || w.DateStop > date))
                .AsNoTracking()
                .Select(s => new EmployeeJobDto
                {
                    SEmployeesId = s.SEmployeesId,
                    SOfficeId = s.SOfficesId,
                    EmployeeName = s.SEmployees.EmployeeName,
                    OfficeName = s.SOffices.OfficeName,
                    JobPositionName = s.SEmployeesJobPosition.JobPositionName,

                })
                .ToListAsync();

            return employee;
        }

        public async Task<List<EmployeeJobDto>> GetEmployeesForMfcV2(List<Guid> employeesId)
        {
            var date = DateTime.Today;
            var employee = await _context.SEmployeesOfficesJoins.Where(w => employeesId.Contains(w.SEmployeesId) &&
                        !w.IsRemove && w.DateStart <= date && (!w.DateStop.HasValue || w.DateStop > date))
                .AsNoTracking()
                .Select(s => new EmployeeJobDto
                {
                    SEmployeesId = s.SEmployeesId,
                    SOfficeId = s.SOfficesId,
                    EmployeeName = s.SEmployees.EmployeeName,
                    OfficeName = s.SOffices.OfficeName,
                    SJobPositionId = s.SEmployeesJobPositionId,
                    JobPositionName = s.SEmployeesJobPosition.JobPositionName,

                })
                .ToListAsync();

            return employee;
        }
    }
}
