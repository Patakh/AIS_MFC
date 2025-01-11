using AisLogistics.App.Extensions;
using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.Cases;
using AisLogistics.App.Models.DTO.Services;
using AisLogistics.App.Service.MDM;
using AisLogistics.App.Utils;
using AisLogistics.App.ViewModels.Cases;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using AisLogistics.DataLayer.Utils;
using AutoMapper;
using Clave.Expressionify;
using FluentFTP;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NinjaNye.SearchExtensions;
using NuGet.Packaging;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace AisLogistics.App.Service
{
    public partial class CaseService : ICaseService
    {
        private readonly IFtpService _ftpService;
        private readonly IMdmService _mdmService;
        private readonly IMapper _mapper;
        private readonly AisLogisticsContext _context;
        private readonly IEmployeeManager _employeeManager;
        private readonly IConfiguration _configuration;


        public CaseService(AisLogisticsContext context, IEmployeeManager employeeManager, 
            IFtpService ftpService, IMdmService mdmService, IMapper mapper, IConfiguration configuration)
        {
            _ftpService = ftpService;
            _context = context;
            _employeeManager = employeeManager;
            _mdmService = mdmService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task SetCaseFavoriteAsync(string id)
        {
            var userId = await _employeeManager.GetIdAsync();
            await _context.DCasesFavorites.AddAsync(new DCasesFavorite()
            {
                DCasesId = id,
                SEmployeesId = userId.Value
            });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveCaseFavoriteAsync(string id)
        {
            var userId = await _employeeManager.GetIdAsync();
            await _context.DCasesFavorites.Where(w => w.DCasesId == id && w.SEmployeesId == userId.Value).DeleteAsync();
        }
        public async Task SetServiceFavoriteAsync(Guid id)
        {
            var userId = await _employeeManager.GetIdAsync();
            await _context.DEmployeesServicesFavorites.AddAsync(new DEmployeesServicesFavorite()
            {
                SServicesId = id,
                SEmployeesId = userId.Value
            });
            await _context.SaveChangesAsync();
        }

        public async Task RemoveServiceFavoriteAsync(Guid id)
        {
            var userId = await _employeeManager.GetIdAsync();
            await _context.DEmployeesServicesFavorites.Where(w => w.SServicesId == id && w.SEmployeesId == userId.Value).DeleteAsync();
        }

        /// <summary>
        /// Список выполненных СМЭВ запросов по id услуги
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <returns></returns>
        public async Task<List<CaseServiceSmevСompletedDto>> GetSmevСompletedByServiceIdAsync(Guid id)
        {
            try
            {
                return await _context.DServicesSmevRequests
                .AsNoTracking()
                .Where(w => w.DServicesId == id)
                .OrderByDescending(o => o.DateAdd)
                .Select(s => new CaseServiceSmevСompletedDto
                {
                    Id = s.Id,
                    Name = s.SSmevRequest.RequestName,
                    Provider = s.SSmevRequest.SSmev.SmevProvider,
                    DateCreate = s.DateRequest.Value.Add(s.TimeRequest.Value.ToTimeSpan()),
                    DateResponse = s.DateFact.HasValue ? s.DateFact.Value.Add(s.TimeFact.Value.ToTimeSpan()) : s.DateReg,
                    Status = s.SmevStatus(),
                    EmployeeAdd = new EmployeeDto(s.SEmployeesId, NameSplitter.GetInitials(s.EmployeesFioAdd),
                    s.SEmployeesJobPosition.JobPositionName),
                    Description = s.Commentt,
                    Service = new ServiceDto(s.DServicesId, s.DServices.SServices.ServiceNameSmall,
                    s.DServices.SServices.SOffice.OfficeNameSmall)
                }).ToListAsync();
            }
            catch (Exception e)
            {
                return new List<CaseServiceSmevСompletedDto>();
            }

        }

        /// <summary>
        /// Список выполненных платежей по id услуги
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <returns></returns>
        public async Task<List<CaseServicePaymentsСompletedDto>> GetPaymentsСompletedByServiceIdAsync(Guid id)
        {
            try
            {
                return await _context.DAcquirings
                .AsNoTracking()
                .Where(w => w.DServicesId == id)
                .OrderByDescending(o => o.DateAdd)
                .Select(s => new CaseServicePaymentsСompletedDto
                {
                    Id = s.Id,
                    //EmployeeFio = s.SE.employee_fio,
                    //PayerFio = s.Data_services_customers.customer_fio,
                    Status = s.Status,
                    TypePayment = "Гос Пошлина",
                    PaymentMethod = string.IsNullOrEmpty(s.Uin) ? "По реквизитам" : "По УИН",
                    Summa = s.Summ,
                    DateAdd = s.DateAdd,
                    //DatePayment = s.Data_acquirings_checks.FirstOrDefault().operation_time
                }).OrderByDescending(o => o.DateAdd).ToListAsync();
            }
            catch (Exception e)
            {
                return new List<CaseServicePaymentsСompletedDto>();
            }

        }

        /// <summary>
        /// Список выполненных платежей по id услуги
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <returns></returns>
        public async Task<ServicePaymentsInfo?> GetPaymentsInfoServiceIdAsync(Guid id)
        {
            try
            {
                return await _context.DServices
                .AsNoTracking()
                .Where(w => w.Id == id)
                .Select(s => new ServicePaymentsInfo
                {
                    DServicesId = s.Id,
                    DCaseId = s.DCasesId,
                    SOfficesIdProvider = s.SOfficesIdProvider,
                    ServiceName = s.SServices.ServiceName,
                    TariffState = s.TariffState,
                    TariffMfc = s.TariffMfc
                }).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Список выполненных платежей по id услуги
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <returns></returns>
        public async Task<Guid?> AddServicePaymentAsync(ServicePaymentsRequestModelAddDto request)
        {
            return null;
            try
            {
                DAcquiring model = new DAcquiring
                {
                    DCasesId = request.DCasesId,
                    DServicesId = request.DServicesId,
                    DServicesCustomersId = request.DServicesCustomersId,
                    SRecipientPaymentId = request.SRecipientPaymentId,
                    Summ = request.Summ,
                    TypePaymet = request.TypePaymet,
                    IsMirCard = request.IsMirCard,
                    Uin = request.Uin,
                    IpWindow = request.IpWindow,
                    SEmployeesId = request.SEmployeesId,
                    SOfficesId = request.SOfficesId,
                    DateAdd = DateTime.Now
                };

                await _context.DAcquirings.AddAsync(model);
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Список выполненных платежей по id услуги
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <returns></returns>
        public bool IsCheckServicePaymentAsync(Guid Id)
        {
            try
            {
                bool? isChecks = null;

                var dAcquiring = new DAcquiring();

                for (int i = 0; i < 10; i++)
                {
                    dAcquiring = _context.DAcquirings.Find(Id);

                    if (dAcquiring.Status == "FAILED" || dAcquiring.Status == "UNKNOWN")
                    {
                        isChecks = true;
                        break;
                    }

                    if (dAcquiring.Stage == 7 && dAcquiring.Status == "SUCCESS")
                    {
                        isChecks = false;
                        break;
                    }
                    Thread.Sleep(3000);
                }

                if (isChecks == null || isChecks == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Список возможных СМЭВ запросов, для добавления нового запроса в услугу
        /// </summary>
        /// <param name="id">Id услуги</param>
        /// <param name="search">строка поиска</param>
        /// <param name="start">skip</param>
        /// <param name="length">take</param>
        /// <param name="smevCount">всего найдено</param>
        /// <param name="smevFilteredCount">отсортировано</param>
        /// <returns></returns>
        public async Task<(List<CaseServiceSmevActiveDto>, int, int)> GetSmevActiveByServiceId(Guid id, string search, int start, int length)
        {
            try
            {
                var smevs = await _context.DServices.Where(w => w.Id == id)
                    .AsNoTracking()
                    .Select(s => s.SServices.SServicesSmevRequestJoins
                        .DefaultIfEmpty()
                        .Where(w => w.SSmevRequest.IsRequestActive != null && w.IsRemove == false && w.SSmevRequest.IsRequestActive.Value)
                        .Select(ss =>
                            new CaseServiceSmevActiveDto
                            {
                                Id = ss.SSmevRequestId,
                                Name = ss.SSmevRequest.RequestName,
                                Description = ss.SSmevRequest.SSmev.SmevDescription,
                                Provider = ss.SSmevRequest.SSmev.SmevProvider,
                                Days = ss.SSmevRequest.CountDayExecution,
                                WeekTypeName = ss.SSmevRequest.SServicesWeek.TypeName,
                                FormPath = ss.SSmevRequest.SmevFormPath(),
                                ActionPath = ss.SSmevRequest.ActionPath
                            })).FirstAsync();

                var smevCount = smevs.Count();

                var filteredData = String.IsNullOrWhiteSpace(search)
                    ? smevs
                    : smevs.Search(s => s.Name.ToLower(),
                            s => s.Provider.ToLower(),
                            s => s.Id.ToString())
                        .Containing(search.Trim().ToLower().Split(" "));

                var smevFilteredCount = filteredData.Count();

                return (filteredData.Skip(start).Take(length).ToList(), smevCount, smevFilteredCount);
            }
            catch
            {
                return (new List<CaseServiceSmevActiveDto>(), 0,0);
            }
        }

        /// <summary>
        /// Поставщики услуги
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns></returns>
        public async Task<List<ActiveServiceProviderDto>> GetServiceProvidersAll()
        {
            return await _context.SOffices
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.SOfficesTypeId != (int)OfficeType.Mfc && w.SOfficesTypeId != (int)OfficeType.Tosp)
                .Select(s => new ActiveServiceProviderDto
                {
                    Id = s.Id,
                    OfficeName = s.OfficeName
                })
                .ToListAsync();
        }

        public async Task<NotesAddDto?> GetServiceNoteAsync(Guid id)
        {
            var entity = await _context.DNotes
            .Select(s => new NotesAddDto
            {
                Id = s.Id,
                DCaseId = s.DCasesId,
                DateReminder = s.DateReminder,
                NotesText = s.NoteText
            }).FirstOrDefaultAsync(f => f.Id == id);

            return entity;
        }

        public async Task<bool> AddServiceNotesAsync(NotesAddSaveDto request)
        {
            try
            {
                await _context.DNotes.AddAsync(new DNote
                {
                    DCasesId = request.DCaseId,
                    DateReminder = request.DateReminder,
                    NoteText = request.NotesText,
                    SEmployeesId = request.EmployeeId
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> EditServiceNotesAsync(NotesAddSaveDto request)
        {
            try
            {
                var entity = await _context.DNotes.FindAsync(request.Id);
                if (entity == null)
                    return false;

                entity.NoteText = request.NotesText;
                entity.DateReminder = request.DateReminder;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteServiceNotesAsync(Guid id)
        {
            try
            {
                var entity = await _context.DNotes.Where(w => w.Id == id).DeleteAsync();
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<List<CaseServiceDocumentsDto>> GetDocumentsByServiceIdAsync(Guid id)
        {
            try
            {
                return await _context.DServicesDocuments
                    .AsNoTracking()
                    .Where(w => w.DServicesId == id)
                    .Select(s => new CaseServiceDocumentsDto
                    {
                        Id = s.Id,
                        CaseId = s.DCasesId,
                        DocumentId = s.SDocumentsId,
                        DocumentName = s.SDocuments.DocumentName,
                        DocumentNeedId = s.DocumentNeeds,
                        DocumentTypeId = s.DocumentType,
                        DocumentCopyCount = s.DocumentCount,
                        IsCheck = s.IsCheck,
                        Commentt = s.Commentt,
                        Files = s.DServicesFiles.DefaultIfEmpty().Select(file => new FileDto
                        {
                            Id = file.Id,
                            Name = file.FileName,
                            Extension = file.FileExtention,
                            Size = file.FileSize,
                            EmployeeAdd = new EmployeeDto(file.SEmployeesId, NameSplitter.GetInitials(file.EmployeesFioAdd),
                                file.SEmployeesJobPosition.JobPositionName),
                            DateAdd = file.DateAdd
                        }).ToList()
                    }).ToListAsync();
            }
            catch(Exception ex)
            {
                return new List<CaseServiceDocumentsDto>();
            }
        }

        public async Task<CaseServiceDocumentsDto?> GetServiceDocumentsIdAsync(Guid id)
        {
            try
            {
                return await _context.DServicesDocuments
                    .AsNoTracking()
                    .Where(w => w.Id == id)
                    .Select(s => new CaseServiceDocumentsDto
                    {
                        Id = s.Id,
                        CaseId = s.DCasesId,
                        DocumentId = s.SDocumentsId,
                        DocumentName = s.SDocuments.DocumentName,
                        DocumentNeedId = s.DocumentNeeds,
                        DocumentTypeId = s.DocumentType,
                        DocumentCopyCount = s.DocumentCount,
                        IsCheck = s.IsCheck,
                        Commentt = s.Commentt
                    }).FirstAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task AddServiceDepartamentAsync(ServiceDepartamentsDto model)
        {
            var entity = await _context.DServices.FindAsync(model.ServiceId);
            if (entity is null) throw new ArgumentException("Данные не найдены");
            var departament = await _context.SOffices.FindAsync(model.DepartamentId);
            if (departament is null) throw new ArgumentException("Отдел не найден");
            entity.SOfficesIdProviderDepartament = departament.Id;
            entity.FrguProviderIdDepartment = departament.OfficeFrguProviderId;
            _context.Update(entity);
            await _context.SaveChangesAsync();            
        }


        public async Task<List<CaseServiceDocumentsDto>> GetDocumentsByServiceIdAsync(string id)
        {
            return await _context.DServicesDocuments
                .AsNoTracking()
                .Where(w => w.DCasesId == id)
                .Select(s => new CaseServiceDocumentsDto
                {
                    Id = s.Id,
                    DocumentId = s.SDocumentsId,
                    DocumentName = s.SDocuments.DocumentName,
                    DocumentNeedId = s.DocumentNeeds,
                    DocumentTypeId = s.DocumentType,
                    DocumentCopyCount = s.DocumentCount,
                    IsCheck = s.IsCheck,
                    CountCopy = s.CountCopy ?? s.CountOriginal.GetValueOrDefault(),
                    CountOriginal = s.CountOriginal ?? s.CountOriginal.GetValueOrDefault()
                })
                .ToListAsync();
        }

        public async Task<List<CaseServiceDocumentsDto>> GetDocumentsIssuanceByServiceIdAsync(string id)
        {
            List<CaseServiceDocumentsDto> documents = new();

            documents.AddRange(await _context.DServicesDocuments
                .AsNoTracking()
                .Where(w => w.DCasesId == id&& w.IsCheck)
                .Select(s => new CaseServiceDocumentsDto
                {
                    Id = s.Id,
                    DocumentName = s.SDocuments.DocumentName,
                    IsCheck = s.IsIssued,
                    CountCopy = s.CountCopy ?? s.CountCopy.GetValueOrDefault(),
                    CountOriginal = s.CountOriginal ?? s.CountOriginal.GetValueOrDefault()
                })
                .ToListAsync());

            documents.AddRange(await _context.DServicesDocumentsResults
                .AsNoTracking()
                .Where(w => w.DCasesId == id)
                .Select(s => new CaseServiceDocumentsDto
                {
                    Id = s.Id,
                    DocumentName = s.SDocuments.DocumentName,
                    IsCheck = s.IsIssued,
                    CountCopy = s.CountCopy ?? s.CountCopy.GetValueOrDefault(),
                    CountOriginal = s.CountOriginal ?? s.CountOriginal.GetValueOrDefault()
                })
                .ToListAsync());

            return documents;
        }


        public async Task<List<CaseServiceDocumentsResultsDto>> GetDocumentsResultsByServiceIdAsync(Guid id)
        {
            return await _context.DServicesDocumentsResults
                .AsNoTracking()
                .Where(w => w.DServicesId == id)
                .Select(s => new CaseServiceDocumentsResultsDto
                {
                    Id = s.Id,
                    DocumentId = s.SDocumentsId,
                    DocumentName = s.SDocuments.DocumentName,
                    Method = s.DocumentMethod,
                    PeriodMfc = s.DocumentPeriodMfc,
                    PeriodProvider = s.DocumentPeriodProvider,
                    Result = s.DocumentResult,
                    Files = s.DServicesFileResults.DefaultIfEmpty().Select(file => new FileDto
                    {
                        Id = file.Id,
                        Name = file.FileName,
                        Extension = file.FileExtention,
                        Size = file.FileSize,
                        EmployeeAdd = new EmployeeDto(file.SEmployeesId, NameSplitter.GetInitials(file.EmployeesFioAdd),
                            file.SEmployeesJobPosition.JobPositionName),
                        DateAdd = file.DateAdd
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<bool> UploadServicesDocumentsIsCheckAsync(Guid id, bool isCheck)
        {
            try
            {
                var document = await _context.DServicesDocuments.FindAsync(id);
                if (document == null) return false;

                document.IsCheck = isCheck;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UploadServicesDocumentsIsCheckAsync(List<DocumentsPrintDto> doc)
        {
            try
            {
                var listId = doc.Select(s => s.Id).ToList();

                var documents = await _context.DServicesDocuments.Where(w => listId.Contains(w.Id)).ToListAsync();

                var d = new DocumentsPrintDto();

                documents.ForEach(f =>
                {
                    d = doc.First(x => f.Id == x.Id);
                    f.IsCheck = d.IsChecked;
                    f.CountCopy = d.CountCopy;
                    f.CountOriginal = d.CountOriginal;
                });

                _context.UpdateRange(documents);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> UploadServicesDocumentsIssuanceIsCheckAsync(List<DocumentsPrintDto> doc)
        {
            try
            {
                var listId = doc.Select(s => s.Id).ToList();

                var documents = await _context.DServicesDocuments.Where(w => listId.Contains(w.Id)).ToListAsync();

                var d = new DocumentsPrintDto();

                documents.ForEach(f =>
                {
                    d = doc.First(x => f.Id == x.Id);
                    f.IsIssued = doc.First(x => f.Id == x.Id).IsChecked;
                    f.CountCopy = d.CountCopy;
                    f.CountOriginal = d.CountOriginal;
                });

                var documentsResult = await _context.DServicesDocumentsResults.Where(w => listId.Contains(w.Id)).ToListAsync();

                documentsResult.ForEach(f =>
                {
                    d = doc.First(x => f.Id == x.Id);
                    f.IsIssued = d.IsChecked;
                    f.CountCopy = d.CountCopy;
                    f.CountOriginal = d.CountOriginal;
                });

                _context.UpdateRange(documents);
                _context.UpdateRange(documentsResult);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public async Task<ServiceFileResponseModel> UploadServicesFileAsync(Guid id, DocumentFileAddType fileAddType, IFormFile file)
        {
            var response = new ServiceFileResponseModel().SetFileId(Guid.NewGuid());
            var employee = await _employeeManager.GetFullInfoAsync();
            var document = await _context.DServicesDocuments.AsNoTracking().Select(s => new
            {
                s.Id,
                s.DCasesId,
                s.SDocumentsId,
                s.DServicesId,
                s.DServices.DServicesIdParent
            }).SingleOrDefaultAsync(sd => sd.Id == id);

            if (document is null)
                return response.Error("Документ не найден").Build();

            var officeFtp =await _employeeManager.GetFtpAsync();

            if (officeFtp is null)
                return response.Error("ФТП сервер не настроен").Build();

            if (await _ftpService.UploadFileAsync(file,
                    $"{document.DCasesId}/{response.Id}{Path.GetExtension(file.FileName)}", officeFtp) == FtpStatus.Failed)
                return response.Error("Не удалось загрузить файл на ФТП").Build();

            var newFile = new DServicesFile
            {
                Id = response.Id,
                DServicesDocumentsId = document.Id,
                DCasesId = document.DCasesId,
                SFtpId = officeFtp.Id,
                FileName = Path.GetFileNameWithoutExtension(file.FileName),
                FileExtention = Path.GetExtension(file.FileName),
                FileSize = (int)file.Length,
                TypeAddFile = (int)fileAddType,
                DateAdd = DateTime.Now,
                SEmployeesId = employee.Id,
                SOfficesId = employee.Office.Id,
                SEmployeesJobPositionId = employee.Job.Id,
                EmployeesFioAdd = employee.Name
            };
            await _context.DServicesFiles.AddAsync(newFile);
            await _context.SaveChangesAsync();
            return response.Success().Build();
        }

        public async Task<ServiceFileResponseModel> UploadServicesFilesAsync(Guid id, DocumentFileAddType fileAddType, IFormFileCollection files)
        {
            var response = new ServiceFileResponseModel();
            var employee = await _employeeManager.GetFullInfoAsync();
            var document = await _context.DServicesDocuments.AsNoTracking().Select(s => new
            {
                s.Id,
                s.DCasesId,
                s.SDocumentsId,
                s.DServicesId,
                s.DServices.DServicesIdParent
            }).SingleOrDefaultAsync(sd => sd.Id == id);

            if (document is null)
                return response.Error("Документ не найден").Build();

            var officeFtp = await _employeeManager.GetFtpAsync();

            if (officeFtp is null)
                return response.Error("ФТП сервер не настроен").Build();

            foreach (var file in files)
            {
                response.SetFileId(Guid.NewGuid());
                if (await _ftpService.UploadFileAsync(file,
                        $"{document.DCasesId}/{response.Id}{Path.GetExtension(file.FileName)}", officeFtp) == FtpStatus.Failed)
                    return response.Error("Не удалось загрузить файл на ФТП").Build();

                var newFile = new DServicesFile
                {
                    Id = response.Id,
                    DServicesDocumentsId = document.Id,
                    DCasesId = document.DCasesId,
                    SFtpId = officeFtp.Id,
                    FileName = Path.GetFileNameWithoutExtension(file.FileName),
                    FileExtention = Path.GetExtension(file.FileName),
                    FileSize = (int)file.Length,
                    TypeAddFile = (int)fileAddType,
                    DateAdd = DateTime.Now,
                    SEmployeesId = employee.Id,
                    SOfficesId = employee.Office.Id,
                    SEmployeesJobPositionId = employee.Job.Id,
                    EmployeesFioAdd = employee.Name
                };
                await _context.DServicesFiles.AddAsync(newFile);
            }

            await _context.SaveChangesAsync();
            return response.Success().Build();
        }

        public async Task<ServiceFileResponseModel> RemoveServicesFileAsync(Guid id)
        {
            var responseModel = new ServiceFileResponseModel();
            var file = await _context.DServicesFiles.FindAsync(id);
            if (file is null) return responseModel.Error(ErrorDescription.FileNotFound).Build();
            _context.DServicesFiles.Remove(file);
            await _context.SaveChangesAsync();
            return responseModel.Success().Build();
        }

        public async Task<ServiceFileResponseModel> UploadServicesFileResultAsync(Guid id, DocumentFileAddType fileAddType, IFormFile file)
        {
            var response = new ServiceFileResponseModel().SetFileId(Guid.NewGuid());
            var employee = await _employeeManager.GetFullInfoAsync();
            var document = await _context.DServicesDocumentsResults.AsNoTracking().Select(s => new
            {
                s.Id,
                s.DCasesId,
                s.SDocumentsId,
                s.DServicesId,
                s.DServices.DServicesIdParent,
            }).SingleOrDefaultAsync(sd => sd.Id == id);

            if (document is null)
                return response.Error("Документ не найден").Build();

            var officeFtp = await _employeeManager.GetFtpAsync();

            if (officeFtp is null)
                return response.Error("ФТП сервер не настроен").Build();

            if (await _ftpService.UploadFileAsync(file,
                    $"{document.DCasesId}/{response.Id}{Path.GetExtension(file.FileName)}", officeFtp) == FtpStatus.Failed)
                return response.Error("Не удалось загрузить файл на ФТП").Build();

            var newFile = new DServicesFileResult()
            {
                Id = response.Id,
                DServicesDocumentResultId = document.Id,
                DCasesId = document.DCasesId,
                SFtpId = officeFtp.Id,
                FileName = Path.GetFileNameWithoutExtension(file.FileName),
                FileExtention = Path.GetExtension(file.FileName),
                FileSize = (int)file.Length,
                TypeAddFile = (int)fileAddType,
                DateAdd = DateTime.Now,
                SEmployeesId = employee.Id,
                SOfficesId = employee.Office.Id,
                SEmployeesJobPositionId = employee.Job.Id,
                EmployeesFioAdd = employee.Name
            };
            await _context.DServicesFileResults.AddAsync(newFile);
            await _context.SaveChangesAsync();
            return response.Success().Build();
        }

        public async Task<ServiceFileResponseModel> RemoveServicesFileResultAsync(Guid id)
        {
            var responseModel = new ServiceFileResponseModel();
            var file = await _context.DServicesFileResults.FindAsync(id);
            if (file is null) return responseModel.Error(ErrorDescription.FileNotFound).Build();
            _context.DServicesFileResults.Remove(file);
            await _context.SaveChangesAsync();
            return responseModel.Success().Build();
        }

        public async Task DocumentServiceAddSave(List<ServiceDocumentsDto> request)
        {
            var entity = new List<DServicesDocument>();
            request.ForEach(f =>
            {
                entity.Add(new DServicesDocument
                {
                    DCasesId = f.CasesId,
                    DServicesId = f.ServiceId,
                    SDocumentsId = f.DocumentId,
                    DateAdd = f.DateAdd,
                    SEmployeesId = f.SEmployeesId,
                    EmployeesFioAdd = f.EmployeesFioAdd,
                    DocumentNeeds = f.DocumentNeeds,
                    DocumentCount = f.DocumentCount,
                    DocumentType = f.DocumentType,
                    Commentt = f.Commentt
                });
            }); 
            await _context.DServicesDocuments.AddRangeAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DocumentServiceAddSave(ServiceDocumentsDto request)
        {
            var entity = new DServicesDocument
            {
                DCasesId = request.CasesId,
                DServicesId = request.ServiceId,
                SDocumentsId = request.DocumentId,
                DateAdd = request.DateAdd,
                SEmployeesId = request.SEmployeesId,
                EmployeesFioAdd = request.EmployeesFioAdd,
                DocumentNeeds = request.DocumentNeeds,
                DocumentCount = request.DocumentCount,
                DocumentType = request.DocumentType,
                Commentt = request.Commentt
            };
            await _context.DServicesDocuments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DocumentServiceAddNewNameSave(ServiceDocumentNewNameDto request)
        {
            var entity = await _context.DServicesDocuments.FindAsync(request.Id);
            if (entity == null) throw new InvalidOperationException();
            entity.Commentt = request.Commentt;
            await _context.SaveChangesAsync();
        }


        public async Task<FormFile?> DownloadServicesFileAsync(Guid id, Models.DocumentType type)
        {
            FileDownloadDto serviceFile = type switch
            {
                Models.DocumentType.ServiceDocument => await _context.DServicesFiles.AsNoTracking().Select(s=> new FileDownloadDto { Id=s.Id, DcaseId = s.DCasesId, FileName = s.FileName, FileExtention = s.FileExtention, FileSize = s.FileSize, Ftp = new FtpSettingsModel { Login = s.SFtp.FtpLogin, Password = s.SFtp.FtpPassword, Server = s.SFtp.FtpServer } }).SingleAsync(s => s.Id == id),
                Models.DocumentType.ServiceDocumentResult => await _context.DServicesFileResults.AsNoTracking().Select(s => new FileDownloadDto { Id = s.Id, DcaseId = s.DCasesId, FileName = s.FileName, FileExtention = s.FileExtention, FileSize = s.FileSize, Ftp = new FtpSettingsModel { Login = s.SFtp.FtpLogin, Password = s.SFtp.FtpPassword, Server = s.SFtp.FtpServer } }).SingleAsync(s => s.Id == id),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };

            var bytes = await _ftpService.DownloadFileAsync(
                $"{serviceFile.DcaseId}/{serviceFile.Id}{serviceFile.FileExtention}", serviceFile.Ftp);

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

        public async Task<List<CaseCommentsDto>> GetCommentsByCaseIdAsync(string id)
        {
            var employeeId = await _employeeManager.GetIdAsync();
            await _context.SEmployeesJobPositions.LoadAsync();
            return await _context.DServicesCommentts
                .AsNoTracking()
                .Where(w => w.IsRemove == false && w.DCasesId == id)
                .Select(s => new CaseCommentsDto
                {
                    Id = s.Id,
                    Comment = s.Commentt,
                    DateAdd = s.DateAdd,
                    EmployeeAdd = new EmployeeDto(s.SEmployeesId, s.SEmployees.EmployeeName,
                        s.SEmployeesJobPosition.JobPositionName),
                    IsLeft = s.SEmployeesId != employeeId.Value
                })
                .ToListAsync();
        }

        public async Task<CaseNotificationsDto> GetNotificationsByCaseIdAsync(string id)
        {
            var employeeId = await _employeeManager.GetIdAsync();
            await _context.SEmployeesJobPositions.LoadAsync();

            CaseNotificationsDto result = new();

            result.CaseApplicantPhoneDtos.AddRange(await _context.DServicesCustomers.AsNoTracking().Where(w => w.DCasesId == id).Select(s => new CaseApplicantPhoneDto
            {
                Id = s.Id,
                ApplicantName = s.Fio(),
                Phone1 = s.CustomerPhone1,
                Phone2 = s.CustomerPhone2,
                CustomerType = (CustomerType)s.CustomerType

            }).ToListAsync());

            result.NotificationsDtos.AddRange(await _context.DServicesCustomersCalls.AsNoTracking().Where(w => w.DCasesId == id).Select(s => new NotificationsDto
            {
                Id = s.Id,
                CustomerFio = s.CustomerName,
                CustomerPhone = s.CustomerPhone,
                Period = s.TimeTalk,
                DateAdd = s.DateCall,
                EmployeeAdd = new EmployeeDto(s.SEmployeesId, s.SEmployees.EmployeeName,
                        s.SEmployeesJobPosition.JobPositionName),
                Type = 1
            }).ToListAsync());

            result.NotificationsDtos.AddRange(await _context.DServicesCustomersMessages.AsNoTracking().Where(w => w.DCasesId == id).Select(s => new NotificationsDto
            {
                Id = s.Id,
                CustomerFio = s.CustomerName,
                CustomerPhone = s.CustomerPhone,
                DateAdd = s.DateAdd,
                EmployeeAdd = new EmployeeDto(s.SEmployeesId, s.SEmployees.EmployeeName,
                        s.SEmployeesJobPosition.JobPositionName),
                TextMessage = s.TextMessage,
                //Status = s.Status,
                Type = 2
            }).ToListAsync());

            return result;
        }

        public async Task<string> AddNotificationsByCaseIdAsync(string caseid, Guid customerId, string tel)
        {
            try
            {
                var employees = await _employeeManager.GetFullInfoAsync();

                var data_services_customer_info = _context.DServicesCustomers.First(f => f.Id == customerId);
                var service = _context.DServices.Where(w => w.DCasesId == caseid && w.DServicesDocumentIdParent == Guid.Empty).Select(s => new { s.Id, s.SOfficesIdAdd, s.SOfficesIdAddNavigation.SFtpId }).First();
                string new_phone = "8" + tel.Trim(new Char[] { ' ', '+', '-' }).Remove(0, 1);
                string _testCALL = $"{{\"caseNumber\":\"{caseid}\",\"idEmployee\":\"{employees.Id}\",\"employeeFio\":\"{employees.Name}\",\"customerName\":\"{data_services_customer_info.Fio()}\",\"customerPhone\":\"{new_phone}\",\"callDuration\":\"0\",\"idService\":\"{service.Id}\",\"idFtp\":\"{service.SFtpId}\",\"idMfc\":\"{service.SOfficesIdAdd}\",\"callType\":\"{1}\",\"command\":\"" + 1 + "\"}";
                return _testCALL;
            }
            catch
            {
                return string.Empty;
            }
        }

        public async Task<bool> SaveSMSCaseAsync(CasesSMSSaveDto request, EmployeeInfo employee)
        {
            try
            {
                await _context.AddAsync(new DServicesCustomersMessage
                {
                    DCasesId = request.CasesId,
                    CustomerName = request.CustomerName,
                    CustomerPhone = request.CustomerPhone,
                    TextMessage = request.Text,
                    Status = 0,
                    SEmployeesId = employee.Id,
                    SEmployeesJobPositionId = employee.Job.Id,
                    SOfficesId = employee.Office.Id
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CaseCommentsDto> AddCommentAsync(string id, string comment, Guid[] employeesId)
        {
            var employee = await _employeeManager.GetFullInfoAsync();
            var model = new DServicesCommentt
            {
                DCasesId = id,
                SEmployeesId = employee.Id,
                SEmployeesJobPositionId = employee.Job.Id,
                SOfficesId = employee.Office.Id,
                Commentt = comment
            };
            if (employeesId.Any())
            {
                model.DServicesCommenttEmployees.AddRange(employeesId.Select(employeeId => new DServicesCommenttEmployee
                {
                    SEmployeesId = employeeId
                }));
                model.IsUnicast = true;
            }

            await _context.AddWithAudit(model, employee).SaveChangesAsync();

            return new CaseCommentsDto
            {
                Id = model.Id,
                Comment = model.Commentt,
                DateAdd = model.DateAdd,
                EmployeeAdd = new EmployeeDto(employee.Id, employee.Name, employee.Job.Name)
            };
        }

        public async Task<List<CaseAuditDto>> GetServiceAuditByCaseIdAsync(string id)
        {
            var response = new List<CaseAuditDto>();

            response.AddRange(await _context.DCasesViews
                .AsNoTracking()
                .Where(w => w.DCasesId == id)
                .Select(s => new CaseAuditDto
                {
                    DateAdd = s.DateAdd,
                    Changed = new ChangedAudit { Description = "Просмотр" },
                    Employee = new EmployeeDto(s.SEmployeesId, s.EmployeesName,
                        s.JobPositionName, s.OfficeName)
                })
                .ToListAsync());

            response.AddRange(await _context.DServicesAudits
                .AsNoTracking()
                .Where(w => w.DCasesId == id)
                .Select(s => new CaseAuditDto
                {
                    DateAdd = s.DateAdd,
                    Changed = JsonConvert.DeserializeObject<ChangedAudit>(s.Changed),
                    Employee = new EmployeeDto(s.SEmployeesId, s.SEmployees.EmployeeName,
                                                    s.SEmployeesJobPosition.JobPositionName, s.SOffices.OfficeName)
                })
                .ToListAsync());

            return response;
        }

        public async Task<(Guid ServiceId, string? FormPath)> GetAdditionalFormByCaseIdAsync(Guid id)
        {
            var service = await _context.DServices
                .AsNoTracking()
                .Select(s => new
                {
                    s.Id,
                    s.DCasesId,
                    s.DServicesIdParent,
                    s.SServicesProcedure.ExtraFormPath
                }).FirstAsync(f => f.Id == id);
            return (service.Id, service.ExtraFormPath);
        }

        public async Task<string> GetAdditionalDataStringByServiceIdAsync(Guid id)
        {
            var service = await _context.DServices
                .AsNoTracking()
                .Select(s => new
                {
                    s.Id,
                    s.ExtraInfo
                }).FirstAsync(f => f.Id == id);
            return service.ExtraInfo;
        }

        public async Task SaveAdditionalData(Guid id, string data, Dictionary<string, string> search)
        {
            try
            {
                var model = await _context.DServices.FindAsync(id) ?? throw new InvalidOperationException("Данные не найдены!");
                model.ExtraInfo = data;

                if (search.Any())
                {
                    if (!string.IsNullOrEmpty(model.SearchString))
                    {
                        var dict = model.SearchString.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => split[1]);

                        var newDict = search.Union(dict.Where(w => !search.ContainsKey(w.Key))).ToDictionary(k => k.Key, v => v.Value);

                        if (newDict.Any())
                        {
                            model.SearchString = string.Join("|", newDict.Select(pair => $"{pair.Key}={pair.Value}").ToArray());
                        }
                    }
                    else
                    {
                        model.SearchString = string.Join("|", search.Select(pair => $"{pair.Key}={pair.Value}").ToArray());
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                var a = 5;
            }
        }

        public async Task<T?> GetAdditionalDataByServiceIdAsync<T>(Guid id)
        {
            var data = await GetAdditionalDataStringByServiceIdAsync(id);
            if (data is null)
            {
                return default(T);
            }
            try
            {
                return JsonConvert.DeserializeObject<T>(data, new IsoDateTimeConverter { DateTimeFormat = "dd.MM.yyyy" });
            }catch(Exception e)
            {
                return default(T);
            }
        }
    }
}