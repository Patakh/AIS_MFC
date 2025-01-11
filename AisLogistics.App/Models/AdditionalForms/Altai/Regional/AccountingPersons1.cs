namespace AisLogistics.App.Models.AdditionalForms.Regional
{
    /// <summary>
    /// Внесение изменений в сведения, содержащиеся в списке, по заявлению физического лица
    /// </summary>
    public class AccountingPersons1 : AbstractAdditionalFormModel
    {
        public AccountingPersons1()
        {
            FamilyList = new[]{
                new Family(),
            };
            AppliedDocumentList = new[]
           {
                new AppliedDocument()
            };
        }
        public class Person
        {
            /// <summary>
            /// Фамилия
            /// </summary>
            public string F { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string I { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            public string O { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public string BirthDate { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            public string AddressBirth { get; set; }

            /// <summary>
            /// Пол
            /// </summary>
            public string Gender { get; set; }

            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан паспорт
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи паспорта
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Код подразделения паспорта
            /// </summary>
            public string DocDevision { get; set; }

            /// <summary>
            ///  СНИЛС
            /// </summary>
            public string SNILS { get; set; }

            /// <summary>
            ///  ИНН
            /// </summary>
            public string INN { get; set; }

            /// <summary>
            ///  Наименование коренного малочисленного народа
            /// </summary>
            public string NameNaroda { get; set; }
        }

        public class Adress
        {
            /// <summary>
            /// Почтовый индекс
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// Субъект Российской Федерации
            /// </summary>
            public string Region { get; set; }

            /// <summary>
            /// Район
            /// </summary>
            public string Raion { get; set; }

            /// <summary>
            /// Населенный пункт
            /// </summary>
            public string NP { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            public string Street { get; set; }

            /// <summary>
            /// Номер дома
            /// </summary>
            public string HouseNumber { get; set; }

            /// <summary>
            /// Номер корпуса
            /// </summary>
            public string KorpuseNumber { get; set; }

            /// <summary>
            /// Номер квартиры
            /// </summary>
            public string FlatNumber { get; set; }

            /// <summary>
            /// Является адресом местной администрации поселения в муниципальном районе, в границах которого проходят маршруты кочевий
            /// </summary>
            public bool? IsKhz { get; set; }

        }


        /// <summary>
        /// 1. Сведения о гражданине Российской Федерации(в соответствии с основным документом, удостоверяющим личность)
        /// </summary>
        public Person Applicant { get; set; }

        /// <summary>
        /// 2. Сведения, подлежащие изменению
        /// </summary>
        public ChangeInfo Change_Info { get; set; }

        public class ChangeInfo
        {
            /// <summary>
            /// Наименование коренного малочисленного народа
            /// </summary>
            public string NameNaroda_W { get; set; }

            /// <summary>
            /// Полное наименование организации
            /// </summary>
            public string FullNameOrganization_W { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN_W { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INN_W { get; set; }


            ///Членство в общине коренных малочисленных народов (при наличии) 
            /// <summary>
            /// Наименование коренного малочисленного народа
            /// </summary>
            public string NameNaroda_S { get; set; }

            /// <summary>
            /// Полное наименование организации
            /// </summary>
            public string FullNameOrganization_S { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN_S { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INN_S { get; set; }



            ///2.4. Сведения о ведении традиционного образа жизни и традиционной хозяйственной деятельности 
            /// <summary>
            /// 2.4.1. Веду традиционный образ жизни и традиционную хозяйственную деятельность:
            /// </summary>
            public bool Is_2_4_1 { get; set; }

            /// <summary>
            /// 2.4.2. Традиционная хозяйственной деятельности является подсобной по отношению к основному виду деятельности:
            /// </summary>
            public bool Is_2_4_2 { get; set; }

            ///2.4.3. Осуществляемый вид (виды) традиционной хозяйственной деятельности: 
            /// <summary>
            /// 2.4.3.1. Животноводство, в том числе кочевое (оленеводство, коневодство, яководство, овцеводство).
            /// </summary>
            public bool Is_2_4_3_1 { get; set; }

            /// <summary>
            /// 2.4.3.2. Переработка продукции животноводства, включая сбор, заготовку и выделку шкур, шерсти, волоса, окостенелых рогов, копыт, пантов, костей, эндокринных желез, мяса, субпродуктов.
            /// </summary>
            public bool Is_2_4_3_2 { get; set; }

            /// <summary>
            /// 2.4.3.3. Собаководство (разведение оленегонных, ездовых и охотничьих собак).
            /// </summary>
            public bool Is_2_4_3_3 { get; set; }

            /// <summary>
            /// 2.4.3.4. Разведение зверей, переработка и реализация продукции звероводства.
            /// </summary>
            public bool Is_2_4_3_4 { get; set; }

            /// <summary>
            /// 2.4.3.5. Бортничество, пчеловодство.
            /// </summary>
            public bool Is_2_4_3_5 { get; set; }

            /// <summary>
            /// 2.4.3.6. Рыболовство (в том числе морской зверобойный промысел) и реализация водных биологических ресурсов.
            /// </summary>
            public bool Is_2_4_3_6 { get; set; }

            /// <summary>
            /// 2.4.3.7. Промысловая охота, переработка и реализация охотничьей продукции.
            /// </summary>
            public bool Is_2_4_3_7 { get; set; }

            /// <summary>
            /// 2.4.3.8. Земледелие (огородничество), а также разведение и переработка ценных в лекарственном отношении растений.
            /// </summary>
            public bool Is_2_4_3_8 { get; set; }

            /// <summary>
            /// 2.4.3.9. Заготовка древесины и недревесных лесных ресурсов для собственных нужд.
            /// </summary>
            public bool Is_2_4_3_9 { get; set; }

            /// <summary>
            /// 2.4.3.10. Собирательство (заготовка, переработка и реализация пищевых лесных ресурсов, сбор лекарственных растений).
            /// </summary>
            public bool Is_2_4_3_10 { get; set; }

            /// <summary>
            /// 2.4.3.11. Добыча и переработка общераспространенных полезных ископаемых для собственных нужд.
            /// </summary>
            public bool Is_2_4_3_11 { get; set; }

            /// <summary>
            /// 2.4.3.12. Художественные промыслы и народные ремесла (кузнечное и железоделательное ремесло, изготовление утвари, инвентаря, лодок, нарт, иных традиционных средств передвижения, музыкальных инструментов, берестяных изделий, чучел промысловых зверей и птиц, сувениров из меха оленей и промысловых зверей и птиц, иных материалов, плетение из трав и иных растений, вязание сетей, резьба по кости, резьба по дереву, пошив национальной одежды и другие виды промыслов и ремесел, связанные с обработкой меха, кожи, кости и других материалов).
            /// </summary>
            public bool Is_2_4_3_12 { get; set; }

            /// <summary>
            /// 2.4.3.13. Строительство национальных традиционных жилищ и других построек, необходимых для осуществления традиционных видов хозяйственной деятельности.
            /// </summary>
            public bool Is_2_4_3_13 { get; set; }
        }

        ///  <summary>
        /// 4. Сведения о лице, имеющем право без доверенности действовать от имени общины коренных
        ///        малочисленных народов Россиской Федерации, членом которой является гражданин, 
        ///                       в отношении которого представлены документы
        /// </summary>
        public PersonLegal Legal { get; set; }
        public class PersonLegal : Person
        {
            /// <summary>
            /// Должность
            /// </summary>
            public string Job { get; set; }

            /// <summary>
            /// Полное наименование организации
            /// </summary>
            public string FullName { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN { get; set; }
        }

        /// <summary>
        /// Члены семьи
        /// </summary>
        public Family[] FamilyList { get; set; }
        public class Family
        {
            /// <summary>
            /// Степень родства
            /// </summary>
            public string DegreeKinship { get; set; }
            /// <summary>
            /// Фамилия
            /// </summary>
            public string F { get; set; }

            /// <summary>
            /// Имя
            /// </summary>
            public string I { get; set; }

            /// <summary>
            /// Отчество
            /// </summary>
            public string O { get; set; }

            /// <summary>
            /// Дата рождения
            /// </summary>
            public string BirthDate { get; set; }

            /// <summary>
            /// Место рождения
            /// </summary>
            public string AddressBirth { get; set; }

            /// <summary>
            /// Серия паспорта
            /// </summary>
            public string DocSeries { get; set; }

            /// <summary>
            /// Номер паспорта
            /// </summary>
            public string DocNumber { get; set; }

            /// <summary>
            /// Кем выдан паспорт
            /// </summary>
            public string DocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи паспорта
            /// </summary>
            public string DocIssueDate { get; set; }

            /// <summary>
            /// Код подразделения паспорта
            /// </summary>
            public string DocDevision { get; set; }

            /// <summary>
            ///  СНИЛС
            /// </summary>
            public string SNILS { get; set; }

            /// <summary>
            ///  ИНН
            /// </summary>
            public string INN { get; set; }

            /// <summary>
            ///  Наименование коренного малочисленного народа
            /// </summary>
            public string NameNaroda { get; set; }

            /// <summary>
            /// 1.12. Свидетельство о рождении(при отсутствии основного документа, удостоверяющего личность)
            /// Серия
            /// </summary>
            public string BirthDocSeries { get; set; }

            /// <summary>
            /// Номер
            /// </summary>
            public string BirthDocNumber { get; set; }

            /// <summary>
            /// Кем выдан
            /// </summary>
            public string BirthDocIssuer { get; set; }

            /// <summary>
            /// Дата выдачи
            /// </summary>
            public string BirthDocIssueDate { get; set; }


            /// <summary>
            /// Почтовый индекс
            /// </summary>
            public string AdressLivePostalCode { get; set; }

            /// <summary>
            /// Субъект Российской Федерации
            /// </summary>
            public string AdressLiveRegion { get; set; }

            /// <summary>
            /// Район
            /// </summary>
            public string AdressLiveRaion { get; set; }

            /// <summary>
            /// Населенный пункт
            /// </summary>
            public string AdressLiveNP { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            public string AdressLiveStreet { get; set; }

            /// <summary>
            /// Номер дома
            /// </summary>
            public string AdressLiveHouseNumber { get; set; }

            /// <summary>
            /// Номер корпуса
            /// </summary>
            public string AdressLiveKorpuseNumber { get; set; }

            /// <summary>
            /// Номер квартиры
            /// </summary>
            public string AdressLiveFlatNumber { get; set; }

            /// <summary>
            /// Является адресом местной администрации поселения в муниципальном районе, в границах которого проходят маршруты кочевий
            /// </summary>
            public bool AdressLiveIsKhz { get; set; }


            /// <summary>
            /// Почтовый индекс
            /// </summary>
            public string AdressRegistrationPostalCode { get; set; }

            /// <summary>
            /// Субъект Российской Федерации
            /// </summary>
            public string AdressRegistrationRegion { get; set; }

            /// <summary>
            /// Район
            /// </summary>
            public string AdressRegistrationRaion { get; set; }

            /// <summary>
            /// Населенный пункт
            /// </summary>
            public string AdressRegistrationNP { get; set; }

            /// <summary>
            /// Улица
            /// </summary>
            public string AdressRegistrationStreet { get; set; }

            /// <summary>
            /// Номер дома
            /// </summary>
            public string AdressRegistrationHouseNumber { get; set; }

            /// <summary>
            /// Номер корпуса
            /// </summary>
            public string AdressRegistrationKorpuseNumber { get; set; }

            /// <summary>
            /// Номер квартиры
            /// </summary>
            public string AdressRegistrationFlatNumber { get; set; }

            /// <summary>
            /// Наименование коренного малочисленного народа
            /// </summary>
            public string NameNaroda_W { get; set; }

            /// <summary>
            /// Полное наименование организации
            /// </summary>
            public string FullNameOrganization_W { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN_W { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INN_W { get; set; }


            ///Членство в общине коренных малочисленных народов (при наличии) 
            /// <summary>
            /// Наименование коренного малочисленного народа
            /// </summary>
            public string NameNaroda_S { get; set; }

            /// <summary>
            /// Полное наименование организации
            /// </summary>
            public string FullNameOrganization_S { get; set; }

            /// <summary>
            /// ОГРН
            /// </summary>
            public string OGRN_S { get; set; }

            /// <summary>
            /// ИНН 
            /// </summary>
            public string INN_S { get; set; }

            /// Сведения о ведении традиционного образа жизни и традиционной хозяйственной деятельности 
            /// <summary>
            /// 3.1 Веду традиционный образ жизни и традиционную хозяйственную деятельность:
            /// </summary>
            public bool Is_A { get; set; }

            /// <summary>
            /// 3.2. Традиционная хозяйственной деятельности является подсобной по отношению к основному виду деятельности:
            /// </summary>
            public bool Is_B { get; set; }

            /// 3.3. Осуществляемый вид (виды) традиционной хозяйственной деятельности: 
            /// <summary>
            /// 3.3.1. Животноводство, в том числе кочевое (оленеводство, коневодство, яководство, овцеводство).
            /// </summary>
            public bool Is_C { get; set; }

            /// <summary>
            /// 3.3.2. Переработка продукции животноводства, включая сбор, заготовку и выделку шкур, шерсти, волоса, окостенелых рогов, копыт, пантов, костей, эндокринных желез, мяса, субпродуктов.
            /// </summary>
            public bool Is_D { get; set; }

            /// <summary>
            /// 3.3.3. Собаководство (разведение оленегонных, ездовых и охотничьих собак).
            /// </summary>
            public bool Is_E { get; set; }

            /// <summary>
            /// 3.3.4. Разведение зверей, переработка и реализация продукции звероводства.
            /// </summary>
            public bool Is_F { get; set; }

            /// <summary>
            /// 3.3.5. Бортничество, пчеловодство.
            /// </summary>
            public bool Is_G { get; set; }

            /// <summary>
            /// 3.3.6. Рыболовство (в том числе морской зверобойный промысел) и реализация водных биологических ресурсов.
            /// </summary>
            public bool Is_H { get; set; }

            /// <summary>
            /// 3.3.7. Промысловая охота, переработка и реализация охотничьей продукции.
            /// </summary>
            public bool Is_I { get; set; }

            /// <summary>
            /// 3.3.8. Земледелие (огородничество), а также разведение и переработка ценных в лекарственном отношении растений.
            /// </summary>
            public bool Is_J { get; set; }

            /// <summary>
            /// 3.3.9. Заготовка древесины и недревесных лесных ресурсов для собственных нужд.
            /// </summary>
            public bool Is_K { get; set; }

            /// <summary>
            /// 3.3.10. Собирательство (заготовка, переработка и реализация пищевых лесных ресурсов, сбор лекарственных растений).
            /// </summary>
            public bool Is_L { get; set; }

            /// <summary>
            /// 3.3.11. Добыча и переработка общераспространенных полезных ископаемых для собственных нужд.
            /// </summary>
            public bool Is_M { get; set; }

            /// <summary>
            /// 3.3.12. Художественные промыслы и народные ремесла (кузнечное и железоделательное ремесло, изготовление утвари, инвентаря, лодок, нарт, иных традиционных средств передвижения, музыкальных инструментов, берестяных изделий, чучел промысловых зверей и птиц, сувениров из меха оленей и промысловых зверей и птиц, иных материалов, плетение из трав и иных растений, вязание сетей, резьба по кости, резьба по дереву, пошив национальной одежды и другие виды промыслов и ремесел, связанные с обработкой меха, кожи, кости и других материалов).
            /// </summary>
            public bool Is_N { get; set; }

            /// <summary>
            /// 3.3.13. Строительство национальных традиционных жилищ и других построек, необходимых для осуществления традиционных видов хозяйственной деятельности.
            /// </summary>
            public bool Is_O { get; set; }
        }

        /// <summary>
        /// Документы
        /// </summary>
        public AppliedDocument[] AppliedDocumentList { get; set; }

        public class AppliedDocument
        {
            public AppliedDocument(){

                Count ="1";
                CountList ="1";
                Digital = "0";
            }

            /// <summary>
            /// Название
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// кол-во экземпляров
            /// </summary>
            public string Count { get; set; }

            /// <summary>
            /// кол-во листов в одном экземпляре
            /// </summary>
            public string CountList { get; set; }

            /// <summary>
            /// на электронных носителях
            /// </summary>
            public string Digital { get; set; }
        }
    }
}
