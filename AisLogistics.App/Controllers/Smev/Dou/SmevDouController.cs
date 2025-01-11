using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.Dou
{
    public class SmevDouController : SmevBaseController
    {
        public SmevDouController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Прием заявлений на зачисление в ДОУ
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">802</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> DouDeclaration(Guid serviceId, int smevId, GetDouDeclarationRequestData request,string[] multiselect_to)
        {
           
            multiselect_to = multiselect_to.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            request.Order.WishDouIdList = new int[multiselect_to.Length >= 3 ? 3 : multiselect_to.Length];
            request.Order.WishDouNameList = new string[multiselect_to.Length >= 3 ? 3 : multiselect_to.Length];
            for (var i = 0; i <= multiselect_to.Length - 1 && i <= 2; i++)
            {
                var _t = multiselect_to[i].Split('|');
                request.Order.WishDouIdList[i] = Convert.ToInt32(_t[0]);
                request.Order.WishDouNameList[i] = _t[1];
            }
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.Declarant.Fio.LastName} {request.Declarant.Fio.FirstName} {request.Declarant.Fio.SecondName}");
           
            var response = SmevClient.RequestDouDeclaration(request);
            return SmevResponse(response);
        }
        
        
        /// <summary>
        /// Город/Район
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDouDistrictList()
        {
            SmevSimpleRequestData request = new SmevSimpleRequestData();
            SmevKeyOkatoValueResponseData response = SmevClient.GetDouDistrictList(request);
            var result = response.Result;
            return Json(result);
        }
        
        /// <summary>
        /// Потребность по здоровью
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDouHealthNeeds(GetDouHealthNeedsRequestData request)
        {
            SmevKeyValueResponseData response = SmevClient.GetDouHealthNeeds(request);
            return Json(response.Result);
        }
        
        /// <summary>
        /// КАТЕГОРИЯ ЛЬГОТ
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDouPrivilegeCategory(GetDouPrivilegeCategoryRequestData request)
        {
            SmevKeyValueResponseData response = SmevClient.GetDouPrivilegeCategory(request);
            return Json(response.Result);
        }
        
        /// <summary>
        /// ДОУ
        /// </summary>
        /// <returns></returns>
        public JsonResult GetDouFilteredUnits(GetDouFilteredUnitsRequestData request)
        {
            SmevKeyValueResponseData response = SmevClient.GetDouFilteredUnits(request);
            return Json(response.Result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Smev_GetDouOrderJson(GetDouDeclarationRequestData request,  string[] multiselect_to)
        {
            try
            {
                multiselect_to = multiselect_to.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                request.Order.WishDouIdList = new int[multiselect_to.Length >= 3 ? 3 : multiselect_to.Length];
                request.Order.WishDouNameList = new string[multiselect_to.Length >= 3 ? 3 : multiselect_to.Length];
                for (var i = 0; i <= multiselect_to.Length - 1 && i <= 2; i++)
                {
                    var _t = multiselect_to[i].Split('|');
                    request.Order.WishDouIdList[i] = Convert.ToInt32(_t[0]);
                    request.Order.WishDouNameList[i] = _t[1];
                }
             /*   multiselect_to = multiselect_to.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                request.Order.WishDouIdList = new int[multiselect_to.Length >= 3 ? 3 : multiselect_to.Length];
                orderInfo.WishDouNameList = new string[multiselect_to.Length >= 3 ? 3 : multiselect_to.Length];
                for (var i = 0; i <= multiselect_to.Length - 1 && i <= 2; i++)
                {
                    orderInfo.WishDouNameList[i] = _multiselect_to[i];
                }
                GetDouDeclarationRequestData request = new GetDouDeclarationRequestData
                {
                    IsDeclarationQuery = false,
                    Declarant = declarantInfo,
                    Children = childInfo,
                    Order = orderInfo,
                    CustomModeInfo = CustomModeSupport.GetDouDeclarationCustomModeInfo()
                };*/
                var PdfDocument = SmevClient.GetDouOrderForm(request);
                var base64EncodedPDF = Convert.ToBase64String(PdfDocument);
                return Json(new { _document = base64EncodedPDF, _error = "" });
              }
            catch (Exception ex)
            {
                return Json(new { _document = "", _error = ex.Message });
            }
        }
    }
}