using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;
namespace AisLogistics.App.Controllers.Smev.MSP
{
    public class SmevMspController : SmevBaseController
    {
        public SmevMspController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Регистрация на Портале Бизнес-навигатора МСП
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1907</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpPortalRegistrationQuery(Guid serviceId, int smevId, MspCorpPortalRegistrationQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.MspCorpPortalRegistrationQueryRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информация об имуществе, включенном в перечни государственного и муниципального имущества и свободном от прав третьих лиц
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1908</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpPropertySupportInfoQuery20(Guid serviceId, int smevId, MspCorpPropertySupportInfoQuery20RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.ReportingMethod}");
            var response = SmevClient.MspCorpPropertySupportInfoQuery20Request(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление информации о формах и условиях поддержки сельскохозяйственной кооперации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1909</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcAgricultureInfoQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcAgricultureInfoQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.AddProductInfo}");
            var response = SmevClient.MspCorpAgricultureInfoRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Подбор информации об имуществе
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1910</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcPropertySupportInfoQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcPropertySupportInfoQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.EstateInfo.LocationFiasCode}");
            var response = SmevClient.MspCorpPropertySupportInfoRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информирование о мерах поддержки
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1911</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcInfrastructureAppQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcInfrastructureAppQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.CityFiasCode}");
            var response = SmevClient.MspCorpInfrastructureAppRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информирование о номенклатуре закупок
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1912</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcPurchaseInfoAppQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcPurchaseInfoAppQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.CustomerInn}");
            var response = SmevClient.MspCorpPurchaseInfoAppRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информирование о тренингах
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1913</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcTrainingInfoQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcTrainingInfoQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.SubscriptionEndDate}");
            var response = SmevClient.MspCorpTrainingInfoAppRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информирование о формах и условиях финансовой поддержки 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1914</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcFinancialSupportInfoQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcFinancialSupportInfoQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.ReportingMethod}");
            var response = SmevClient.MspCorpFinancialSupportInfoRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информирование о программе льготного лизинга
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1915</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcLeasingQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcLeasingQueryRequestData request)
        {

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.ReportingMethod}");
            var response = SmevClient.MspCorpLeasingRequest(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Кредитно-гарантийная поддержка
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1916</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> CorpStatementsEgpuMfcIndependentGuaranteesQuery(Guid serviceId, int smevId, MspCorpStatementsEgpuMfcIndependentGuaranteesQueryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.Fio.LastName} {request.Fio.FirstName}{request.Fio.SecondName}");
            var response = SmevClient.MspCorpIndependentGuaranteesRequest(request);
            return SmevResponse(response);
        }
    }
}
