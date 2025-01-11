namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// заявления о присвоении объекту адресации адреса или аннулировании его адреса
/// </summary>
public class AssigningCancelingAddressModel
{
    /// <summary>
    /// Регистрационный номер
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// Вид объекта адресации
    /// 1 - Земельный участок
    /// 2 - Сооружение
    /// 3 - Объект незавершенного строительства
    /// 4 - Здание
    /// 5 - Помещение
    /// </summary>
    public int AddressedObjectTypeId { get; set; }

    /// <summary>
    /// 1 - Присвоить адрес
    /// 2 - Аннулировать адрес объекта регистрации
    /// </summary>
    public int AddressApplicationTypeId { get; set; }


    #region Присвоить адрес 

    /// <summary>
    /// Присвоить адрес в связи с:
    /// 1 - Образованием земельного участка(ов) из земель, находящихся в государственной или муниципальной собственности
    /// 2 - Образованием земельного участка(ов) путем раздела земельного участка
    /// 3 - Образованием земельного участка путем объединения земельных участков
    /// 4 - Образованием земельного участка(ов) путем выдела из земельного участка
    /// 5 - Образованием земельного участка(ов) путем перераспределения земельных участков
    /// 6 - Строительством, реконструкцией здания, сооружения
    /// 7 - Подготовкой в отношении следующего объекта адресации документов, необходимых для осуществления государственного кадастрового учета указанного объекта адресации, в случае, если в соответствии с Градостроительным кодексом Российской Федерации, законодательством субъектов Российской Федерации о градостроительной деятельности для его строительства, реконструкции выдача разрешения на строительство не требуется
    /// 8 - Переводом жилого помещения в нежилое помещение и нежилого помещения в жилое помещение
    /// 9 - Образованием помещения(ий) в здании, сооружении путем раздела здания, сооружения
    /// 10 - Образованием помещения(ий) в здании, сооружении путем раздела помещения
    /// 11 - Образованием помещения в здании, сооружении путем объединения помещений в здании, сооружении
    /// 12 - Образованием помещения в здании, сооружении путем переустройства и (или) перепланировки мест общего пользования
    /// </summary>
    public int AssigningAddressReasonId { get; set; }


    #region 1. Образованием земельного участка(ов) из земель, находящихся в государственной или муниципальной собственности

    /// <summary>
    /// Количество образуемых земельных участков, если AssigningAddressReasonId = 1
    /// </summary>
    public int LandPlotsAmount1 { get; set; }

    /// <summary>
    /// Дополнительная информация, если AssigningAddressReasonId = 1
    /// </summary>
    public string? AdditionalInformation1 { get; set; }

    #endregion

    #region 2. Образованием земельного участка(ов) путем раздела земельного участка

