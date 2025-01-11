using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Common;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.RosReestr
{
    public class SmevRosReestrController : SmevBaseController
    {
        public SmevRosReestrController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Запрос на предоставление сведений, содержащихся в ЕГРН, об объектах недвижимости
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId"></param>
        /// <param name="request">414</param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequestRosReestrEgrnInfo(Guid serviceId, int smevId, GetRosReestrEgrnObjectInfoRequestData request)
        {
            if (string.IsNullOrWhiteSpace(request.Declarant.Person.ContactInfo.EMail)
                && string.IsNullOrWhiteSpace(request.Declarant.Person.ContactInfo.PhoneNumber))
            {
                request.Declarant.Person.ContactInfo = null;
            }

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,$"{request.CadastralNumber}");
            var response = SmevClient.RequestRosReestrEgrnObjectInfo(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Запрос на предоставление сведений, содержащихся в ЕГРН, об объектах недвижимости
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId"></param>
        /// <param name="request">446</param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequestRosReestrEgrnSubjectInfo(Guid serviceId, int smevId, GetRosReestrEgrnSubjectInfoRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,$"{request.DatePeriodType}");
            var response = SmevClient.RequestRosReestrEgrnSubjectInfo(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Регистрация сделки об ограничении (обременении) права (регистрация договора участия в долевом строительстве и регистрация договора аренды)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId"></param>
        /// <param name="request">428</param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequesDealsRegistrationRightRestriction(Guid serviceId, int smevId, GetDealsRegistrationRightRestrictionRequestData request)
        {
            try
            {
                request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId, $"{request.StatementOwner.Owners[0].Person.Fio.LastName}");
                var response = SmevClient.DealsRegistrationRightRestrictionQuery(request);
                return SmevResponse(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
    }
}
