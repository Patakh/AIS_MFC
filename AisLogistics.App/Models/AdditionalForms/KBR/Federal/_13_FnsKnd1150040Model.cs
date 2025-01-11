namespace AisLogistics.App.Models;

public sealed class _13_FnsKnd1150040Model : AbstractAdditionalFormModel
{
    /// <summary>
    /// Код налогового органа
    /// </summary>
    public string CodeFNS { get; set; }

    /// <summary>       
    /// Способ информирования
    /// </summary>
    public string MethodInforming { get; set; }

    /// <summary>
    /// Жилой дом 
    /// </summary>
    public RealEstateType ResidentialBuilding { get; set; }

    /// <summary>
    /// Квартира
    /// </summary>
    public RealEstateType Flat { get; set; }

    /// <summary>
    /// Гараж 
    /// </summary>
    public RealEstateType Garage { get; set; }

    /// <summary>
    /// Помещение или сооружение, указанные в подпункте 14 пункта 1 статьи 407 Налогового кодекса Российской Федерации 
    /// </summary>
    public RealEstateType Room { get; set; }

    /// <summary>
    /// Хозяйственное строение или сооружение, указанные в подпункте 15 пункта 1 статьи 407 Налогового кодекса Российской Федерации
    /// </summary>
    public RealEstateType EconomicStructure { get; set; }

    public class RealEstateType
    { 
        /// <summary>
        /// Начало применения налоговой льготы mm.dddd
        /// </summary>
        public string DateStart { get; set; }

        /// <summary>
        /// Тип номера (1- кадастровый, 2 - условный, 3 - инвентарный)
        /// </summary>            
        public string NumberType { get; set; }

        /// <summary>
        /// Номер ОН
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Регион
        /// </summary>
        public string Region { get; set; }
    }
}
