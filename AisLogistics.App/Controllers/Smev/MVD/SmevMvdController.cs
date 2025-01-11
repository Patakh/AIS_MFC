using System.Text.RegularExpressions;
using AisLogistics.App.Service;
using AisLogistics.App.Settings;
using Microsoft.Extensions.Options;
using NUglify.Helpers;
using SmevGate.Client.Core;
using SmevRouter;

namespace AisLogistics.App.Controllers.Smev.MVD
{
    public class SmevMvdController : SmevBaseController
    {
        private readonly IEmployeeManager _employeeManager;

        public SmevMvdController(ICaseService caseService, IEmployeeManager employeeManager, ISmevService smevService, IGarService garService, IOptions<SmevSettings> smevOptions)
            : base(caseService, smevService, garService, smevOptions)
        {
            _employeeManager = employeeManager;
        }

        /// <summary>
        /// Предоставление справки о наличии (отсутствии) судимости, факта уголовного преследования (УП), прекращении УП, о нахождении в розыске версии
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1002</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestGiacCriminal(Guid serviceId, int smevId, GetGiacCriminalRequestData request, string[] regionList)
        {
            request.Personal.Regions = regionList;
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestGiacCriminal(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Запрос на предоставление справки о привлечении (не привлечении) лица к административному наказанию за потребление наркотических или психотропных веществ без назначения врача
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1005</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestGiacAdmOffenceDrugs(Guid serviceId, int smevId, GetGiacAdmOffenceDrugsRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Person.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestGiacAdmOffenceDrugs(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление справки о наличии (отсутствии) судимости, факта уголовного преследования (УП), прекращении УП, о нахождении в розыске версии 1.1.0
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1026</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestGiacCriminalV11(Guid serviceId, int smevId, GetGiacCriminalV11RequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.Applicant.Fio.LastName} {request.Applicant.Fio.FirstName} {request.Applicant.Fio.SecondName}");
            var response = SmevClient.RequestGiacCriminalV11(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Информационное уведомление по выдаче заграничного паспорта, содержащего электронный носитель информации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1043</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMvdAisOpvNotification(Guid serviceId, int smevId, MvdAisOpvNotificationRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId, $"{request.RegistrationNumber}");
            var response = SmevClient.RequestMvdAisOpvNotification(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Прием детской анкеты для выдачи заграничного паспорта, содержащего электронный носитель информации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1044</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMvdAisOpvChildAnket(Guid serviceId, int smevId, MvdAisOpvChildAnketRequestData request, string BirthPlaceManual)
        {
            if (!string.IsNullOrEmpty(BirthPlaceManual)) request.PersonData.BirthPlace.Region = BirthPlaceManual;
            if (request.Address == null)
            {
                request.Address = new MvdAisOpvStructuredAddressType();
            }
            else
            {
                if (request.Address.ActualResidence == null && request.Address.TemporaryResidence == null)
                {
                    request.Address.ActualResidence = request.Address.PermanentResidence;
                }
            }
            if (request.LegalRepresentative != null)
            {
                if (request.LegalRepresentative.Address == null)
                {
                    request.LegalRepresentative.Address = new MvdAisOpvStructuredAddressType();
                }
                else
                {
                    if (request.LegalRepresentative.Address.ActualResidence == null && request.LegalRepresentative.Address.TemporaryResidence == null)
                    {
                        request.LegalRepresentative.Address.ActualResidence = request.LegalRepresentative.Address.PermanentResidence;
                    }
                }
            }

            if (request.Attachments?.Length > 0)
            {
                request.Attachments = request.Attachments.Where(i => i.AttachmentTypeCode != "photo").ToArray();
            }

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.PersonData.LastName} {request.PersonData.FirstName} {request.PersonData.Patronymic}");
            var response = SmevClient.RequestMvdAisOpvChildAnket(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Прием детской анкеты для выдачи заграничного паспорта, содержащего электронный носитель информации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1045</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMvdAisOpvMatureAnket(Guid serviceId, int smevId, MvdAisOpvMatureAnketRequestData request, string BirthPlaceManual)
        {
            if (!string.IsNullOrEmpty(BirthPlaceManual)) request.PersonData.BirthPlace.Region = BirthPlaceManual;
            foreach (var item in request.EmploymentHistory)
            {
                if (item.DismissalDate?.Year == 0) item.DismissalDate = null;
            }

            if (request.Address == null)
            {
                request.Address = new MvdAisOpvStructuredAddressType();
            }
            else
            {
                if (request.Address.ActualResidence == null && request.Address.TemporaryResidence == null)
                {
                    request.Address.ActualResidence = request.Address.PermanentResidence;
                }
            }
            if (request.LegalRepresentative != null)
            {
                if (request.LegalRepresentative.Address == null)
                {
                    request.LegalRepresentative.Address = new MvdAisOpvStructuredAddressType();
                }
                else
                {
                    if (request.LegalRepresentative.Address.ActualResidence == null && request.LegalRepresentative.Address.TemporaryResidence == null)
                    {
                        request.LegalRepresentative.Address.ActualResidence = request.LegalRepresentative.Address.PermanentResidence;
                    }
                }
            }

            if (request.Attachments?.Length > 0)
            {
                request.Attachments = request.Attachments.Where(i => i.AttachmentTypeCode != "photo").ToArray();
            }

            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                $"{request.PersonData.LastName} {request.PersonData.FirstName} {request.PersonData.Patronymic}");
            var response = SmevClient.RequestMvdAisOpvMatureAnket(request);

            return SmevResponse(response);
        }

        /// <summary>
        /// Предоставление сведений о наличии судимости
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1051</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMvdIbdSearch(Guid serviceId, int smevId, MvdIbdSearchRequestData[] request)
        {
            List<string> requestErrors = new();
            MvdIbdSearchResponseData requestSucceeded = new();
            int i = 0;
            foreach (var item in request)
            {
                i++;
                item.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
                    $"{item.Fio.LastName} {item.Fio.FirstName} {item.Fio.SecondName}");
                var response = SmevClient.RequestMvdIbdSearch(item);
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

        //Печать банков для загран паспортов форма "Детская"
        [HttpPost]
        public JsonResult RequestMvdAisOpvChildAnketBlanksPdf(MvdAisOpvChildAnketRequestData request, string BirthPlaceManual)
        {
            try
            {
                if (!string.IsNullOrEmpty(BirthPlaceManual)) request.PersonData.BirthPlace.Region = BirthPlaceManual;
                if (request.Address == null)
                {
                    request.Address = new MvdAisOpvStructuredAddressType();
                }
                else
                {
                    if (request.Address.ActualResidence == null && request.Address.TemporaryResidence == null)
                    {
                        request.Address.ActualResidence = request.Address.PermanentResidence;
                    }
                }
                if (request.LegalRepresentative != null)
                {
                    if (request.LegalRepresentative.Address == null)
                    {
                        request.LegalRepresentative.Address = new MvdAisOpvStructuredAddressType();
                    }
                    else
                    {
                        if (request.LegalRepresentative.Address.ActualResidence == null && request.LegalRepresentative.Address.TemporaryResidence == null)
                        {
                            request.LegalRepresentative.Address.ActualResidence = request.LegalRepresentative.Address.PermanentResidence;
                        }
                    }
                }

                if (request.Attachments?.Length > 0)
                {
                    request.Attachments = request.Attachments.Where(i => i.AttachmentTypeCode == "photo").ToArray();
                }

                var response = SmevClient.RequestMvdAisOpvChildAnketBlanks(request);

                if (response.PdfContentBlanks != null)
                {
                    var base64EncodedPDF = Convert.ToBase64String(response.PdfContentBlanks);
                    var jsonResult = Json(new
                    {
                        _document = base64EncodedPDF,
                        error = ""
                    });
                    return jsonResult;
                }
                else
                {
                    throw new Exception(response.Fault.ErrorText);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }

        //Печать банков для загран паспортов форма "Взрослая"
        [HttpPost]
        public JsonResult RequestMvdAisOpvMatureAnketBlanksPdf(MvdAisOpvMatureAnketRequestData request, string BirthPlaceManual)
        {
            try
            {
                if (!string.IsNullOrEmpty(BirthPlaceManual)) request.PersonData.BirthPlace.Region = BirthPlaceManual;
                if (request.Address == null)
                {
                    request.Address = new MvdAisOpvStructuredAddressType();
                }
                else
                {
                    if (request.Address.ActualResidence == null && request.Address.TemporaryResidence == null)
                    {
                        request.Address.ActualResidence = request.Address.PermanentResidence;
                    }
                }
                if (request.LegalRepresentative != null)
                {
                    if (request.LegalRepresentative.Address == null)
                    {
                        request.LegalRepresentative.Address = new MvdAisOpvStructuredAddressType();
                    }
                    else
                    {
                        if (request.LegalRepresentative.Address.ActualResidence == null && request.LegalRepresentative.Address.TemporaryResidence == null)
                        {
                            request.LegalRepresentative.Address.ActualResidence = request.LegalRepresentative.Address.PermanentResidence;
                        }
                    }
                }

                if (request.EmploymentHistory?.Length > 0)
                {
                    foreach (var i in request.EmploymentHistory)
                    {
                        if (i.DismissalDate.Month == 0 && i.DismissalDate.Year == 0)
                        {
                            i.DismissalDate = null;
                        }
                    }
                }

                if (request.Attachments?.Length > 0)
                {
                    request.Attachments = request.Attachments.Where(i => i.AttachmentTypeCode == "photo").ToArray();
                }

                var response = SmevClient.RequestMvdAisOpvMatureAnketBlanks(request);

                if (response.PdfContentBlanks != null)
                {
                    var base64EncodedPDF = Convert.ToBase64String(response.PdfContentBlanks);
                    var jsonResult = Json(new
                    {
                        _document = base64EncodedPDF,
                        error = ""
                    });
                    return jsonResult;
                }
                else
                {
                    throw new Exception(response.Fault.ErrorText);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<JsonResult> RequestMvdAisOpvGenerateRegNumber(MvdAisOpvGenerateRegNumberRequestData requestData)//1044-1045 запрос 
        {
            var mfcId = await _employeeManager.GetOfficeAsync();
            requestData.SprEmployeesMfcId = mfcId.Value;
            var result = SmevClient.RequestMvdAisOpvGenerateRegNumber(requestData);
            return Json(result);
        }


        /// <summary>
        /// Отзыв заявления о выдаче заграничного паспорта, содержащего электронный носитель информации
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="smevId">1039</param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<string>> RequestMvdAisOpvCancel(Guid serviceId, int smevId, MvdAisOpvCancelRequestData request)
        {
            request.DataServicesRequestSmevId = await _smevService.CreateNewSmevRequestAsync(serviceId, smevId,
            $"{request.NotificationText}");
            var response = SmevClient.RequestMvdAisOpvCancel(request);
            return SmevResponse(response);
        }
    }
}