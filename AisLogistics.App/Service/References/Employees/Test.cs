using AisLogistics.App.Models.DTO.References;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - Тест
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Получить тесты сотрудника
        /// </summary>
        /// <param name="request">Запрос</param>
        /// <param name="id">Id сотрудника</param>
        public async Task<(List<EmployeeTestDto>, int, int)> GetEmployeeTest(IDataTablesRequest request, Guid id)
        {
            var dateNow = DateTime.Now;
            var results = _context.DTestEmployees
                .AsNoTracking()
                .Where(x => x.SEmployeesId == id);

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderByDescending(x => x.DTest.DateStartTest)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new EmployeeTestDto()
                {
                    Id = x.Id,
                    SEmployeesId = x.SEmployeesId,
                    TestNumber = x.DTest.TestNumber,
                    TestName = x.DTest.TestName,
                    CountQuestion = x.DTest.CountQuestions,
                    DateStartActiveTest = x.DTest.DateStartTest.ToShortDateString(),
                    IsDateStartActiveTest = dateNow > x.DTest.DateStartTest,
                    DateStartEmployee = x.DateStart.HasValue ? x.DateStart.Value.ToShortDateString() : null,
                    DateStopEmployee = x.DateStop.HasValue ? x.DateStop.Value.ToShortDateString() : null,
                    Percent = x.PercentResult,
                    CountMinute = x.DTest.TestTime
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        public async Task<EmployeeTestStartDto?> GetEmployeeTestStart(Guid id)
        {
            var date = DateTime.Now;

            return await _context.DTestEmployees
                .AsNoTracking()
                .Select(s => new EmployeeTestStartDto
                {
                    EmployeeTestId = s.Id,
                    Name = s.DTest.TestName,
                    Number = s.DTest.TestNumber,
                    CountQuestions = s.DTest.CountQuestions,
                    CountTestTime = s.DTest.TestTime,
                    Directions = s.DTest.DTestDirections.Select(s => s.STestDirection.DirectionName).ToList(),
                    IsActive = date > s.DTest.DateStartTest && !s.DateStop.HasValue
                })
                .FirstOrDefaultAsync(f => f.EmployeeTestId == id);
        }

        public async Task<EmployeeTestQuestionDto?> GetEmployeeTestQuestion(Guid id)
        {
            var data = await _context.DTestEmployees
                .AsNoTracking()
                .Where(w => w.Id == id)
                .Select(s => new
                {
                    TestEmployee = s,
                    Question = new EmployeeTestQuestionDto
                    {
                        EmployeeId = s.SEmployeesId,
                        EmployeeTestId = s.Id,
                        Percent = s.PercentResult,
                        Question = s.DTestQuestionsEmployees.Where(w => !w.DTestAnswerEmployees.Any()).Select(ss => new Question
                        {
                            EmployeeQuestionId = ss.Id,
                            QuestionName = ss.QuestionName,
                            QuestionType = ss.STestQuestion.QuestionType,
                            TestTime = s.TestTime,
                            QuestionCount = s.DTest.CountQuestions,
                            QuestionNumber = s.DTestQuestionsEmployees.Count(c => c.DTestAnswerEmployees.Any()),
                            Answers = ss.STestQuestion.STestAnswers.Where(W => !W.IsRemove).Select(ss => new EmployeeTestAnswer { AnswerId = ss.Id, AnswerName = ss.AnswerName, IsTruth = ss.IsRight }).ToList(),
                        }).FirstOrDefault()
                    }
                }).FirstOrDefaultAsync();
            if (data is null) throw new ArgumentException("Тест не найден");

            if (!data.TestEmployee.DateStart.HasValue)
            {
                data.TestEmployee.DateStart = DateTime.Now;
                _context.Update(data.TestEmployee);
                await _context.SaveChangesAsync();
            }

            return data.Question;

        }

        public async Task EmployeeTestAnswersSave(EmployeesTestAnswerDto request)
        {
            var testEmployee = await _context.DTestEmployees.FindAsync(request.EmployeeTestId);
            if (testEmployee == null) throw new ArgumentException(nameof(testEmployee));

            var answerEmployees = new List<DTestAnswerEmployee>();
            var ip = await _employeeManager.GetIp();

            request.Answers.ForEach(answer =>
            {
                answerEmployees.Add(new DTestAnswerEmployee
                {
                    DTestQuestionsEmployeesId = request.EmployeeTestQuestionId,
                    DateTimeAnswer = DateTime.Now,
                    IpAddress = ip,
                    STestAnswersId = answer.Id,
                    AnswerName = answer.Name,
                    IsResponseEmployees = answer.IsResponse,
                    IsTruth = answer.IsTruth,
                });
            });

            var istruth = request.Answers.All(a => a.IsTruth == a.IsResponse);

            testEmployee.TestTime = (long)new TimeSpan(0, int.Parse(request.TestTime.Split(':')[0], CultureInfo.InvariantCulture), int.Parse(request.TestTime.Split(':')[1], CultureInfo.InvariantCulture)).TotalSeconds;
            testEmployee.NumberQuestionsAnswered = testEmployee.NumberQuestionsAnswered.HasValue ? (short)(testEmployee.NumberQuestionsAnswered.Value + 1) : testEmployee.NumberQuestionsAnswered.GetValueOrDefault(1);
            if (istruth) testEmployee.NumberCorrectQuestions = testEmployee.NumberCorrectQuestions.HasValue ? (short)(testEmployee.NumberQuestionsAnswered.Value + 1) : testEmployee.NumberCorrectQuestions.GetValueOrDefault(1);
            else testEmployee.NumberIncorrectQuestions = testEmployee.NumberIncorrectQuestions.HasValue ? (short)(testEmployee.NumberIncorrectQuestions.Value + 1) : testEmployee.NumberIncorrectQuestions.GetValueOrDefault(1);

            testEmployee.PercentResult = (short)Math.Round(((100 / (double)request.QuestionCount) * testEmployee.NumberCorrectQuestions ?? 0));

            if (testEmployee.TestTime == 0 || testEmployee.NumberQuestionsAnswered == request.QuestionCount)
            {
                testEmployee.DateStop = DateTime.Now;
            }

            await _context.AddRangeAsync(answerEmployees);
            await _context.SaveChangesAsync();
        }
    }
}
