using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                         Уведомление 
    /// о планируемых строительстве или реконструкции объекта индивидуального
    ///             жилищного строительства или садового дома
    /// </summary>
    public class _9_1_Model : AbstractAdditionalFormModel
    {
        public _9_1_Model()
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
        /// Заявитель
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// Контактные телефоны
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        /// <summary>
        /// рган местного самоуправления
        /// </summary>
        public string OrganRecipient { get; set; }

            /// <summary>
            /// Адрес земельного участка
            /// </summary>
            public string AddressPlot { get; set; }

            /// <summary>
            /// Кадастровый номер
            /// </summary>
            public string CadastralNumber { get; set; }

        /// <summary>
        /// Сведения о праве застройщика на земельный участок
        /// </summary>
        public string Right { get; set; }

        /// <summary>
        /// Сведения о наличии прав иных лиц на земельный участок (при наличии)
        /// </summary>
        public string RightOther { get; set; }

        /// <summary>
        /// Сведения о виде разрешенного использования земельного участка
        /// </summary>
        public string TypePermitted { get; set; }

        /// <summary>
        /// Сведения о виде разрешенного использования объекта капитального строительства 
        /// </summary>
        public string TypeObject { get; set; }

        /// <summary>
        /// Цель подачи уведомления 
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Сведения о планируемых параметрах
        /// </summary>
        public string InformationParameters { get; set; }

        /// <summary>
        /// Количество надземных этажей
        /// </summary>
        public string NumberFloors { get; set; }

        /// <summary>
        /// Высота
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Сведения об отступах от границ земельного участка
        /// </summary>
        public string InformationDeviations { get; set; }

        /// <summary>
        /// Площадь застройки
        /// </summary>
        public string BuildingArea { get; set; }

        /// <summary>
        /// Сведения о решении о предоставлении разрешения на отклонение от предельных параметров разрешенного строительства, реконструкции 
        /// </summary>
        public string Deviation { get; set; }

        /// <summary>
        /// Сведения о типовом архитектурном решении объекта капитального строительства, в случае строительства или реконструкции такого объекта в границах территории исторического поселения федерального или регионального значения
        /// </summary>
        public string ArchitecturalSolution { get; set; }

        /// <summary>
        /// Схематичное изображение планируемого к строительству или реконструкции объекта капитального  строительства на земельном участке
        /// </summary>

        public class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

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
            public DateTime? DocIssueDate { get; set; }

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
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }

            /// <summary>
            /// адрес
            /// </summary>
            public string AddressLegal { get; set; }

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
            public string Applicant { get; set; }
        }
        /// <summary>
        /// Сведения о застройщике
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Applicant { get; set; }

        /// <summary>
        /// Приложение
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }
        public class AppliedDocument
        {
            /// <summary>
            /// Приложение
            /// </summary>
            public string Applications { get; set; }
        }

    }
}
    