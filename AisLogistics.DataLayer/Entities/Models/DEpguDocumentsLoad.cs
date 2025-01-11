using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для получения данных из системы ЕОС Дело
    /// </summary>
    public partial class DEpguDocumentsLoad
    {
        public DEpguDocumentsLoad()
        {
            DEpguDocumentsResponses = new HashSet<DEpguDocumentsResponse>();
        }

        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Cвязь с номером обращения, data_services_info id
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Связь со справочником spr_smev_system_access -&gt; id, идентифицирует систему, от которой пришел запрос
        /// </summary>
        public Guid SSmevSystemAccessId { get; set; }
        /// <summary>
        /// Флаг, что запрос сделан в тестовом режиме (эмулятор)
        /// </summary>
        public bool? TestMode { get; set; }
        /// <summary>
        /// Дата и время получения данных из запроса
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Начальный идентификатор MessageId запроса
        /// </summary>
        public Guid OriginalMessageId { get; set; }
        /// <summary>
        /// Идентификатор МФЦ из справочника ПГУ
        /// </summary>
        public string PortalMfcId { get; set; }
        /// <summary>
        /// Идентификатор зявления на ЕПГУ, для изменения статуса заявления или приглашениия на прием через сервис ЕЛК
        /// </summary>
        public long EpguOrderId { get; set; }
        /// <summary>
        /// Наименование услуги в АИС Дело, по которой пришли документы
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Код результата оказания услуги, принятого ведомством (1 - Исполнено, 2 - Отказ)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Комментарий к коду результата, принятого ведомством
        /// </summary>
        public string StatusComment { get; set; }
        /// <summary>
        /// Количество вложений в принятом пакете документов
        /// </summary>
        public int AttachmentCount { get; set; }
        /// <summary>
        /// Тип заявителя (1 - физическое лицо, 2 - юридическое лицо)
        /// </summary>
        public int ApplicantType { get; set; }
        /// <summary>
        /// ФИО заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysFio { get; set; }
        /// <summary>
        /// Дата рождения заявителя (физическое лицо)
        /// </summary>
        public DateTime? ApplicantPhysBirthdate { get; set; }
        /// <summary>
        /// Место рождения заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysBirthplace { get; set; }
        /// <summary>
        /// СНИЛС заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysSnils { get; set; }
        /// <summary>
        /// Email заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysEmail { get; set; }
        /// <summary>
        /// Адрес регистрации заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysRegAddress { get; set; }
        /// <summary>
        /// Адрес проживания заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysLivingAddress { get; set; }
        /// <summary>
        /// Тип документа заявителя (физическое лицо) (1 - паспорт РФ, 2 - иностранный паспорт, 3 - вид на жительство)
        /// </summary>
        public int? ApplicantPhysIdentityType { get; set; }
        /// <summary>
        /// Серия документа заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysIdentitySeries { get; set; }
        /// <summary>
        /// Номер документа заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysIdentityNumber { get; set; }
        /// <summary>
        /// Дата выдачи документа заявителя (физическое лицо)
        /// </summary>
        public DateTime? ApplicantPhysIdentityDate { get; set; }
        /// <summary>
        /// Орган выдачи документа заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysIdentityIssuer { get; set; }
        /// <summary>
        /// Код подразделения органа выдачи документа заявителя (физическое лицо)
        /// </summary>
        public string ApplicantPhysIdentityIssuerCode { get; set; }
        /// <summary>
        /// Организационно-правовая формая (юридическое лицо)
        /// </summary>
        public string ApplicantLegalForm { get; set; }
        /// <summary>
        /// Полное фирменное наименование (юридическое лицо)
        /// </summary>
        public string ApplicantLegalFullname { get; set; }
        /// <summary>
        /// Сокращенное фирменное наименование (юридическое лицо)
        /// </summary>
        public string ApplicantLegalName { get; set; }
        /// <summary>
        /// ИНН (юридическое лицо)
        /// </summary>
        public string ApplicantLegalInn { get; set; }
        /// <summary>
        /// ОГРН (юридическое лицо)
        /// </summary>
        public string ApplicantLegalOgrn { get; set; }
        /// <summary>
        /// КПП (юридическое лицо)
        /// </summary>
        public string ApplicantLegalKpp { get; set; }
        /// <summary>
        /// Адрес юридический (юридическое лицо)
        /// </summary>
        public string ApplicantLegalAddress { get; set; }
        /// <summary>
        /// Адрес почтовый (юридическое лицо)
        /// </summary>
        public string ApplicantLegalFactAddress { get; set; }
        /// <summary>
        /// Контактный телефон (юридическое лицо)
        /// </summary>
        public string ApplicantLegalPhone { get; set; }
        /// <summary>
        /// Адрес электронной почты (юридическое лицо)
        /// </summary>
        public string ApplicantLegalEmail { get; set; }
        /// <summary>
        /// ФИО руководителя (юридическое лицо)
        /// </summary>
        public string ApplicantLegalChiefFio { get; set; }
        /// <summary>
        /// Флаг, что вложения данных запроса прикреплены к делу и отправлены на FTP МФЦ.
        /// </summary>
        public bool AttachedToMfcData { get; set; }
        /// <summary>
        /// Статус отправки в ЕЛК:
        /// 0 - Приглашение на прием не отправлено;
        /// 1 - Приглашение на прием отправлено;
        /// 2 - Требуется отправить статус &quot;Исполнено&quot;;
        /// 3 - Статус &quot;Исполнено&quot; отправлен.
        /// 
        /// </summary>
        public int ElkStage { get; set; }
        /// <summary>
        /// Контактный телефон (физическое лицо)
        /// </summary>
        public string ApplicantPhysPhone { get; set; }

        public virtual DCase DCases { get; set; }
        public virtual SSmevSystemAccess SSmevSystemAccess { get; set; }
        public virtual ICollection<DEpguDocumentsResponse> DEpguDocumentsResponses { get; set; }
    }
}
