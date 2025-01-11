namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                        ЗАЯВЛЕНИЕ
    ///   В соответствии с Градостроительным кодексом Российской Федерации
    ///         прошу принять решение  о  подготовке  документации
    ///                    по планировке территории
    /// </summary>
    public class _21_1_Model : AbstractAdditionalFormModel
    {
        public _21_1_Model()
        {
            RightAppliedDocumentList = new[]
            {
                new RightAppliedDocument()
            };
            DeadlinesAppliedDocumentList = new[]
            {
                new DeadlinesAppliedDocument()
            };
            ContentAppliedDocumentList = new[]
            {
                new ContentAppliedDocument()
            };
        }

        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

         public class PersonType
        {
            /// <summary>
            /// ФИО
            /// </summary>
            public string Fio { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddress { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string Phone { get; set; }

            /// <summary>
            /// полное наименование
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// почтовый адрес
            /// </summary>
            public string PostalAddressLegal { get; set; }

            /// <summary>
            /// телефон для связи
            /// </summary>
            public string PhoneLegal { get; set; }

            /// <summary>
            /// Заявитель
            /// </summary>
            public string Applicant { get; set; }
        }
       
        /// <summary>
        /// Сведения о заявителе
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string Adress { get; set; }


        /// <summary>
        /// наименование правоустанавливающего документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// номер правоустанавливающего документа
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Дата выдачи  правоустанавливающего документа
        /// </summary>
        public string DocIssueDate { get; set; }

        /// <summary>
        /// информация о государственной регистрации
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// кадастровый номер
        /// </summary>
        public string Kadastr { get; set; }

        /// <summary>
        /// дату постановки учет 
        /// </summary>
        public string KadastrDate { get; set; }
        

        /// <summary>
        /// историческое назначение объекта культурного наследия и его фактическое использование
        /// </summary>
        public string ActualUsage { get; set; }

        /// <summary>
        /// наименование органа государственной власти
        /// </summary>
        public string OrganName { get; set; }

        /// <summary>
        /// наименование нормативного правового акта
        /// </summary>
        public string NameaAct { get; set; }

        /// <summary>
        /// дата принятия
        /// </summary>
        public string DateAct { get; set; }

        /// <summary>
        /// номер его принятия
        /// </summary>
        public string NumberAct { get; set; }

        /// <summary>
        /// регистрационный номер
        /// </summary>
        public string RegisterNumber { get; set; }

        /// <summary>
        /// дата постановки 
        /// </summary>
        public string DateRegister { get; set; }

        /// <summary>
        /// Способ получения результата 
        /// </summary>
        public string ResultProviding { get; set; }

        /// <summary>
        /// Заявитель
        /// </summary>
        public PersonType Applicant { get; set; }

        /// <summary>
        /// Приложение о порядке подготовки документации по планировке территории
        /// </summary>
        public RightAppliedDocument[] RightAppliedDocumentList { get; set; }
        public class RightAppliedDocument
        {
            public string Applications { get; set; }
        }

        /// <summary>
        /// Приложение о сроках подготовки документации по планировке территории
        /// </summary>
        public DeadlinesAppliedDocument[] DeadlinesAppliedDocumentList { get; set; }
        public class DeadlinesAppliedDocument
        {
            public string Applications { get; set; }
        }

        /// <summary>
        /// Приложение о содержании документации по планировке территории
        /// </summary>
        public ContentAppliedDocument[] ContentAppliedDocumentList { get; set; }
        public class ContentAppliedDocument
        {
            public string Applications { get; set; }
        }

    }
}
    