using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

public class _198_ReinstatementSeniorityModel : AbstractAdditionalFormModel
{
    public _198_ReinstatementSeniorityModel()
    {
        FamilyMembersList = new[]
        {
            new FamilyMembers()
        };
    }

    /// <summary>
    /// Для какой цели запрашивается архивная справка
    /// </summary>
    public string Target { get; set; }

    /// <summary>
    /// ФИО лица запрашивающего справку
    /// </summary>
    public string FIO { get; set; }

    /// <summary>
    /// Прежняя фамилия
    /// </summary>
    public string PrevLastname { get; set; }

    /// <summary>
    /// Дата смены
    /// </summary>
    public string DateChange { get; set; }

    /// <summary>
    /// Период работы:
    /// </summary>
    public string Period { get; set; }

    /// <summary>
    /// название организации с указанием должности и подразделения (номер или название цеха, участка и т.д.
    /// </summary>
    public string Organizatioon { get; set; }
     
    /// <summary>
    /// Дата Рождение детей
    /// </summary>
    public FamilyMembers[] FamilyMembersList { get; set; }

    public class FamilyMembers
    { 
        /// <summary>
        /// Дата Рождение
        /// </summary>
        public string BirthDate { get; set; } 
    }
}
