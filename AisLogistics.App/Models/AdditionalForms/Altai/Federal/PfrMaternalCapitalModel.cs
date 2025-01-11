namespace AisLogistics.App.Models.AdditionalForms
{
    public class PfrMaternalCapitalModel : AbstractAdditionalFormModel
    {
        public PfrMaternalCapitalModel()
        {
            Customer = new PersonType();
            Representative = new RepresentativeType();
            ChildList = new PersonType[]
            {
                new PersonType()
            };
            AppliedDocumentList = new AppliedDocument[]
            {
                new AppliedDocument()
            };
        }

        /// <summary>
        /// Наименование территориального органа ПФР РФ
        /// </summary>
        public string PfrDepartment { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Customer { get; set; }

        /// <summary>
        /// Представитель
        /// </summary>
        public RepresentativeType Representative { get; set; }

        /// <summary>
        /// Дети
        /// </summary>
        public PersonType[] ChildList { get; set; }

        /// <summary>
        /// Причина получения услуги
        /// 1 - Рождение ребенка
        /// 2 - Усыновление ребенка
        /// </summary>
        public string Cause { get; set; }

        /// <summary>
        /// очередность рождения (усыновления) ребенка
        /// </summary>
        public string ChildDuration { get; set; }

        /// <summary>
        /// ФИО ребенка
        /// </summary>
        public FioType ChildFio { get; set; }

        /// <summary>
        /// Дата рождения (усыновления) ребенка
        /// </summary>
        public DateTime? AdoptionDate { get; set; }

        /// <summary>
        /// Мат капитал ранее
        /// - не выдавался, 
        /// - выдавался
        /// </summary>
        public string MaternalCapitalStatus { get; set; }

        /// <summary>
        /// Родительских прав в отношении ребенка (детей)  
        /// - не лишалась(ся), 
        /// - лишалась(ся)
        /// </summary>
        public string ParentalRightsStatus { get; set; }

        /// <summary>
        /// Умышленных преступлений, относящихся к преступлениям против 
        /// личности и повлекших за собой лишение или ограничение 
        /// родительских прав в отношении ребенка(детей)
        /// - не совершал(а)
        /// - совершал(а)
        /// </summary>
        public string CrimeStatus { get; set; }

        /// <summary>
        /// Способ получения сертификата
        /// 1 - лично
        /// 2 - по почте
        /// 3 - посредством единого портала государственных и муниципальных услуг (функций)
        /// 4 - посредством информационной системы Пенсионного фонда 
        ///     Российской Федерации «Личный кабинет застрахованного лица»
        /// 5 - через многофункциональный центр
        /// </summary>
        public string MethodResult { get; set; }

        /// <summary>
        /// Вид получаемого сертификата
        /// 1 - на бумажном носителе
        /// 2 - в форме электронного документа
        /// </summary>
        public string ResultFormat { get; set; }

        /// <summary>
        /// Почтовый адрес, по которому отправят сертификат
        /// </summary>
        public string ResultPostAddress { get; set; }        

        /// <summary>
        /// Получатель уведомлений о ходе и результатах рассмотрения
        /// данного заявления
        /// 1 - заявитель
        /// 2 - представитель
        /// </summary>
        public string RecipientNotification { get; set; }

        /// <summary>
        /// e-mail для информирования
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Номер телефона для информирования
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Приложенные документы
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Наименование документа
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Количество
            /// </summary>
            public string Count { get; set; }
        }

        public class PersonType
        {
            /// <summary>
            /// Статус
            /// - мать
            /// - отец
            /// - ребенок
            /// </summary>
            public string Status { get; set; }    
            
            /// <summary>
            /// ФИО
            /// </summary>
            public FioType Fio { get; set; }

            /// <summary>
            /// Фамилия при рождении
            /// </summary>
            public string BirthLastName { get; set; }

            /// <summary>
            /// Пол
            /// </summary>
            public string Gender { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            public string BirthPlace { get; set; }

            /// <summary>
            /// Наименование ДУЛ
            /// </summary>
            public string DocName { get; set; }

            /// <summary>
            /// Серия ДУл
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер ДУЛ
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Дата выдачи ДУЛ
            /// </summary>
            public DateTime? DocIssueDate { get; set; }

            /// <summary>
            /// Кем выдан ДУЛ
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Гражданство
            /// </summary>
            public string Citizenship { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string Snils { get; set; }

            /// <summary>
            /// Адрес места жительства
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// Контактный телефон
            /// </summary>
            public string Phone { get; set; }
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

        public class RepresentativeType : PersonType
        {
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
        }
    }
}
