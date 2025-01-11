﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                       ГАРАНТИЙНОЕ ПИСЬМО 
    /// Просим предоставить разрешение на осуществление земляных работ по
    ///                         данному проекту
    /// </summary>
    public class _30_2_Model : AbstractAdditionalFormModel
    {
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// наименование организации 
        /// </summary>
        public string NameOrganization { get; set; }

        /// <summary>
        /// место нахождения
        /// </summary>
        public string AdressRecipient { get; set; }

        /// <summary>
        /// полное наименование банка
        /// </summary>
        public string NameBank { get; set; }

        /// <summary>
        ///  Счет 
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        ///  БИК 
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// корреспондентский счет
        /// </summary>
        public string CorrespondentAccount { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }
        
        /// <summary>
        /// телефон 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// вид работы
        /// </summary>
        public string TypeWork { get; set; }

        /// <summary>
        /// от
        /// </summary>
        public string With { get; set; }

        /// <summary>
        /// До
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// наименование подрядной организации
        /// </summary>
        public string NameСontractorOrganization { get; set; }

        /// <summary>
        ///  по адресу 
        /// </summary>
        public string Adress { get; set; }


    }
}
    