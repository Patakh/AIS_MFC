using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данные по расторжению брака
    /// </summary>
    public partial class DZagsDivorce
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер записи акта о заключении брака
        /// </summary>
        public string ActNumber { get; set; }
        /// <summary>
        /// Дата составления записи акта о заключении брака
        /// </summary>
        public DateTime? ActDate { get; set; }
        /// <summary>
        /// Номер версии записи
        /// </summary>
        public string ActVersionNumber { get; set; }
        /// <summary>
        /// Дата версии записи
        /// </summary>
        public DateTime? ActVersionDate { get; set; }
        /// <summary>
        /// Дата начала действия статуса
        /// </summary>
        public DateTime? ActStatusDate { get; set; }
        /// <summary>
        /// Код статуса
        /// </summary>
        public string ActStatus { get; set; }
        /// <summary>
        /// Код/Наименование органа ЗАГС
        /// </summary>
        public string ZagsCode { get; set; }
        /// <summary>
        /// Серия свидетельства о расторжении брака
        /// </summary>
        public string SerialDocumentDivorce { get; set; }
        /// <summary>
        /// Номер свидетельства о расторжении брака
        /// </summary>
        public string NumberDocumentDivorce { get; set; }
        /// <summary>
        /// Дата выдачи свидетельства о расторжении брака
        /// </summary>
        public DateTime? DateDocumentDivorce { get; set; }
        /// <summary>
        /// Дата прекращения брака
        /// </summary>
        public DateTime? DivorceDate { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }
        /// <summary>
        /// Национальность (код)
        /// </summary>
        public string NationalityCode { get; set; }
        /// <summary>
        /// Гражданство (страна)
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }
        /// <summary>
        /// Наименование документа, удостоверяющего личность
        /// </summary>
        public string DocumentCode { get; set; }
        /// <summary>
        /// Серия и номер документа, удостоверяющего личность
        /// </summary>
        public string DocumentSerialNumber { get; set; }
        /// <summary>
        /// Дата выдачи документа, удостоверяющего личность
        /// </summary>
        public DateTime? DocumentDate { get; set; }
        /// <summary>
        /// Наименование органа, выдавшего документ, удостоверяющий личность
        /// </summary>
        public string DocumentIssuer { get; set; }
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Наименование АГС/документа
        /// </summary>
        public string DocumentNameUpdate { get; set; }
        /// <summary>
        /// Номер АГС / Серия и номер документа
        /// </summary>
        public string DocumentSerialNumberUpdate { get; set; }
        /// <summary>
        /// Дата составления АГС / Выдачи документа
        /// </summary>
        public DateTime? DocumentDateUpdate { get; set; }
        /// <summary>
        /// ЗАГС / кем выдан документ
        /// </summary>
        public string DocumentIssuerUpdate { get; set; }
        /// <summary>
        /// Код/Наименование вида записей 
        /// </summary>
        public string ActCodeUpdate { get; set; }
        /// <summary>
        /// Дата внесения исправления и изменения в запись акта гражданского состояния или дата внесения отметки  
        /// 
        /// 	о восстановлении или об аннулировании записи акта гражданского состояния
        /// </summary>
        public DateTime? ActDateUpdate { get; set; }
        /// <summary>
        /// Содержание внесенного исправления или изменения
        /// </summary>
        public string ActTextUpdate { get; set; }
        /// <summary>
        /// Фамилия до расторжения брака
        /// </summary>
        public string LastNameOld { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }
    }
}
