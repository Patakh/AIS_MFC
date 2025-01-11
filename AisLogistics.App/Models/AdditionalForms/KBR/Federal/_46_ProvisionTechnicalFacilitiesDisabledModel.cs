namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// ЗАЯВЛЕНИЕ
/// о предоставлении государственной услуги по обеспечению инвалидов техническими средствами реабилитации
/// </summary>
public class _46_ProvisionTechnicalFacilitiesDisabledModel : AbstractAdditionalFormModel
{
    #region Перечень технических средств реабилитации, услуг с указанием вида обеспечения

    /// <summary>
    /// Техническое средство реабилитации или услуга с указанием вида обеспечения
    /// </summary>
    /// <param name="Name">Наименование</param>
    /// <param name="ProvisionTypeId">Вид обеспечения: 1 - предостав¬ление изделия, оказание услуги; 2 - выплата компен-сации расходов; 3 - формиро¬вание электрон¬ного сертифи¬ката</param>
    public class TechReabilitationService
    {
        public string? Name { get; set; }
        public int ProvisionTypeId { get; set; }
    };

    /// <summary>
    /// Перечень
    /// </summary>
    public TechReabilitationService[] TechReabilitationServiceList { get; set; } = Array.Empty<TechReabilitationService>();

    #endregion

    #region Способ перечисления компенсации за самостоятельно приобретенные изделия, оказанные услуги

    /// <summary>
    /// Способ перечисления компенсации за самостоятельно приобретенные изделия, оказанные услуги
    /// 1 - перечисление на счет, открытый в кредитной организации
    /// 2 - почтовый перевод
    /// 3 - перечисление на платежную карту, являющуюся национальным платежным инструментом
    /// </summary>
    public int TransferCompensationMethodId { get; set; }

    /// <summary>
    /// № карты, если выбран TransferCompensationMethodId = 3 - перечисление на платежную карту
    /// </summary>
    public string? TransferCompensationCardNumber { get; set; }

    #endregion

    #region Обеспечение с использованием электронного сертификата

    /// <summary>
    /// № платежной карты
    /// </summary>
    public string ProvisionEelectronicCertificateCardNumber { get; set; } = null!;

    /// <summary>
    /// уведомлен о необходимости предоставления актуального номера платежной карты
    /// </summary>
    public bool ProvisionEelectronicCertificateNotified { get; set; }

    #endregion

    #region Сопровождение

    /// <summary>
    /// Необходимо сопровождение
    /// </summary>
    public bool AssistantRequired { get; set; }

    /// <summary>
    /// Фамилия, имя, отчество сопровождающего
    /// </summary>
    public string? AssistantFullName { get; set; }

    /// <summary>
    /// Документ, удостоверяющий личность сопровождающего - наименование
    /// </summary>
    public string? AssistantDocumentName { get; set; }

    /// <summary>
    /// Документ, удостоверяющий личность сопровождающего - серия
    /// </summary>
    public string? AssistantDocumentSeries { get; set; }

    /// <summary>
    /// Документ, удостоверяющий личность сопровождающего - номер
    /// </summary>
    public string? AssistantDocumentNumber { get; set; }

    /// <summary>
    /// Документ, удостоверяющий личность сопровождающего - дата выдачи
    /// </summary>
    public string? AssistantDocumentDate { get; set; }

    /// <summary>
    /// Документ, удостоверяющий личность сопровождающего - наименование органа, выдавшего документ
    /// </summary>
    public string? AssistantDocumentGivenBy { get; set; }

    #endregion

    #region Проведение медико-технической экспертизы

    /// <summary>
    /// Желаемое место проведения медико-технической экспертизы
    /// 1 - место осуществления приема территориальным органом Фонда социального страхованияместо осуществления приема территориальным органом Фонда социального страхования
    /// 2 - место пребывания заявителя вследствие затруднения в транспортировке технического средства
    /// 3 - место пребывания заявителя вследствие состояния здоровья заявителя
    /// </summary>
    public int MedicalExpertisePlaceId { get; set; }

    #endregion

    #region Перечень прилагаемых заявителем документов


    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();
    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Количество листов оригиналов
        /// </summary>
        public string? NumdberOriginals { get; set; }
        /// <summary>
        /// Количество листов копий
        /// </summary>
        public string? NumdberCopies { get; set; }
    }

    #endregion

    #region Обратная связь с заявителем

    /// <summary>
    /// Предпочтительный способ информирования заявителя
    /// 1 - по домашнему телефону
    /// 2 - по мобильному телефону
    /// 3 - смс-информирование
    /// 4 - посредством почтовых отправлений
    /// 5 - по электронной почте
    /// 6 - иным способом   
    /// </summary>
    public int ApplicantInformingMethodId { get; set; }

    /// <summary>
    /// Наименование метода информирования заявителя, если ApplicantInformingMethodId = 6 - иным способом
    /// </summary>
    public string? ApplicantInformingOtherMetodName { get; set; }

    /// <summary>
    /// Способ направления заявителю результата предоставления государственной услуги
    /// 1 - вручить в территориальном органе Фонда
    /// 2 - вручить в многофункциональном центре
    /// 3 - направить по почте
    /// 4 - направить в форме электронного документа
    /// </summary>
    public int ApplicantSendingResultMethodId { get; set; }

    /// <summary>
    /// Подтверждаю согласие на участие в смс-опросе о качестве предоставления услуг
    /// </summary>
    public bool ApplicantSMSQualitySurveyConfirmed { get; set; }

    #endregion
}
