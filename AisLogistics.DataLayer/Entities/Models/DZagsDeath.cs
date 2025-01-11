using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Данные по смертности с ЗАГС
    /// </summary>
    public partial class DZagsDeath
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Номер записи акта о смерти
        /// </summary>
        public string ActNumber { get; set; }
        /// <summary>
        /// Дата составления записи акта о смерти
        /// </summary>
        public DateTime ActDate { get; set; }
        /// <summary>
        /// Код/Наименование органа ЗАГС
        /// </summary>
        public string ZagsCode { get; set; }
        /// <summary>
        /// Статус (код/наименование) записи акта
        /// </summary>
        public string ActStatus { get; set; }
        /// <summary>
        /// Серия Свидетельства
        /// </summary>
        public string SerialDocumentDeath { get; set; }
        /// <summary>
        /// Номер Свидетельства
        /// </summary>
        public string NumberDocumentDeath { get; set; }
        /// <summary>
        /// Признак умершего лица, личность которого не установлена
        /// </summary>
        public bool? IsDeath { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Гражданство (страна)
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string BirthPlace { get; set; }
        /// <summary>
        /// Дата рождения (может быть без Дня и/или месяца)
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string Address { get; set; }
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
        /// Дата смерти (может быть без Дня и/или месяца)
        /// </summary>
        public string DeathDate { get; set; }
        /// <summary>
        /// Время Смерти
        /// </summary>
        public TimeOnly? DeathTime { get; set; }
        /// <summary>
        /// Место смерти
        /// </summary>
        public string DeathPlace { get; set; }
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
        /// Наименование АГС/документа
        /// </summary>
        public string DocumentNameUpdate { get; set; }
        /// <summary>
        /// Серия документа исправившего
        /// </summary>
        public string DocumentSerialNumberUpdate { get; set; }
        /// <summary>
        /// Дата составления
        /// </summary>
        public DateTime? DocumentDateUpdate { get; set; }
        /// <summary>
        /// Кем выдан
        /// </summary>
        public string DocumentIssuerUpdate { get; set; }
        /// <summary>
        /// Номер версии записи
        /// </summary>
        public string ActVersionNumber { get; set; }
        /// <summary>
        /// Дата версии записи
        /// </summary>
        public DateTime ActVersionDate { get; set; }
        /// <summary>
        /// Дата выдачи свидетельства о смерти
        /// </summary>
        public DateTime? DateDocumentDeath { get; set; }
        /// <summary>
        /// Национальность
        /// </summary>
        public string NationalityCode { get; set; }
        /// <summary>
        /// Семейное положение
        /// </summary>
        public string MaritalStatusCode { get; set; }
        /// <summary>
        /// Образование
        /// </summary>
        public string EducationCode { get; set; }
        /// <summary>
        /// Занятость
        /// </summary>
        public string EmploymentCode { get; set; }
        /// <summary>
        /// Причины смерти
        /// </summary>
        public string DeathCause { get; set; }
        /// <summary>
        /// Обстоятельства смерти
        /// </summary>
        public string DeathCircumstancesCode { get; set; }
        /// <summary>
        /// Место наступления смерти (код)
        /// </summary>
        public string DeathPlaceCode { get; set; }
        /// <summary>
        /// Лицо, установившее причину смерти (код)
        /// </summary>
        public string SetCauseDeathPersonCode { get; set; }
        /// <summary>
        /// ФИО врача, установившего причину смерти
        /// </summary>
        public string SetCauseDeathPersonFio { get; set; }
        /// <summary>
        /// Основание, послужившее для установления причины смерти
        /// </summary>
        public string SetCauseDeathBasic { get; set; }
        /// <summary>
        /// Код документа, подтверждающего факт смерти
        /// </summary>
        public string DocumentConfirmDeathCode { get; set; }
        /// <summary>
        /// Серия и номер документа, подтверждающего факт смерти
        /// </summary>
        public string DocumentConfirmDeathSerialNumber { get; set; }
        /// <summary>
        /// Дата документа, подтверждающего факт смерти
        /// </summary>
        public DateTime? DocumentConfirmDeathDate { get; set; }
        /// <summary>
        /// Кем выдан документ, подтверждающий факт смерти
        /// </summary>
        public string DocumentConfirmDeathIssuer { get; set; }
    }
}
