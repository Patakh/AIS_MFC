using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Concrete;
using Microsoft.Extensions.Options;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.PFR
{
    public class SmevPfrController : SmevBaseController
    {
        private readonly AisLogisticsContext _context;
        private readonly ICaseService _caseService;

        public SmevPfrController(ICaseService caseService, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions, AisLogisticsContext context)
            : base(caseService, smevService, garService, smevOptions)
        {
            _context = context;
            _caseService = caseService;
        }


        public JsonResult GetPfrDepartments()
        {
            try
            {
                return Json(_context.SPfrDepartments);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }


        public JsonResult GetZags()
        {
            try
            {
                return Json(_context.SSmevClassZags);
            }
            catch (Exception e)
            {
                return Json(new { error = e.Message });
            }
        }


        /// <summary>
        /// Запрос ПФР VipNet
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">11</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrVipnetQuery(Guid serviceId, int smevId, GetPfrVipnetQueryRequestData request)
        {
            request.TargetMfcId = _context.DServices.First(i => i.Id == serviceId).SOfficesIdAdd;
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"");
            var response = SmevClient.RequestPfrVipnetQuery(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение сведений о размере социальных выплат застрахованного лица за период (без учета пенсии, доплат, устанавливаемых к пенсии, выплат по уходу)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">22</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestBenefitsForPeriodSmev3(Guid serviceId, int smevId, GetBenefitsPeriodRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestBenefitsForPeriodSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение сведений о размере пенсии и доплат, устанавливаемых к пенсии, застрахованного лица на даты
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">23</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPensionsOnDateSmev3(Guid serviceId, int smevId, GetBenefitsDateRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPensionsOnDateSmev3(request);
            return SmevResponse(response);
        }


        /// <summary>
        /// Получение сведений о размере выплат по уходу застрахованного лица за период
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">24</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> BenefitsCareForPeriodRequestSmev3(Guid serviceId, int smevId, GetBenefitsPeriodRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.BenefitsCareForPeriodRequest(request);
            return SmevResponse(response);
        }


        /// <summary>
        /// Получение сведений о размере социальных выплат на дату (без учета пенсии, доплат, устанавливаемых к пенсии, выплат по уходу)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">25</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> Request45Smev3(Guid serviceId, int smevId, GetBenefitsDateRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestBenefitsForDate(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// О соответствии фамильно-именной группы, даты рождения, пола и СНИЛС
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">27</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestValidateSnils(Guid serviceId, int smevId, GetValidateSnilsRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestValidateSnils(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление страхового номера индивидуального лицевого счёта (СНИЛС) застрахованного лица с учётом дополнительных сведений о месте рождения, документе, удостоверяющем личность
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">28</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPensionsForPeriod(Guid serviceId, int smevId, GetBenefitsPeriodRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPensionsForPeriodSmev3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение сведений о размере выплат за период (включая пенсию, доплаты, устанавливаемые к пенсии, социальные выплаты и выплаты по уходу)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">29</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestBapForPeriodSmev3(Guid serviceId, int smevId, GetBenefitsPeriodRequestData[] request)
        {
            List<string> requestErrors = new();
            GetBenefitsPeriodResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.BeginPeriod = request[0].BeginPeriod;
                item.NumberOfMonth = request[0].NumberOfMonth;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestBapForPeriodSmev3(item);
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
        /// Предоставление страхового номера индивидуального лицевого счёта (СНИЛС) застрахованного лица с учётом дополнительных сведений о месте рождения, документе, удостоверяющем личность
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">30</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestSnilsByAdditionalData(Guid serviceId, int smevId, GetSnilsByAdditionalDataRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestSnilsByAdditionalData(request);
            return SmevResponse(response);
        }
        /// <summary>
        /// Сведения о продолжительности периодов работы в районах Крайнего Севера
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">31</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFarNorth(Guid serviceId, int smevId, GetFarNorthRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestFarNorth(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Прием от граждан анкет регистрации в системе обязательного пенсионного страхования
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">32</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMfcPfrAdv1Query(Guid serviceId, int smevId, GetMfcPfrAdv1QueryRequestData request)
        {
            request.RegAddress?.Validate();
            request.LivingAddress?.Validate();
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestMfcPfrAdv1Query(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Заявление об обмене страхового свидетельства
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">33</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMfcPfrAdv2Query(Guid serviceId, int smevId, GetMfcPfrAdv2QueryRequestData request)
        {
            request.RegAddress?.Validate();
            request.LivingAddress?.Validate();
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestMfcPfrAdv2Query(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Заявление о выдаче дубликата страхового свидетельства
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">34</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMfcPfrAdv3Query(Guid serviceId, int smevId, GetMfcPfrAdv3QueryRequestData request)
        {
            request.RegAddress?.Validate();
            request.LivingAddress?.Validate();
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestMfcPfrAdv3Query(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Операция «Передача в МФЦ статусов обработки заявлений, полученных из МФЦ»
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">35</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMfcPfrStatus(Guid serviceId, int smevId, GetMfcPfrStatusRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.ApplicationNumber} {request.ServiceCode}");
            var response = SmevClient.RequestMfcPfrStatus(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Получение через МФЦ сведений об отнесении гражданина к категории граждан предпенсионного возраста
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">37</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPreRetirementAge(Guid serviceId, int smevId, GetPreRetirementAgeRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPreRetirementAge(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Информирование из ЕГИССО по СНИЛС
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">38</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestEgissoInfSnils(Guid serviceId, int smevId, GetEgissoInfSnilsRequestData[] request)
        {
            List<string> requestErrors = new();
            GetEgissoInfSnilsResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.ObligationsInclude = false;
                item.IncomesInclude = false;
                item.AssigneeInclude = false;
                item.ReportPeriod = new TimeFrame
                {
                    Begin = request[0].ReportPeriod.Begin,
                    End = request[0].ReportPeriod.End
                };

                // выбраны все меры КМСЗ
                if (item.AssignmentsFilterMszCodes[0] == "all")
                {
                    item.AssignmentsFilterMszCodes = null;
                }
                if (item.AssignmentsFilterForm == "all")
                {
                    item.AssignmentsFilterForm = null;
                }
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio}");
                var response = SmevClient.RequestEgissoInfSnils(item);
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
        /// Информирование застрахованных лиц о состоянии их индивидуальных лицевых счетов в системе обязательного пенсионного страхования
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">39</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestIlsPointFile(Guid serviceId, int smevId, GetIlsPointFileRequestData[] request)
        {
            List<string> requestErrors = new();
            GetIlsPointFileResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestIlsPointFile(item);
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
        /// Справка о назначенных пенсиях и социальных выплатах на дату
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">40</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestBenefitsFormInfo(Guid serviceId, int smevId, GetBenefitsFormInfoRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestBenefitsFormInfo(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Справка о выплатах за период
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">41</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestBenefitsPeriodFormInfo(Guid serviceId, int smevId, GetBenefitsPeriodFormInfoRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestBenefitsPeriodFormInfo(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о страховом стаже застрахованного лица
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">42</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestWorkExperience(Guid serviceId, int smevId, GetWorkExperienceRequestData[] request)
        {
            List<string> requestErrors = new();
            GetWorkExperienceResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestWorkExperience(item);
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
        /// Предоставление сведений о трудовой деятельности
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">43</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestLaborActivity(Guid serviceId, int smevId, GetLaborActivityRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestLaborActivity(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Прием и обработка заявлений во ФГИС ФРИ из МФЦ
        /// Внесение сведений о транспортном средстве, управляемом инвалидом, или транспортном средстве, перевозящем инвалида и(или) ребенка-инвалида
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">44</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestFriMfcVehicle(Guid serviceId, int smevId, PfrFriMfcVehicleRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.InvalidInfo.Fio.LastName} {request.InvalidInfo.Fio.FirstName} {request.InvalidInfo.Fio.SecondName}");
            var response = SmevClient.RequestFriMfcVehicle(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Справка, подтверждающая право на получение набора социальных услуг (НСУ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">45</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestSocialBenefits(Guid serviceId, int smevId, GetSocialBenefitsRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestSocialBenefits(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о факте получения пенсии
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">46</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrReceiptPensionFact(Guid serviceId, int smevId, PfrReceiptPensionFactRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrReceiptPensionFact(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Выписка из регистра о выдаче сертификата
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">48</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrFamilyAssetsBalance(Guid serviceId, int smevId, GetFamilyAssetsBalanceRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Snils}");
            var response = SmevClient.RequestPfrFamilyAssetsBalance(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Выписка сведений об инвалиде
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">49</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrExtractionInvalidData(Guid serviceId, int smevId, PfrExtractionInvalidDataRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Snils}");
            var response = SmevClient.RequestPfrExtractionInvalidData(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Сведения о государственной социальной помощи в виде набора социальных услуг
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">50</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrFrgsp(Guid serviceId, int smevId, PfrFrgspRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.LastName} {request.FirstName} {request.MiddleName}");
            var response = SmevClient.RequestPfrFrgsp(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление СНИЛС по данным лицевого счёта
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">51</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrFindSnils(Guid serviceId, int smevId, GetFindSnilsRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}".Trim());
            var response = SmevClient.RequestPfrFindSnils(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о доставке пенсии
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">52</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZdp(Guid serviceId, int smevId, PfrZdpRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZdp(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Запрос в ЕГИССО на получение сведений из реестра лиц, связанных с изменением родительских прав, реестра лиц с измененной дееспособностью и реестра законных представителей
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">56</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrEgissoInfRegistry(Guid serviceId, int smevId, PfrEgissoInfRegistryRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId, $"{request.RequestType}");
            var response = SmevClient.RequestPfrEgissoInfRegistry(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о выдаче государственного сертификата на материнский (семейный) капитал (МЗМК)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">53</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMzmk(Guid serviceId, int smevId, PfrMzmkRequestData request)
        {
            request.CertifiedChild.ChildIndex--;

            if (request.ParentRightsDeprivation == null)
            {
                request.ParentRightsDeprivation = false;
            }
            if (request.CrimeSign == null)
            {
                request.CrimeSign = false;
            }
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrMzmk(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о назначении ежемесячной денежной выплаты (ЗЕДВ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">60</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZedv(Guid serviceId, int smevId, PfrZedvRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");

            var response = SmevClient.RequestPfrZedv(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о переводе ежемесячной денежной выплаты с одного основания на другое (ЗЕДВ-П)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">61</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZedvp(Guid serviceId, int smevId, PfrZedvpRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZedvp(request);
            return SmevResponse(response);
        }


        /// <summary>
        /// Приём заявления о переводе ежемесячной денежной выплаты с одного основания на другое (ЗЕДВ-П)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">62</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZpnsu(Guid serviceId, int smevId, PfrZpnsuRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZpnsu(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о возобновлении предоставления набора социальных услуг (социальной услуги) (ЗВНСУ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">63</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZvnsu(Guid serviceId, int smevId, PfrZvnsuRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZvnsu(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления об отзыве ранее поданного заявления об отказе от получения НСУ, о предоставлении НСУ или о возобновлении предоставления НСУ (ЗОЗНСУ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">64</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZoznsu(Guid serviceId, int smevId, PfrZoznsuRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZoznsu(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о восстановлении выплаты пенсии (ЗВСВ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">65</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZvsv(Guid serviceId, int smevId, PfrZvsvRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZvsv(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о возобновлении выплаты пенсии (ЗВЗВ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">66</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZvzv(Guid serviceId, int smevId, PfrZvzvRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZvzv(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления о прекращении выплаты пенсии (ЗПВ)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">67</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZpv(Guid serviceId, int smevId, PfrZpvRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZpv(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Регистрация граждан в системе персонифицированного учёта
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">69</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrAdv1(Guid serviceId, int smevId, PfrAdv1RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrAdv1(request);
            return SmevResponse(response);
        }


        /// <summary>
        ///Приём заявления об изменении анкетных данных зарегистрированного лица, содержащихся на индивидуальном лицевом счете (АДВ-2)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">70</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrAdv2(Guid serviceId, int smevId, PfrAdv2RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrAdv2(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление по запросу документа, подтверждающего регистрацию в системе индивидуального (персонифицированного) учета (АДВ-3)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">71</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrAdv3(Guid serviceId, int smevId, PfrAdv3RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrAdv3(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления об отказе от получения назначенной пенсии (ЗОПП)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">72</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrZopp(Guid serviceId, int smevId, PfrZoppRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
               $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestPfrZopp(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Анкета зарегистрированного лица (АДВ-1) (ЕЦП)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">78</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrIisEcpAdv1(Guid serviceId, int smevId, PfrIisEcpAdv1RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrIisEcpAdv1(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Приём заявления об изменении анкетных данных зарегистрированного лица, содержащихся на индивидуальном лицевом счете (ЕЦП)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">79</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrIisEcpAdv2(Guid serviceId, int smevId, PfrIisEcpAdv2RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrIisEcpAdv2(request);
            return SmevResponse(response);
        }

        /// <summary>
        /// Запрос на выдачу документа, подтверждающего регистрацию в системе индивидуального (персонифицированного) учета (ЕЦП)
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">80</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestPfrIisEcpAdv3(Guid serviceId, int smevId, PfrIisEcpAdv3RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Fio.LastName} {request.Fio.FirstName} {request.Fio.SecondName}");
            var response = SmevClient.RequestPfrIisEcpAdv3(request);
            return SmevResponse(response);
        }

        //Печать бланка АДВ-1
        [HttpPost]
        public async Task<JsonResult> GetPfrAdv1Statement(PfrAdv1StatementRequestData request, Guid serviceId)
        {
            try
            {
                var caseServices = await _caseService.GetCasesServicesAsync(serviceId);
                if (request.IdentityDocument.IdentityType == PfrIdentityTypeEnum.SvedRozhRf)
                {
                    request.BirthAct.ZagsCode = "R0000000";
                }
                request.DCaseId = caseServices.CaseId;
                var response = SmevClient.GetPfrAdv1Statement(request);

                if (response.PdfContent != null)
                {
                    var base64EncodedPDF = Convert.ToBase64String(response.PdfContent);
                    var jsonResult = Json(new
                    {
                        _document = base64EncodedPDF,
                        error = ""
                    });
                    return jsonResult;
                }

                throw new Exception(response.Fault.ErrorText);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }

        //Печать бланка АДВ-2
        [HttpPost]
        public async Task<JsonResult> GetPfrAdv2Statement(PfrAdv2StatementRequestData request, Guid serviceId)
        {
            try
            {
                var caseServices = await _caseService.GetCasesServicesAsync(serviceId);
                if (request.IdentityDocument.IdentityType == PfrIdentityTypeEnum.SvedRozhRf)
                {
                    request.BirthAct.ZagsCode = "R0000000";
                }
                request.DCaseId = caseServices.CaseId;
                var response = SmevClient.GetPfrAdv2Statement(request);

                if (response.PdfContent != null)
                {
                    var base64EncodedPDF = Convert.ToBase64String(response.PdfContent);
                    var jsonResult = Json(new
                    {
                        _document = base64EncodedPDF,
                        error = ""
                    });
                    return jsonResult;
                }

                throw new Exception(response.Fault.ErrorText);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }

        //Печать бланка АДВ-3
        [HttpPost]
        public async Task<JsonResult> GetPfrAdv3Statement(PfrAdv3StatementRequestData request, Guid serviceId)
        {
            try
            {
                var caseServices = await _caseService.GetCasesServicesAsync(serviceId);
                if (request.IdentityDocument.IdentityType == PfrIdentityTypeEnum.SvedRozhRf)
                {
                    request.BirthAct.ZagsCode = "R0000000";
                }
                request.DCaseId = caseServices.CaseId;
                var response = SmevClient.GetPfrAdv3Statement(request);

                if (response.PdfContent != null)
                {
                    var base64EncodedPDF = Convert.ToBase64String(response.PdfContent);
                    var jsonResult = Json(new
                    {
                        _document = base64EncodedPDF,
                        error = ""
                    });
                    return jsonResult;
                }

                throw new Exception(response.Fault.ErrorText);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }
    }
}