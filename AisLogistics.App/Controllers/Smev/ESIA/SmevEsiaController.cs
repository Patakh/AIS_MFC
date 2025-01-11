using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.ESIA
{
    public class SmevEsiaController : SmevBaseController
    {
        public SmevEsiaController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Справка о выплатах за период
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1109</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaRegisterBySimplified(Guid serviceId, int smevId, GetEsiaRegisterBySimplifiedRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
               $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaRegisterBySimplified(request);
            return SmevResponse(response);
        }


        /// <summary>
        /// Регистрация подтвержденной учетной записи в ЕСИА с отправкой пароля для первого входа в систему на контактные данные
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1111</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaRegister(Guid serviceId, int smevId, GetEsiaRegisterRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaRegisterSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Восстановление доступа к учетной записи ЕСИА с выдачей пароля для входа
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1112</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaRecovery(Guid serviceId, int smevId, GetEsiaRecoverRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaRecoverySmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Подтверждение личности гражданина РФ или иностранного гражданина в ЕСИА
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1113</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequestEsiaConfirm(Guid serviceId, int smevId, GetEsiaConfirmRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaConfirmSmev3(request);
            return SmevResponse(response);
            
        }

        /// <summary>
        /// Поиск учетной записи в ЕСИА
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1114</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaSearch(Guid serviceId, int smevId, GetEsiaSearchRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaSearchSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Удаление учетной записи пользователя ЕСИА
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1115</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaDelete(Guid serviceId, int smevId, GetEsiaDeleteRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
               $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaDeleteSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Регистрация информации о ребенке в ЕСИА
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1116</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaRegisterChildSmev(Guid serviceId, int smevId, GetEsiaRegisterChildRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.ChildFio.LastName} {request.ChildFio.FirstName} {request.ChildFio.SecondName}");
            var response = SmevClient.RequestEsiaRegisterChildSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Подтверждение учётной записи в ЕСИА, созданной на основе существующей упрощённой
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1117</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaRegisterBySimplifiedSmev3(Guid serviceId, int smevId, GetEsiaRegisterBySimplifiedRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
               $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaRegisterBySimplifiedSmev3(request);
            return SmevResponse(response);
        }


        /// <summary>
        /// Изменение паспортных данных пользователя в ЕСИА
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1118</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEsiaUpdatePassportDataSmev3(Guid serviceId, int smevId, GetEsiaUpdatePassportRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
               $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestEsiaUpdatePassportDataSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение результатов оказания услуги от ЕПГУ - 1121
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> GetServiceResultRequest(Guid serviceId, int smevId, GetServiceResultRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId, 
            $"{request.OrderId}");
            var response = SmevClient.GetServiceResultRequest(request);
            return SmevResponse(response);
        }
    }
}