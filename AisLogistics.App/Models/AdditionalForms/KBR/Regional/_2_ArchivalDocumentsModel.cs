namespace AisLogistics.App.Models;

/// <summary>
/// Выдача копий архивных документов, подтверждающих право на владение землей (местная администрация)
/// </summary>
public class _2_ArchivalDocumentsModel
{  
    /// <summary>
    /// Прошу предоставить архивную справку (архивную выписку, архивную копию)
    /// </summary>
    public string Request { get; set; }

    /// <summary>
    /// от
    /// </summary>
    public string FIOGen { get; set; }
}
