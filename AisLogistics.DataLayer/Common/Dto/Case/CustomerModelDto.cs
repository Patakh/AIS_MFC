using System;
using System.Collections.Generic;

namespace AisLogistics.DataLayer.Common.Dto.Case
{
    public class CustomerModelDto
    {
        /// <summary>
        /// Первичный ключ
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Связь со справочником документов, удостоверяющих личность заявителя
        /// </summary>
        public int SDocumentsIdentityId { get; set; }
        /// <summary>
        /// Пол заявителя (1 - мужской, 2 - женский)
        /// </summary>
        public int CustomerGender { get; set; }
        /// <summary>
        /// Номер документа
        /// </summary>
        public string? DocumentNumber { get; set; }
        /// <summary>
        /// Серия документа
        /// </summary>
        public string? DocumentSerial { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime? DocumentBirthDate { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string? DocumentBirthPlace { get; set; }
        /// <summary>
        /// Дата выдачи паспорта
        /// </summary>
        public DateTime? DocumentIssueDate { get; set; }
        /// <summary>
        /// Наименование отделения, выдавшего паспорт
        /// </summary>
        public string? DocumentIssueBody { get; set; }
        /// <summary>
        /// Код документа
        /// </summary>
        public string? DocumentCode { get; set; }
        /// <summary>
        /// ИНН
        /// </summary>
        public string? CustomerInn { get; set; }
        /// <summary>
        /// Номер телефона 1
        /// </summary>
        public string? CustomerPhone1 { get; set; }
        /// <summary>
        /// Номер телефона 2
        /// </summary>
        public string? CustomerPhone2 { get; set; }
        /// <summary>
        /// Электронная почта заявителя
        /// </summary>
        public string? CustomerEmail { get; set; }
        /// <summary>
        /// Адрес регистрации
        /// </summary>
        public string? CustomerAddress { get; set; }
        /// <summary>
        /// ОКАТО
        /// </summary>
        public string? CustomerOkato { get; set; }
        /// <summary>
        /// ОКТМО
        /// </summary>
        public string? CustomerOktmo { get; set; }
        /// <summary>
        /// КОД региона
        /// </summary>
        public string? CustomerCodeRegion { get; set; }
        /// <summary>
        /// СНИЛС Заявителя
        /// </summary>
        public string? CustomerSnils { get; set; }
        /// <summary>
        /// Дата и время добавления записи
        /// </summary>
        public DateTime DateAdd { get; set; }
        /// <summary>
        /// Адрес регистрации детальный
        /// </summary>
        public string? CustomerAddressDetail { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? SecondName { get; set; }
        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string? CustomerAddressResidence { get; set; }
        /// <summary>
        /// Дата временной регистрации
        /// </summary>
        public DateTime? DateTempRegistration { get; set; }
        /// <summary>
        /// Адрес регистрации временный
        /// </summary>
        public string? CustomerAddressTemp { get; set; }
        /// <summary>
        /// Сотрудник, добавивший заявителя
        /// </summary>
        public string EmployeesFioAdd { get; set; }

        public AddressDetails? AddressDetails { get; set; }

        public string Fio()
        {
            List<string> list = new();
            if (!string.IsNullOrEmpty(FirstName)) list.Add(LastName);
            if (!string.IsNullOrEmpty(LastName)) list.Add(FirstName);
            if (!string.IsNullOrEmpty(SecondName)) list.Add(SecondName);

            return string.Join(" ", list);
        } 

    }

    public class AddressDetails
    {
        /// <summary>
        /// Регион
        /// </summary>
        public AddressFieldType? Region { get; set; }
        /// <summary>
        /// Район
        /// </summary>
        public AddressFieldType? Area { get; set; }
        /// <summary>
        /// Поселение
        /// </summary>
        public AddressFieldType? CityAndRuralSettlements { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        public AddressFieldType? City { get; set; }
        /// <summary>
        /// Населённый пункт
        /// </summary>
        public AddressFieldType? Settlement { get; set; }
        /// <summary>
        /// Внутригородской район
        /// </summary>
        public AddressFieldType? IntracityDistrict { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        public AddressFieldType? Street { get; set; }
        /// <summary>
        /// Дом
        /// </summary>
        public AddressHouseField? House { get; set; }
        /// <summary>
        /// Квартира
        /// </summary>
        public AddressRoomField? Room { get; set; }

    }

    public class AddressFieldType
    {
        public Guid? ObjectGuid { get; set; }
        public string? RegionCode { get; set; }
        public string? ShortName { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
    public class AddressHouseField
    {
        public Guid? ObjectGuid { get; set; }
        /// <summary>
        /// Номер корпуса
        /// </summary>
        public string? BuildNum { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        public string? HouseNum { get; set; }
        /// <summary>
        /// Номер строения
        /// </summary>
        public string? StructNum { get; set; }
        public string? PostalCode { get; set; }
        public string? Okato { get; set; }
        public string? Oktmo { get; set; }
    }
    public class AddressRoomField
    {
        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string? FlatNumber { get; set; }
        /// <summary>
        /// Тип помещения квартиры
        /// </summary>
        public string? FlatType { get; set; }
        public Guid? ObjectGuid { get; set; }
    }

    public class CustomerServiceModelDto : CustomerModelDto
    {
        /// <summary>
        /// Номер дела заявителя
        /// </summary>
        public string DCasesId { get; set; }
        /// <summary>
        /// Тип заявителя (1 - Заявитель, 2 - Представитель)
        /// </summary>
        public int CustomerType { get; set; }
        /// <summary>
        /// Согласие на участие в региональном опросе
        /// </summary>
        public bool PollRegionSms { get; set; }
        /// <summary>
        /// Согласие на участие ИАС МКГУ (0 - отказ, 1 - СМС, 2 - Через теминал)
        /// </summary>
        public int PollIasMkgu { get; set; }
        /// <summary>
        /// Способ оповещения, связь со справочником оповещений
        /// </summary>
        public int SAlertCustomerId { get; set; }
        /// <summary>
        /// Номер доверенности
        /// </summary>
        public string NumberProcuration { get; set; }
        public string NameProcuration { get; set; }
        public string IssueBodyProcuration { get; set; }
        public DateTime? IssueDateProcuration { get; set; }
        public string PeriodProcuration { get; set; }
        /// <summary>
        /// Сотрудник, добавивший заявителя
        /// </summary>
        public Guid SEmployeesId { get; set; }
        /// <summary>
        /// Филиал сотрудника, добавившего заявителя
        /// </summary>
        public Guid SOfficesId { get; set; }
        /// <summary>
        /// Должность сотрудника добавившего заявителя
        /// </summary>
        public int SEmployeesJobPositionId { get; set; }
    }

}
