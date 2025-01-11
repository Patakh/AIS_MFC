using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.Extensions.Options;
using Sentry;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.FNS
{
    public class SmevFnsController : SmevBaseController
    {
        private readonly AisLogisticsContext _context;

        public SmevFnsController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions, AisLogisticsContext context)
            : base(caseService, smevService, garService, smevOptions)
        {
            _context = context;
        }

        public JsonResult GetFnsDepartments()
        {
            try
            {
                return Json(_context.SFnsSouns.ToList());
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }

        /// <summary>
        /// Прием запроса о предоставлении справки об исполнении налогоплательщиком (плательщиком сбора, налоговым агентом) 
        /// обязанности по уплате налогов, сборов, пеней, штрафов, процентов
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="request"></param>
        /// <param name="smevId">318</param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequestSprispnp(Guid serviceId, int smevId, GetSprispnpRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.PersonFio}");
            var response = SmevClient.RequestSprispnp(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Об ИНН физических лиц на основании полных паспортных данных по единичному запросу органов исполнительной власти
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">319</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestInnSingular(Guid serviceId, int smevId, GetInnSingularRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestInnSingular(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Выписки из ЕГРИП по запросам органов государственной власти
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">324</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestVipIp(Guid serviceId, int smevId, GetVipIpRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                 $"{request.Query}");
            var response = SmevClient.RequestVipIp(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление сведений из реестра малого и среднего предпринимательства в отношении ЮЛ и ИП
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">325</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRrmsp(Guid serviceId, int smevId, GetFnsRrmspQueryRequestData[] request)
        {
            List<string> requestErrors = new();
            GetFnsRrmspQueryResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Inn}");
                var response = SmevClient.RequestFnsRrmsp(item);
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
        /// Информация из Реестра дисквалифицированных лиц
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">326</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestRstrdiskvlic(Guid serviceId, int smevId, GetFnsRstrdiskvlicRequestData[] request)
        {
            List<string> requestErrors = new();
            GetFnsRstrdiskvlicResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestRstrdiskvlic(item);
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
        /// Представление электронных документов при государственной регистрации юридического лица или индивидуального предпринимателя
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="request"></param>
        /// <param name="smevId">327</param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequestFnsPrdDoc(Guid serviceId, int smevId, SendFnsPrdDocRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
              $"{request.GosRegType}");
            var response = SmevClient.RequestFnsPrdDoc(request);
            return SmevResponse(response);
        }


        /// <summary>
        /// Представление электронных документов при государственной регистрации индивидуального предпринимателя с формированием транспортного контейнера
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">329</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsRegIpTrCon(Guid serviceId, int smevId, SendFnsRegIpTrConRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
              $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFnsRegIpTrCon(request);
            return SmevResponse(response);
        }

        [HttpPost]
        public JsonResult Smev_RequestFnsRegAppliedDocuments(GetFnsRegAppliedDocumentsRequestData request)
        {
            var result = SmevClient.RequestFnsRegAppliedDocuments(request);
            return Json(result);
        }


        /// <summary>
        /// Представление электронных документов при государственной регистрации юридического лица с формированием транспортного контейнера
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">330</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsRegUlTrCon(Guid serviceId, int smevId, SendFnsRegUlTrConRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.Applicants[0].Fio.LastName} {request.Applicants[0].Fio.FirstName} {request.Applicants[0].Fio.SecondName}");
            var response = SmevClient.RequestFnsRegUlTrCon(request);
            return SmevResponse(response);
        }
        [HttpPost]
        public JsonResult Smev_RequestFnsRegAppliedDocumentsUI(GetFnsRegAppliedDocumentsRequestData request)
        {
            var result = SmevClient.RequestFnsRegAppliedDocuments(request);
            return Json(result);
        }

        /// <summary>
        /// Предоставление сведений о наличии (отсутствии) задолженности по уплате налогов, сборов, страховых взносов, пеней, штрафов, процентов
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">331</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsZadorg(Guid serviceId, int smevId, GetFnsZadorgRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.ApplicantType} {request.Inn}");
            var response = SmevClient.RequestFnsZadorg(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление выписки из ЕГРЮЛ, ЕГРИП в форме электронного документа
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId"></param>
        /// <param name="request">332</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsZpvipegr(Guid serviceId, int smevId, GetFnsZpvipegrRequestData request)
        {
            request.RequestValue = request.RequestValueType switch
            {
                FnsQueryTypeEnum.InnFl => request.ApplicantFl.InnFl,
                FnsQueryTypeEnum.OgrnFl => request.ApplicantFl.OgrnIp,
                FnsQueryTypeEnum.InnUl => request.ApplicantUl.InnUl,
                FnsQueryTypeEnum.OgrnUl => request.ApplicantUl.Ogrn,
                _ => request.RequestValue
            };

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.RequestValue}");
            var response = SmevClient.RequestFnsZpvipegr(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о доходах физических лиц из налоговой декларации формы 3-НДФЛ - 333
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">333</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFns3Ndf(Guid serviceId, int smevId, GetFns3NdflVsRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFns3Ndfl(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Представление сведений о выплатах, произведенных плательщиками страховых взносов в пользу физических лиц
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">334</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestSvviplfl(Guid serviceId, int smevId, GetFnsSvviplflRequestData[] request, string Period)
        {
            List<string> requestErrors = new();
            GetFnsSvviplflResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.Period = (FnsSvviplflPeriodType)Convert.ToInt32(Period);
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestSvviplfl(item);
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
        /// 1 Предоставление сведений из налоговых деклараций, представленных индивидуальными предпринимателями, применяющими специальные налоговые режимы
        /// 2 Сведения налоговой декларации по налогу на доходы физических лиц (по форме 3-НДФЛ) 
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">336+338</param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ActionResult<string>> RequestFnsNdipsrAnd3NdflDoh(Guid serviceId, int smevId, GetFnsNdipsrRequestData request, GetFnsNdfl3DohRequestData request2)
        {
            List<string> requestErrors = new();
            SmevResponseData requestSucceeded = new();
            if (request.Fio == null && request2?.Fio == null)
            {
                return SmevResponse(new SmevResponseData
                {
                    Fault = new SmevFault
                    {
                        ErrorText = "Выберите запрос"
                    }
                });
            }

            //1 запрос
            if (request.Fio != null)
            {
                request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, 336,
                    $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
                var response = SmevClient.RequestNdipsr(request);
                if (response.Fault != null)
                {
                    requestErrors.Add($"Запрос #1: {response.Fault.ErrorText}");
                }
                else
                {
                    requestSucceeded = response;
                }
            }

            //2 запрос
            if (request2.Fio != null)
            {
                request2.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, 338, $"{request2.Fio.LastName} {request2.Fio.FirstName} {request2.Fio.SecondName}");
                var response2 = SmevClient.RequestFns3NdflDoh(request2);
                if (response2.Fault != null)
                {
                    requestErrors.Add($"Запрос #2: {response2.Fault.ErrorText}");
                }
                else
                {
                    requestSucceeded = response2;
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
        /// Выписки из ЕГРИП по запросам органов государственной власти (открытые сведения и адрес места жительства ИП)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">337</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestVipipAdr(Guid serviceId, int smevId, FnsVipipAdrRequestData[] request)
        {
            List<string> requestErrors = new();
            FnsVipipAdrResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestVipipAdr(item);
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
        /// Открытые сведения из ЕГРИП по запросам органов государственной власти и организаций, зарегистрированных в СМЭВ
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">341</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsOtsvegrip(Guid serviceId, int smevId, FnsOtsvegripRequestData[] request)
        {
            List<string> requestErrors = new();
            FnsOtsvegripResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestFnsOtsvegrip(item);
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
        /// Открытые сведения из ЕГРЮЛ по запросам органов государственной власти и организаций, зарегистрированных в СМЭВ
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">342</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsOtsvegrul(Guid serviceId, int smevId, FnsOtsvegrulRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    request.Inn ?? request.Ogrn);
            var response = SmevClient.RequestFnsOtsvegrul(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Передача заявления физического лица о постановке на учет в налоговый орган и выдача (повторная выдача) физическому лицу свидетельства о постановке на учет в налоговом органе
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">347</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsMfcUfl(Guid serviceId, int smevId, FnsMfcUflRequestData request)
        {
            if (request.AddressRf != null)
            {
                if (string.IsNullOrWhiteSpace(request.AddressRf.Area.ElementName))
                {
                    request.AddressRf.Area = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.City.ElementName))
                {
                    request.AddressRf.City = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.Settlement.ElementName))
                {
                    request.AddressRf.Settlement = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.PlanningStructureElement.ElementName))
                {
                    request.AddressRf.PlanningStructureElement = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.Street.ElementName))
                {
                    request.AddressRf.Street = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.House.ElementName))
                {
                    request.AddressRf.House = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.Building.ElementName))
                {
                    request.AddressRf.Building = null;
                }

                if (string.IsNullOrWhiteSpace(request.AddressRf.Flat.ElementName))
                {
                    request.AddressRf.Flat = null;
                }
            }

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}".Trim());
            var response = SmevClient.RequestFnsMfcUfl(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Направление запросов на получение документов в сфере налогообложения имущества через МФЦ
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">345</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFnsImMfc(Guid serviceId, int smevId, FnsImMfcRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                        $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFnsImMfc(request);
            return SmevResponse(response);
        }

        [HttpPost]
        public JsonResult GetFnsImMfcAppliedDocuments(string kndId)
        {
            if (string.IsNullOrEmpty(kndId))
                return Json("");
            else
            {
                var result = SmevClient.RequestFnsImMfcAppliedDocuments(new FnsImMfcAppliedDocumentsRequestData
                {
                    FnsKndId = kndId
                });

                return Json(result);
            }
        }

        /// <summary>
        /// 1 Сведения о регистрации по месту жительства граждан РФ
        /// 2 Представление сведений о выплатах, произведенных плательщиками страховых взносов в пользу физических лиц
        /// 3 Сведения о выплате пособий работающим гражданам в субъектах Российской Федерации, участвующих в пилотном проекте Фонда социального страхования «Прямые выплаты»
        /// 4 Предоставление выписки из ЕГРЮЛ, ЕГРИП в форме электронного документа
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1063+334+531+352</param>
        /// <param name="request1 "></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestConbined(
            Guid serviceId,
            int smevId,
            MvdGetRegistrationRequestData[] request1,
            GetFnsSvviplflRequestData[] request2,
            GetFssInfoPaymentsRequestData request3,
            GetFnsZpvipegrRequestData request4)

        {

            int i = 0;
            foreach (var item in request1)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, 1063,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestMvdGetLivingPlaceRegistration(item);
                if (response.ResponseReports is null || response.ResponseReports.Length == 0)
                {
                    return BadRequest(response.Fault?.ErrorText);
                }
                else
                {
                    //pdf
                }
            }
            int j = 0;
            foreach (var item in request2)
            {
                j++;
                item.Period = request2[0].Period;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, 334,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response2 = SmevClient.RequestSvviplfl(item);
                if (response2.ResponseReports is null || response2.ResponseReports.Length == 0)
                {
                    return BadRequest(response2.Fault?.ErrorText);
                }
                else
                {
                    //pdf
                }
            }
            request3.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, 531,
                    $"{request3.Fio.LastName} {request3.Fio.FirstName} {request3.Fio.SecondName}");
            var response3 = SmevClient.RequestFssInfoPayments(request3);

            request4.RequestValue = request4.RequestValueType switch
            {
                FnsQueryTypeEnum.InnFl => request4.ApplicantFl.InnFl,
                FnsQueryTypeEnum.OgrnFl => request4.ApplicantFl.OgrnIp,
                FnsQueryTypeEnum.InnUl => request4.ApplicantUl.InnUl,
                FnsQueryTypeEnum.OgrnUl => request4.ApplicantUl.Ogrn,
                _ => request4.RequestValue
            };

            request4.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, 332,
                $"{request4.RequestValue}");
            var response4 = SmevClient.RequestFnsZpvipegr(request4);

            if (response3.ResponseReports is null || response3.ResponseReports.Length == 0 || response4.ResponseReports is null || response4.ResponseReports.Length == 0)
                return BadRequest(response3.Fault?.ErrorText ?? response3.Fault?.ErrorText);

            return Ok();
        }
    }
}