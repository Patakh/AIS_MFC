using AisLogistics.App.Models.DTO.References;

namespace AisLogistics.App.Service
{
    /// <summary>
    /// Справочники - Сотрудники - Авторизация
    /// </summary>
    public partial class ReferencesService : IReferencesService
    {
        /// <summary>
        /// Изменить пароль сотрудника
        /// </summary>
        /// <param name="password">Данные о новом пароле</param>
        public async Task EmployeePasswordChange(EmployeePasswordChangeDto password)
        {
            var emlpoyee = await GetEmployeeDtoAsync(password.EmployeeId);


        }
    }
}
