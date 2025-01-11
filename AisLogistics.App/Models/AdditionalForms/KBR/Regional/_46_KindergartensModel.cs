 namespace AisLogistics.App.Models;

/// <summary>
/// Прием заявлений, постановка на учет и зачисление детей в образовательные учреждения,
/// реализующие основную общеобразовательную программу дошкольного образования (детские сады) (Э)
/// </summary>
public class _46_KindergartensModel
{
    public _46_KindergartensModel()
    {
        DOU = new[] { 
          new DOU_()
        };

        OtherDOU = new[] {
          new DOU_()
        };

    }

    /// <summary>
    /// ФИО ребенка
    /// </summary>
    public string ChildFio { get; set; }

    /// <summary>
    /// Свидетельство о рождении 
    /// серия 
    /// </summary>
    public string Series { get; set; }

    /// <summary>
    /// номер
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// дата выдачи
    /// </summary>
    public string DateIssuer { get; set; }

    /// <summary>
    /// Дата рождения
    /// </summary>
    public string BirthDate { get; set; }

    /// <summary>
    /// Список дошкольных образовательных учреждений
    /// </summary>
    public DOU_[] DOU { get; set; }
     
    /// <summary>
    /// Категории льгот
    /// </summary>
    public string Category { get; set; }

    /// <summary>
    /// Потребность в специализированном детском саде (группе)
    /// </summary>
    public string IsSpecializedDOU { get; set; }

    /// <summary>
    /// Дата желаемого зачисления
    /// </summary>
    public string DataDesired { get; set; }

    /// <summary>
    /// Желаемый язык обучения в группе
    /// </summary>
    public string DesiredLanguageInstruction { get; set; }

    /// <summary>
    /// Время пребывания:
    /// </summary>
    public string TimeStay { get; set; }

    /// <summary>
    ///  В случае отсутствия мест в указанных мною приоритетных детских садах предлагать другие варианты
    /// </summary>
    public DOU_[] OtherDOU { get; set; }

    public class DOU_
    {
        public string Name { get; set; }
    }
}
