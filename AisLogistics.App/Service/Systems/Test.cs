using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Systems;
using AisLogistics.App.ViewModels.Systems.Test;
using AisLogistics.DataLayer.Entities.Models;
using DataTables.AspNet.Core;
using FastReport;
using FastReport.Export.Pdf;
using FastReport.Utils;
using Microsoft.EntityFrameworkCore;

namespace AisLogistics.App.Service.Systems
{
    public partial class SystemsService
    {
        public async Task<(List<TestModelDto>, int, int)> GetTest(IDataTablesRequest request)
        {
            var results = _context.DTests
                 .AsNoTracking();

            int totalCount = await results.CountAsync();

            var dataPage = await results
                .OrderByDescending(o => o.DateAdd)
                .Skip(request.Start)
                .Take(request.Length)
                .Select(x => new TestModelDto()
                {
                    Id = x.Id,
                    Name = x.TestName,
                    CountQuestions = x.CountQuestions,
                    CountTime = x.TestTime,
                    Number = x.TestNumber,
                    DateAdd = x.DateAdd.ToShortDateString(),
                    Directions = x.DTestDirections.Select(s => s.STestDirection.DirectionName).ToList(),
                    CountDirections = x.DTestDirections.Count,
                    CountEmployees = x.DTestEmployees.Count,
                    CountDoneEmployees = x.DTestEmployees.Count(c => c.DateStop.HasValue),
                    EmployeesFioAdd = x.EmployeesFioAdd,
                }).ToListAsync();

            return (dataPage, totalCount, totalCount);
        }

        public async Task<List<TestEmployeesModelDto>> GetTestEmployees(Guid Id)
        {
            return await _context.DTestEmployees
                .AsNoTracking()
                .Where(w => w.DTestId == Id)
                .Select(s => new TestEmployeesModelDto
                {
                    Id = s.Id,
                    EmployeesName = s.EmployeesName,
                    OfficesName = s.OfficesName,
                    JobPositionsName = s.JobPositionsName,
                    PercentResult = s.PercentResult,
                    NumberCorrectQuestions = s.NumberCorrectQuestions,
                    NumberIncorrectQuestions = s.NumberIncorrectQuestions,
                    NumberQuestionsAnswered = s.NumberQuestionsAnswered,
                    DateStart = s.DateStart,
                    DateEnd = s.DateStop
                }).ToListAsync();
        }

        public async Task<byte[]?> GetTestEmployeesPrint(byte[] content, Guid id, string connection)
        {
            RegisteredObjects.AddConnection(typeof(FastReport.Data.PostgresDataConnection));
            var rep = new Report();
            rep.Load(new MemoryStream(content));
            rep.SetParameterValue("EmployeeTestId", id.ToString());

            if (rep.Dictionary.Connections.Count != 0)
            {
                rep.Dictionary.Connections[0].ConnectionString = connection;
            }

            var isPrepare = rep.Prepare();

            if (!isPrepare) throw new InvalidOperationException("Ошибка при создание бланка");

            var strm = new MemoryStream();

            var pdfExport = new PDFExport();
            rep.Export(pdfExport, strm);
            pdfExport.Dispose();

            rep.Dispose();

            return strm.ToArray();
        }

