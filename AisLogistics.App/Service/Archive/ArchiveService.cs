using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.Archive;
using AisLogistics.DataLayer.Concrete;
using Clave.Expressionify;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NinjaNye.SearchExtensions;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public class ArchiveService : IArchiveService
    {
        private readonly IFtpService _ftpService;
        private readonly AisLogisticsContext _context;

        public ArchiveService(AisLogisticsContext context, IFtpService ftpService)
        {
            _ftpService = ftpService;
            _context = context;
        }

        /// <summary>
        /// Список обращений
        /// </summary>
        /// <param name="searchData">данные для поиска</param>
        /// <param name="start">skip</param>
        /// <param name="length">take</param>
        /// <returns></returns>
        public (List<CasesDto> Cases, int Count, int FilteredCount) GetCases(SearchArchiveCasesRequestData searchData, int start, int length)
        {
            var date = DateTime.Today;

            var cases = _context.ACases
                .AsNoTracking()
                .AsSplitQuery()
                .Expressionify();

            if (!string.IsNullOrWhiteSpace(searchData.CustomerNameLegal))
            {
                cases = cases.Where(w => w.SServicesCustomerTypeId != 1912196).Search(s => s.CustomerName.ToLower()).Containing(searchData.CustomerNameLegal.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchData.CustomerName))
            {
                cases = cases.Where(w => w.SServicesCustomerTypeId == 1912196).Search(s => s.CustomerName.ToLower()).Containing(searchData.CustomerName.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchData.Serial))
            {
                cases = cases.Search(s => s.DocumentSerial.ToLower()).Containing(searchData.Serial.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchData.Number))
            {
                cases = cases.Search(s => s.DocumentNumber.ToLower()).Containing(searchData.Number.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchData.Phone))
            {
                cases = cases.Search(s => s.CustomerPhone1.ToLower(),
                                     s => s.CustomerPhone2.ToLower()).ContainingAll(searchData.Phone.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchData.Inn))
            {
                cases = cases.Search(s => s.CustomerInn.ToLower()).Containing(searchData.Inn.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchData.Snils))
            {
                cases = cases.Search(s => s.CustomerSnils.ToLower()).Containing(searchData.Snils.ToLower());
            }


            /*.Include(i => i.ACases.AServicesRoutesStages)
            .ThenInclude(i => i.SEmployees)
            .Include(i => i.ACases.AServices.Where(f => f.AServicesIdParent == Guid.Empty))
            .ThenInclude(i => i.SServicesStatus)
            .Include(i => i.ACases.AServices.Where(f => f.AServicesIdParent == Guid.Empty))
            .ThenInclude(i => i.SEmployeesIdAddNavigation)
            .Where(w => (string.IsNullOrWhiteSpace(searchData.LastName) || w.LastName.ToLower() == searchData.LastName.ToLower()) &&
                        (string.IsNullOrWhiteSpace(searchData.FirstName) || w.FirstName.ToLower() == searchData.FirstName.ToLower()) &&
                        (string.IsNullOrWhiteSpace(searchData.SecondName) || w.SecondName.ToLower() == searchData.SecondName.ToLower()) &&
                        (string.IsNullOrWhiteSpace(searchData.Phone) || w.CustomerPhone1 == searchData.Phone) &&
                        (string.IsNullOrWhiteSpace(searchData.Serial) || w.DocumentSerial == searchData.Serial) &&
                        (string.IsNullOrWhiteSpace(searchData.Number) || w.DocumentNumber == searchData.Number)) ;*/

            var casesCount = cases.Count();

            var dataPage = cases.OrderByDescending(o => o.DateAdd).Skip(start).Take(length)
                .Select(s => new CasesDto
                {
                    archiveCasesMainDto = new ArchiveCasesMainDto
                    {
                        CaseId = s.Id,
                        DateAdd = s.DateAdd.ToShortDateString(),
                        Applicant = new ApplicantDto(s.CustomerName, s.CustomerAddress, s.CustomerPhone1),
                        ServiceName = s.ServiceName,
                        ProviderName = s.OfficeNameProvider,
                        StageName = s.AServicesRoutesStages.Where(w => w.AServicesIdParent == Guid.Empty).OrderByDescending(o => o.DateAdd).Select(s => s.SRoutesStage.StageName).First(),
                        StatusId = s.SServicesStatusId,
                        StatusName = s.StatusName,
                        EmployeeNameAdd = s.EmployeeNameAdd,
                        EmployeeNameExecution = s.EmployeeNameExecution,
                    },
                    /*Service = s.AServices
                        .Select(ss => new CaseServiceDto
                        {
                            Id = ss.Id,
                            Name = ss.SServices.ServiceName,
                            Office = ss.SServices.SOffice.OfficeNameSmall,
                            EmployeeAdd = new EmployeeDto(ss.SEmployeesIdAddNavigation.Id,
                                    NameSplitter.GetInitials(ss.SEmployeesIdAddNavigation.EmployeeName),
                                    ss.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                            Status = new StatusDto(ss.SServicesStatusId, ss.SServicesStatus.StatusName),
                            SerivesStage = ss.AServicesRoutesStages.OrderByDescending(o => o.DateAdd).Select(sss =>
                                        new SerivesStageDto
                                        {
                                            EmployeeCurrent = new EmployeeDto(sss.SEmployeesId, NameSplitter.GetInitials(sss.SEmployees.EmployeeName), sss.SEmployeesJobPosition.JobPositionName),
                                            Stage = new StageDto(sss.SRoutesStageId, sss.SRoutesStage.StageName),
                                            Office = sss.SEmployees.SEmployeesOfficesJoins.Where(w => w.DateStart < date && (w.DateStop == null || w.DateStop > date) && !w.IsRemove).Select(s => s.SOffices.OfficeName).First(),
                                            Days = sss.DateReg.HasValue ? sss.DateReg.Value.Subtract(date).Days : null
                                        }).First(),
                        }
                        ).FirstOrDefault()*/
                }).AsParallel().ToList();

            return (dataPage, casesCount, casesCount);
        }

        /// <summary>
        /// Обращение по id 
        /// </summary>
        /// <param name="id">id услуги</param>
        /// <returns></returns>
        public async Task<ArchiveCaseDetailsDto> GetCaseDetailsByIdAsync(string id)
        {
            try
            {
                /*await _context.SEmployeesJobPositions.LoadAsync();*/

                var caseDto = await _context.ACases
                    .AsNoTracking()
                    .AsSplitQuery()
                    .Select(s => new ArchiveCaseDetailsDto
                    {
                        CaseId = s.Id,
                        Info = s.AServices.Select(ss => new ArchiveCaseServiceInfoDto
                        {
                            Name = ss.SServices.ServiceName,
                            Office = ss.SServices.SOffice.OfficeNameSmall,
                            DateAdd = ss.DateAdd,
                            Status = new StatusDto(ss.SServicesStatusId, ss.SServicesStatus.StatusName),
                            IsRoot = ss.AServicesIdParent == Guid.Empty
                        }).First(f => f.IsRoot),
                        //Customers = s.AServicesCustomers.Select(ss => new ApplicantAdditionalDto()
                        //{
                        //    Id = ss.Id,
                        //}).Concat(s.AServicesCustomersLegals.ToList().Select(ss => new ApplicantAdditionalDto()
                        //{
                        //    Id = ss.Id,
                        //})),
                        //Customers = s.AServicesCustomers.Select(ss => new
                        //{
                        //    Id = ss.Id,
                        //    CasesId = ss.ACasesId,
                        //    Name = ss.Fio(),
                        //    FirstName = ss.FirstName,
                        //        LastName = ss.LastName,
                        //        SecondName = ss.SecondName,
                        //    BirthDate = ss.DocumentBirthDate,
                        //    Address = ss.CustomerAddress,
                        //    Phone = ss.CustomerPhone1,
                        //    Type = (CustomerType)ss.CustomerType,
                        //    SubjectCustomerType = SubjectCustomerType.Physical
                        //}).Join(s.AServicesCustomersLegals.Select(ss => new
                        //    {
                        //    Id = ss.Id,
                        //    CasesId = ss.ACasesId,
                        //    Name = ss.CustomerName,
                        //    FirstName = ss.HeadFirstName,
                        //    LastName = ss.HeadLastName,
                        //    SecondName = ss.HeadSecondName,
                        //    Address = ss.CustomerAddress,
                        //    Phone = ss.CustomerPhone1,
                        //    Type = CustomerType.Representative,
                        //    SubjectCustomerType = SubjectCustomerType.Legal
                        //}),
                        //    legal => legal.CasesId,
                        //    customer => customer.CasesId,
                        //    (customer, legal) => new ApplicantAdditionalDto
                        //    {
                        //        Id = customer.Id,

                        //    }),
                        Customers = s.AServicesCustomersLegals.Count == 0 ? s.AServicesCustomers.Select(ss => new ApplicantAdditionalDto
                        {
                            Id = ss.Id,
                            Name = ss.Fio(),
                            Gender = ss.CustomerGender,
                            BirthDate = ss.DocumentBirthDate,
                            Address = ss.CustomerAddress,
                            Phone = ss.CustomerPhone1,
                            Type = (CustomerType)ss.CustomerType,
                            SubjectCustomerType = SubjectCustomerType.Physical
                        }) :
                        s.AServicesCustomersLegals.Select(ss => new ApplicantAdditionalDto
                        {
                            Id = ss.Id,
                            Name = ss.CustomerName,
                            //Gender = ss.CustomerGender,
                            //BirthDate = ss.DocumentBirthDate,
                            Address = ss.CustomerAddress,
                            Phone = ss.CustomerPhone1,
                            //Type = (CustomerType)ss.CustomerType,
                            SubjectCustomerType = SubjectCustomerType.Legal
                        }),
                        /* Customers = s.AServicesCustomers.Select(ss => new ApplicantAdditionalDto
                         {
                             Id = ss.Id,
                             Name = ss.Fio(),
                             Gender = ss.CustomerGender,
                             BirthDate = ss.DocumentBirthDate,
                             Address = ss.CustomerAddress,
                             Phone = ss.CustomerPhone1,
                             Type = (CustomerType)ss.CustomerType,
                             SubjectCustomerType = SubjectCustomerType.Physical
                         }),*/
                        Documents = s.AServicesDocuments.Where(w => w.AServicesFiles.Any())
                            .SelectMany(sm => sm.AServicesFiles, (document, file) => new ArchiveCaseServiceDocumentsDto
                            {
                                Id = file.Id,
                                DocumentName = document.SDocuments.DocumentName,
                                DocumentId = document.SDocumentsId,
                                Name = file.FileName,
                                Extension = file.FileExtention,
                                Size = file.FileSize,
                                DateAdd = file.DateAdd,
                                EmployeeAdd = new EmployeeDto(file.SEmployeesId,
                                    NameSplitter.GetInitials(file.EmployeesFioAdd),
                                    file.SEmployeesJobPosition.JobPositionName)
                            }),
                        Results = s.AServicesDocumentsResults.Where(w => w.AServicesFileResults.Any())
                            .SelectMany(sm => sm.AServicesFileResults, (document, file) =>
                                new ArchiveCaseServiceDocumentsDto
                                {
                                    Id = file.Id,
                                    DocumentName = document.SDocuments.DocumentName,
                                    DocumentId = document.SDocumentsId,
                                    Name = file.FileName,
                                    Extension = file.FileExtention,
                                    Size = file.FileSize,
                                    DateAdd = file.DateAdd,
                                    EmployeeAdd = new EmployeeDto(file.SEmployeesId,
                                        NameSplitter.GetInitials(file.EmployeesFioAdd),
                                        file.SEmployeesJobPosition.JobPositionName)
                                }),
                        Smev = s.AServicesSmevRequests.Select(ss => new CaseServiceSmevСompletedDto
                        {
                            Id = ss.Id,
                            Name = ss.SSmevRequest.RequestName,
                            Provider = ss.SSmevRequest.SSmev.SmevProvider,
                            DateCreate = ss.DateRequest.Value,
                            DateResponse = ss.DateFact.HasValue ? ss.DateFact.Value : ss.DateReg.Value,
                            Status = ss.SmevStatus(),
                            EmployeeAdd = new EmployeeDto(ss.SEmployeesId, NameSplitter.GetInitials(ss.EmployeesFioAdd),
                                ss.SEmployeesJobPosition.JobPositionName),
                            Description = ss.Commentt
                        }),
                        Comments = s.AServicesCommentts.Select(ss => new CaseCommentsDto
                        {
                            Id = ss.Id,
                            Comment = ss.Commentt,
                            DateAdd = ss.DateAdd,
                            EmployeeAdd = new EmployeeDto(ss.SEmployeesId,
                                NameSplitter.GetInitials(ss.SEmployees.EmployeeName),
                                ss.SEmployeesJobPosition.JobPositionName)
                        }),
                        Stages = s.AServicesRoutesStages.OrderBy(o => o.DateAdd).Select(ss => new CaseServiceStageDto
                        {
                            Id = ss.Id,
                            Name = ss.SRoutesStage.StageName,
                            Days = ss.DateReg.HasValue
                                ? ss.DateFact.HasValue
                                    ? ss.DateReg.Value.Day - ss.DateFact.Value.Day
                                    : ss.DateReg.Value.Day - DateTime.Now.Day
                                : null,
                            EmployeeCurrent = new EmployeeDto(ss.SEmployeesId,
                                NameSplitter.GetInitials(ss.SEmployees.EmployeeName),
                                ss.SEmployeesJobPosition.JobPositionName),
                            EmployeeAdd = new EmployeeDto(ss.SEmployeesIdAdd, NameSplitter.GetInitials(ss.EmployeesFioAdd),
                                ss.SEmployeesJobPositionIdAddNavigation.JobPositionName),
                            DateAdd = s.DateAdd,
                            DateReg = ss.DateReg,
                            DateFact = ss.DateFact,
                            IsAutomaticallyTransferred = ss.PassAutomatically
                        }),
                        Audits = s.AServicesAudits.Select(ss => new CaseAuditDto
                        {
                            Changed = JsonConvert.DeserializeObject<ChangedAudit>(ss.Changed),
                            DateAdd = s.DateAdd,
                            Employee = new EmployeeDto(ss.SEmployeesId, ss.SEmployees.EmployeeName,
                                ss.SEmployeesJobPosition.JobPositionName)
                        })
                    })
                    .FirstAsync(f => f.CaseId == id);

                return caseDto;
            }
            catch
            {
                return new ArchiveCaseDetailsDto();
            }
        }

        public async Task<FormFile?> DownloadServicesFileAsync(Guid id, DocumentType type)
        {
            dynamic serviceFile = type switch
            {
                DocumentType.ServiceDocument => await _context.AServicesFiles.Include(i => i.SFtp).SingleAsync(s => s.Id == id),
                DocumentType.ServiceDocumentResult => await _context.AServicesFileResults.Include(i => i.SFtp).SingleAsync(s => s.Id == id),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            var ftp = new FtpSettingsModel
            {
                Server = serviceFile.SFtp.FtpServer,
                Login = serviceFile.SFtp.FtpLogin,
                Password = serviceFile.SFtp.FtpPassword
            };

            var bytes = await _ftpService.DownloadFileAsync(
                $"{serviceFile.ACasesId}/{serviceFile.Id}{serviceFile.FileExtention}", ftp);

            if (bytes is null) return null;

            var file = new FormFile(new MemoryStream(bytes), 0, serviceFile.FileSize,
                $"{serviceFile.FileName}{serviceFile.FileExtention}",
                $"{serviceFile.FileName}{serviceFile.FileExtention}")
            {
                Headers = new HeaderDictionary(),
                ContentType = MimeTypes.GetMimeType($"{serviceFile.FileName}{serviceFile.FileExtention}")
            };
            return file;
        }

        public async Task<List<CaseServiceBlank>> GetServiceBlanksByCaseIdAsync(string id)
        {
            return await _context.DServices
                .Where(f => f.DCasesId == id)
                .SelectMany(s => s.SServices.SServicesFiles.Where(w =>
                        w.IsRemove == false),
                    (dService, join) => new CaseServiceBlank
                    {
                        Id = join.Id,
                        ServiceId = dService.Id,
                        Name = join.FileName,
                        Expansion = join.FileExpansion,
                        Comment = join.Commentt
                    }).ToListAsync();
        }

        public async Task<CaseServiceBlankFile> GetServiceBlankFileByIdAsync(Guid id)
        {
            var file = await _context.SServicesFiles.FindAsync(id);
            if (file is null) throw new ArgumentException(nameof(file));

            return new CaseServiceBlankFile
            {
                Id = file.Id,
                Name = file.FileName,
                Expansion = file.FileExpansion,
                Content = file.File,
                Size = file.FileSize
            };
        }
    }
}