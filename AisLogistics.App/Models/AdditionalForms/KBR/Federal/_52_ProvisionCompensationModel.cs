using System.ComponentModel.DataAnnotations;

namespace AisLogistics.App.Models
{
    public sealed class _52_ProvisionCompensationModel : AbstractAdditionalFormModel
    {
        public int Id { get; set; }

        [Display(Name = "Категория заявителя")]
        public int ApplicantCategory { get; set; }

        [Display(Name = "ФИО инвалида")]
        public string DisabledPersonName { get; set; }

        [Display(Name = "Дата рождения инвалида")]
        public DateTime? DisabledPersonBirthDate { get; set; }

        [Display(Name = "СНИЛС инвалида")]
        public string DisabledPersonSnils { get; set; }

        [Display(Name = "Собственник ТС")]
        public int VehicleOwner { get; set; }

        [Display(Name = "ФИО, число, месяц, год рождения в случае, если не является заявителем)")]
        public string AnotherPerson { get; set; }

        [Display(Name = "Страхователь ТС")]
        public int VehicleInsurer { get; set; }

        [Display(Name = "Серия и номер страхового полиса")]
        public string InsurancePolicy { get; set; }

        [Display(Name = "Размер уплаченной страховой премии")]
        public string InsurancePremium { get; set; }

        [Display(Name = "Способ перечисления компенсации")]
        public string CompensationMethod { get; set; }

        [Display(Name = "БИК")]
        public string BIC { get; set; }

        [Display(Name = "Расчетный счет")]
        public string AccountNumber { get; set; }

        [Display(Name = "Способ получения решения")]
        public int DecisionMethod { get; set; }

        [Display(Name = "Электронная почта")]
        public string DecisionEmail { get; set; }
    }
}
