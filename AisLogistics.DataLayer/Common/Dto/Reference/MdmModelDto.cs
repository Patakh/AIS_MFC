using System;

namespace AisLogistics.DataLayer.Common.Dto.Reference
{
    public class MdmModelDto
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; } 
        /// <summary>
        /// Наименование процедуры
        /// </summary>
        public string ProcedureName { get; set; }
        /// <summary>
        /// Индетификатор Цели ФРГУ
        /// </summary>
        public string FrguTargetId { get; set; }
        /// <summary>
        /// Отправлять в ИС МДМ или нет
        /// </summary>
        public bool IsMdm { get; set; }
    }
}
