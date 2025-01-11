namespace AisLogistics.App.Models
{
    public class FnsAccountingKbrModel : AbstractAdditionalFormModel
    {
       
        public FnsAccountingKbrModel()
        {


        }
        #region Блок1
        /// <summary>
        /// Код налогового органа
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Гражданство
        /// </summary>
        public int CitizenshipType { get; set; }
        /// <summary>
        /// Код страны
        /// </summary>
        public string? CodeCountry { get; set; } 
        /// <summary>
        /// Количество Копий
        /// </summary>
        public int SheetCount {get;set;}
        #endregion

        #region Блок2
        /// <summary>
        /// Срок действия документа удостоверяющего личность
        /// </summary> 
        public DateTime? ValidityPeriodDocument { get; set; }

        /// <summary>
        /// Номер записи акта гражданского состояния
        /// </summary> 
        public string? ActRecordNumberZags { get; set; }

        public Document DocumentConfirmingRight { get; set; }
        public Document DocumentConfirmingRegistration { get; set; }

        public class Document 
        { 
            public string? IndentityCode { get; set; }
            public string? Serial { get; set; }
            public string? Number { get; set; }
            public string? IssueBody { get; set; }
            public DateTime? IssueDate { get; set; }
            public DateTime? ValidityPeriodDocument { get; set; }
        }


        #endregion 

    }
}
