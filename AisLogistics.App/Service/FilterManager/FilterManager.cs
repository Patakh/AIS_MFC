using AisLogistics.App.Models;
using AisLogistics.App.Models.DTO.References;
using AisLogistics.App.Models.DTO.Template;
using AisLogistics.App.Settings;
using AisLogistics.App.ViewModels.Filter;
using AisLogistics.DataLayer.Concrete;
using log4net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NUglify.Helpers;

namespace AisLogistics.App.Service
{
    public class FilterManager : IFilterManager
    {
        private readonly AisLogisticsContext _context;
        private readonly IEmployeeManager _employeeManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly SpsSettings _spsSettings;
        public FilterManager(AisLogisticsContext context,IEmployeeManager employeeManager, IHttpContextAccessor httpContextAccessor, IOptions<SpsSettings> spsOptions)
        {
            _context = context;
            _employeeManager = employeeManager;
            _httpContextAccessor = httpContextAccessor;
            _spsSettings = spsOptions.Value;
        }
        public async Task<List<OfficeDto>> GetProvidersDataJson()
        {
            List<OfficeDto> providers = new List<OfficeDto>();
            providers.Add(new OfficeDto { Id = Guid.Empty, OfficeName = "Все" });

            providers.AddRange(await _context.SOffices
                .AsNoTracking()
                .Where(w => !w.IsRemove && w.IsProviderService)
                .OrderBy(o => o.SOfficesTypeId)
                .ThenBy(x => x.OfficeNameSmall)
                .Select(s => new OfficeDto
                {
                    Id = s.Id,
                    OfficeName = s.OfficeNameSmall
                })
                .ToListAsync());

            return providers;
        }

        public async Task<List<ServicesDto>> GetServicesForProviderDataJson(List<Guid> providersId)
        {
            List<ServicesDto> services = new List<ServicesDto>();
            services.Add(new ServicesDto { Id = Guid.Empty, ServiceName = "Все" });
            services.AddRange(await _context.SServices
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && (providersId.Count == 0 || providersId.Contains(x.SOfficesId)))
                    .OrderBy(x => x.ServiceNameSmall)
                    .Select(x => new ServicesDto()
                    {
                        Id = x.Id,
                        ServiceName = x.ServiceNameSmall.Length > 200 ? x.ServiceNameSmall.Substring(0,200) + "..." : x.ServiceNameSmall
                    }).ToListAsync());
            
            return services;
        }


        public async Task<List<FilterOfficeModel>> GetOfficesReceptionAllCustomerDataJson(bool isAll, bool isGroup)
        {
            List<FilterOfficeModel> mfc = new List<FilterOfficeModel>();
            if (isAll)
            {
                mfc.Add(new FilterOfficeModel { Id = Guid.Empty.ToString(), OfficeName = "Все" });
            }

            var mfcData = await _context.SOffices
            .AsNoTracking()
            .Where(x => !x.IsRemove && x.IsReceptionCustomer)
            .OrderBy(o=>o.SOfficesTypeId)
            .ThenBy(x => x.OfficeNameSmall)
            .Select(x => new FilterOfficeModel()
            {
                Id = x.Id.ToString(),
                OfficeName = x.OfficeNameSmall,
                OfficeTypeId = x.SOfficesTypeId,
                OfficeTypeName = x.SOfficesType.TypeName
            }).ToListAsync();

            if (isGroup)
            {
                mfcData.GroupBy(g => new { g.OfficeTypeId, g.OfficeTypeName })
                .OrderBy(o => o.Key.OfficeTypeId)
                .ForEach(f =>
                {
                    mfc.Add(new FilterOfficeModel { Id = f.Key.OfficeTypeId.ToString(), OfficeName = $"Все {f.Key.OfficeTypeName}" });
                });
            }

            mfc.AddRange(mfcData);

            return mfc;
        }

        public async Task<List<FilterOfficeModel>> GetOfficesReceptionDepartamentCustomerDataJson(bool isAll)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            List<FilterOfficeModel> mfc = new List<FilterOfficeModel>();
            if (isAll)
            {
                mfc.Add(new FilterOfficeModel { Id = Guid.Empty.ToString(), OfficeName = "Все" });
            }

