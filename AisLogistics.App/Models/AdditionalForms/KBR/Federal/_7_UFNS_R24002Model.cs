namespace AisLogistics.App.Models;

/// <summary>
/// Заявление
/// о внесении изменений в сведения о крестьянском(фермерском) хозяйстве,
/// содержащиеся в Едином государственном реестре индивидуальных предпринимателей
/// </summary>
public class _7_UFNS_R24002Model
{
    /// <summary>
    /// Сведения о крестьянском (фермерском) хозяйстве, содержащиеся в Едином государственном реестре индивидуальных
    /// На русском языке
    /// Фамилия
    /// </summary>
    public string LastNameIP { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstNameIP { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string SecondNameIP { get; set; }

    /// <summary>
    ///  Причина внесения сведений
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// С использованием букв латинского алфавита
    /// Фамилия
    /// </summary>
    public string LastNameLatIP { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstNameLatIP { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string SecondNameLatIP { get; set; }

    /// <summary> 
    /// ОГРНИП
    /// </summary>
    public string OGRNIP { get; set; }

    /// <summary> 
    /// Дата рождения
    /// </summary>
    public string BirthsDateIP { get; set; }

    /// <summary> 
    /// Место рождения
    /// </summary>
    public string BirthsPlaceIP { get; set; }

    /// <summary> 
    /// Сведения о документе, удостоверяющем личность
    /// </summary>
    public Document IdentityDocumentIP { get; set; }
    /// <summary> 
    /// тип гражданства
    /// </summary>
    public string CitizenshipType { get; set; }

    /// <summary> 
    /// код страны гражданства
    /// </summary>
    public string CitizenshipCode { get; set; }

    /// <summary> 
    /// Сведения о документе, подтверждающем право иностранного гражданина или лица без гражданства
    /// </summary>
    public Document RightDocument  { get; set; }
      
    /// <summary>
    /// 2. Причина представления заявления: 
    /// </summary>
    public string ApplicationReasonTypeId { get; set; }

    /// <summary>
    /// Адрес электронной почты индивидуального предпринимателя
    /// </summary>
    public string EMailChangeTypeId { get; set; }

    /// <summary>
    /// 4. Индивидуальный предприниматель является главой крестьянского (фермерского) хозяйства: 
    /// </summary>
    public string FarmHoldingHeadChangeTypeId { get; set; }

    /// <summary>
    /// Для значения 1 указать адрес электронной почты
    /// </summary>
    public string FarmHoldingHeadChangeEmaill { get; set; }

    /// <summary>
    /// 5. Индивидуальному предпринимателю принадлежит производственный объект: 
    /// </summary>
    public string ProductionFacilityOwnerChangeTypeId { get; set; }
     
    /// <summary>
    /// Код основного вида деятельности
    /// </summary>
    public string MainActivityCodeIncluded { get; set; }    

    /// <summary>
    /// Код основного вида деятельности
    /// </summary>
    public string MainActivityCodeExcluded { get; set; }
     
    /// <summary>
    /// Документы, связные с предоставлением государственной услуги: 
    /// </summary>
    public string DocumentSendingTypeId { get; set; }

    /// <summary>
    /// Адрес электронной почты, если выбран DocumentSendingTypeId = 1
    /// </summary>
    public string DocumentSendingEmail { get; set; }
     
    /// <summary>
    /// Заявление представлено непосредственно заявителем: 
    /// </summary>
    public string ApplicationProvidedTypeId { get; set; }

    /// <summary>
    /// Лицо, засвидетельствовавшее подлинность подписи заявителя: 
    /// </summary>
    public string PersonAuthenticatedSignatureTypeId { get; set; }

    /// <summary>
    /// ИНН лица, засвидетельствовавшего подлинность подписи заявителя
    /// </summary>
    public string PersonAuthenticatedSignatureINN { get; set; }
       
    /// <summary>
    /// Коды дополнительных видов деятельности
    /// </summary>
    public AdditionalActivityCodeModel[] AdditionalActivityCodesIncludedList { get; set; }

    /// <summary>
    /// Коды дополнительных видов деятельности
    /// </summary>
    public AdditionalActivityCodeModel[] AdditionalActivityCodesExcludedList { get; set; }

    public class AdditionalActivityCodeModel
    {
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Code4 { get; set; }
    }


    public class Document
    {
        /// <summary> 
        /// Вид документа
        /// </summary>
        public string  Type { get; set; }

        /// <summary> 
        /// номер документа
        /// </summary>
        public string Number { get; set; }

        /// <summary> 
        /// серия документа
        /// </summary>
        public string Series { get; set; }

        /// <summary> 
        /// дата выдачи документа
        /// </summary>
        public string IssueDate { get; set; }

        /// <summary> 
        /// кем выдан
        /// </summary>
        public string Issuer { get; set; }

        /// <summary> 
        /// код подразделения
        /// </summary>
        public string IssuerCode { get; set; }

        /// <summary> 
        /// Срок действия документа
        /// </summary>
        public string ValidityPeriod { get; set; }

        /// <summary> 
        /// дата действия документа
        /// </summary>
        public string ValidityPeriodDate { get; set; }
    }
}
