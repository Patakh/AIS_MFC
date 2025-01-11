using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// о внесении изменений в реестр лицензий на медицинскую деятельность медицинских организаций
    /// (за исключением медицинских организаций, подведомственных федеральным органам исполнительной власти), 
    /// </summary>
    public class Service29_1_4Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Регистрационный номер 
        /// </summary>
        public string Registration_Number { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// В  
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// адрес места нахождения
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Регистрационный №
        /// </summary>
        public string Registration_Number_1 { get; set; }

        /// <summary>
        /// лицензии от 
        /// </summary>
        public string Licenses_From { get; set; }

        /// <summary>
        /// наименование лицензирующего органа
        /// </summary>
        public string Name_Authority { get; set; }

        /// <summary>
        /// в связи с:
        /// </summary>
        public string Due_To { get; set; }

        /// <summary>
        /// Полное и (в случае, если имеется) сокращенное наименование
        /// </summary>
        public string Full_Name { get; set; }

        /// <summary>
        /// Адрес места нахождения юридического лица
        /// </summary>
        public string ResidenceAddress2 { get; set; }

        /// <summary>
        /// Государственный регистрационный номер записи о создании юридического лица(ОГРН)
        /// </summary>
        public string Registration_Number_3 { get; set; }

        /// <summary>
        /// Дата присвоения ОГРН
        /// </summary>
        public DateTime? Date_Of_Assignment { get; set; }

        /// <summary>
        /// ГРН
        /// </summary>
        public string UAH { get; set; }

        /// <summary>
        /// Дата внесения в ЕГРЮЛ записи: 
        /// </summary>
        public string Date_Of_Assignment_USRLE { get; set; }

        /// <summary>
        /// Наименование регистрирующего органа
        /// </summary>
        public string Name_Registering_Authority{ get; set; }

        /// <summary>
        /// Номер телефона: 
        /// </summary>
        public string Phone_Number { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Фамилия, имя и (в случае, если имеется) отчество индивидуального предпринимателя: 
        /// </summary>
        public string FIO_Entrepreneur { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress_Entrepreneur { get; set; }

        /// <summary>
        /// выдан
        /// </summary>
        public string Issued { get; set; }
        
      
        /// <summary>
        /// дата выдачи
        /// </summary>
        public string Date_of_issue { get; set; }

        /// <summary>
        /// ОГРНИП
        /// </summary>
        public string OGRNIP { get; set; }

        /// <summary>
        /// ГРН
        /// </summary>
        public string UAH2 { get; set; }

        /// <summary>
        /// Дата внесения в ЕГРИП записи
        /// </summary>
        public DateTime? Date_of_issue_EGRIP { get; set; }

        /// <summary>
        /// Наименование регистрирующего органа
        /// </summary>
        public string Name_Registering_Authority_2 { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public string Phone_Number2 { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        public string Email_2 { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// Дата постановки на учет
        /// </summary>
        public DateTime? Production_Date { get; set; }

        /// <summary>
        /// Наименование налогового органа
        /// </summary>
        public string Name_Tax { get; set; }

        /// <summary>
        /// Адрес(а) места осуществления лицензируемого вида деятельности, и новый перечень выполняемых работ, оказываемых услуг по адресу
        /// </summary>
        public string Address_Place { get; set; }

        /// <summary>
        /// Выполняемые работы, оказываемые услуги, которые лицензиат прекращает исполнять при осуществлении деятельности, с указанием адреса(ов) места осуществления лицензируемого вида деятельности
        /// </summary>
        public string Work_Performed { get; set; }

        /// <summary>
        /// Новый адрес места осуществления лицензируемого вида деятельности, и перечень выполняемых работ, оказываемых услуг по адресу 
        /// </summary>
        public string New_Address { get; set; }

        /// <summary>
        /// Адрес(а) места осуществления лицензируемого вида деятельности, на которых лицензиат прекращает деятельность указанных в лицензии:
        /// </summary>
        public string Ceases_Operations_Address { get; set; }

        /// <summary>
        /// Дата фактического прекращения осуществления деятельности
        /// </summary>
        public DateTime? Date_Fact { get; set; }

        /// <summary>
        /// (Указать адрес (адреса) мест осуществления лицензируемого вида деятельности)
        /// </summary>
        public string Termination_Address { get; set; }

        /// <summary>
        /// Сведения о наличии высшего или среднего фармацевтического образования и сертификатов специалистов - для работников, намеренных осуществлять фармацевтическую деятельность по указанному адресу (за исключением обособленных подразделений медицинских организаций): 
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        /// Сведения о наличии санитарно-эпидемиологического заключения о соответствии помещений по указанному адресу требованиям санитарных правил (за исключением медицинских организаций, обособленных подразделений медицинских организаций), выданного в установленном порядке 
        /// </summary>
        public string Sanitary_Epidemiological { get; set; }

        /// <summary>
        ///  дополнительного профессионального образования сфере обращения лекарственных средств для медицинского применения в обособленных подразделениях медицинских организаций
        /// </summary>
        public string Dop { get; set; }
        
        /// <summary>
        /// Наименование органа, выдавшего заключение 
        /// </summary>
        public string Name_Authority_Conclusion { get; set; }

        /// <summary>
        /// Адрес электронной почты 
        /// </summary>
        public string Email3 { get; set; }

        /// <summary>
        /// Техническая возможность использования при проведении выездной оценки средств дистанционного взаимодействия, средств фото- и видео фиксации, а также видео-конференц-связи с возможностью идентификации лицензиата через ЕСИА 
        /// </summary>
        public string Technical_Capability { get; set; }

        /// <summary>
        /// Форма получения выписки из реестра лицензий 
        /// </summary>
        public string Extract { get; set; }

        /// <summary>
        /// Номер заключения 
        /// </summary>
        public string Conclusio_Cumber { get; set; }

        /// <summary>
        /// Дата фактического прекращения осуществления деятельности
        /// </summary>
        public DateTime? Date_Cumber { get; set; }

        /// <summary>
        /// Серия паспорта
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер паспорта
        /// </summary>
        public string DocNumber { get; set; }

    }
}
