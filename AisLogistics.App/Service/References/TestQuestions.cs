using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Common.Dto.Reference;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service
{
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить список Вопросов
        /// </summary>
        public async Task<(List<TestQuestionDto>, int, int)> GetQuestions(IDataTablesRequest request)
        {
            var results = _context.STestQuestions
                .AsNoTracking();

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new TestQuestionDto()
                {
                    Id = x.Id,
                    Name = x.QuestionName,
                    IsActive = x.IsActive,
                    QuestionType = x.QuestionType,
                    DateAdd = x.DateAdd.ToShortDateString(),
                    EmployeesFioAdd = x.EmployeesFioAdd
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        /// <summary>
        /// Получить список Вопросов
        /// </summary>
        public async Task<List<TestQuestionDto>> GetAllQuestionsAsync()
        {
            return await _context.STestQuestions
                .AsNoTracking()
                .Where(x => x.IsActive)
                .Select(s => new TestQuestionDto
                {
                    Id = s.Id,
                    Name = s.QuestionName
                }).ToListAsync();
        }

        /// <summary>
        /// Модель для редактирования Вопроса
        /// </summary>
        public async Task<TestQuestionsModelDto?> GetQuestionsDtoAsync(Guid? Id)
        {
            try
            {
                if (Id is null)
                    throw new ArgumentNullException(nameof(Id));

                return await _context.STestQuestions
                    .Select(s => new TestQuestionsModelDto
                    {
                        Id = s.Id,
                        QuestionName = s.QuestionName,
                        IsActive = s.IsActive,
                        TestDirectionId = s.STestDirectionQuestions.Select(ss => ss.STestDirectionId).ToList(),
                        TestQuestionsAnswers = s.STestAnswers.Select(ss => new TestQuestionsAnswerModelDto
                        {
                            Id = ss.Id,
                            AnswerName = ss.AnswerName,
                            IsRight = ss.IsRight,
                        }).ToList()
                    }).FirstOrDefaultAsync(f => f.Id == Id) ?? throw new InvalidOperationException("Данные не найдены!");
            }
            catch
            {
                return null;
            }
        }

        public async Task AddQuestionsAsync(TestQuestionsModelDto model)
        {
            if (model.TestDirectionId.Count == 0) throw new InvalidOperationException("Не выбраны направления");
            if (model.TestQuestionsAnswers.Count == 0) throw new InvalidOperationException("Не добавлены ответы");
            if (!model.TestQuestionsAnswers.Any(a => a.IsRight)) throw new InvalidOperationException("Нету правильных ответов");
            if (model.TestQuestionsAnswers.Any(a => string.IsNullOrEmpty(a.AnswerName))) throw new InvalidOperationException("Текст ответа не добавлен");

            var entity = _mapper.Map<STestQuestion>(model);

            if (model.TestDirectionId.Any(a => a == Guid.Empty))
            {
                model.TestDirectionId = await _context.STestDirections.Where(w => !w.IsRemove).Select(s => s.Id).ToListAsync();
            }

            model.TestDirectionId.ForEach(f =>
            {
                entity.STestDirectionQuestions.Add(new STestDirectionQuestion
                {
                    STestDirectionId = f,
                    EmployeesFioAdd = model.EmployeesFioAdd,
                    DateAdd = model.DateAdd,
                });

            });

            model.TestQuestionsAnswers.ForEach(f =>
            {
                entity.STestAnswers.Add(new STestAnswer
                {
                    AnswerName = f.AnswerName,
                    IsRight = f.IsRight,
                    EmployeesFioAdd = model.EmployeesFioAdd,
                    DateAdd = model.DateAdd,
                });
            });

            entity.QuestionType = (short)model.TestQuestionsAnswers.Count(c => c.IsRight);
            await _context.STestQuestions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQuestionsAsync(TestQuestionsModelDto model)
        {
            if (model.TestDirectionId.Count == 0) throw new InvalidOperationException("Не выбраны направления");
            if (model.TestQuestionsAnswers.Count == 0) throw new InvalidOperationException("Не добавлены ответы");
            if (!model.TestQuestionsAnswers.Any(a => a.IsRight)) throw new InvalidOperationException("Нету правильных ответов");
            if (model.TestQuestionsAnswers.Any(a => string.IsNullOrEmpty(a.AnswerName))) throw new InvalidOperationException("Текст ответа не добавлен");

            var entity = await _context.STestQuestions
                .Include(i => i.DTestQuestionsEmployees)
                .Include(i => i.STestAnswers)
                .FirstOrDefaultAsync(f => f.Id == model.Id) ?? throw new InvalidOperationException("Данные не найдены!");

            _mapper.Map<TestQuestionsModelDto, STestQuestion>(model, entity);

            entity.DTestQuestionsEmployees.Clear();


            if (model.TestDirectionId.Any(a => a == Guid.Empty))
            {
                model.TestDirectionId = await _context.STestDirections.Where(w => !w.IsRemove).Select(s => s.Id).ToListAsync();
            }

            model.TestDirectionId.ForEach(f =>
            {
                entity.STestDirectionQuestions.Add(new STestDirectionQuestion
                {
                    STestDirectionId = f,
                    EmployeesFioAdd = model.EmployeesFioAdd,
                    DateAdd = model.DateAdd,
                });

            });

            entity.STestAnswers.Clear();

            model.TestQuestionsAnswers.ForEach(f =>
            {
                entity.STestAnswers.Add(new STestAnswer
                {
                    AnswerName = f.AnswerName,
                    IsRight = f.IsRight,
                    EmployeesFioAdd = model.EmployeesFioAdd,
                    DateAdd = model.DateAdd,
                });
            });

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Пометить на удаление (удалить?) Вопроса
        /// </summary>
        /// <param name="Id">ID записи</param>
        /// <param name="comment">Причина удаления</param>
        public async Task RemoveQuestionsAsync(Guid Id, string comment)
        {
            var entity = await _context.STestQuestions.FindAsync(Id) ?? throw new InvalidOperationException("Данные не найдены!");
            entity.IsActive = false;

            await _context.SaveChangesAsync();
        }
    }
}
