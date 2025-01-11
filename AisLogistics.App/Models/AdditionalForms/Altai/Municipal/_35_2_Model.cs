using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///      Заявление
    /// О ПЕРЕОФОРМЛЕНИИ ЛИЦЕНЗИИ
    /// </summary> 
    public class _35_2_Model : AbstractAdditionalFormModel
    {
        public _35_2_Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }

        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Организация
        /// </summary>
        public string OrganizationName { get; set; }

        /// <summary>
        /// Ф.И.О. руководителя или доверенного лица
        /// </summary>
        public string FioManager { get; set; }

        /// <summary>
        /// должность руководителя или доверенного лица
        /// </summary>
        public string PostManager { get; set; }

        /// <summary>
        /// Устав
        /// </summary>
        public string Regulation { get; set; }

        /// <summary>
        /// № Устава
        /// </summary>
        public string RegulationNumber { get; set; }

        /// <summary>
        /// даты выдачи
        /// </summary>
        public string DateRegulation { get; set; }

        /// <summary>
        /// срока действия
        /// </summary>
        public string ValidityPeriodRegulation { get; set; }
        
        /// <summary>
        /// Место нахождения организации(согласно Уставу)
        /// </summary>
        public string AddressOrganization { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Расчетный счет №
        /// </summary>
        public string Score  { get; set; }

        /// <summary>
        /// наименование банка
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// БИК
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Телефон/факс
        /// </summary>
        public string PhoneFax { get; set; }

        /// <summary>
        /// № алкогольной продукции 
        /// </summary>
        public string NuberaLcoholicBeverages { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public string DateLcoholic { get; set; }

        /// <summary>
        /// причина  ,в связи с
        /// </summary>
        public string Reason { get; set; }

       
        /// <summary>
        /// Прилагаемые документы
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Name { get; set; }
        }
    }
}
