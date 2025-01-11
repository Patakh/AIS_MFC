namespace AisLogistics.App.Models;

/// <summary>
/// Государственная регистрация юридического лица в связи с его ликвидацией
/// </summary>
public class _7_UFNS_R16001Model
{
    /// <summary>
    /// 1. Сведения о  юридическом лице, содержащиеся в Едином государственном реестре юридических лиц
    /// ОГРН
    /// </summary>
    public string LegalOGRN { get; set; }

    /// <summary>
    /// ИНН
    /// </summary>
    public string LegalINN { get; set; }

    /// <summary>
    /// Полное наименование на русском языке
    /// </summary>
    public string LegalFullName { get; set; }

    /// <summary>
    /// Дата публикации сообщения о принятом решении
    /// </summary>
    public string LegalRealizeDate { get; set; }

    /// <summary>
    /// Заявителем является
    /// </summary>
    public string ApplicantType { get; set; }

    /// <summary>
    /// Адрес места жительства
    /// </summary>
    public Address AddressResidence { get; set; }

    /// <summary>
    /// За пределами территории Российской Федерации
    /// Страна места жительства
    /// </summary>
    public string ForiginContryResidence { get; set; }

    /// <summary> 
    /// Адрес места жительства
    /// </summary>
    public string ForiginAddressResidence { get; set; }

    /// <summary> 
    /// Прошу документы, подтверждающие факт внесения записи в Единый государственный реестр юридических лиц, или решение об отказе в государственной регистрации
    /// </summary>
    public string Response { get; set; }
    
    /// <summary>
    /// Лицо, засвидетельствовавшее подлинность подписи заявителя: 
    /// </summary>
    public string PersonAuthenticatedSignatureTypeId { get; set; }

    /// <summary>
    /// ИНН лица, засвидетельствовавшего подлинность подписи заявителя
    /// </summary>
    public string PersonAuthenticatedSignatureINN { get; set; }

    public class Address {

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string PostalIndex { get; set; }

        /// <summary>
        /// Субъект Российской Федерации
        /// </summary>
        public string SubjectRF { get; set; }

        /// <summary>
        /// Район
        /// </summary>
        public AddressElement District { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public AddressElement Town { get; set; }

        /// <summary>
        /// Населенный пункт
        /// </summary>
        public AddressElement Locality { get; set; }
         
        /// <summary>
        /// Улица
        /// </summary>
        public AddressElement Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        public AddressElement House { get; set; }

        /// <summary>
        /// Корпус
        /// </summary>
        public AddressElement Body { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        public AddressElement Flat { get; set; }
    }

    public class AddressElement {

        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
