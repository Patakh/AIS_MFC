namespace AisLogistics.DataLayer.Utils;

public static class ErrorDescription
{
    public const string InvalidInputParameters = "Не правильное значение входных параметров.";
    public const string DbQueryExecutionError = "Ошибка выполнения запроса к БД.";
    public const string InternalServerError = "Внутренняя ошибка сервиса.";

    public const string CommentLengthOutOfRange = "Комментарий содержит более 255 символов.";
    public const string CommentNotUpdate = "Примечание изменяется в течние суток";




    public const string InvalidEmployeeId = "Невалидный идентификатор сотрудника.";
    public const string InvalidFileId = "Невалидный идентификатор файла.";
    public const string InvalidServiceId = "Невалидный идентификатор услуги.";
    public const string InvalidDocumentId = "Невалидный идентификатор документа.";
        
    public const string EmployeeNotFound = "Сотрудник не найден";
    public const string CustomerNotFound = "Заявитель не найден";
    public const string FileNotFound = "Файл не найден.";
    public const string ServiceNotFound = "Услуга не найдена.";
    public const string ProcedureNotFound = "Процедура не найдена.";
    public const string CaseNotFound = "Обращение не найдено.";
    public const string DocumentNotFound = "Документ не найден.";
    public const string OfficeNotFound = "Филиал не найден.";
    public const string FtpServerNotFound = "ФТП не найден.";
    public const string CommentNotFound = "Комментарий не найден.";
}