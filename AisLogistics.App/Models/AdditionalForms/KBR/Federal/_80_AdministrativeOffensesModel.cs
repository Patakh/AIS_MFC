using AisLogistics.App.Models.AdditionalForms;

namespace AisLogistics.App.Models;

/// <summary>
/// Предоставление сведений об административных правонарушениях в области дорожного движения.
/// </summary>
public class _80_AdministrativeOffensesModel : AbstractAdditionalFormModel
{
    public _80_AdministrativeOffensesModel()
    {
        ViolationsList = new []
        {
            new AppliedDocument()
        };
    }

    /// <summary>
    ///  Государственный регистрационный знак
    /// </summary>
    public string GosZnak { get; set; }

    /// <summary>
    ///  Имеются нарушения
    /// </summary>
    public bool IsViolations { get; set; }

    /// <summary>
    /// нарушения
    /// </summary>
    public AppliedDocument[] ViolationsList { get; set; }

    public class AppliedDocument
    {
        /// <summary>
        /// Дата нарушения
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// статья
        /// </summary>
        public string Article { get; set; }

        /// <summary>
        /// подразделения
        /// </summary>
        public string Divisions { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public int Summ { get; set; }
    }
}
