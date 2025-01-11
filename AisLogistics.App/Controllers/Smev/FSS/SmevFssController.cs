using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.FK
{
    public class SmevFssController : SmevBaseController
    {
        public SmevFssController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
        }

        /// <summary>
        /// Получение списка типов вложений
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetFssAttachmentTypes(int id)
        {
            GetFssAttachmentTypesRequestData request = new GetFssAttachmentTypesRequestData
            {
                SprSmevRequestId = id
            };
            SmevKeyValueResponseData response = SmevClient.GetFssAttachmentTypesSmev3(request);
            var result = response.Result;
            return Json(result);
        }

        /// <summary>
        /// метод возвращает bool значение - доступен ли для данного типа запроса тип заявителя - юридическое лицо.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public bool GetFssApplicantUlEnabled(int id)
        {
            GetFssApplicantUlEnabledRequestData request = new GetFssApplicantUlEnabledRequestData
            {
                SprSmevRequestId = id
            };
            GetFssApplicantUlEnabledResponseData response = SmevClient.GetFssApplicantUlEnabledSmev3(request);
            return response.Enabled;
        }

        /// <summary>
        /// Получение путевки на санаторно-курортное лечение
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">528</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFssApplication(Guid serviceId, int smevId, GetFssApplicationSmev3RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.PhysicalInfo?.Fio.LastName} {request.PhysicalInfo?.Fio.FirstName} {request.PhysicalInfo?.Fio.SecondName}");
            var response = SmevClient.RequestFssApplicationSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения об отсутствии регистрации родителей в ФСС в качестве страхователей и о неполучении ими единовременного пособия
        /// при рождении ребенка и ежемесячного пособия по уходу за ребенком
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">530</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFssSvedRegisterNoPosob(Guid serviceId, int smevId, GetFssSvedRegisterNoPosobRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.CivFio.LastName} {request.CivFio.FirstName} {request.CivFio.SecondName}");
            var response = SmevClient.RequestFssSvedRegisterNoPosob(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о выплате пособий работающим гражданам в субъектах Российской Федерации,
        /// участвующих в пилотном проекте Фонда социального страхования «Прямые выплаты»
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">531</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFssInfoPayments(Guid serviceId, int smevId, GetFssInfoPaymentsRequestData[] request)
        {
            List<string> requestErrors = new();
            GetFssInfoPaymentsResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.RecipientCode = request[0].RecipientCode;
                item.DateStart = request[0].DateStart;
                item.DateEnd = request[0].DateEnd;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestFssInfoPayments(item);
                if (response.Fault != null)
                {
                    requestErrors.Add($"Запрос #{i}: {response.Fault.ErrorText}");
                }
                else
                {
                    requestSucceeded = response;
                }
            }

            if (requestErrors.Any())
            {
                return SmevResponse(new SmevResponseData
                {
                    Fault = new SmevFault
                    {
                        ErrorText = string.Join("\n", requestErrors)
                    }
                });
            }
            return SmevResponse(requestSucceeded);
        }

        /// <summary>
        /// Сведения о размере ежемесячных страховых выплат по обязательному социальному страхованию от несчастных случаев на производстве и профессиональных заболеваний
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">532</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFssSocstrahRegistration(Guid serviceId, int smevId, FssSocStrahRegistrationRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFssSocstrahRegistration(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о состоянии расчетов по страховым взносам, пеням и штрафам плательщика страховых взносов
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">533</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFssRaschRegistration(Guid serviceId, int smevId, FssRaschRegistrationRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.FlFio?.LastName} {request.FlFio?.FirstName} {request.FlFio?.SecondName}");
            var response = SmevClient.RequestFssRaschRegistration(request);
            return SmevResponse(response);
        }
    }
}