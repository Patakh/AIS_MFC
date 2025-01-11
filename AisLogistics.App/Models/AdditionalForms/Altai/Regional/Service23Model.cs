using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    
    public class Service23Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Заявление поступило
        /// </summary>
        public string Request_path { get; set; }
        
        /// <summary>
        /// сведения о матери:
        /// Фамилия
        /// </summary>
        public string FirstName { get; set; }

         /// <summary>
        ///  Имя
        /// </summary>
        public string LastName { get; set; }

         /// <summary>
        ///  Отчество
        /// </summary>
        public string SecondName { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }

        /// <summary>
        /// Мсто рождения
        /// </summary>
        public string BirdPlace { get; set; }
        
        /// <summary>
        /// Гражданство
        /// </summary>
        public string Contry { get; set; }
        
        /// <summary>
        /// Национальность
        /// </summary>
        public string Nstionati { get; set; }
        
        /// <summary>
        /// сведений о национальности матери
        /// </summary>
        public string NationalInfo { get; set; }
        
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddress { get; set; }

        /// <summary>
        /// Документ удостоверяющий личность
        /// Тип 
        /// </summary>
        public string DocType { get; set; }

        /// <summary>
        /// Серия 
        /// </summary>
        public string DocSeries { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        public string DocNumber { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string DocIssueDate { get; set; }
        

        /// <summary>
        /// Ребенок
        /// пол 
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Ребенок
        /// дата рождения
        /// </summary>
        public string ChildBirds { get; set; }
        
        /// <summary>
        /// Ребенок
        /// фамилия
        /// </summary>
        public string FChild { get; set; }

        /// <summary>
        /// Ребенок
        /// имя 
        /// </summary>
        public string IChild { get; set; }

        /// <summary>
        /// Ребенок
        /// отчество 
        /// </summary>
        public string OChild { get; set; }

        /// <summary>
        /// Ребенок
        /// Место рождения
        /// </summary>
        public string AdressChild { get; set; }
        
        
        /// <summary>
        /// сведений о отце
        /// </summary>
        public string NationalInfoOther { get; set; }

        /// <summary>
        /// Фамилия отца
        /// </summary>
        public string LastNameOther { get; set; }

        /// <summary>
        ///  Имя отца
        /// </summary>
        public string FirstNameOther { get; set; }

        /// <summary>
        /// Отчество отца
        /// </summary>
        public string SecondNameOther { get; set; }

        /// <summary>
        /// Основание для государственной регистрации рождения  
        /// </summary>
        public string Core { get; set; }

        /// <summary>
        /// медицинское свидетельство о рождении
        /// Наименование 
        /// </summary>
        public string DocNameMedical { get; set; }

        /// <summary>
        /// медицинское свидетельство о рождении
        /// Серия 
        /// </summary>
        public string DocSeriesMedical { get; set; }

        /// <summary>
        /// медицинское свидетельство о рождении
        /// Номер 
        /// </summary>
        public string DocNumberMedical { get; set; }
        
        /// <summary>
        /// медицинское свидетельство о рождении
        /// Дата выдачи 
        /// </summary>
        public string DocIssueDateMedical { get; set; }

        /// <summary>
        /// ФИО лица, присутствовавшего во время родов
        /// </summary>
        public string FioPolm { get; set; }

        /// <summary>
        /// от 
        /// </summary>
        public string DatePolm { get; set; }

        /// <summary>
        /// решение суда об установлении факта рождения от
        /// </summary>
        public string DateSud { get; set; }

        /// <summary>
        /// наименование суда
        /// </summary>
        public string NameSud { get; set; }
        
        
        /// <summary>
        /// ФИО
        /// </summary>
        public string FioAuthorizedPerson { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string ResidenceAddressAuthorizedPerson  { get; set; }

        /// <summary>
        /// Документ удостоверяющий личность
        /// Тип 
        /// </summary>
        public string AuthorizedPersonDocType  { get; set; }

        /// <summary>
        /// Серия 
        /// </summary>
        public string AuthorizedPersonDocSeries  { get; set; }

        /// <summary>
        /// Номер 
        /// </summary>
        public string AuthorizedPersonDocNumber { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string AuthorizedPersonDocIssuer  { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public string AuthorizedPersonDocIssueDate { get; set; }

    }
}
