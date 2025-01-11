using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    public sealed class FnsKnd1150076Model : AbstractAdditionalFormModel
    {
        public FnsKnd1150076Model()
        {
            RepresentativeFio = new();
            VehicleList = new[]
            {
                new VehicleType()
            };        
        }

        /// <summary>
        /// Налоговый орган направления заявления
        /// </summary>
        public string FnsDepartmentCode { get; set; }

        /// <summary>
        /// Тип заявителя
        /// </summary>
        public string CustomerType { get; set; }

        /// <summary>
        /// наименование налогоплательщика – организации или фамилия, имя, отчество налогоплательщика – физического лица
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// ФИО представителя
        /// </summary>
        public FioType RepresentativeFio { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string Inn { get; set; }

        /// <summary>
        /// КПП
        /// </summary>
        public string Kpp { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }

        /// <summary>
        /// Код вида документа
        /// </summary>
        public string DocCode { get; set; }

        /// <summary>
        /// Серия и номер документа
        /// </summary>
        public string DocSeriesNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Кем выдан документ
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Номер контактного телефона
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Способ информирования
        /// </summary>
        public string MethodInforming { get; set; }

        /// <summary>
        /// Наименование документа, подтверждающего полномочия представителя
        /// </summary>
        public string AuthorityDocName { get; set; }

        /// <summary>
        /// Серия документа, подтверждающего полномочия представителя
        /// </summary>
        public string AuthorityDocSeries { get; set; }

        /// <summary>
        /// Номер документа, подтверждающего полномочия представителя
        /// </summary>
        public string AuthorityDocNumber { get; set; }

        /// <summary>
        /// Дата выдачи документа, подтверждабщего полномочия представителя
        /// </summary>
        public DateTime? AuthorityDocIssueDate { get; set; }

        /// <summary>
        /// Кем выдан документ, подтверждающий полномочия представителя
        /// </summary>
        public string AuthorityDocIssuer { get; set; }

        /// <summary>
        /// Сведения об объекте налогообложения, в отношении которого представляется заявление
        /// </summary>
        public VehicleType[] VehicleList { get; set; }
    }

    public class FioType
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string SecondName { get; set; }
    }

    public class VehicleType
    {
        /// <summary>
        /// Вид транспортного средства
        /// </summary>            
        public string Type { get; set; }

        /// <summary>
        /// Марка (модель)
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Государственный регистрационный знак (номер)
        /// </summary>
        public string RegSign { get; set; }

        /// <summary>
        /// Дата гибели или уничтожения ТС
        /// </summary>
        public DateTime? DestructionDate { get; set; }

        /// <summary>
        /// Полное наименование документа
        /// </summary>
        public string DestructionConfirmDocName { get; set; }

        /// <summary>
        /// Полное наименование органа (организвцииб лица), выдавшего документ
        /// </summary>
        public string DestructionConfirmDocIssuer { get; set; }

        /// <summary>
        /// Дата составления документа
        /// </summary>
        public DateTime? DestructionConfirmDocDate { get; set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public string DestructionConfirmDocNumber { get; set; }
    }
}
