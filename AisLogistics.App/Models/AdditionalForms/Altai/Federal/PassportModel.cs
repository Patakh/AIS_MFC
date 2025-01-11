using System.ComponentModel;

namespace AisLogistics.App.Models.AdditionalForms
{
    public sealed class PassportModel : AbstractAdditionalFormModel
    {
        public PassportModel()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument(),
            };
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
            public string LastName { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            [DisplayName("Имя")]
            public string FirstName { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            [DisplayName("Отчество")]
            public string SecondName { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            [DisplayName("Дата рождения")]
            public string BirthDate { get; set; }

            /// <summary>
            /// Пол
            /// </summary>
            [DisplayName("Пол")]
            public string Gender { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        [DisplayName("Место рождения")]
        public string AddressBirth { get; set; }

        /// <summary>
        /// ранее имели другие фамилию, имя, отчество
        /// </summary>
        [DisplayName("ранее имели другие фамилию, имя, отчество")]
        public string Before { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [DisplayName("Фамилия")]
            public string LastNameBefore { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            [DisplayName("Имя")]
            public string FirstNameBefore { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            [DisplayName("Отчество")]
            public string SecondNameBefore { get; set; }

            /// <summary>
            /// Дата смены
            /// </summary>
            [DisplayName("Дата смены")]
            public string ShiftsDate { get; set; }

            /// <summary>
            /// Пол
            /// </summary>
            [DisplayName("Пол")]
            public string GenderBefore { get; set; }

            /// <summary>
            /// Место смены 
            /// </summary>
            [DisplayName("Место смены")]
            public string ShiftsPlace { get; set; }

            /// <summary>
            /// Адрес 
            /// </summary>
            [DisplayName("Адрес")]
            public Address RegistrationAddress { get; set; }

            /// <summary>
            /// Адрес места жительства
            /// </summary>
            [DisplayName("Адрес места жительства")]
            public Address ResidenceAddress { get; set; }

            /// <summary>
            /// Серия 
            /// </summary>
            [DisplayName("Серия")]
            public string MainDocSeries { get; set; }

            /// <summary>
            /// Номер 
            /// </summary>
            [DisplayName("Номер")]
            public string MainDocNumber { get; set; }

            /// <summary>
            /// Кем выдан 
            /// </summary>
            [DisplayName("Кем выдан")]
            public string MainDocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи 
            /// </summary>
            [DisplayName("Дата выдачи")]
            public string MainDocIssueDate { get; set; }

            /// <summary>
            /// Телефон
            /// </summary>
            [DisplayName("Телефон")]
            public string Phone { get; set; }

            /// <summary>
            /// Адрес электронной почты(по желанию)
            /// </summary>
            [DisplayName("Email")]
            public string Email { get; set; }

        /// <summary>
        /// допуск к государственной тайне
        /// </summary>
        [DisplayName("допуск к государственной тайне")]
         public string Roote { get; set; }

        /// <summary>
        /// Организация
        /// </summary>
        [DisplayName("Организация")]
         public string RootOrganization { get; set; }

        /// <summary>
        /// Год
        /// </summary>
        [DisplayName("Год")]
         public string RootDate { get; set; }

        /// <summary>
        ///  препятствия выезда за границу
        /// </summary>
        [DisplayName("препятствия выезда за границу")]
         public string Obstacles { get; set; }

        /// <summary>
        /// Организация
        /// </summary>
        [DisplayName("Организация")]
         public string ObstaclesOrganization { get; set; }

        /// <summary>
        /// Год
        /// </summary>
        [DisplayName("Год")]
         public string ObstaclesDate { get; set; }

        /// <summary>
        /// Серия 
        /// </summary>
        [DisplayName("Серия")]
        public string OverseasDocSeries { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        [DisplayName("Номер")]
        public string OverseasDocNumber { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        [DisplayName("Кем выдан")]
        public string OverseasDocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        [DisplayName("Дата выдачи")]
        public string OverseasDocIssueDate { get; set; }


        /// <summary>
        /// Дата подачи заявления
        /// </summary>
        [DisplayName("Дата подачи заявления")]
        public string FeedsDate { get; set; }

        /// <summary>
        /// Дата приема документов
        /// </summary>
        [DisplayName("Дата приема документов")]
        public string AcceptanceDate { get; set; }


        public sealed class Address
        {

            /// <summary>
            /// Регион
            /// </summary>
            [DisplayName("Регион")]
            public string Region { get; set; }

            /// <summary>
            /// Город/Район
            /// </summary>
            [DisplayName("Город/Район")]
            public string District { get; set; }

            /// <summary>
            /// Село
            /// </summary>
            [DisplayName("Село")]
            public string Locality { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            [DisplayName("Улица")]
            public string Street { get; set; }

            /// <summary>
            /// Дом
            /// </summary>
            [DisplayName("Дом")]
            public string House { get; set; }

            /// <summary>
            /// Корпус
            /// </summary>
            [DisplayName("Корпус")]
            public string Housing { get; set; }

            /// <summary>
            /// Строение
            /// </summary>
            [DisplayName("Строение")]
            public string Building { get; set; }

            /// <summary>
            /// Квартира
            /// </summary>
            [DisplayName("Квартира")]
            public string Flat { get; set; }

            /// <summary>
            /// Дата регистрации
            /// </summary>
            [DisplayName("Дата регистрации")]
            public string DateRegstration { get; set; }

            /// <summary>
            /// Адрес
            /// </summary>
            [DisplayName("Адрес")]
            public string AddressType { get; set; }


            /// <summary>
            /// Срок регистрации 
            /// </summary>
            [DisplayName("с")]
            public string WithDate { get; set; }

            /// <summary>
            /// по
            /// </summary>
            [DisplayName("по")]
            public string ByDate { get; set; }
        }

            public AppliedDocument[] AppliedDocumentList { get; set; }

            public class AppliedDocument
            {
                /// <summary>
                /// поступления
                /// </summary>
                public string ReceiptsDate { get; set; }

                /// <summary>
                /// увольнения
                /// </summary>
                public string DismissalsDate { get; set; }

                /// <summary>
                /// Должность и место работы,номер войсковой части
                /// </summary>
                public string Post { get; set; }

                /// <summary>
                /// Адрес организации, войсковой части
                /// </summary>
                public string AdressOrganization { get; set; }
            }

    }
      
}
