using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Назначение ежемесячной выплаты на ребенка в возрасте от 3 до 7 лет включительно на территории Республики Алтай
    /// </summary>
    public class Service10Model : AbstractAdditionalFormModel
    {
       
        public Service10Model()
        {
            AppliedDocumentList = new[]
            {
                new AppliedDocument()
            };
        }
        public class Person
        {
            /// <summary>
            /// Ф
            /// </summary>
            public string F { get; set; }

            /// <summary>
            /// И
            /// </summary>
            public string I { get; set; }

            /// <summary>
            /// О
            /// </summary>
            public string O { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string SNILS { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// Адрес места регистрации
            /// </summary>
            public string RegistrationAddress { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            public string BirthAddress { get; set; }

            /// <summary>
            /// Адрес места жительства
            /// </summary>
            public string ResidenceAddress { get; set; }

            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Семейное положение 
            /// </summary>
            public string FamelyStatuse { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан паспорт
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи паспорта
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Реквизиты актовой записи о расторжении брака номер актовой записи
            /// </summary>
            public string NumberAct { get; set; }

            /// <summary>
            /// дата составления актовой записи
            /// </summary>
            public string DateAct { get; set; }

            /// <summary>
            /// орган ЗАГС, где составлена актовая запись
            /// </summary>
            public string OrgaAct { get; set; }

            /// <summary>
            /// Реквизиты актовой записи о смерти супруга(супруги) 
            /// </summary>
            public string NumberActRip { get; set; }

            /// <summary>
            /// дата составления актовой записи
            /// </summary>
            public string DateActRip { get; set; }


            /// <summary>
            /// орган ЗАГС, где составлена актовая запись
            /// </summary>
            public string OrgaActRip { get; set; }

            /// <summary>
            /// ф. и. о. умершего
            /// </summary>
            public string FioRip { get; set; }

            /// <summary>
            /// дата смерти
            /// </summary>
            public string DateRip { get; set; }

            /// <summary>
            /// Место работы  
            /// </summary>
            public string PlaceWorked { get; set; }

            /// <summary>
            /// ИНН работодателя 
            /// </summary>
            public string INNWorke { get; set; }

            /// <summary>
            /// Сведения о сумме алиментов,полученных в период, за который рассчитывается среднедушевой доход семьи
            /// </summary>
            public string SumAlimetInfo { get; set; }

            /// <summary>
            /// Фамилия, имя, отчество (при наличии), дата рождения, СНИЛС нетрудоспособного лица, закоторым осуществлялся уход в период расчета среднедушевого дохода семьи
            /// </summary>
            public string FioInvalid { get; set; }

            /// <summary>
            /// Менял (меняла) паспорт  гражданина Российской Федерации в период после рождения/усыновления/ установления опеки над ребенком (детьми), входящем в состав семьи
            /// </summary>
            public string SwiachPasport { get; set; }

            /// <summary>
            /// Освобожден (освобождена) из мест лишения свободы в период, за который рассчитывается среднедушевой доход семьи
            /// </summary>
            public string Osvabajden { get; set; }

            /// <summary>
            /// субъект Российской Федерации в котором гражданин отбывал наказание
            /// </summary>
            public string OsvabajdenRegion { get; set; }

            /// <summary>
            /// Отбывает наказание в виде лишения свободы
            /// </summary>
            public string Zakluchon { get; set; }

            /// <summary>
            /// субъект Российской Федерации в котором гражданин отбывает наказание
            /// </summary>
            public string ZakluchonRegion { get; set; }

            /// <summary>
            /// В отношении супруга (супруги) применена мера пресечения в виде заключения под стражу
            /// </summary>
            public string PrimenenoNacazanie { get; set; }
        }

        /// <summary>
        /// Заявитель
        /// </summary>
        public Person Applicant { get; set; }

        /// <summary>
        ///  Супруг(а) Заявителя
        /// </summary>
        public Person ApplicantSuprug { get; set; }

        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            /// <summary>
            /// Ф
            /// </summary>
            public string FChild { get; set; }

            /// <summary>
            /// И
            /// </summary>
            public string IChild { get; set; }

            /// <summary>
            /// О
            /// </summary>
            public string OChild { get; set; }

            /// <summary>
            /// Гражданство
            /// </summary>
            public string Grajdan { get; set; }

            /// <summary>
            /// СНИЛС
            /// </summary>
            public string SNILSChild { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public string BirthDateChild { get; set; }

            /// <summary>
            /// Реквизиты актовой записио рождении
            /// </summary>
            public string NumberActChild { get; set; }

            /// <summary>
            /// дата составления актовой записи
            /// </summary>
            public string DateActChild { get; set; }

            /// <summary>
            /// орган ЗАГС, где составлена актовая запись
            /// </summary>
            public string OrgaActChild { get; set; }

            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeriesChild { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumberChild { get; set; }

            /// <summary>
            /// Кем выдан паспорт
            /// </summary>
            public string DocIssuerChild { get; set; }

            /// <summary>
            /// Дата выдачи паспорта
            /// </summary>
            public string DocIssueDateChild { get; set; }

            /// <summary>
            /// Обучается в общеобразовательном учреждении либо образовательном учреждении среднего профессионального или высшего образования по очной форме обучения
            /// </summary>
            public string CursUnivesyte { get; set; }

            /// <summary>
            ///  Родитель
            /// </summary>
            public string Parent { get; set; }

            /// <summary>
            /// Освобожден (освобождена) из мест лишения свободы в период, за который рассчитывается среднедушевой доход семьи
            /// </summary>
            public string OsvabajdenChild { get; set; }

            /// <summary>
            /// субъект Российской Федерации в котором гражданин отбывал наказание
            /// </summary>
            public string OsvabajdenRegionChild { get; set; }

            /// <summary>
            /// В отношении ребенка применены меры пресечения в виде заключения под стражу
            /// </summary>
            public string PrimenenoNacazanie { get; set; }

            /// <summary>
            /// Отбывает наказание в виде лишения свободы
            /// </summary>
            public string ZakluchonChild { get; set; }

            /// <summary>
            /// субъект Российской Федерации в котором гражданин отбывает наказание
            /// </summary>
            public string ZakluchonRegionChild { get; set; }
        }

        /// <summary>
        /// из следующих утверждений о вас или членах вашей семьи является верным на момент подачи заявления
        /// </summary>
        public string InfoFamely0  { get; set; }
        public string InfoFamely1{ get; set; }
        public string InfoFamely2 { get; set; }
        public string InfoFamely3 { get; set; }
        public string InfoFamely4 { get; set; }
        public string InfoFamely5 { get; set; }
        public string InfoFamely6 { get; set; }
        public string InfoFamely7 { get; set; }

        /// <summary>
        /// утверждений о вас или членах вашей семьи является верным в период, за который рассчитывается среднедушевой доход семьи
        /// </summary>
        public string SredneDokhode { get; set; }
        public string SredneDokhode1 { get; set; }
        public string SredneDokhode2 { get; set; }
        public string SredneDokhode3 { get; set; }
        public string SredneDokhode4 { get; set; }
        public string SredneDokhode5 { get; set; }
        public string SredneDokhode6 { get; set; }
        public string SredneDokhode7 { get; set; }
        public string SredneDokhode8 { get; set; }
        public string SredneDokhode9 { get; set; }
        public string SredneDokhode10 { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Способ выплаты средств       
        /// </summary>
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Наименование кредитной организации      
        /// </summary>
        public string NameCredit { get; set; }

        /// <summary>
        /// Лицевой счет        
        /// </summary>
        public string PersonalAccount { get; set; }

        /// <summary>
        /// выплату выплачивать через:
        /// </summary>
        public string method_Oplat { get; set; }
        /// <summary>
        ///БИК кредитной организации
        /// </summary>
        public string BIK { get; set; }

        /// <summary>
        /// КПП кредитной организации
        /// </summary>
        public string KPP { get; set; }

        /// <summary>
        /// Адрес получателя
        /// </summary>
        public string Aress_Person { get; set; }
        /// <summary>
        /// Номер почтового отделения
        /// </summary>
        public string Number_Pochta { get; set; }

    }
}
