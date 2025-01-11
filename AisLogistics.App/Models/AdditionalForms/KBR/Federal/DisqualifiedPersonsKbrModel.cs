namespace AisLogistics.App.Models
{
    public class DisqualifiedPersonsKbrModel : AbstractAdditionalFormModel
    {
        /// <summary>
        /// лица , о котором запрашивается информация 
        /// </summary>
        public PersonType RequestedFace { get; set; }
        /// <summary>
        /// Информирование
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// адрес электронной почты 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// почтовый адрес
        /// </summary>
        public string PostalAddress { get; set; }

        public class PersonType
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

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// полное наименование юридического лица
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INNLegal { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }

            /// <summary>
            /// Заявитель
            /// </summary>
            public string Applicant { get; set; }

            /// <summary>
            /// место рождения
            /// </summary>
            public Address PlaceBirth { get; set; }

            /// <summary>
            ///  место жительства
            /// </summary>
            public Address Residence { get; set; }

            public class Address
            {
                /// <summary>
                /// почтовый индекс
                /// </summary>
                public string PostalСode { get; set; }

                /// <summary>
                /// Субъект РФ
                /// </summary>
                public string Region { get; set; }

                /// <summary>
                /// Город, район, населенный пункт
                /// </summary>
                public string Locality { get; set; }

                /// <summary>
                /// Улица
                /// </summary>
                public string Street { get; set; }

                /// <summary>
                /// Дом
                /// </summary>
                public string House { get; set; }
            }

        }
    }
}
