using System.Text;
using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.MinTrud
{
    public class SmevMinTrudController : SmevBaseController
    {
        private readonly AisLogisticsContext _context;
        
        public SmevMinTrudController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions, AisLogisticsContext context)
           : base(caseService, smevService, garService, smevOptions)
        {
            _context = context;
        }

        public async Task<JsonResult> GetBanks()
        {
            try
            {
                return Json(await _context.SBanks.AsNoTracking().ToListAsync());
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Передача заявления на государственную услугу из МФЦ в ОИВ осуществляющему полномочия в области социальной защиты населения
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">2213</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> MinTrudSocialProtectMfcRequest(Guid serviceId, int smevId, SocialProtectMfcRequestData request, List<string> ServiceCode, List<string> DepartmentId)
        {
            var servicesDict = SmevClient.GetDictionary(DictionaryType.SocialProtectMfcServices);
            var departmentName = SmevClient.GetDictionary(DictionaryType.SocialProtectMfcUsznCodes).Dictionary.First(k => k.Key == DepartmentId[0]).Value;

            SocialProtectMfcResponseData lastResponse = new SocialProtectMfcResponseData();
           /* if (request.FamilyMembersData.SpouseData?.Fio is null)
            {
                request.FamilyMembersData.SpouseData = null;
            }

            if (request.FamilyMembersData.SpouseData is null
                && request.FamilyMembersData.FamilyData is null
                && request.FamilyMembersData.RelativesData is null)
            {
                request.FamilyMembersData = null;
            }*/

            request.Declarant.ServiceAddress?.Validate();
            request.Delegate?.ServiceAddress?.Validate();
            request.ReceivingPaymentData?.PostOrganisation?.PostAddress?.Validate();

            for (int i = 0; i < ServiceCode.Count; i++)
            {
                request.ServiceId = ServiceCode[i];
                request.DepartmentId = DepartmentId[0];
                if (request.FamilyMembersData?.FamilyData != null)
                {
                    foreach (var familyData in request.FamilyMembersData.FamilyData)
                    {
                        familyData.ChildrenDataBlock?.ChildAddress?.Validate();
                    }
                }

                string serviceName = servicesDict.Dictionary.First(k => k.Key == ServiceCode[i]).Value;

                StringBuilder comment = new StringBuilder();
                //comment.AppendLine($"{request.Declarant.Fio.LastName} {request.Declarant.Fio.FirstName} {request.Declarant.Fio.SecondName}");
                comment.AppendLine(serviceName);
                comment.Append(departmentName);

                request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId, comment.ToString());
                var response = SmevClient.MinTrudSocialProtectMfcRequest(request);
                lastResponse = response;
            }

            return SmevResponse(lastResponse);
        }
    }
}
