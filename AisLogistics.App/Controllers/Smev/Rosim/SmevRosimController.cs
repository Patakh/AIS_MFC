using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.Rosim
{
    public class SmevRosimController : SmevBaseController
    {
        private readonly AisLogisticsContext _context;
        public SmevRosimController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions, AisLogisticsContext context)
            : base(caseService, smevService, garService, smevOptions)
        {
            _context = context;
        }
        /// <summary>
        /// Запрос для предоставления земельного участка без проведения торгов
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1803</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRosimLand(Guid serviceId,string ApplicantType, int smevId, GetRosimLandRequestData request)
        {
            string fio;
            if (ApplicantType == "FL")
            {
                request.LegalDeclarant = null; request.PhysDeclarantRepresentative = null;
                fio = $"{request.PhysDeclarant.Fio.SecondName} {request.PhysDeclarant.Fio.FirstName} {request.PhysDeclarant.Fio.LastName}";
            }
            else if (ApplicantType == "PFL")
            {
                request.LegalDeclarant = null; request.PhysDeclarant = null;
                fio = $"{request.PhysDeclarantRepresentative.Fio.SecondName} {request.PhysDeclarantRepresentative.Fio.FirstName} {request.PhysDeclarantRepresentative.Fio.LastName}";
            }
            else
            {
                request.PhysDeclarant = null; request.PhysDeclarantRepresentative = null;
                fio = $"{request.LegalDeclarant.RepresentativeFio.SecondName} {request.LegalDeclarant.RepresentativeFio.FirstName} {request.LegalDeclarant.RepresentativeFio.LastName}";
            }
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,$"{fio}");
            var response = SmevClient.RequestRosimLandProvision(request);
            return SmevResponse(response);
        }
        /// <summary>
        /// Запрос о предварительном согласовании предоставления земельного участка, находящегося в федеральной собственности, без проведения торгов
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1802</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRosimLandPreAgreement(Guid serviceId,string ApplicantType, int smevId, GetRosimLandRequestData request, bool isRussianFederationCitizenshipUl, bool isRussianFederationCitizenshipFl)
        {
            string fio;
            if (ApplicantType == "FL")
            {
                request.IsRussianFederationCitizenship = isRussianFederationCitizenshipFl;
                request.LegalDeclarant = null; request.PhysDeclarantRepresentative = null;
                fio = $"{request.PhysDeclarant.Fio.SecondName} {request.PhysDeclarant.Fio.FirstName} {request.PhysDeclarant.Fio.LastName}";
            }
            else if (ApplicantType == "PFL")
            {
                request.LegalDeclarant = null; request.PhysDeclarant = null;
                fio = $"{request.PhysDeclarantRepresentative.Fio.SecondName} {request.PhysDeclarantRepresentative.Fio.FirstName} {request.PhysDeclarantRepresentative.Fio.LastName}";
            }
            else
            {
                request.IsRussianFederationCitizenship = isRussianFederationCitizenshipUl;
                request.PhysDeclarant = null; request.PhysDeclarantRepresentative = null;
                fio = $"{request.LegalDeclarant.RepresentativeFio.SecondName} {request.LegalDeclarant.RepresentativeFio.FirstName} {request.LegalDeclarant.RepresentativeFio.LastName}";
            }
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,$"{fio}");
            var response = SmevClient.RequestRosimLandPreAgreement(request);
            return SmevResponse(response);
        }
        
        /// <summary>
        ///  Операция «Выписка из реестра федерального имущества для МФЦ»
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1801</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRosimExcerpt(Guid serviceId,string ApplicantType, int smevId, GetRosimExcerptRequestData request)
        {
            string fio;
            if (ApplicantType == "FL")
            {
                request.LegalDeclarant = null;
                fio = $"{request.PhysDeclarant.Fio.LastName} {request.PhysDeclarant.Fio.FirstName} {request.PhysDeclarant.Fio.SecondName}";
            }
            else
            {
                request.PhysDeclarant = null;
                fio = $"{request.LegalDeclarant.RepresentativeFio.LastName} {request.LegalDeclarant.RepresentativeFio.FirstName} {request.LegalDeclarant.RepresentativeFio.SecondName}";
            }
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,$"{fio}");
            var response = SmevClient.RequestRosimExcerpt(request);
            return SmevResponse(response);
        }
    }
}