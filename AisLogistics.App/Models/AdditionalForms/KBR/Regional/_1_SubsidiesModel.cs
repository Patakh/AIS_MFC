 namespace AisLogistics.App.Models;

/// <summary>
/// Субсидии на оплату жилого помещения и коммунальных услуг
/// </summary>
public class _1_SubsidiesModel : AbstractAdditionalFormModel
{  
    /// <summary>
    /// Период
    /// С
    /// </summary>
    public string DateStart { get; set; }

    /// <summary>
    /// Период
    /// по
    /// </summary>
    public string DateStop { get; set; }

    /// <summary>
    /// Отказать в предоставлении субсидии на оплату ЖКУ по следующим причинам
    /// </summary>
    public string Deny { get; set; }

    /// <summary>
    /// Вид жилищного фонда
    /// </summary>
    public int HousingTypeId { get; set; }

    /// <summary>
    /// Вид регионального стандарта
    /// </summary>
    public string RegionalStandardType { get; set; }

    /// <summary>
    /// Общая площадь
    /// </summary>
    public float TotalSquare { get; set; }

    /// <summary>
    /// Отапливаемая площадь
    /// </summary>
    public float HeatedSquare { get; set; }

    /// <summary>
    /// количество комнат 
    /// </summary>
    public int RoomAmount { get; set; }

    /// <summary>
    /// Этаж
    /// </summary>
    public int Floor { get; set; }

    /// <summary>
    /// Количество жильцов
    /// </summary>
    public int RoomerAmount { get; set; }

    /// <summary>
    /// Тех. обслуживание жилья 
    /// Лифт и мусоропровод
    /// </summary>
    public Landscaping PaymentHousing { get; set; }

    /// <summary>
    /// Капитальный ремонт МКД
    /// </summary>
    public Landscaping KR { get; set; }

    /// <summary>
    /// Электроснабжение
    /// Электроплита
    /// </summary>
    public Landscaping Electric { get; set; }

    /// <summary>
    /// Газовая плита
    /// Колонка
    /// Газовое отопление
    /// </summary>
    public Landscaping MainsGas { get; set; }

    /// <summary>
    /// Центральное отопление
    /// Центр.горячее водоснабжение
    /// </summary>
    public Landscaping CentralHeating { get; set; }

    /// <summary>
    /// Водоснабжение в доме
    /// Канализация в доме
    /// Дворовая канализация
    /// </summary>
    public Landscaping Water { get; set; }

    /// <summary>
    /// Вывоз ТКО
    /// </summary>
    public Landscaping TKO { get; set; }
     
    /// <summary>
    /// состав семьи
    /// </summary>
    public FamilyMembers[] FamilyMembersList { get; set; }

    /// <summary>
    /// Прилагаемые документы
    /// </summary>
    public AppliedDocument[] AppliedDocuments { get; set; }
     
    public class Landscaping 
    {  
        /// <summary>
        /// Поставщик услуг
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// № лицевого счета
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// Ежемесячное начисление
        /// </summary>
        public string MonthlyAccrual { get; set; } 
    }

    /// <summary>
    /// Прилагаемый документ
    /// </summary>
    public class AppliedDocument
    {
        public string Name { get; set; }
        public string PageAmount { get; set; }
    }

    public class FamilyMembers
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Степень родства
        /// </summary>
        public string FamilyRelations { get; set; }

        /// <summary>
        /// Данные паспорта (свидетельства о рождении)
        /// </summary>
        public string  PassportData { get; set; }

        /// <summary>
        /// Источник дохода
        /// </summary>
        public string SourceIncome { get; set; }
         
        /// <summary>
        /// месяцы
        /// 1
        /// </summary>
        public string MonthOne { get; set; }

        /// <summary>
        /// месяцы
        /// 2
        /// </summary>
        public string MonthTwo { get; set; }

        /// <summary>
        /// месяцы
        /// 3
        /// </summary>
        public string MonthThree { get; set; }
         
        /// <summary>
        /// месяцы
        /// 4
        /// </summary>
        public string MonthFour { get; set; }

        /// <summary>
        /// месяцы
        /// 5
        /// </summary>
        public string MonthFive { get; set; }

        /// <summary>
        /// месяцы
        /// 6
        /// </summary>
        public string MonthSix { get; set; }
    }
}
