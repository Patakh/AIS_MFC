using AisLogistics.DataLayer.Entities.Models;

namespace AisLogistics.App.Models.DTO.References
{
    //public class EmployeesOfficesJoinDto
    //{
    //    public Guid Id { get; set; }

    //    //Сотрудник
    //    public Guid SEmployeesId { get; set; }
    //    public string EmployeeName { get; set; }

    //    //Офис
    //    public Guid SOfficesId { get; set; }
    //    public string OfficeName { get; set; }

    //    //Должность
    //    public int SEmployeesJobPositionId { get; set; }
    //    public string JobPositionName { get; set; }

    //    //Статус
    //    public int SEmployeesStatusId { get; set; }
    //    public string? StatusName { get; set; }

    //    //Исполнение
    //    public bool? IsExecution { get; set; }
    //    //public EmployeeExecutionDto? EmployeeExecution { get; set; }

    //    //Активность
    //    public bool? IsActive { get; set; }
    //}


    public class EmployeesOfficesJoinDto
    {
        public Guid Id { get; set; }

        //Сотрудник
        public Guid SEmployeesId { get; set; }
        public string EmployeeName { get; set; }

        public EmployeeOffice? EmployeeOfficeInfo { get; set; }

        public EmployeeStatus? EmployeeStatusInfo { get; set; }

        //Исполнение
        public bool? IsExecution { get; set; }
        //public EmployeeExecutionDto? EmployeeExecution { get; set; }

        //Активность
        public bool? IsActive { get; set; }
    }

    public class EmployeeOffice
    {
        //Офис
        public Guid SOfficesId { get; set; }
        public string OfficeName { get; set; }

        //Должность
        public int SEmployeesJobPositionId { get; set; }
        public string JobPositionName { get; set; }
    }

    public class EmployeeStatus
    {
        //Статус
        public int SEmployeesStatusId { get; set; }
        public string? StatusName { get; set; }
    }

}
