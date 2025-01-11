using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Entities.Models
{
    /// <summary>
    /// Справочник отделений ФНС (общероссийский классификатор организационно-правовых форм), осуществляющих государственную регистрацию.
    /// </summary>
    public partial class SSmevClassFnsReg
    {
        /// <summary>
        /// Код налогового органа или его территориального участка (подразделения), осуществляющего регистрацию
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Сокращенное наименование РО
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
    }
}