        public async Task<List<TestEmployeesQuestionModelDto>> GetTestEmployeesQuestionAndAnswer(Guid Id)
        {
            return await _context.DTestQuestionsEmployees
                  .AsNoTracking()
                  .Where(w => w.DTestEmployeesId == Id)
                  .Select(s => new TestEmployeesQuestionModelDto
                  {
                      QuestionId = s.STestQuestionId,
                      QuestionName = s.QuestionName,
                      Answers = s.DTestAnswerEmployees.Select(ss => new TestEmployeesQuestionAnswer
                      {
                          AnswerId = ss.STestAnswersId,
                          AnswerName = ss.AnswerName,
                          IsTruth = ss.IsTruth,
                          IsAnswer = ss.IsResponseEmployees
                      }).ToList()
                  }).ToListAsync();
        }
        public async Task<List<EmployeesQuestionResponseModel>?> GetEmployeesQuestionList(EmployeesQuestionRequestModel requestModel)
        {
            try
            {
                var employeeQuestionList = new List<EmployeesQuestionResponseModel>();
                var employees = new List<EmployeeJobDto>();

                if (requestModel.TestDirectionId.Any(a => a == Guid.Empty))
                {
                    var dataDirection = await _referencesService.GetAllDirectionsAsync(requestModel.TestEmployeeJobsId);
                    requestModel.TestDirectionId = dataDirection.Select(s => s.Id).ToList();
                }
                if (requestModel.TestEmployeesId.Any(a => a == Guid.Empty))
                {
                    employees.AddRange(await _referencesService.GetEmployeesForMfcV2(requestModel.TestOfficesId, requestModel.TestEmployeeJobsId));
                }
                else
                {
                    employees.AddRange(await _referencesService.GetEmployeesForMfcV2(requestModel.TestEmployeesId));
                }

                var questionDirection = await _context.STestDirectionQuestions
                    .AsNoTracking()
                    .Where(w => w.STestQuestion.IsActive && requestModel.TestDirectionId.Contains(w.STestDirectionId))
                    .GroupBy(g => g.STestQuestionId)
                    .Select(s => s.Select(ss => new { ss.STestDirectionId, ss.STestQuestionId, ss.STestQuestion.QuestionName }).First())
                    .ToListAsync();

                if (questionDirection.Count == 0) return null;
                else if (questionDirection.Count <= requestModel.CountQuestions)
                {
                    foreach (var emp in employees)
                    {
                        employeeQuestionList.Add(new EmployeesQuestionResponseModel
                        {

                            EmployeeId = emp.SEmployeesId,
                            EmployeeName = emp.EmployeeName,
                            OfficeName = emp.OfficeName,
                            JobPositionName = emp.JobPositionName,
                            EmployeesQuestionsInfo = questionDirection.Select(s => new EmployeesQuestion
                            {
                                Id = s.STestQuestionId,
                                Name = s.QuestionName
                            }).ToList(),
                        });
                    }
                }
                else
                {

                    var groupQuestionDirection = questionDirection.GroupBy(g => g.STestDirectionId).Select(s => new { DirectionId = s.Key, Question = s.Select(ss => new EmployeesQuestion { Id = ss.STestQuestionId, Name = ss.QuestionName }).ToList() });

                    var countQuestionDirection = requestModel.CountQuestions <= groupQuestionDirection.Count() ? 1 : requestModel.CountQuestions / groupQuestionDirection.Count();

                    var count = requestModel.CountQuestions;

                    foreach (var emp in employees)
                    {
                        var group2 = groupQuestionDirection.ToList();
                        count = requestModel.CountQuestions;
                        var employeeQuestion = new EmployeesQuestionResponseModel();
                        employeeQuestion.EmployeeId = emp.SEmployeesId;
                        employeeQuestion.EmployeeName = emp.EmployeeName;
                        employeeQuestion.OfficeId = emp.SOfficeId;
                        employeeQuestion.OfficeName = emp.OfficeName;
                        employeeQuestion.JobPositionId = emp.SJobPositionId;
                        employeeQuestion.JobPositionName = emp.JobPositionName;
                        employeeQuestion.EmployeesQuestionsInfo = new List<EmployeesQuestion>(count);

                        if ((group2.Count * countQuestionDirection) <= count)
                        {

                            foreach (var g in group2)
                            {
                                if (g.Question.Count <= countQuestionDirection)
                                {

                                    employeeQuestion.EmployeesQuestionsInfo.AddRange(g.Question);

                                    count -= g.Question.Count;
                                }
                                else
                                {
                                    var questionList = GetRandomQuestion(g.Question, countQuestionDirection);

                                    employeeQuestion.EmployeesQuestionsInfo.AddRange(questionList);

                                    g.Question.RemoveAll(r => questionList.Any(a => a.Id == r.Id));

                                    count -= questionList.Count;
                                }
                            }
                        }

                        if (count > 0)
                        {

                            employeeQuestion.EmployeesQuestionsInfo.AddRange(GetRandomQuestion(group2.SelectMany(s => s.Question).ToList(), count));
                        }

                        employeeQuestionList.Add(employeeQuestion);
                    }
                }

                return employeeQuestionList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<EmployeesQuestionResponseModel?> GetRefreshEmployeesQuestion(EmployeesQuestioRefreshRequestModel requestModel)
        {
            try
            {
                var employeeQuestions = new EmployeesQuestionResponseModel();
                if (requestModel.TestDirectionId.Any(a => a == Guid.Empty))
                {
                    var dataDirection = await _referencesService.GetAllDirectionsAsync(requestModel.TestEmployeeJobsId);
                    requestModel.TestDirectionId = dataDirection.Select(s => s.Id).ToList();
                }
                var questionDirection = await _context.STestDirectionQuestions
                       .AsNoTracking()
                       .Where(w => w.STestQuestion.IsActive && requestModel.TestDirectionId.Contains(w.STestDirectionId))
                       .GroupBy(g => g.STestQuestionId)
                       .Select(s => s.Select(ss => new { ss.STestDirectionId, ss.STestQuestionId, ss.STestQuestion.QuestionName }).First())
                       .ToListAsync();

                if (questionDirection.Count == 0) return null;
                else if (questionDirection.Count <= requestModel.CountQuestions)
                {
                    employeeQuestions.EmployeeId = requestModel.TestEmployeeId;
                    employeeQuestions.EmployeesQuestionsInfo = questionDirection.Select(s => new EmployeesQuestion
                    {
                        Id = s.STestQuestionId,
                        Name = s.QuestionName
                    }).ToList();
                }
                else
                {
                    var groupQuestionDirection = questionDirection.GroupBy(g => g.STestDirectionId).Select(s => new { DirectionId = s.Key, Question = s.Select(ss => new EmployeesQuestion { Id = ss.STestQuestionId, Name = ss.QuestionName }).ToList() });

                    var countQuestionDirection = requestModel.CountQuestions <= groupQuestionDirection.Count() ? 1 : requestModel.CountQuestions / groupQuestionDirection.Count();

                    var group2 = groupQuestionDirection.ToList();
                    var count = requestModel.CountQuestions;
                    employeeQuestions.EmployeeId = requestModel.TestEmployeeId;
                    employeeQuestions.EmployeesQuestionsInfo = new List<EmployeesQuestion>(count);

                    if ((group2.Count * countQuestionDirection) <= count)
                    {

                        foreach (var g in group2)
                        {
                            if (g.Question.Count <= countQuestionDirection)
                            {

                                employeeQuestions.EmployeesQuestionsInfo.AddRange(g.Question);

                                count -= g.Question.Count;
                            }
                            else
                            {
                                var questionList = GetRandomQuestion(g.Question, countQuestionDirection);

                                employeeQuestions.EmployeesQuestionsInfo.AddRange(questionList);

                                g.Question.RemoveAll(r => questionList.Any(a => a.Id == r.Id));

                                count -= questionList.Count;
                            }
                        }
                    }

                    if (count > 0)
                    {

                        employeeQuestions.EmployeesQuestionsInfo.AddRange(GetRandomQuestion(group2.SelectMany(s => s.Question).ToList(), count));
                    }

                }

                return employeeQuestions;
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> EmployeesTestSave(EmployeesTestSaveRequestModel requestModel)
        {
            try
            {
                var employeName = await _employeeManager.GetNameAsync();
                var newTest = new DTest
                {
                    TestName = requestModel.TestName,
                    CountQuestions = (short)requestModel.CountQuestions,
                    TestTime = requestModel.TestTime,
                    DateStartTest = requestModel.DateStartTest.Add(requestModel.TimeStartTest),
                    EmployeesFioAdd = employeName,
                    DateAdd = DateTime.Now,
                };

                requestModel.EmployeeQuestion.ForEach(f =>
                {
                    newTest.DTestEmployees.Add(new DTestEmployee
                    {
                        SEmployeesId = f.Id,
                        EmployeesName = f.EmployeeName,
                        SEmployeesJobPositionId = f.JobPositionId,
                        JobPositionsName = f.JobPositionName,
                        SOfficesId = f.OfficeId,
                        OfficesName = f.OfficeName,
                        TestTime = (long)TimeSpan.FromMinutes(requestModel.TestTime).TotalSeconds,
                        DTestQuestionsEmployees = f.Question.Select(s => new DTestQuestionsEmployee
                        {
                            STestQuestionId = s.Id,
                            QuestionName = s.Name
                        }).ToList()
                    });
                });

                if (requestModel.TestDirectionId.Any(a => a == Guid.Empty))
                {
                    var dataDirection = await _referencesService.GetAllDirectionsAsync(requestModel.TestEmployeeJobsId);
                    requestModel.TestDirectionId = dataDirection.Select(s => s.Id).ToList();
                }

                requestModel.TestDirectionId.ForEach(f =>
                {
                    newTest.DTestDirections.Add(new DTestDirection
                    {
                        STestDirectionId = f
                    });
                });

                await _context.AddAsync(newTest);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static List<EmployeesQuestion> GetRandomQuestion(List<EmployeesQuestion> question, int count)
        {
            var random = new Random();
            List<EmployeesQuestion> questionList = new List<EmployeesQuestion>(count);

            for (int i = 0; i < count; i++)
            {
                var temp = question.Skip(random.Next(0, question.Count - 1)).First();
                questionList.Add(temp);
                question.Remove(temp);
            }

            return questionList;
        }

    }
}
