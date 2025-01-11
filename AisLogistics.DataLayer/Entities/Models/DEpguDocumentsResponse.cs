using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Таблица для хранения ответов для системы ЕОС Дело
    /// </summary>
    public partial class DEpguDocumentsResponse
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь с таблицей data_epgu_documents_load -&gt; id
        /// </summary>
        public Guid DEpguDocumentsLoadId { get; set; }
        /// <summary>
        /// Дата и время создания ответа
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// Статус в ответе (0 - Успешно зарегистрировано в МФЦ, 1 - Ошибка регистрации в МФЦ)
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Идентификатор MessageId ответа
        /// </summary>
        public Guid? MessageId { get; set; }
        /// <summary>
        /// Дата и время, когда ответ ушел в систему Дело
        /// </summary>
        public DateTime? DateResponseRequested { get; set; }
        /// <summary>
        /// Дата и время, когда пришло подтверждение получения ответа от системы Дело
        /// </summary>
        public DateTime? DateAckConfirmed { get; set; }
        /// <summary>
        /// Флаг, что это ответ на запрос, сделаный в тестовом режиме (эмулятор).
        /// </summary>
        public bool TestMode { get; set; }
        /// <summary>
        /// Связь со справочником spr_smev_system_access -&gt; id, идентифицирует систему, от которой пришел запрос
        /// </summary>
        public Guid SSmevSystemAccessId { get; set; }
        /// <summary>
        /// Комментарий к статусу в ответе
        /// </summary>
        public string StatusComment { get; set; }

        public virtual DEpguDocumentsLoad DEpguDocumentsLoad { get; set; }
        public virtual SSmevSystemAccess SSmevSystemAccess { get; set; }
    }
}
