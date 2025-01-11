namespace AisLogistics.App.Models.AdditionalForms.KBR.Federal;

/// <summary>
/// Заявление о назначении и выплате единовременной государственной
/// социальной помощи в виде социального пособия
/// </summary>
public class SocialAssistanceBenefitModel
{
    /// <summary>
    /// Обстоятельства и причины послужившие основанием для обращения
    /// </summary>
    public string? AppealanseReason { get; set; }

    /// <summary>
    /// Модель члена семьи
    /// </summary>
    public class FamilyMember
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Степень родства
        /// </summary>
        public string? Kinship { get; set; }

        /// <summary>
        /// Род занятий
        /// 1 - работает
        /// 2 - учится
        /// 3 - служит
        /// 4 - независящие причины
        /// </summary>
        public int OccupationTypeId { get; set; }

        /// <summary>
        /// Вид дохода
        /// 1 - доходы от трудовой, предпринимательской деятельности
        /// 2 - выплаты социального характера
        /// 3 - полученные алименты
        /// 4 - доходы от имущества
        /// 5 - от личного подсобного хозяйства
        /// 6 - иные доходы
        /// </summary>
        public int ProfitTypeId { get; set; }
    }

    /// <summary>
    /// Члены семьи
    /// </summary>
    public FamilyMember[] FamilyMembers { get; set; } = Array.Empty<FamilyMember>();

    /// <summary>
    /// Прошу исключить из общей суммы дохода моей семьи уплаченные алименты в сумме
    /// </summary>
    public float AlimentsAmount { get; set; }

    /// <summary>
    /// Основание для удержания алиментов
    /// </summary>
    public string? AlimentsReason { get; set; }

    /// <summary>
    /// Фамилия, имя, отчество лица, в пользу которого производится удержание
    /// </summary>
    public string? AlimentsPerson { get; set; }

    /// <summary>
    /// Имущество члена семьи
    /// </summary>
    public class FamilyMemberEstateItem
    {
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Вид имущества
        /// </summary>
        public int EstateTypeName { get; set; }
    }

    /// <summary>
    /// Имущество членов семьи
    /// </summary>
    public FamilyMemberEstateItem[] FamilyMembersEstate { get; set; } = Array.Empty<FamilyMemberEstateItem>();

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public string[] AppliedDocuments { get; set; } = Array.Empty<string>();
}
