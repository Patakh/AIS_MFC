namespace AisLogistics.App.Settings;

/// <summary>
/// Статус СМЭВ запросов
/// </summary>
public enum SmevStatusType
{
    /// <summary>
    /// Просрочено
    /// </summary>
    Expired,
    /// <summary>
    /// Отправлено
    /// </summary>
    Sent,
    /// <summary>
    /// Ошибка
    /// </summary>
    Error,
    /// <summary>
    /// Получен ответ
    /// </summary>
    ResponseSuccess,
}