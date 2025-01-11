namespace AisLogistics.App.Models;

/// <summary>
/// Комплексная услуга
/// </summary>
public class _34_ComprehensiveServiceModel
{
    public _34_ComprehensiveServiceModel()
    {
        AppliedDocumentList = new[]
        {
            new AppliedDocument()
        };

        ServiceList = new[]
        {
            new Service()
        };
    }

    /// <summary>
    ///  Иные сведения
    /// </summary>
    public string OtherInfo { get; set; }

    /// <summary>
    ///  Способ информирования
    /// </summary>
    public string MethodInforming { get; set; }

    /// <summary>
    /// Услуги 
    /// </summary>
    public Service[] ServiceList { get; set; }

    /// <summary>
    /// Приложенные документы
    /// </summary>
    public AppliedDocument[] AppliedDocumentList { get; set; }

    public class Service {

        /// <summary>
        /// Наименование государственной и (или) муниципальной услуги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Последовательность предоставления услуг
        /// </summary>
        public string Sequence { get; set; }
    }

    public class AppliedDocument
    {
        /// <summary>
        /// Наименование документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Реквизиты документа
        /// </summary>
        public string Rikvizits { get; set; }

        /// <summary>
        /// Количество экземпляров
        /// </summary>
        public string CopyCount { get; set; }

        /// <summary>
        /// Количество листов
        /// </summary>
        public string CopyList { get; set; }

        /// <summary>
        /// Количество оригиналов
        /// </summary>
        public string OriginalCount { get; set; }

        /// <summary>
        /// Количество листов
        /// </summary>
        public string OriginalList { get; set; }
    }
}
