using SmevRouter;

namespace AisLogistics.App.Models;

/// <summary>
/// Прием от граждан анкет в целях регистрации в системе индивидуального (персонифицированного) учета,
/// в том числе прием от зарегистрированных лиц заявлений об изменении анкетных данных, содержащихся в индивидуальном лицевом счете,
/// или о выдаче документа, подтверждающего регистрацию в системе индивидуального (персонифицированного) учета.
/// </summary>
public class _44_1_PfrAdv1Model : AbstractAdditionalFormModel
{
    public string OKUDCode { get; set; }
    public string CitizenshipCountry { get; set; }
    public PfrBirthAct BirthAct { get; set; }

    public class PfrBirthAct
    {
        public string BirthActDate { get; set; }
        public string BirthActNumber { get; set; }
        public string ZagsName { get; set; }
    } 
}