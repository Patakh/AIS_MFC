using AisLogistics.App.Models.MDM;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace AisLogistics.App.Service.MDM
{
    public class MdmService : IMdmService
    {
        private readonly AisLogisticsContext _context;

        public MdmService(AisLogisticsContext context)
        {
            _context = context;
        }

        public async Task<List<DMdmObjectsUpload>?> MdmStartedDataServicesObjectsAsync(Guid dServiceId, Guid officeIdMdm, Guid sprServicesSubId, Guid dServiceRouteStageId, int? recivedWindowsCount)
        {
            DateTime date = DateTime.Now;

            DateTime d11 = date;
            DateTime d25 = d11.AddSeconds(-30);
            DateTime d8 = d25.AddSeconds(-30);
            DateTime d5 = d8.AddSeconds(-30);

            DateTime d34 = d5.AddMinutes(-1);
            DateTime d3 = d34;

            var rnd = new Random();

            int minutes = rnd.Next(1, 99) switch
            {
                <= 85 => rnd.Next(1, 14),
                > 85 and <= 93 => rnd.Next(15, 29),
                > 93 => rnd.Next(30, 50),
            };

            var interimDate = d3.AddMinutes(-minutes);

            DateTime d2 = DateTime.Today.AddHours(interimDate.Hour).AddMinutes(interimDate.Minute).AddSeconds(rnd.Next(1, 59));

            if (d2.Hour < 8)
            {
                d2 = DateTime.Today.AddHours(8);
            }

            DateTime d4 = d2;

            var windowId = recivedWindowsCount.HasValue ? rnd.Next(recivedWindowsCount.Value) : 1;

            List<DMdmObjectsUpload> mdmObjects = new();

            // 4 - Формирование талона
            var request4 = new MdmTicket { TicketMfcUuid = dServiceId, IdAppointmentType = rnd.Next(0,2), IdTicketType = 0, TicketTimestamp = d4.ToString("yyyy-MM-dd HH:mm:ss.fffzz", new CultureInfo("ru-RU")) };
            var response4 = await MdmDataServicesObjectsAttributesAsync(request4, d4, 4, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 4");
            mdmObjects.Add(response4);

            // 2 - Выдача талона
            var request2 = new MdmTicketIssued { TicketIssuedMfcUuid = dServiceId, TicketIssuedTimestamp = d2.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), TicketMfcUuid = request4.TicketMfcUuid };
            var response2 = await MdmDataServicesObjectsAttributesAsync(request2, d2, 2, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 2");
            mdmObjects.Add(response2);

            // 3 - Вызов талона
            var request3 = new MdmTicketCalled { TicketCalledMfcUuid = dServiceId, TicketCalledTimestamp = d3.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), TicketIssuedMfcUuid = request2.TicketIssuedMfcUuid, WindowId = windowId };
            var response3 = await MdmDataServicesObjectsAttributesAsync(request3, d3, 3, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 3");
            mdmObjects.Add(response3);

            // 34 - Завершение обработки талона
            var request34 = new MdmTicketResult { TicketResultMfcUuid = dServiceId, IdTicketResult = 0, TicketCalledMfcUuid = request3.TicketCalledMfcUuid, TicketResultTimestamp = d34.ToString("yyyy-MM-dd HH:mm:ss.fffzz", new CultureInfo("ru-RU")) };
            var response34 = await MdmDataServicesObjectsAttributesAsync(request34, d34, 34, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 34");
            mdmObjects.Add(response34);

            //5 - Начало процесса регистрации запроса на услугу
            var request5 = new MdmReceptionStarted { IdReceptionChannel = 1, ReceptionStartedMfcUuid = dServiceId, ReceptionStartedTimestamp = d5.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), TicketResultMfcUuid = request34.TicketResultMfcUuid, WindowId = windowId };
            var response5 = await MdmDataServicesObjectsAttributesAsync(request5, d5, 5, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 5");
            mdmObjects.Add(response5);

            // 8 - Завершение процесса регистрации запроса на услугу
            var request8 = new MdmReceptionEnded { IdReceptionResult = 0, ReceptionStartedMfcUuid = request5.ReceptionStartedMfcUuid, ReceptionEndedMfcUuid = dServiceId, ReceptionEndedTimestamp = d8.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), WindowId = windowId };
            var response8 = await MdmDataServicesObjectsAttributesAsync(request8, d8, 8, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 8");
            mdmObjects.Add(response8);

            // 25 Формирование дела
            var request25 = new MdmApplication { ApplicationMfcUuid = dServiceId, ApplicationTimestamp = d25.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), ReceptionEndedMfcUuid = request8.ReceptionEndedMfcUuid, IsComplex = false, FromOtherMfc = false };
            var response25 = await MdmDataServicesObjectsAttributesAsync(request25, d25, 25, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 25");
            mdmObjects.Add(response25);

            // 11 Взятие услуги в работу работником МФЦ
            var request11 = new MdmServiceProcessingStarted { ServiceProcessingStartedMfcUuid = dServiceId, ApplicationMfsUuid = request25.ApplicationMfcUuid, ServiceProcessingStartedTimestamp = d11.ToString("yyyy-MM-dd HH:mm:ss.fffzz", new CultureInfo("ru-RU")), ServiceMfcUuid = sprServicesSubId };
            var response11 = await MdmDataServicesObjectsAttributesAsync(request11, d11, 11, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 11");
            mdmObjects.Add(response11);

            return mdmObjects;
        }


        public async Task<List<DMdmObjectsUpload>?> MdmСonsultationDataServicesObjectsAsync(Guid dServiceId, Guid officeIdMdm, Guid sprServicesSubId, Guid dServiceRouteStageId, int? recivedWindowsCount)
        {
            DateTime date = DateTime.Now;

            DateTime consultationFinished = date;
            DateTime consultationStarted = date.AddMinutes(-2);

            DateTime d34 = consultationStarted.AddMinutes(-1);
            DateTime d3 = d34;

            var rnd = new Random();

            int minutes = rnd.Next(1, 99) switch
            {
                <= 85 => rnd.Next(1, 14),
                > 85 and <= 93 => rnd.Next(15, 29),
                > 93 => rnd.Next(30, 50),
            };

            var interimDate = d3.AddMinutes(-minutes);

            DateTime d2 = DateTime.Today.AddHours(interimDate.Hour).AddMinutes(interimDate.Minute).AddSeconds(rnd.Next(1, 59));

            if (d2.Hour < 8)
            {
                d2 = DateTime.Today.AddHours(8);
            }

            DateTime d4 = d2;

            var windowId = recivedWindowsCount.HasValue ? rnd.Next(recivedWindowsCount.Value) : 1;

            List<DMdmObjectsUpload> mdmObjects = new();

            // 4 - Формирование талона
            var request4 = new MdmTicket { TicketMfcUuid = dServiceId, IdAppointmentType = 0, IdTicketType = 0, TicketTimestamp = d4.ToString("yyyy-MM-dd HH:mm:ss.fffzz", new CultureInfo("ru-RU")) };
            var response4 = await MdmDataServicesObjectsAttributesAsync(request4, d4, 4, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 4");
            mdmObjects.Add(response4);

            // 2 - Выдача талона
            var request2 = new MdmTicketIssued { TicketIssuedMfcUuid = dServiceId, TicketIssuedTimestamp = d2.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), TicketMfcUuid = request4.TicketMfcUuid };
            var response2 = await MdmDataServicesObjectsAttributesAsync(request2, d2, 2, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 2");
            mdmObjects.Add(response2);

            // 3 - Вызов талона
            var request3 = new MdmTicketCalled { TicketCalledMfcUuid = dServiceId, TicketCalledTimestamp = d3.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), TicketIssuedMfcUuid = request2.TicketIssuedMfcUuid, WindowId = windowId };
            var response3 = await MdmDataServicesObjectsAttributesAsync(request3, d3, 3, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 3");
            mdmObjects.Add(response3);

            // 34 - Завершение обработки талона
            var request34 = new MdmTicketResult { TicketResultMfcUuid = dServiceId, IdTicketResult = 0, TicketCalledMfcUuid = request3.TicketCalledMfcUuid, TicketResultTimestamp = d34.ToString("yyyy-MM-dd HH:mm:ss.fffzz", new CultureInfo("ru-RU")) };
            var response34 = await MdmDataServicesObjectsAttributesAsync(request34, d34, 34, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 34");
            mdmObjects.Add(response34);

            //9 - Проведение консультации
            var request9 = new MdmConsultation { ConsultationEventChanel = 1, ConsultationEventMfcUuid = dServiceId, ConsultationStartedTimestamp = consultationStarted.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), ConsultationEndedTimestamp = consultationFinished.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), TicketResultMfcUuid = request34.TicketResultMfcUuid, WindowId = windowId };
            var response9 = await MdmDataServicesObjectsAttributesAsync(request9, consultationStarted, 9, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 9");
            mdmObjects.Add(response9);

            return mdmObjects;
        }


        public async Task<List<DMdmObjectsUpload>?> MdmQueryObjectsAsync(Guid dServiceId, Guid officeIdMdm)
        {
            List<DMdmObjectsUpload> mdmObjects = new();

            var request17 = new MdmQuery { QueryMfcUuid = Guid.NewGuid(), QueryTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffzz", new CultureInfo("ru-RU")), QueryType = "1" };
            var response17 = await MdmDataServicesObjectsAttributesAsync(request17, DateTime.Now, 17, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 17");
            mdmObjects.Add(response17);

            return mdmObjects;
        }

        public async Task<List<DMdmObjectsUpload>?> MdmServiceProcessingHoldObjectsAsync(Guid dServiceId, Guid officeIdMdm)
        {
            List<DMdmObjectsUpload> mdmObjects = new();

            var request18 = new MdmServiceProcessingHold { ServiceProcessingHoldMfcId = dServiceId, ServiceProcessingHoldTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), ServiceProcessingStartedMfcUuid = dServiceId, IdServiceHoldReason = "0" };
            var response18 = await MdmDataServicesObjectsAttributesAsync(request18, DateTime.Now, 18, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 18");
            mdmObjects.Add(response18);

            return mdmObjects;
        }

        public async Task<List<DMdmObjectsUpload>?> MdmServiceProcessingEndedObjectsAsync(Guid dServiceId, Guid officeIdMdm, int value, bool isDeadLine, Guid dServiceRouteStageId)
        {
            List<DMdmObjectsUpload> mdmObjects = new();

            var request22 = new MdmServiceProcessingEnded { ApplicationProcessingEndedMfcUuid = dServiceId, ApplicationProcessingEndedTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), ApplicationProcessingEndedCause = value.ToString(new CultureInfo("ru-RU")), DeadlineViolated = isDeadLine, ServicePreocessingStartedMfcUuid = dServiceId };
            var response22 = await MdmDataServicesObjectsAttributesAsync(request22, DateTime.Now, 22, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 22");
            mdmObjects.Add(response22);

            return mdmObjects;
        }

        public async Task<List<DMdmObjectsUpload>?> MdmServiceResultsReceivedObjectsAsync(Guid dServiceId, Guid officeIdMdm)
        {
            List<DMdmObjectsUpload> mdmObjects = new();

            var request23 = new MdmServiceResultsReceived { ApplicantGotResultMfcUuid = dServiceId, ApplicantGotResultTimestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffzz", CultureInfo.InvariantCulture), ChanelType = "1", ServiceProcessingEndedMfcUuid = dServiceId };
            var response23 = await MdmDataServicesObjectsAttributesAsync(request23, DateTime.Now, 23, officeIdMdm, dServiceId) ?? throw new InvalidOperationException("Ошибка с МДМ объект 23");
            mdmObjects.Add(response23);

            return mdmObjects;
        }

        private async Task<DMdmObjectsUpload?> MdmDataServicesObjectsAttributesAsync<T>(T request, DateTime date, int type, Guid officeIdMdm, Guid dServiceId)
        {
            try
            {
                var mdmAttributes = await _context.SMdmObjectAttributes.AsNoTracking().Where(w => w.SMdmObjectTypeV2Id == type).Select(s => new { s.Id, s.ObjectAttributeMnemo }).ToListAsync();

                var json = JsonConvert.SerializeObject(request);
                var dictonary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? throw new InvalidOperationException();
                return new DMdmObjectsUpload
                {
                    CreatedDate = date,
                    DServicesId = dServiceId,
                    SOfficesIdMdm = officeIdMdm,
                    SMdmObjectTypeId = type,
                    DMdmObjectsAttributesUploads = mdmAttributes.Select(s => new DMdmObjectsAttributesUpload
                    {
                        SMdmObjectAttributeId = s.Id,
                        MdmAttributeValue = dictonary[s.ObjectAttributeMnemo],
                    }).ToList()
                };
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
    }
}
