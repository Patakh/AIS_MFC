 namespace AisLogistics.App.Models ;

/// <summary>
///                        ЗАЯВЛЕНИЕ 
/// о присвоении объекту адресации адреса или аннулировании его адреса
/// </summary>
public class _13_AddressesModel : AbstractAdditionalFormModel
{
    public _13_AddressesModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };
    }
    
    /// <summary>
    /// Вид
    /// </summary>
    public string View { get; set; }

    /// <summary>
    /// причина
    /// </summary>
    public string Reason { get; set; }
    public class Info_Plot
    {
        /// <summary>
        /// Количество земельных участков
        /// </summary>
        public string NumberPlotFormed { get; set; }

        /// <summary>
        /// Количество земельных участков, которые перераспределяются
        /// </summary>
        public string NumberPlotRedistributed { get; set; }

        /// <summary>
        /// Количество помещений
        /// </summary>
        public string NumberPremises { get; set; }

        /// <summary>
        /// Количество машино-мест
        /// </summary>
        public string NumberParkingSpaces { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string AdditionalInformation { get; set; }

        /// <summary>
        /// Тип здания 
        /// </summary>
        public string TypeBuilding { get; set; }

        /// <summary>
        /// Вид помещения
        /// </summary>
        public string TypeRoom { get; set; }

        /// <summary>
        /// Адрес земельного участка, раздел которого осуществляется
        /// </summary>
        public string AddressPlot { get; set; }

        /// <summary>
        /// Кадастровый номер
        /// </summary>
        public string CadastralNumber { get; set; }

        /// <summary>
        /// Наименование объекта строительства
        /// </summary>
        public string NameConstructionObject { get; set; }

        /// <summary>
        /// Образование
        /// </summary>
        public string Education { get; set; }
    }
    /// <summary>
    /// 1- Образованием земельного участка(ов) из земель, находящихся в государственной или муниципальной собственности
    /// </summary>
    public Info_Plot LocatedOwnership { get; set; }

    /// <summary>
    ///  2- Образованием земельного участка(ов) путем раздела земельного участка
    /// </summary>
    public Info_Plot Land { get; set; }

    /// <summary>
    ///  3- Образованием земельного участка путем объединения земельных участков
    /// </summary>
    public Info_Plot Associations { get; set; }

    /// <summary>
    ///  4- Образованием земельного участка(ов) путем выдела из земельного участка
    /// </summary>
    public Info_Plot Allotment { get; set; }

    /// <summary>
    ///  5- пОбразованием земельного участка(ов) путем перераспределения земельных участков
    /// </summary>
    public Info_Plot Redistributions { get; set; }

    /// <summary>
    /// 6- Строительством, реконструкцией здания (строения), сооружения
    /// </summary>
    public Info_Plot Construction { get; set; }

    /// <summary>
    /// 7- Подготовкой в отношении следующего объекта адресации документов, необходимых для осуществления государственного кадастрового учета указанного объекта адресации
    /// </summary>
    public Info_Plot Preparation { get; set; }


    /// <summary>
    /// 8- Переводом жилого помещения в нежилое помещение и нежилого помещения в жилое помещение
    /// </summary>
    public Info_Plot Translation { get; set; }

    /// <summary>
    /// 9- Образованием помещения(ий) в здании (строении), сооружении путем раздела здания (строения), сооружения
    /// </summary>
    public Info_Plot BuilingPremises { get; set; }

    /// <summary>
    /// 10- Образованием помещения(ий) в здании (строении), сооружении путем раздела помещения, машино-места
    /// </summary>
    public Info_Plot PremisesSection { get; set; }

    /// <summary>
    /// 11- Образованием помещения в здании (строении), сооружении путем объединения помещений, машино-мест в здании (строении), сооружении
    /// </summary>
    public Info_Plot AssociationsParkingSpaces { get; set; }

    /// <summary>
    /// 12- Образованием помещения в здании, сооружении путем переустройства и (или) перепланировки мест общего пользования
    /// </summary>
    public Info_Plot Realignments { get; set; }

    /// <summary>
    /// 13- Образованием машино-места в здании, сооружении путем раздела здания, сооружения
    /// </summary>
    public Info_Plot DividingBuilding { get; set; }

    /// <summary>
    /// 14- Образованием машино-места (машино-мест) в здании, сооружении путем раздела помещения, машино-места
    /// </summary>
    public Info_Plot SectionRoom { get; set; }

    /// <summary>
    /// 15- Образованием машино-места в здании, сооружении путем объединения помещений, машино-мест в здании, сооружении
    /// </summary>
    public Info_Plot AssociationsPremises { get; set; }

    /// <summary>
    /// 16- Образованием машино-места в здании, сооружении путем переустройства и (или) перепланировки мест общего пользования
    /// </summary>
    public Info_Plot RedevelopmentPlaces { get; set; }

    /// <summary>
    /// 17- Необходимостью приведения адреса земельного участка
    /// </summary>
    public Info_Plot NecessityBringing { get; set; }

    /// <summary>
    /// 18- Отсутствием у земельного участка
    /// </summary>
    public Info_Plot AbsenceLandPlot { get; set; }

    /// <summary>
    /// страна
    /// </summary>
    public string Сountry { get; set; }

    /// <summary>
    ///  субъект
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// Наименование муниципального района, городского, муниципального округа или внутригородской территории
    /// </summary>
    public string Territories { get; set; }

    /// <summary>
    /// Наименование поселения
    /// </summary>
    public string Settlements { get; set; }

    /// <summary>
    /// Наименование внутригородского района городского округа
    /// </summary>
    public string CityDistrict { get; set; }

    /// <summary>
    /// Наименование населенного пункта
    /// </summary>
    public string Locality { get; set; }

    /// <summary>
    /// Наименование элемента планировочной структуры
    /// </summary>
    public string ElementPlanningStructure { get; set; }

    /// <summary>
    /// Наименование элемента улично-дорожной сети
    /// </summary>
    public string ElementRoadNetwork { get; set; }

    /// <summary>
    /// Номер земельного участка
    /// </summary>
    public string LandPlotNumber { get; set; }

    /// <summary>
    /// Тип здания
    /// </summary>
    public string TypeBuilding { get; set; }

    /// <summary>
    ///  Номер здания
    /// </summary>
    public string NumberBuilding { get; set; }

    /// <summary>
    /// Тип помещения,
    /// </summary>
    public string TypePremises { get; set; }

    /// <summary>
    ///  Номер помещения,
    /// </summary>
    public string NumberPremises { get; set; }

    /// <summary>
    /// Тип помещения в пределах квартиры
    /// </summary>
    public string TypeFlat { get; set; }

    /// <summary>
    /// Номер помещения в пределах квартиры
    /// </summary>
    public string NumberFlat { get; set; }

    /// <summary>
    /// Дополнительная информация
    /// </summary>
    public string AdditionalInformation { get; set; }

    /// <summary>
    /// В связи с
    /// </summary>
    public string DueTo { get; set; }

    /// <summary>
    /// Дополнительная информация
    /// </summary>
    public string DueToAdditionalInformation { get; set; }

    public class PersonType
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        
        /// <summary>
        /// Тип документа
        /// </summary>
        public string DocType { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// телефон для связи
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// полное наименование
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// ИНН 
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// ИНН 
        /// </summary>
        public string INNLegal { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        public string CHECKPOINT { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddressLegal { get; set; }

        /// <summary>
        /// телефон для связи
        /// </summary>
        public string PhoneLegal { get; set; }

        /// <summary>
        /// адрес электронной почты
        /// </summary>
        public string EmailLegal { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public string Applicant0 { get; set; }
    }
        /// <summary>
        /// наименование и реквизиты документа, подтверждающего полномочия представителя: 
        /// </summary>
        public string AthorityDocName { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string AthoritySeries { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string AthorityNumber { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string AthorityDocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string AthorityDocIssueDate { get; set; }
    
    /// <summary>
    /// Лицо
    /// </summary>
    public string Face { get; set; }

    /// <summary>
    /// Лицо Заявителя
    /// </summary>
    public string FaceApplicant { get; set; }

    /// <summary>
    /// Собственник объекта
    /// </summary>
    public PersonType OwnerObject { get; set; }

    /// <summary>
    /// Заявитель
    /// </summary>
    public PersonType Applicant { get; set; }

    /// <summary>
    /// Вещное право на объект адресации
    /// </summary>
    public string Right { get; set; }
    
    /// <summary>
    /// Вещное право на объект адресации
    /// </summary>
    public string RightLegal { get; set; }

    /// <summary>
    /// Способ получения документов
    /// </summary>
    public string MethodReceiving { get; set; }

    /// <summary>
    /// Расписку в получении документов 
    /// </summary>
    public string Receipt  { get; set; }

    /// <summary>
    /// Примечание:
    /// </summary>
    public string Note { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество экземпляров
        /// </summary>
        public int CopyCount { get; set; }
        /// <summary>
        /// Количество листов
        /// </summary>
        public int CopyList { get; set; }

        /// <summary>
        /// Количество оригиналов
        /// </summary>
        public int OriginalCount { get; set; }

        /// <summary>
        /// Количество листов
        /// </summary>
        public int OriginalList { get; set; }
    }
}
