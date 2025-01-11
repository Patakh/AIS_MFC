using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                           Уведомление
    /// об окончании строительства или реконструкции объекта индивидуального
    ///                жилищного строительства или садового дома
    /// </summary>
    public class _11_Model : AbstractAdditionalFormModel
    {
        public _11_Model()
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
        /// Уведомление направить следующим способом
        /// </summary>
        public string Notification { get; set; }

        /// <summary>
        /// реквизиты платежного документа
        /// </summary>
        public string Requisites { get; set; }

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
    