            var mfcData = await _context.SOffices
            .AsNoTracking()
            .Where(x => !x.IsRemove && x.IsReceptionCustomer && (officeId == x.Id || officeId == x.ParentId))
            .OrderBy(o => o.SOfficesTypeId)
            .ThenBy(x => x.OfficeNameSmall)
            .Select(x => new FilterOfficeModel()
            {
                Id = x.Id.ToString(),
                OfficeName = x.OfficeNameSmall,
                OfficeTypeId = x.SOfficesTypeId,
                OfficeTypeName = x.SOfficesType.TypeName
            }).ToListAsync();

            if (isAll)
            {
                mfcData.GroupBy(g => new { g.OfficeTypeId, g.OfficeTypeName })
               .OrderBy(o => o.Key.OfficeTypeId)
               .ForEach(f =>
               {
                   mfc.Add(new FilterOfficeModel { Id = f.Key.OfficeTypeId.ToString(), OfficeName = $"Все {f.Key.OfficeTypeName}" });
               });
            }

            mfc.AddRange(mfcData);

            return mfc;
        }

        public async Task<List<FilterOfficeModel>> GetOfficesReceptionEmployeeCustomerDataJson(bool isAll)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            List<FilterOfficeModel> mfc = new List<FilterOfficeModel>();
            var mfcData = await _context.SOffices
                .AsNoTracking()
                .Where(w => w.Id == officeId)
                .Select(s => new FilterOfficeModel { Id = s.Id.ToString(), OfficeName = s.OfficeNameSmall })
                .FirstOrDefaultAsync();

            if (mfcData is not null) mfc.Add(mfcData);
            return mfc;
        }

        public async Task<List<FilterOfficeModel>> GetOfficesReceptionCustomerDataJson(bool isAll)
        {
            var officeId = await _employeeManager.GetOfficeAsync();
            List<FilterOfficeModel> mfc = new List<FilterOfficeModel>();

            if (_httpContextAccessor.HttpContext.User.HasClaim(AccessKeyNames.FilterOfficeAll, AccessKeyValues.View))
            {
                if (isAll)
                {
                    mfc.Add(new FilterOfficeModel { Id = Guid.Empty.ToString(), OfficeName = "Все" });
                }

                var mfcData = await _context.SOffices
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.IsReceptionCustomer)
                .OrderBy(o => o.SOfficesTypeId)
                .ThenBy(x => x.OfficeNameSmall)
                .Select(x => new FilterOfficeModel()
                {
                    Id = x.Id.ToString(),
                    OfficeName = x.OfficeNameSmall,
                    OfficeTypeId = x.SOfficesTypeId,
                    OfficeTypeName = x.SOfficesType.TypeName
                }).ToListAsync();

                if (isAll)
                {
                    mfcData.GroupBy(g => new { g.OfficeTypeId, g.OfficeTypeName })
                    .OrderBy(o => o.Key.OfficeTypeId)
                    .ForEach(f =>
                    {
                        mfc.Add(new FilterOfficeModel { Id = f.Key.OfficeTypeId.ToString(), OfficeName = $"Все {f.Key.OfficeTypeName}" });
                    });
                }

                mfc.AddRange(mfcData);

                return mfc;
            }
            else if (_httpContextAccessor.HttpContext.User.HasClaim(AccessKeyNames.FilterTospAll, AccessKeyValues.View))
            {
                if (isAll)
                {
                    mfc.Add(new FilterOfficeModel { Id = Guid.Empty.ToString(), OfficeName = "Все" });
                }

                var mfcData = await _context.SOffices
                .AsNoTracking()
                .Where(x => !x.IsRemove && x.IsReceptionCustomer && (officeId == x.Id || officeId == x.ParentId))
                .OrderBy(o => o.SOfficesTypeId)
                .ThenBy(x => x.OfficeNameSmall)
                .Select(x => new FilterOfficeModel()
                {
                    Id = x.Id.ToString(),
                    OfficeName = x.OfficeNameSmall,
                    OfficeTypeId = x.SOfficesTypeId,
                    OfficeTypeName = x.SOfficesType.TypeName
                }).ToListAsync();

                if (isAll)
                {
                    mfcData.GroupBy(g => new { g.OfficeTypeId, g.OfficeTypeName })
                   .OrderBy(o => o.Key.OfficeTypeId)
                   .ForEach(f =>
                   {
                       mfc.Add(new FilterOfficeModel { Id = f.Key.OfficeTypeId.ToString(), OfficeName = $"Все {f.Key.OfficeTypeName}" });
                   });
                }

                mfc.AddRange(mfcData);

                return mfc;
            }
            else
            {
                var mfcData = await _context.SOffices
                .AsNoTracking()
                .Where(w => w.Id == officeId)
                .Select(s => new FilterOfficeModel { Id = s.Id.ToString(), OfficeName = s.OfficeNameSmall })
                .FirstOrDefaultAsync();

                if(mfcData is not null) mfc.Add(mfcData);
                return mfc;
            }
        }

       

        public async Task<List<OfficeDto>> GetEmployeesForReceptionOfficeDataJson(List<Guid> officesId)
        {
            var date = DateTime.Today;
            List<int> activeStatus = new List<int> { 0,3,4 };
            List<OfficeDto> employees = new List<OfficeDto>();

            if (_httpContextAccessor.HttpContext.User.HasClaim(AccessKeyNames.FilterEmployeesAll, AccessKeyValues.View))
            {
                employees.Add(new OfficeDto { Id = Guid.Empty, OfficeName = "Все" });

                var data = await _context.SEmployeesOfficesJoins.Where(w => officesId.Contains(w.SOfficesId) &&
                            !w.IsRemove && w.DateStart <= date && (!w.DateStop.HasValue || w.DateStop > date) &&
                            w.SEmployees.SEmployeesStatusJoins.Any(a=> !a.IsRemove && activeStatus.Contains(a.SEmployeesStatusId) && a.DateStart <= date && (!a.DateStop.HasValue || a.DateStop > date)))
                    .AsNoTracking()
                    .Select(s => new OfficeDto
                    {
                        Id = s.SEmployeesId,
                        OfficeName = s.SEmployees.EmployeeName
                    })
                    .ToListAsync();

                employees.AddRange(data);
                return employees;
            }
            else
            {
                var emoloyee = await _employeeManager.GetEmployeeAsync();
                if (emoloyee is not null) employees.Add(new OfficeDto { Id = emoloyee.Id, OfficeName = emoloyee.Name });
             
                return employees;
            }
        }

        public async Task<List<SmevServiceDto>> GetSmevServicesDataJson()
        {
            List<SmevServiceDto> smevServices = new();
            smevServices.Add(new SmevServiceDto { Id = Guid.Empty, SmevName = "Все" });
            smevServices.AddRange(await _context.SSmevs
                .AsNoTracking()
                .Where(w => !w.IsRemove)
                .OrderBy(x => x.SmevName)
                .Select(x => new SmevServiceDto()
                {
                    Id = x.Id,
                    SmevName = x.SmevName,
                }).ToListAsync());
            return smevServices;
        }

        public async Task<List<SmevRequestDto>> GetRequestForSmevServicesDataJson(List<Guid> smevServicesId)
        {
            List<SmevRequestDto> smevRequests = new List<SmevRequestDto>();
            smevRequests.Add(new SmevRequestDto { Id = -1, RequestName = "Все" });
            smevRequests.AddRange(await _context.SSmevRequests
                .AsNoTracking()
                .Where(w => smevServicesId.Contains(w.SSmevId))
                .OrderBy(x => x.RequestName)
                .Select(x => new SmevRequestDto
                {
                    Id = x.Id,
                    RequestName = x.RequestName
                }
               ).ToListAsync());

            return smevRequests;
        }

        public async Task<List<ServiceCustomerTypeDto>> GetServiceCustomerTypeDataJson(bool isAll)
        {
            List<ServiceCustomerTypeDto> serviceCustomerTypes = new List<ServiceCustomerTypeDto>();
            if (isAll) serviceCustomerTypes.Add(new ServiceCustomerTypeDto { Id = -1, TypeName = "Все" });
            serviceCustomerTypes.AddRange(await _context.SServicesCustomerTypes
                .AsNoTracking()
                .Where(w => w.IdParent == 0)
                .OrderBy(x => x.Id)
                .Select(x => new ServiceCustomerTypeDto()
                {
                    Id = x.Id,
                    IdParent = x.IdParent,
                    TypeName = x.TypeName
                }).ToListAsync());

            return serviceCustomerTypes;
        }

        public async Task<List<SelectListDto<int>>> GetServiceTypeDataJson()
        {
            List<SelectListDto<int>> serviceTypes = new List<SelectListDto<int>>();
            serviceTypes.Add(new SelectListDto<int>(-1, "Все"));
            serviceTypes.AddRange(await _context.SServicesTypes
                .AsNoTracking()
                .Select(s => new SelectListDto<int>(s.Id, s.TypeName))
                .ToListAsync());

            return serviceTypes;
        }

        public async Task<List<SelectListDto<int>>> GetServiceInteractionTypeDataJson()
        {
            List<SelectListDto<int>> serviceInteractionTypes = new List<SelectListDto<int>>();
            serviceInteractionTypes.Add(new SelectListDto<int>(-1, "Все"));
            serviceInteractionTypes.AddRange(await _context.SServicesInteractions
                .AsNoTracking()
                .Select(s => new SelectListDto<int>(s.Id, s.InteractionName))
                .ToListAsync());
            return serviceInteractionTypes;
        }

        public async Task<List<SelectListDto<int>>> GetServiceStatusDataJson()
        {
            List<SelectListDto<int>> serviceStatuses = new List<SelectListDto<int>>();
            serviceStatuses.Add(new SelectListDto<int>(-1, "Все"));
            serviceStatuses.AddRange(await _context.SServicesStatuses
                .AsNoTracking()
                .Select(s => new SelectListDto<int>(s.Id, s.StatusName))
                .ToListAsync());
            return serviceStatuses;
        }

        public async Task<List<SelectListDto<int>>> GetServiceRouteStagesDataJson()
        {
            List<SelectListDto<int>> serviceStatuses = new List<SelectListDto<int>>();
            serviceStatuses.Add(new SelectListDto<int>(-1, "Все"));
            serviceStatuses.AddRange(await _context.SRoutesStages
                .AsNoTracking()
                .Select(s => new SelectListDto<int>(s.Id, s.StageName))
                .ToListAsync());
            return serviceStatuses;
        }


        public async Task<List<SelectListDto<int>>> GetServiceHashtagDataJson()
        {
            return await _context.SHashtags
                .AsNoTracking()
                .Select(s => new SelectListDto<int>(s.Id, s.HashtagName))
                .ToListAsync();
        }

        public async Task<List<OfficeSpsDto>> GetSpsMfcDataJson()
        {
            HttpClient httpClient = new();
            List<OfficeSpsDto> mfc = new();
            try
            {
                var url = $"{_spsSettings.SpsConnection}offices/";

                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode) throw new InvalidOperationException();

                var data = await response.Content.ReadFromJsonAsync<List<OfficeSpsDto>>() ?? throw new InvalidOperationException();

                mfc.AddRange(data);

                mfc.Add(new OfficeSpsDto { Id = 0, OfficeName = "Все" });

                return mfc;
            }
            catch
            {
                return mfc;
            }
            finally
            {
                httpClient.Dispose();
            }

        }

        public async Task<FilterOfficeResponseModel> GetOfficesAllIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName)
        {
            FilterOfficeResponseModel responseModel = new FilterOfficeResponseModel();
            try
            {
                var isGuidEmpty = false;
                var isIntTypeId = false;
                var isGuidValue = false;
                List<int> typeIntList = new List<int>();
                List<Guid> typeGuidList = new List<Guid>();
                office.ForEach(f =>
                {
                    if (f == Guid.Empty.ToString())
                    {
                        isGuidEmpty = true;
                    }
                    else if (int.TryParse(f, out int intTypeId))
                    {
                        isIntTypeId = true;
                        typeIntList.Add(intTypeId);
                    }
                    else if (Guid.TryParse(f, out Guid guidTypeId))
                    {
                        isGuidValue = true;
                        typeGuidList.Add(guidTypeId);
                    }
                });

                if (isGuidEmpty)
                {
                    if (isAllOfficeId)
                    {
                        var data = await _context.SOffices
                        .AsNoTracking()
                        .Where(x => !x.IsRemove && x.IsReceptionCustomer)
                        .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                        .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                    }
                    responseModel.OfficesName.Add("Все");
                }
                else if (isIntTypeId)
                {
                    var data = await _context.SOffices
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && x.IsReceptionCustomer && typeIntList.Contains(x.SOfficesTypeId))
                    .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                    .ToListAsync();

                    responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                    responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                }
                else if (isGuidValue)
                {
                    var data = await _context.SOffices
                   .AsNoTracking()
                   .Where(x => !x.IsRemove && x.IsReceptionCustomer && typeGuidList.Contains(x.Id))
                   .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                   .ToListAsync();

                    responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                    responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                }
                return responseModel;
            }
            catch
            {
                return responseModel;
            }
        }


        public async Task<FilterOfficeResponseModel> GetOfficesDepartamentIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName)
        {
            FilterOfficeResponseModel responseModel = new FilterOfficeResponseModel();
            var isGuidEmpty = false;
            var isIntTypeId = false;
            var isGuidValue = false;
            List<int> typeIntList = new List<int>();
            List<Guid> typeGuidList = new List<Guid>();
            office.ForEach(f =>
            {
                if (f == Guid.Empty.ToString())
                {
                    isGuidEmpty = true;
                }
                else if (int.TryParse(f, out int intTypeId))
                {
                    isIntTypeId = true;
                    typeIntList.Add(intTypeId);
                }
                else if (Guid.TryParse(f, out Guid guidTypeId))
                {
                    isGuidValue = true;
                    typeGuidList.Add(guidTypeId);
                }
            });

            try
            {
                var officeId = await _employeeManager.GetOfficeAsync();
                if (isGuidEmpty)
                {
                    var data = await _context.SOffices
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && x.IsReceptionCustomer && (officeId == x.Id || officeId == x.ParentId))
                    .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                    .ToListAsync();

                    responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                    responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                }
                if (isIntTypeId)
                {
                    var data = await _context.SOffices
                    .AsNoTracking()
                    .Where(x => !x.IsRemove && x.IsReceptionCustomer &&
                          (officeId == x.Id || officeId == x.ParentId) &&
                          typeIntList.Contains(x.SOfficesTypeId))
                    .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                    .ToListAsync();

                    responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                    responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                }
                else if (isGuidValue)
                {
                    if (isAddOfficeName)
                    {
                        var data = await _context.SOffices
                            .AsNoTracking()
                            .Where(x => !x.IsRemove && x.IsReceptionCustomer &&
                                  typeGuidList.Contains(x.Id))
                            .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                            .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                    }
                    else
                    {
                        office.ForEach(f =>
                        {
                            responseModel.OfficesId.Add(new Guid(f));
                        });
                    }
                }
                return responseModel;
            }
            catch
            {
                return responseModel;
            }
        }

        public async Task<FilterOfficeResponseModel> GetOfficesEmployeeIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName)
        {
            FilterOfficeResponseModel responseModel = new FilterOfficeResponseModel();
            try
            {
                var isGuidEmpty = false;
                var isIntTypeId = false;
                var isGuidValue = false;
                List<int> typeIntList = new List<int>();
                List<Guid> typeGuidList = new List<Guid>();
                office.ForEach(f =>
                {
                    if (f == Guid.Empty.ToString())
                    {
                        isGuidEmpty = true;
                    }
                    else if (int.TryParse(f, out int intTypeId))
                    {
                        isIntTypeId = true;
                        typeIntList.Add(intTypeId);
                    }
                    else if (Guid.TryParse(f, out Guid guidTypeId))
                    {
                        isGuidValue = true;
                        typeGuidList.Add(guidTypeId);
                    }
                });
                if (isAddOfficeName)
                {
                    var data = await _context.SOffices
                        .AsNoTracking()
                        .Where(x => !x.IsRemove && x.IsReceptionCustomer &&
                              typeGuidList.Contains(x.Id))
                        .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                        .ToListAsync();

                    responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                    responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                }
                else
                {
                    office.ForEach(f =>
                    {
                        responseModel.OfficesId.Add(new Guid(f));
                    });
                }
                return responseModel;
            }
            catch
            {
                return responseModel;
            }
        }


        public async Task<FilterOfficeResponseModel> GetOfficesIdForReceptionCustomer(List<string> office, bool isAllOfficeId, bool isAddOfficeName)
        {

            FilterOfficeResponseModel responseModel = new FilterOfficeResponseModel();
            try
            {
                var isGuidEmpty = false;
                var isIntTypeId = false;
                var isGuidValue = false;
                List<int> typeIntList = new List<int>();
                List<Guid> typeGuidList = new List<Guid>();
                office.ForEach(f =>
                {
                    if (f == Guid.Empty.ToString())
                    {
                        isGuidEmpty = true;
                    }
                    else if (int.TryParse(f, out int intTypeId))
                    {
                        isIntTypeId = true;
                        typeIntList.Add(intTypeId);
                    }
                    else if (Guid.TryParse(f, out Guid guidTypeId))
                    {
                        isGuidValue = true;
                        typeGuidList.Add(guidTypeId);
                    }
                });

                if (_httpContextAccessor.HttpContext.User.HasClaim(AccessKeyNames.FilterOfficeAll, AccessKeyValues.View))
                {

                    if (isGuidEmpty)
                    {
                        if (isAllOfficeId)
                        {
                            var data = await _context.SOffices
                            .AsNoTracking()
                            .Where(x => !x.IsRemove && x.IsReceptionCustomer)
                            .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                            .ToListAsync();

                            responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        }
                        responseModel.OfficesName.Add("Все");
                    }
                    else if (isIntTypeId)
                    {
                        var data = await _context.SOffices
                        .AsNoTracking()
                        .Where(x => !x.IsRemove && x.IsReceptionCustomer && typeIntList.Contains(x.SOfficesTypeId))
                        .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                        .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                    }
                    else if (isGuidValue)
                    {
                        var data = await _context.SOffices
                       .AsNoTracking()
                       .Where(x => !x.IsRemove && x.IsReceptionCustomer && typeGuidList.Contains(x.Id))
                       .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                       .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                    }
                }
                else if (_httpContextAccessor.HttpContext.User.HasClaim(AccessKeyNames.FilterTospAll, AccessKeyValues.View))
                {
                    var officeId = await _employeeManager.GetOfficeAsync();
                    if (isGuidEmpty)
                    {
                        var data = await _context.SOffices
                        .AsNoTracking()
                        .Where(x => !x.IsRemove && x.IsReceptionCustomer && (officeId == x.Id || officeId == x.ParentId))
                        .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                        .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                    }
                    if (isIntTypeId)
                    {
                        var data = await _context.SOffices
                        .AsNoTracking()
                        .Where(x => !x.IsRemove && x.IsReceptionCustomer &&
                              (officeId == x.Id || officeId == x.ParentId) &&
                              typeIntList.Contains(x.SOfficesTypeId))
                        .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                        .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                    }
                    else if (isGuidValue)
                    {
                        if (isAddOfficeName)
                        {
                            var data = await _context.SOffices
                                .AsNoTracking()
                                .Where(x => !x.IsRemove && x.IsReceptionCustomer &&
                                      typeGuidList.Contains(x.Id))
                                .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                                .ToListAsync();

                            responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                            responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                        }
                        else
                        {
                            office.ForEach(f =>
                            {
                                responseModel.OfficesId.Add(new Guid(f));
                            });
                        }
                    }
                }
                else
                {
                    if (isAddOfficeName)
                    {
                        var data = await _context.SOffices
                            .AsNoTracking()
                            .Where(x => !x.IsRemove && x.IsReceptionCustomer &&
                                  typeGuidList.Contains(x.Id))
                            .Select(x => new { OfficesId = x.Id, OfficesName = x.OfficeNameSmall })
                            .ToListAsync();

                        responseModel.OfficesId.AddRange(data.Select(s => s.OfficesId).ToList());
                        responseModel.OfficesName.AddRange(data.Select(s => s.OfficesName).ToList());
                    }
                    else
                    {
                        office.ForEach(f =>
                        {
                            responseModel.OfficesId.Add(new Guid(f));
                        });
                    }
                }

                return responseModel;
            }
            catch(Exception e)
            {
                return responseModel;
            }
        }
    }
}