    /// <summary>
    /// Количество образуемых земельных участков, если AssigningAddressReasonId = 2
    /// </summary>
    public int LandPlotsAmount2 { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка, раздел которого осуществляется, если AssigningAddressReasonId = 2
    /// </summary>
    public string? CadastralNumber2 { get; set; }

    /// <summary>
    /// Адрес земельного участка, раздел которого осуществляется, если AssigningAddressReasonId = 2
    /// </summary>
    public string? Address2 { get; set; }

    #endregion

    #region 3. Образованием земельного участка путем объединения земельных участков

    /// <summary>
    /// Количество объединяемых земельных участков, если AssigningAddressReasonId = 3
    /// </summary>
    public int LandPlotsAmount3 { get; set; }

    /// <summary>
    /// Кадастровый номер объединяемого земельного участка, если AssigningAddressReasonId = 3
    /// </summary>
    public string? CadastralNumber3 { get; set; }

    /// <summary>
    ///Адрес объединяемого земельного участка, если AssigningAddressReasonId = 3
    /// </summary>
    public string? Address3 { get; set; }

    #endregion


    #region 4. Образованием земельного участка(ов) путем выдела из земельного участка

    /// <summary>
    /// Количество образуемых земельных участков (за исключением земельного участка, из которого осуществляется выдел), если AssigningAddressReasonId = 4
    /// </summary>
    public int LandPlotsAmount4 { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка, из которого осуществляется выдел, если AssigningAddressReasonId = 4
    /// </summary>
    public string? CadastralNumber4 { get; set; }

    /// <summary>
    /// Адрес земельного участка, из которого осуществляется выдел, если AssigningAddressReasonId = 4
    /// </summary>
    public string? Address4 { get; set; }

    #endregion

    #region 5. Образованием земельного участка(ов) путем перераспределения земельных участков

    /// <summary>
    /// Количество образуемых земельных участков, если AssigningAddressReasonId = 5
    /// </summary>
    public int LandPlotsAmount5 { get; set; }

    /// <summary>
    /// Количество земельных участков, которые перераспределяются
    /// </summary>
    public int LandPlotsRedistributedNumber { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка, который перераспределяется, если AssigningAddressReasonId = 5
    /// </summary>
    public string? CadastralNumber5 { get; set; }

    /// <summary>
    ///Адрес земельного участка, который перераспределяется, если AssigningAddressReasonId = 5
    /// </summary>
    public string? Address5 { get; set; }

    #endregion

    #region 6. Строительством, реконструкцией здания, сооружения

    /// <summary>
    /// Наименование объекта строительства (реконструкции) в соответствии с проектной документацией, если AssigningAddressReasonId = 6
    /// </summary>
    public string? ConstructionObjectName6 { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка, на котором осуществляется строительство (реконструкция), если AssigningAddressReasonId = 6
    /// </summary>
    public string? CadastralNumber6 { get; set; }

    /// <summary>
    ///Адрес земельного участка, на котором осуществляется строительство (реконструкция), если AssigningAddressReasonId = 6
    /// </summary>
    public string? Address6 { get; set; }

    #endregion

    #region 7. Подготовкой в отношении следующего объекта адресации документов, необходимых для осуществления государственного кадастрового учета указанного объекта адресации, в случае, если в соответствии с Градостроительным кодексом Российской Федерации, законодательством субъектов Российской Федерации о градостроительной деятельности для его строительства, реконструкции выдача разрешения на строительство не требуется

    /// <summary>
    /// Тип здания, сооружения, объекта незавершенного строительства
    /// </summary>
    public string? ConstructionObjectType { get; set; }

    /// <summary>
    /// Наименование объекта строительства (реконструкции) (при наличии проектной документации указывается в соответствии с проектной документацией), если AssigningAddressReasonId = 7
    /// </summary>
    public string? ConstructionObjectName7 { get; set; }

    /// <summary>
    /// Кадастровый номер земельного участка, на котором осуществляется строительство (реконструкция), если AssigningAddressReasonId = 7
    /// </summary>
    public string? CadastralNumber7 { get; set; }

    /// <summary>
    /// Адрес земельного участка, на котором осуществляется строительство (реконструкция), если AssigningAddressReasonId = 7
    /// </summary>
    public string? Address7 { get; set; }

    #endregion

    #region 8. Переводом жилого помещения в нежилое помещение и нежилого помещения в жилое помещение

    /// <summary>
    /// Кадастровый номер помещения, если AssigningAddressReasonId = 8
    /// </summary>
    public string? CadastralNumber8 { get; set; }

    /// <summary>
    /// Адрес помещения, если AssigningAddressReasonId = 8
    /// </summary>
    public string? Address8 { get; set; }

    #endregion

    #region 9. Образованием помещения(ий) в здании, сооружении путем раздела здания, сооружения

    /// <summary>
    /// Назначение помещения, если AssigningAddressReasonId = 9
    /// 1 - Жилое помещение
    /// 2 - Нежилое помещение
    /// </summary>
    public int PremiseFormationTypeId9 { get; set; }

    /// <summary>
    /// Кол-во образуемых помещений, если AssigningAddressReasonId = 9
    /// </summary>
    public int PremiseAmount9 { get; set; }

    /// <summary>
    /// Кадастровый номер помещения, если AssigningAddressReasonId = 9
    /// </summary>
    public string? CadastralNumber9 { get; set; }

    /// <summary>
    /// Адрес помещения, если AssigningAddressReasonId = 9
    /// </summary>
    public string? Address9 { get; set; }

    /// <summary>
    /// Дополнительная информация, если AssigningAddressReasonId = 9
    /// </summary>
    public string? AdditionalInformation9 { get; set; }

    #endregion

    #region 10. Образованием помещения(ий) в здании, сооружении путем раздела помещения

    /// <summary>
    /// Назначение помещения, если AssigningAddressReasonId = 10
    /// 1 - Жилое помещение
    /// 2 - Нежилое помещение
    /// </summary>
    public int PremiseFormationTypeId10 { get; set; }

    /// <summary>
    /// Вид помещения
    /// </summary>
    public string? PremiseType { get; set; }

    /// <summary>
    /// Кол-во помещений, если AssigningAddressReasonId = 10
    /// </summary>
    public int PremiseAmount10 { get; set; }

    /// <summary>
    /// Кадастровый номер помещения, раздел которого осуществляется, если AssigningAddressReasonId = 10
    /// </summary>
    public string? CadastralNumber10 { get; set; }

    /// <summary>
    /// Адрес помещения, если AssigningAddressReasonId = 10
    /// </summary>
    public string? Address10 { get; set; }

    /// <summary>
    /// Дополнительная информация, если AssigningAddressReasonId = 10
    /// </summary>
    public string? AdditionalInformation10 { get; set; }

    #endregion

    #region 11. Образованием помещения в здании, сооружении путем объединения помещений в здании, сооружении

    /// <summary>
    /// Назначение помещения, если AssigningAddressReasonId = 11
    /// 1 - Жилое помещение
    /// 2 - Нежилое помещение
    /// </summary>
    public int PremiseFormationTypeId11 { get; set; }

    /// <summary>
    /// Количество объединяемых помещений, если AssigningAddressReasonId = 11
    /// </summary>
    public int PremiseAmount11 { get; set; }

    /// <summary>
    /// Кадастровый номер объединяемого помещения, если AssigningAddressReasonId = 11
    /// </summary>
    public string? CadastralNumber11 { get; set; }

    /// <summary>
    /// Адрес объединяемого помещения, если AssigningAddressReasonId = 11
    /// </summary>
    public string? Address11 { get; set; }

    /// <summary>
    /// Дополнительная информация, если AssigningAddressReasonId = 11
    /// </summary>
    public string? AdditionalInformation11 { get; set; }

    #endregion

    #region 12. Образованием помещения в здании, сооружении путем переустройства и (или) перепланировки мест общего пользования

    /// <summary>
    /// Назначение помещения, если AssigningAddressReasonId = 12
    /// 1 - Жилое помещение
    /// 2 - Нежилое помещение
    /// </summary>
    public int PremiseFormationTypeId12 { get; set; }

    /// <summary>
    /// Количество образуемых помещений, если AssigningAddressReasonId = 12
    /// </summary>
    public int PremiseAmount12 { get; set; }

    /// <summary>
    /// Кадастровый номер здания, сооружения, если AssigningAddressReasonId = 12
    /// </summary>
    public string? CadastralNumber12 { get; set; }

    /// <summary>
    /// Адрес здания, сооружения, если AssigningAddressReasonId = 12
    /// </summary>
    public string? Address12 { get; set; }

    /// <summary>
    /// Дополнительная информация, если AssigningAddressReasonId = 12
    /// </summary>
    public string? AdditionalInformation12 { get; set; }

    #endregion

    #endregion



    #region Аннулировать адрес объекта регистрации

    /// <summary>
    /// Наименование страны
    /// </summary>
    public string? CountryName { get; set; }

    /// <summary>
    /// Наименование субъекта Российской Федерации
    /// </summary>
    public string? SubjectRussianFederationName { get; set; }

    /// <summary>
    /// Наименование муниципального района, городского округа или внутригородской территории (для городов федерального значения) 
    /// в составе субъекта Российской Федерации
    /// </summary>
    public string? MunicipalityName { get; set; }

    /// <summary>
    /// Наименование поселения
    /// </summary>
    public string? SettlementName { get; set; }

    /// <summary>
    /// Наименование внутригородского района городского округа
    /// </summary>
    public string? IntracityName { get; set; }

    /// <summary>
    /// Наименование населенного пункта
    /// </summary>
    public string? LocalityName { get; set; }

    /// <summary>
    /// Наименование элемента планировочной структуры
    /// </summary>
    public string? PlanningStructureElementName { get; set; }

    /// <summary>
    /// Наименование элемента улично-дорожной сети
    /// </summary>
    public string? RoadNetworkElementName { get; set; }

    /// <summary>
    /// Номер земельного участка
    /// </summary>
    public string? LandPlotNumber { get; set; }

    /// <summary>
    /// Тип и номер здания, сооружения или объекта незавершенного строительства
    /// </summary>
    public string? ConstructionObjectTypeAndNumber { get; set; }

    /// <summary>
    /// Тип и номер помещения, расположенного в здании или сооружении
    /// </summary>
    public string? PremiseTypeAndNumber { get; set; }

    /// <summary>
    /// Тип и номер помещения в пределах квартиры (в отношении коммунальных квартир)
    /// </summary>
    public string? PremiseFlatTypeAndNumber { get; set; }

    public string? AdditionalInfo { get; set; }

    /// <summary>
    /// Аннулировать в связи с:
    /// 1 - Прекращением существования объекта адресации
    /// 2 - Отказом в осуществлении кадастрового учета объекта адресации по основаниям, указанным в пунктах 1 и 3 части 2 статьи 27 Федерального закона 
    /// от 24 июля 2007 года № 221-ФЗ "О государственном кадастре недвижимости" (Собрание законодательства Российской Федерации, 2007, № 31, ст. 4017; 
    /// 2008, № 30, ст. 3597; 2009, № 52, ст. 6410; 2011, № 1, ст. 47; № 49, ст. 7061; № 50, ст. 7365; 2012, № 31, ст. 4322; 2013, № 30, ст. 4083; 
    /// официальный интернет-портал правовой информации www.pravo.gov.ru, 23 декабря 2014 г.)
    /// 3 - Присвоением объекту адресации нового адреса
    /// </summary>
    public int CancelingTypeId { get; set; }

    public string? CancelingAdditionInformation { get; set; }

    #region Собственник объекта адресации

    /// <summary>
    /// Тип собственника
    /// 1 - физическое лицо
    /// 2 - юридическое лицо
    /// 3 - вещное право на объект адресации
    /// </summary>
    public int OwnerTypeId { get; set; }

    /// <summary>
    /// Фамилия, физическое лицо
    /// </summary>
    public string? OwnerIndividualLastName { get; set; }

    /// <summary>
    /// Имя, физическое лицо
    /// </summary>
    public string? OwnerIndividualFirstName { get; set; }

    /// <summary>
    /// Отчество, физическое лицо
    /// </summary>
    public string? OwnerIndividualMiddleName { get; set; }

    /// <summary>
    /// ИНН, физическое лицо
    /// </summary>
    public string? OwnerIndividualInn { get; set; }

    /// <summary>
    /// Вид документа, удостоверяющего личность
    /// </summary>
    public string? OwnerIndividualDocumentType { get; set; }

    /// <summary>
    /// Серия документа, удостоверяющего личность
    /// </summary>
    public string? OwnerIndividualDocumentSeries { get; set; }

    /// <summary>
    /// Номер документа, удостоверяющего личность
    /// </summary>
    public string? OwnerIndividualDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи документа, удостоверяющего личность
    /// </summary>
    public string? OwnerIndividualDocumentGivenDate { get; set; }

    /// <summary>
    ///Кем выдан документ, удостоверяющий личность
    /// </summary>
    public string? OwnerIndividualDocumentGivenBy { get; set; }

    /// <summary>
    /// Почтовый адрес, физическое лицо
    /// </summary>
    public string? OwnerIndividualAddress { get; set; }

    /// <summary>
    /// Телефон для связи, физическое лицо
    /// </summary>
    public string? OwnerIndividualPhone { get; set; }

    /// <summary>
    /// Адрес электронной почты, физическое лицо
    /// </summary>
    public string? OwnerIndividualEMail { get; set; }

    /// <summary>
    /// Полное наименование, юридическое лицо
    /// </summary>
    public string? OwnerLegalEntityFullName { get; set; }

    /// <summary>
    /// ИНН, юридическое лицо
    /// </summary>
    public string? OwnerLegalEntityInn { get; set; }

    /// <summary>
    /// КПП, юридическое лицо
    /// </summary>
    public string? OwnerLegalEntityKpp { get; set; }

    /// <summary>
    /// Страна регистрации (инкорпорации) для иностранного юридического лица
    /// </summary>
    public string? OwnerLegalEntityForeignCountry { get; set; }

    /// <summary>
    /// Дата регистрации для иностранного юридического лица
    /// </summary>
    public string? OwnerLegalEntityForeignRegistrationDate { get; set; }

    /// <summary>
    /// Номер регистрации для иностранного юридического лица
    /// </summary>
    public string? OwnerLegalEntityForeignRegistrationNumber { get; set; }

    /// <summary>
    /// Почтовый адрес, юридическое лицо
    /// </summary>
    public string? OwnerLegalEntityAddress { get; set; }

    /// <summary>
    /// Телефон для связи, юридическое лицо
    /// </summary>
    public string? OwnerLegalEntityPhone { get; set; }

    /// <summary>
    /// Адрес электронной почты, юридическое лицо
    /// </summary>
    public string? OwnerLegalEntityEMail { get; set; }

    #region Вещное право

    /// <summary>
    /// Вещное право на объект адресации:
    /// 1 - право собственности
    /// 2 - право хозяйственного ведения имуществом на объект адресации
    /// 3 - право оперативного управления имуществом на объект адресации
    /// 4 - право пожизненно наследуемого владения земельным участком
    /// 5 - право постоянного (бессрочного) пользования земельным участком
    /// </summary>
    public string? OwnerProprietaryTypeId { get; set; }

    #endregion

    #endregion

    #region Способ получения документов

    /// <summary>
    /// Способ получения документов:
    /// 1 - Лично
    /// 2 - В МФЦ
    /// 3 - почтовым отправлением по адресу
    /// 4 - в личном кабинете единого портала государственных и муниципальных услуг
    /// 5 - в личном кабинете федеральной информационной адресной системы
    /// 6 - на адрес электронной почты
    /// </summary>
    public int DocumentReceivingMethodId { get; set; }

    /// <summary>
    /// Адрес почтового отправления, если DocumentReceivingMethodId = 3
    /// </summary>
    public string? DocumentReceivingByPostAddress { get; set; }

    /// <summary>
    /// Адрес электронной почты, если DocumentReceivingMethodId = 6
    /// </summary>
    public string? DocumentReceivingByEMail { get; set; }

    #endregion

    #region Расписка в получении докумнта

    /// <summary>
    /// Расписку в получении документа прошу:
    /// 1 - Выдать лично
    /// 2 - Направить почтовым отправлением
    /// 3 - не отправлять
    /// </summary>
    public int ReceiptRecievingMethodId { get; set; }

    /// <summary>
    /// Адрес почтового отправления, если ReceiptRecievingMethodId = 2
    /// </summary>
    public string? ReceiptReceivingByPostAddress { get; set; }

    #endregion

    #region Заявитель

    /// <summary>
    /// Тип заявителя
    /// 1 - Собственник объекта адресации
    /// 2 - Представитель собственника объекта
    /// </summary>
    public int ApplicantTypeId { get; set; }

    /// <summary>
    /// Тип заявителя, если ApplicantTypeId = 2
    /// 1 - Физическое лицо
    /// 2 - юридическое лицо
    /// </summary>
    public int ApplicantSubTypeId { get; set; }

    /// <summary>
    /// Фамилия заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualLastName { get; set; }

    /// <summary>
    /// Имя заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualFirstName { get; set; }

    /// <summary>
    /// Отчество заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualMiddleName { get; set; }

    /// <summary>
    /// ИНН заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualInn { get; set; }

    #region Документ, удостоверяющий личность заявителя физического лица

    /// <summary>
    /// Вид документа, удостоверяющего личность
    /// </summary>
    public string? ApplicantIndividualDocumentType { get; set; }

    /// <summary>
    /// Серия документа, удостоверяющего личность
    /// </summary>
    public string? ApplicantIndividualDocumentSeries { get; set; }

    /// <summary>
    /// Номер документа, удостоверяющего личность
    /// </summary>
    public string? ApplicantIndividualDocumentNumber { get; set; }

    /// <summary>
    /// Дата выдачи документа, удостоверяющего личность
    /// </summary>
    public string? ApplicantIndividualDocumentGivenDate { get; set; }

    /// <summary>
    ///Кем выдан документ, удостоверяющий личность
    /// </summary>
    public string? ApplicantIndividualDocumentGivenBy { get; set; }

    #endregion

    /// <summary>
    /// Почтовый адрес заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualAddress { get; set; }

    /// <summary>
    /// Телефон для связи заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualPhone { get; set; }

    /// <summary>
    /// Адрес электронной почты заявителя, физическое лицо
    /// </summary>
    public string? ApplicantIndividualEMail { get; set; }

    /// <summary>
    /// Наименование и реквизиты документа, подтверждающего полномочия представителя
    /// </summary>
    public string? ApplicantIndividualRepresentativeDocumentInformation { get; set; }

    /// <summary>
    /// Полное наименование, юридическое лицо
    /// </summary>
    public string? ApplicantLegalEntityFullName { get; set; }

    /// <summary>
    /// КПП, юридическое лицо
    /// </summary>
    public string? ApplicantLegalEntityKpp { get; set; }

    /// <summary>
    /// ИНН, юридическое лицо
    /// </summary>
    public string? ApplicantLegalEntityInn { get; set; }

    /// <summary>
    /// Страна регистрации (инкорпорации) для иностранного юридического лица
    /// </summary>
    public string? ApplicantLegalEntityForeignCountry { get; set; }

    /// <summary>
    /// Дата регистрации для иностранного юридического лица
    /// </summary>
    public string? ApplicantLegalEntityForeignRegistrationDate { get; set; }

    /// <summary>
    /// Номер регистрации для иностранного юридического лица
    /// </summary>
    public string? ApplicantLegalEntityForeignRegistrationNumber { get; set; }

    /// <summary>
    /// Почтовый адрес, юридическое лицо
    /// </summary>
    public string? ApplicantLegalEntityAddress { get; set; }

    /// <summary>
    /// Телефон для связи, юридическое лицо
    /// </summary>
    public string? ApplicantLegalEntityPhone { get; set; }

    /// <summary>
    /// Адрес электронной почты, юридическое лицо
    /// </summary>
    public string? ApplicantLegalEntityEMail { get; set; }

    /// <summary>
    /// Наименование и реквизиты документа, подтверждающего полномочия представителя
    /// </summary>
    public string? ApplicantLegalEntityRepresentativeDocumentInformation { get; set; }

    #endregion

    #region Документы, прилагаемые к заявлению  

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Количество листов оригиналов
        /// </summary>
        public int OriginalsAmount { get; set; }

        /// <summary>
        /// Количество листов копий
        /// </summary>
        public int CopiesAmount { get; set; }
    }

    public AppliedDocument[] AppliedDocumentList { get; set; } = Array.Empty<AppliedDocument>();

    #endregion

    #endregion
}