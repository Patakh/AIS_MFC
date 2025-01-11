namespace AisLogistics.App.Models;

/// <summary>
/// Предоставление сведений и документов, содержащихся в Едином государственном реестре юридических лиц и Едином государственном реестре индивидуальных предпринимателей (в части предоставления по запросам физических и юридических лиц выписок из указанных реестров, за исключением выписок, содержащих сведения ограниченного доступа)
/// </summary>
public class _10_3_LegalDigitalInfoModel : AbstractAdditionalFormModel
{
    /// <summary>
    /// ОГРНИП
    /// </summary>
    public string OGRPNIP { get; set; }

    /// <summary>       
    /// Способ информирования
    /// </summary>
    public string MethodInforming { get; set; }
}