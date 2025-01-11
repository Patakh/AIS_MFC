using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Information;
using AisLogistics.DataLayer.Concrete;
using DataTables.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public class InformationManager : IInformationManager
    {
        private readonly AisLogisticsContext _context;
        private readonly IEmployeeManager _employeeManager;

        public InformationManager(AisLogisticsContext context, IEmployeeManager employeeManager)
        {
            _context = context;
            _employeeManager = employeeManager;
        }

        public async Task<List<EmployeeInformationDto>> GetInformationListAsync(int count)
        {
            var userId = await _employeeManager.GetIdAsync();
            var information = await _context.DInformations.AsNoTracking()
                .Select(s => new EmployeeInformationDto
                {
                    Id = s.Id,
                    Type = s.SInformationType.TypeName,
                    Topic = s.InformationTopic,
                    Text = s.InformationText,
                    DateAdd = s.DateAdd,
                    DateStop = s.DateStop,
                    DateStart = s.DateStart,
                    IsRemove = s.IsRemove,
                    EmployeeFio = s.EmployeesFioAdd,
                    EmployeeJob = s.EmployeesJobPositionAdd,
                    IsAttachment = s.DInformationFiles.Any(),
                    ForMe = s.DInformationRecipients.Any(a => a.SEmployeesId == userId)
                }).OrderBy(o => o.DateAdd)
                .Where(w => w.IsRemove == false && w.ForMe && w.DateStart <= DateTime.Today &&
                            (w.DateStop.HasValue == false || w.DateStop >= DateTime.Now)).ToListAsync();
            return information;
        }

        public async Task<(List<EmployeeInformationDto>, int, int)> GetEmployeeInformationAsync(IDataTablesRequest? request)
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();
                var data = _context.DInformations
                    .AsNoTracking()
                    .Where(w => w.IsRemove == false &&
                           w.DInformationRecipients.Any(a => a.SEmployeesId == userId) &&
                           w.DateStart <= DateTime.Today && (w.DateStop.HasValue == false || w.DateStop >= DateTime.Now));

                var dataCount = await data.CountAsync();

                var information = await data
                    .OrderBy(o => o.DateAdd)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(s => new EmployeeInformationDto
                    {
                        Id = s.Id,
                        Type = s.SInformationType.TypeName,
                        Topic = s.InformationTopic,
                        Text = s.InformationText,
                        DateAdd = s.DateAdd,
                        DateAddToString = s.DateAdd.ToLongDateString(),
                        DateStop = s.DateStop,
                        DateStart = s.DateStart,
                        IsRemove = s.IsRemove,
                        EmployeeFio = s.EmployeesFioAdd,
                        EmployeeJob = s.EmployeesJobPositionAdd,
                        IsAttachment = s.DInformationFiles.Any(),
                    }).ToListAsync();

                return (information, dataCount, dataCount);
            }
            catch
            {
                return (new List<EmployeeInformationDto>(), 0, 0);
            }
        }


        public async Task<InformationDetails?> GetInformationDetailssAsync(Guid id)
        {
            return await _context.DInformations.AsNoTracking()
                .Select(s => new InformationDetails
                {
                    Id = s.Id,
                    Type = s.SInformationType.TypeName,
                    Topic = s.InformationTopic,
                    Text = s.InformationText,
                    DateAdd = s.DateAdd,
                    EmployeeFio = s.EmployeesFioAdd,
                    EmployeeJob = s.EmployeesJobPositionAdd,
                    Files = s.DInformationFiles.Select(ss => new FileDto { Id = ss.Id, FileName = ss.FileName, FileExtensions = ss.FileExtention, FileSize = ss.FileSize }).ToList()
                })
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<EmployeeWarningDto> GetWarningRousteStageListAsync()
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();

                var date = DateTime.Now;

                var response = new EmployeeWarningDto();

                var list = await _context.DServicesRoutesStages
                    .AsNoTracking()
                    .Where(w => w.SEmployeesId == userId &&
                    !w.DateFact.HasValue &&
                    w.DateReg.HasValue &&
                    w.DateReg <= date.AddDays(3))
                    .Select(s => new
                    {
                        s.DCasesId,
                        s.DServices.SServices.ServiceName,
                        CustomerName = s.DCases.DServicesCustomersLegals.Count == 0 ? s.DCases.DServicesCustomers.Where(w => w.CustomerType == (int)CustomerType.Applicant).Select(ss => ss.Fio()).First() :
                                                                              s.DCases.DServicesCustomers.Where(w => w.CustomerType == (int)CustomerType.Representative).Select(ss => ss.Fio()).First(),
                        s.SRoutesStage.StageName,

                        days = s.DateReg.Value.Date.Subtract(date.Date).Days
                    }).ToListAsync();

                response.Expired.AddRange(list.Where(w => w.days < 0).Select(s => new StageInfo { ServiceName = s.ServiceName, CaseId = s.DCasesId, StageName = s.StageName, ApplicantName = s.CustomerName }).ToList());
                response.Lastday.AddRange(list.Where(w => w.days == 1 || w.days == 0).Select(s => new StageInfo { ServiceName = s.ServiceName, CaseId = s.DCasesId, StageName = s.StageName, ApplicantName = s.CustomerName }).ToList());
                response.LessThreeDays.AddRange(list.Where(w => w.days > 1 && w.days <= 3).Select(s => new StageInfo { ServiceName = s.ServiceName, CaseId = s.DCasesId, StageName = s.StageName, ApplicantName = s.CustomerName }).ToList());

                return response;
            }
            catch (Exception ex)
            {
                return new EmployeeWarningDto();
            }
        }


        public async Task<List<RatingDto>> GetEmployeeRatingAsync(IDataTablesRequest? request, int typeId)
        {
            List<RatingDto> response = new List<RatingDto>();
            try
            {
                //var date = DateTime.Now.AddDays(-1);
                var orderColumns = request?.Columns.Where(x => x.Sort != null);
                var employeeId = await _employeeManager.GetIdAsync();
                //var employeeId = new Guid("c64cc0d5-2bed-41cd-82ec-9ddef8af4b78");

                if (typeId == 1)
                {
                    var date = await _context.DRatingEmployeesDays.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f=>f.DayOfWeek!=DayOfWeek.Sunday);

                    var topFive = await _context.DRatingEmployeesDays
                        .AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Employee = new EmployeeRatingDto
                            {
                                EmployeeName = s.EmployeeName,
                                OfficesName = s.OfficeName,
                                EmployeeId = s.SEmployeesId,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Employee.EmployeeId == employeeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingEmployeesDays
                                .AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SEmployeesId == employeeId)
                                .Select(s => new EmployeeRatingDto
                                {
                                    EmployeeName = s.EmployeeName,
                                    OfficesName = s.OfficeName,
                                    EmployeeId = s.SEmployeesId,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {

                            var topPositionPrev = await _context.DRatingEmployeesDays
                                    .AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new EmployeeRatingDto
                                    {
                                        EmployeeName = s.EmployeeName,
                                        OfficesName = s.OfficeName,
                                        EmployeeId = s.SEmployeesId,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Employee = new EmployeeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Employee = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Employee = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }

                }

                if (typeId == 2)
                {
                    var date = await _context.DRatingEmployeesMonths.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek != DayOfWeek.Sunday);

                    var topFive = await _context.DRatingEmployeesMonths
                        .AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Employee = new EmployeeRatingDto
                            {
                                EmployeeName = s.EmployeeName,
                                OfficesName = s.OfficeName,
                                EmployeeId = s.SEmployeesId,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Employee.EmployeeId == employeeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingEmployeesMonths
                                .AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SEmployeesId == employeeId)
                                .Select(s => new EmployeeRatingDto
                                {
                                    EmployeeName = s.EmployeeName,
                                    OfficesName = s.OfficeName,
                                    EmployeeId = s.SEmployeesId,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {

                            var topPositionPrev = await _context.DRatingEmployeesMonths
                                    .AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new EmployeeRatingDto
                                    {
                                        EmployeeName = s.EmployeeName,
                                        OfficesName = s.OfficeName,
                                        EmployeeId = s.SEmployeesId,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Employee = new EmployeeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Employee = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Employee = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }
                }

                if (typeId == 3)
                {
                    var date = await _context.DRatingEmployeesYears.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek != DayOfWeek.Sunday);

                    var topFive = await _context.DRatingEmployeesYears.AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Employee = new EmployeeRatingDto
                            {
                                EmployeeName = s.EmployeeName,
                                OfficesName = s.OfficeName,
                                EmployeeId = s.SEmployeesId,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Employee.EmployeeId == employeeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingEmployeesYears.AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SEmployeesId == employeeId)
                                .Select(s => new EmployeeRatingDto
                                {
                                    EmployeeName = s.EmployeeName,
                                    OfficesName = s.OfficeName,
                                    EmployeeId = s.SEmployeesId,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {

                            var topPositionPrev = await _context.DRatingEmployeesYears.AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new EmployeeRatingDto
                                    {
                                        EmployeeName = s.EmployeeName,
                                        OfficesName = s.OfficeName,
                                        EmployeeId = s.SEmployeesId,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Employee = new EmployeeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Employee = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Employee = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }
                }

                if (typeId == 4)
                {
                    var date = await _context.DRatingEmployeesAlls.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek!= DayOfWeek.Sunday);

                    var topFive = await _context.DRatingEmployeesAlls.AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Employee = new EmployeeRatingDto
                            {
                                EmployeeName = s.EmployeeName,
                                OfficesName = s.OfficeName,
                                EmployeeId = s.SEmployeesId,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Employee.EmployeeId == employeeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingEmployeesAlls.AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SEmployeesId == employeeId)
                                .Select(s => new EmployeeRatingDto
                                {
                                    EmployeeName = s.EmployeeName,
                                    OfficesName = s.OfficeName,
                                    EmployeeId = s.SEmployeesId,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {

                            var topPositionPrev = await _context.DRatingEmployeesAlls.AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new EmployeeRatingDto
                                    {
                                        EmployeeName = s.EmployeeName,
                                        OfficesName = s.OfficeName,
                                        EmployeeId = s.SEmployeesId,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Employee = new EmployeeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Employee = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Employee = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                return response;
            }
        }

        public async Task<List<RatingDto>> GetOfficeRatingAsync(IDataTablesRequest? request, int typeId)
        {
            List<RatingDto> response = new List<RatingDto>();
            try
            {
                //var date = DateTime.Now.AddDays(-1);
                var orderColumns = request?.Columns.Where(x => x.Sort != null);
                var officeId = await _employeeManager.GetOfficeAsync();

                if (typeId == 1)
                {
                    var date = await _context.DRatingOfficesDays.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek != DayOfWeek.Sunday);

                    var topFive = await _context.DRatingOfficesDays.AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Office = new OfficeRatingDto
                            {
                                OfficesName = s.OfficeName,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Office.OfficessId == officeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingOfficesDays.AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SOfficesId == officeId)
                                .Select(s => new OfficeRatingDto
                                {
                                    OfficesName = s.OfficeName,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {
                            var topPositionPrev = await _context.DRatingOfficesDays.AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new OfficeRatingDto
                                    {
                                        OfficesName = s.OfficeName,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Office = new OfficeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Office = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Office = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }

                }

                if (typeId == 2)
                {
                    var date = await _context.DRatingOfficesMonths.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek != DayOfWeek.Sunday);

                    var topFive = await _context.DRatingOfficesMonths.AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Office = new OfficeRatingDto
                            {
                                OfficesName = s.OfficesName,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Office.OfficessId == officeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingOfficesMonths.AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SOfficesId == officeId)
                                .Select(s => new OfficeRatingDto
                                {
                                    OfficesName = s.OfficesName,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {
                            var topPositionPrev = await _context.DRatingOfficesMonths.AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new OfficeRatingDto
                                    {
                                        OfficesName = s.OfficesName,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Office = new OfficeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Office = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Office = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }
                }

                if (typeId == 3)
                {
                    var date = await _context.DRatingOfficesYears.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek != DayOfWeek.Sunday);

                    var topFive = await _context.DRatingOfficesYears.AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Office = new OfficeRatingDto
                            {
                                OfficesName = s.OfficesName,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Office.OfficessId == officeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingOfficesYears.AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SOfficesId == officeId)
                                .Select(s => new OfficeRatingDto
                                {
                                    OfficesName = s.OfficesName,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {
                            var topPositionPrev = await _context.DRatingOfficesYears.AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new OfficeRatingDto
                                    {
                                        OfficesName = s.OfficesName,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Office = new OfficeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Office = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Office = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }
                }

                if (typeId == 4)
                {
                    var date = await _context.DRatingOfficesAlls.AsNoTracking()
                        .OrderByDescending(o => o.RatingDate).Select(s => s.RatingDate).FirstOrDefaultAsync(f => f.DayOfWeek != DayOfWeek.Sunday);

                    var topFive = await _context.DRatingOfficesAlls.AsNoTracking()
                        .Where(w => w.RatingDate.Date == date.Date)
                        .OrderByDescending(o => o.RatingValue)
                        .Take(5)
                        .Select(s => new RatingDto
                        {
                            IsSkip = false,
                            Office = new OfficeRatingDto
                            {
                                OfficesName = s.OfficeName,
                                OfficessId = s.SOfficesId,
                                ReceivedCount = s.ReceivedCount,
                                ConsultationCount = s.ConsultationCount,
                                IssuedCount = s.IssuedCount,
                                EmployeePoint = s.RatingValue,
                                PositionId = s.RatingPosition,
                                PositionMovingId = s.RatingMoving
                            }
                        })
                        .ToListAsync();

                    if (topFive.Any(a => a.Office.OfficessId == officeId))
                    {
                        response.AddRange(topFive);
                    }
                    else
                    {
                        var topCurrentPosition = await _context.DRatingOfficesAlls.AsNoTracking()
                                .Where(w => w.RatingDate.Date == date.Date && w.SOfficesId == officeId)
                                .Select(s => new OfficeRatingDto
                                {
                                    OfficesName = s.OfficeName,
                                    OfficessId = s.SOfficesId,
                                    ReceivedCount = s.ReceivedCount,
                                    ConsultationCount = s.ConsultationCount,
                                    IssuedCount = s.IssuedCount,
                                    EmployeePoint = s.RatingValue,
                                    PositionId = s.RatingPosition,
                                    PositionMovingId = s.RatingMoving
                                }).FirstOrDefaultAsync();

                        if (topCurrentPosition != null)
                        {
                            var topPositionPrev = await _context.DRatingOfficesAlls.AsNoTracking()
                                    .Where(w => w.RatingDate.Date == date.Date && w.RatingPosition == topCurrentPosition.PositionId - 1)
                                    .Select(s => new OfficeRatingDto
                                    {
                                        OfficesName = s.OfficeName,
                                        OfficessId = s.SOfficesId,
                                        ReceivedCount = s.ReceivedCount,
                                        ConsultationCount = s.ConsultationCount,
                                        IssuedCount = s.IssuedCount,
                                        EmployeePoint = s.RatingValue,
                                        PositionId = s.RatingPosition,
                                        PositionMovingId = s.RatingMoving
                                    }).FirstOrDefaultAsync();

                            topFive.RemoveRange(3, 2);
                            topFive.Add(new RatingDto { IsSkip = true, Office = new OfficeRatingDto() });
                            if (topPositionPrev != null) topFive.Add(new RatingDto { IsSkip = false, Office = topPositionPrev });
                            topFive.Add(new RatingDto { IsSkip = false, Office = topCurrentPosition });
                        }

                        response.AddRange(topFive);
                    }
                }

                return response;
            }
            catch (Exception e)
            {
                return response;
            }
        }


        public async Task<List<EmployeeRatingDto>> GetEmployeeRatingAsync(IDataTablesRequest? request, bool isAll)
        {
            List<EmployeeRatingDto> response = new List<EmployeeRatingDto>();
            try
            {
                var date = DateTime.Now.AddDays(-1);
                int i = 1;
                List<int> indicators = new List<int>() { 1, 25, 29 };

                var orderColumns = request?.Columns.Where(x => x.Sort != null);

                var data = _context.DIndicatorsValues
                        .AsNoTracking()
                        .Where(w => w.Month == date.Month && w.Year == date.Year
                                && indicators.Contains(w.SIndicatorsId)
                            )
                    .Join(_context.SEmployees, indicators => indicators.SEmployeesId, b => b.Id, (indicators, b) => new { indicators.SEmployeesId, indicators.SOfficesId, indicators.SIndicatorsId, indicators.IndicatorValue, b.EmployeeName })
                    .Join(_context.SOffices, c => c.SOfficesId, d => d.Id, (c, d) => new { c.SEmployeesId, c.SOfficesId, c.SIndicatorsId, c.IndicatorValue, c.EmployeeName, d.OfficeNameSmall })
                    .GroupBy(g => g.SEmployeesId)
                    .Select(s => new EmployeeRatingDto
                    {
                        EmployeeId = s.Key.Value,
                        EmployeeName = s.First().EmployeeName,
                        OfficesName = s.First().OfficeNameSmall,
                        OfficessId = s.First().SOfficesId.Value,
                        EmployeePoint = (int)s.Sum(s => s.IndicatorValue),
                        ReceivedCount = (int)s.Where(w => w.SIndicatorsId == 1).Sum(s => s.IndicatorValue),
                        IssuedCount = (int)s.Where(w => w.SIndicatorsId == 29).Sum(s => s.IndicatorValue),
                        ConsultationCount = (int)s.Where(w => w.SIndicatorsId == 25).Sum(s => s.IndicatorValue),
                    })
                    .OrderByDescending(o => o.EmployeePoint);


                if (isAll == false)
                {
                    response = await data.Take(10).ToListAsync();
                }
                else
                {
                    response = await data.ToListAsync();
                }

                response.ForEach(f => f.PositionId = i++);

                if (request != null)
                {
                    Guid? office = null;
                    var MfcIdColumn = request?.Columns?.Where(w => w.Name == "mfc").Select(s => s.Search.Value).FirstOrDefault();
                    if (MfcIdColumn != null) office = new Guid(MfcIdColumn);

                    if (office != null)
                    {
                        response.RemoveAll(r => r.OfficessId != office.Value);
                    }

                    if (string.IsNullOrEmpty(request.Search.Value) == false) response.RemoveAll(x => !x.EmployeeName.Contains(request.Search.Value, StringComparison.OrdinalIgnoreCase));
                }

                if (orderColumns != null)
                {
                    return response.AsQueryable().OrderByColums(orderColumns).ToList();
                }
                else
                {
                    return response;
                }
            }
            catch (Exception ex)
            {
                return response;
            }
        }


        public async Task<List<EmployeeNotesDto>> GetNotesListAsync()
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();
                string? applicantName = null;
                List<EmployeeNotesDto> notesEmployee = new();
                var notes = await _context.DNotes.Where(w => w.SEmployeesId == userId).OrderByDescending(o => o.DateAdd).ToListAsync();
                var isView = false;

                if (notes.Any())
                {
                    foreach (var note in notes)
                    {
                        if (note.DCasesId is not null)
                        {
                            applicantName = await _context.DCases.AsNoTracking().Where(w => w.Id == note.DCasesId)
                                .Select(s => s.DServicesCustomersLegals.Count != 0 ? s.DServicesCustomersLegals.First().CustomerName : s.DServicesCustomers.First(f => f.CustomerType == (int)CustomerType.Applicant).Fio())
                                .FirstOrDefaultAsync();
                        }
                        notesEmployee.Add(new EmployeeNotesDto
                        {
                            Id = note.Id,
                            ApplicantName = applicantName ?? string.Empty,
                            DateAdd = note.DateAdd,
                            DateReminder = note.DateReminder,
                            DCasesId = note.DCasesId ?? string.Empty,
                            NoteText = note.NoteText,
                            IsViewed = note.IsViewed
                        });

                        if (!note.DateReminder.HasValue || note.DateReminder.Value != DateTime.Now) continue;
                        note.IsViewed = true;
                        isView = true;
                        _context.Update(note);
                    }

                    if (isView) await _context.SaveChangesAsync();
                }
                return notesEmployee;
            }
            catch (Exception ex)
            {
                return new List<EmployeeNotesDto>();
            }
        }

        public async Task<(List<EmployeeNotesDto>, int, int)> GetEmployeeNotesAsync(IDataTablesRequest? request)
        {
            try
            {
                var userId = await _employeeManager.GetIdAsync();
                string? applicantName = null;
                List<EmployeeNotesDto> notesEmployee = new();
                var isView = false;
                var data = _context.DNotes.Where(w => w.SEmployeesId == userId);

                var dataCount = await data.CountAsync();

                var notes = await data.OrderByDescending(o => o.DateAdd).Skip(request.Start).Take(request.Length).ToListAsync();

                if (notes.Any())
                {
                    foreach (var note in notes)
                    {
                        if (note.DCasesId is not null)
                        {
                            applicantName = await _context.DCases.AsNoTracking().Where(w => w.Id == note.DCasesId)
                                .Select(s => s.DServicesCustomersLegals.Count != 0 ? s.DServicesCustomersLegals.First().CustomerName : s.DServicesCustomers.First(f => f.CustomerType == (int)CustomerType.Applicant).Fio())
                                .FirstOrDefaultAsync();
                        }
                        notesEmployee.Add(new EmployeeNotesDto
                        {
                            Id = note.Id,
                            ApplicantName = applicantName ?? string.Empty,
                            DateAdd = note.DateAdd,
                            DateReminder = note.DateReminder,
                            DCasesId = note.DCasesId ?? string.Empty,
                            NoteText = note.NoteText,
                            IsViewed = note.IsViewed
                        });

                        if (!note.DateReminder.HasValue || note.DateReminder.Value != DateTime.Now) continue;
                        note.IsViewed = true;
                        isView = true;
                        _context.Update(note);
                    }

                    if (isView) await _context.SaveChangesAsync();
                }
                return (notesEmployee, dataCount, dataCount);
            }
            catch
            {
                return (new List<EmployeeNotesDto>(), 0, 0);
            }
        }

    }
}
