using AisLogistics.App.Models.AdditionalForms; 

namespace AisLogistics.App.Models;

/// <summary>
/// Осуществление миграционного учета иностранных граждан и лиц без гражданства в Российской Федерации
/// Снятие иностранного гражданина с регистрации по месту жительства
/// </summary>
public class _92_3_WithdrawalForeignResidenceModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// ФИО
    /// </summary> 
    public string FIO  { get; set; }
      
    /// <summary>
    /// Дата рождения
    /// </summary> 
    public string BirthDate { get; set; }

    /// <summary>
    /// гражданство
    /// </summary>
    public string Citizenship { get; set; }

    /// <summary>
    /// с регистрации по месту жительства по адресу
    /// </summary>
    public string ResidenceAddress { get; set; }

    /// <summary>
    /// Основание для снятия с регистрации по месту жительства:
    /// </summary>
    public string FootingWithdrawal { get; set; }

    /// <summary>
    /// Наименование и реквизиты документа, подтверждающего основание для снятия с регистрации по месту жительства:
    /// </summary>
    public string RightFootingWithdrawalDoc{ get; set; }

    /// <summary>
    /// Вид и реквизиты документа, подтверждающего полномочия представителя юридического лица:
    /// </summary>
    public string RightDocLegal { get; set; }
}