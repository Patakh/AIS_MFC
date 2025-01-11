using Microsoft.AspNetCore.Mvc.Rendering;

namespace AisLogistics.App.Models.AdditionalForms.Municipal
{
    /// <summary>
    ///                    Заявление
    ///        на получение специального разрешения
    ///  на движение по автомобильным дорогам тяжеловесного
    ///   и (или) крупногабаритного транспортного средства
    /// </summary> 
    public class _34_Model : AbstractAdditionalFormModel
    { 
        /// <summary>
        /// Место направления заявления
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Лицо(Физическое && Юридическое)
        /// </summary>
        public string FaceApplicant { get; set; }

        /// <summary>
        /// полное наименование юридического лица
        /// </summary>
        public string NameLegal { get; set; }

        /// <summary>
        /// ОПФ
        /// </summary>
        public string OPF_ { get; set; }

        /// <summary>
        /// ЕГРЮЛ
        /// </summary>
        public string USRLE { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Fio { get; set; }

        /// <summary>
        /// серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// номер
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Кем выдан 
        /// </summary>
        public string DocIssuer { get; set; }

        /// <summary>
        /// Дата выдачи 
        /// </summary>
        public DateTime? DocIssueDate { get; set; }

        /// <summary>
        /// Адрес места жительства
        /// </summary>
        public string AddressLife { get; set; }

        /// <summary>
        /// телефон для связи
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// ИНН
        /// </summary>
        public string INN { get; set; }

        /// <summary>
        /// ОГРН/ОГРНИП
        /// </summary>
        public string OGRN { get; set; }

        /// <summary>
        /// начало маршрута
        /// </summary>
        public string Elementary { get; set; }

        /// <summary>
        /// конечный пункт маршрута 
        /// </summary>
        public string FinalRoute { get; set; }

        /// <summary>
        /// Вид перевозки 
        /// </summary>
        public string TypeTransportation { get; set; }


        /// <summary>
        /// срок : с
        /// </summary>
        public string With { get; set; }

        /// <summary>
        ///  по
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Количество поездок 
        /// </summary>
        public string NumberTransportation { get; set; }

        /// <summary>
        /// Делимый да || нет
        /// </summary>
        public bool Divisible { get; set; }

        /// <summary>
        /// полное наименование груза
        /// </summary>
        public string NameGruz { get; set; }

        /// <summary>
        /// марка
        /// </summary>
        public string Stamp { get; set; }

        /// <summary>
        /// модель
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// описание индивидуальной и транспортной тары (способ крепления)
        /// </summary>length
        public string Description { get; set; }

        /// <summary>
        /// длина(м)
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// ширина(м)
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        /// высота(м)
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        /// Масса(т)
        /// </summary>
        public string Weight { get; set; }

        /// <summary>
        /// Длина свеса (м) 
        /// </summary>
        public string OverhangLength { get; set; }

        /// <summary>
        /// Транспортное средство
        /// марка
        /// </summary>
        public string VehicleBrand { get; set; }

        /// <summary>
        /// модель
        /// </summary>
        public string VehicModel { get; set; }

        /// <summary>
        /// государственный регистрационный номер
        /// </summary>
        public string VehicGRN { get; set; }

        /// <summary>
        /// Масса (т)
        /// </summary>
        public string VehicleWeight { get; set; }

        /// <summary>
        /// Расстояния между осями (м)
        /// </summary>
        public string DistancesBetweenAxes { get; set; }

        /// <summary>
        /// Нагрузки на оси (т)
        /// </summary>
        public string AxleLoads { get; set; }

        /// <summary>
        /// Габариты транспортного средства 
        /// Длина (м)
        /// </summary>
        public string VehicleLength { get; set; }

        /// <summary>
        /// Ширина (м)
        /// </summary>
        public string VehicleWidth { get; set; }

        /// <summary>
        /// Высота (м) 
        /// </summary>
        public string VehicleHeight { get; set; }
        
        /// <summary>
        ///  Длина свеса(при наличии)
        /// </summary>
        public string VehicOverhangLength { get; set; }

        /// <summary>
        /// Минимальный радиус поворота с грузом (м)
        /// </summary>
        public string MinimumTurningRadius { get; set; }

        /// <summary>
        /// Способ связи: 
        /// </summary>
        public string CommunicationMethod{ get; set; }
        
    }
}
