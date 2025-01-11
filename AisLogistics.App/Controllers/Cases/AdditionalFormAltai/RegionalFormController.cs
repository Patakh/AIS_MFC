using AisLogistics.App.Models.AdditionalForms.Regional;
using System.Text.Json;
namespace AisLogistics.App.Controllers.Cases;

public partial class CasesController
{
    public async Task<IActionResult> Service1Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service1", new Service1Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service1Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service1", model ?? new Service1Model());
    }

    public async Task<IActionResult> Service2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service2", new Service2Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service2Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service2", model ?? new Service2Model());
    }

    public async Task<IActionResult> Service3Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service3", new Service3Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service3Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service3", model ?? new Service3Model());
    }
    public async Task<IActionResult> Service4Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service4", new Service4Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service4Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service4", model ?? new Service4Model());
    }
    public async Task<IActionResult> Service5Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service5", new Service5Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service5Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service5", model ?? new Service5Model());
    }
    public async Task<IActionResult> Service6Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service6", new Service6Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service6Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service6", model ?? new Service6Model());
    }
    public async Task<IActionResult> Service7Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service7", new Service7Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service7Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service7", model ?? new Service7Model());
    }
    public async Task<IActionResult> Service8Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service8", new Service8Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service8Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service8", model ?? new Service8Model());
    }
    public async Task<IActionResult> Service9Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service9", new Service9Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service9Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service9", model ?? new Service9Model());
    }

    public async Task<IActionResult> Service10Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service10", new Service10Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service10Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service10", model ?? new Service10Model());
    }

    public async Task<IActionResult> Service15Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service15", new Service15Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service15Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service15", model ?? new Service15Model());
    }
    public async Task<IActionResult> Service20Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service20", new Service20Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service20Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service20", model ?? new Service20Model());
    }
    public async Task<IActionResult> Service21Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service21", new Service21Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service21Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service21", model ?? new Service21Model());
    }
    public async Task<IActionResult> Service21_2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service21_2", new Service21_2Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service21_2Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service21_2", model ?? new Service21_2Model());
    }
    public async Task<IActionResult> Service22Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service22", new Service22Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service22Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service22", model ?? new Service22Model());
    }
    public async Task<IActionResult> Service23Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service23", new Service23Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service23Model>(id.Value);
        string json = JsonSerializer.Serialize(model);
        return PartialView("AdditionalForms/Altai/Regional/_Service23", model ?? new Service23Model());
    }
    public async Task<IActionResult> Service23_2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service23_2", new Service23_2Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service23_2Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service23_2", model ?? new Service23_2Model());
    }
    public async Task<IActionResult> Service24Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service24", new Service24Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service24Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service24", model ?? new Service24Model());
    }
    public async Task<IActionResult> Service25Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service25", new Service25Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service25Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service25", model ?? new Service25Model());
    }
    public async Task<IActionResult> Service26Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service26", new Service26Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service26Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service26", model ?? new Service26Model());
    }
    public async Task<IActionResult> Service27_1Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service27_1", new Service27_1Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service27_1Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service27_1", model ?? new Service27_1Model());
    }
    public async Task<IActionResult> Service27_2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service27_2", new Service27_2Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service27_2Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service27_2", model ?? new Service27_2Model());
    }
    public async Task<IActionResult> Service27_3Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service27_3", new Service27_3Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service27_3Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service27_3", model ?? new Service27_3Model());
    }
    public async Task<IActionResult> Service27_4Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service27_4", new Service27_4Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service27_4Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service27_4", model ?? new Service27_4Model());
    }
    public async Task<IActionResult> Service27_5Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service27_5", new Service27_5Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service27_5Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service27_5", model ?? new Service27_5Model());
    }
    public async Task<IActionResult> Service27_6Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service27_6", new Service27_6Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service27_6Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service27_6", model ?? new Service27_6Model());
    }
    public async Task<IActionResult> Service28Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service28", new Service28Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service28Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service28", model ?? new Service28Model());
    }
    public async Task<IActionResult> Service29_1Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service29_1", new Service29_1Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service29_1Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service29_1", model ?? new Service29_1Model());
    }
    public async Task<IActionResult> Service29_1_3Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service29_1_3", new Service29_1_3Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service29_1_3Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service29_1_3", model ?? new Service29_1_3Model());
    }
    public async Task<IActionResult> Service29_1_4Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service29_1_4", new Service29_1_4Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service29_1_4Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service29_1_4", model ?? new Service29_1_4Model());
    }
    public async Task<IActionResult> Service29_1_5Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service29_1_5", new Service29_1_5Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service29_1_5Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service29_1_5", model ?? new Service29_1_5Model());
    }
    public async Task<IActionResult> Service29_1_7Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service29_1_7", new Service29_1_7Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service29_1_7Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service29_1_7", model ?? new Service29_1_7Model());
    }
    public async Task<IActionResult> Service29_2_2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Service29_2_2", new Service29_2_2Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Service29_2_2Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Service29_2_2", model ?? new Service29_2_2Model());
    }
    public async Task<IActionResult> ServiceNew1Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_ServiceNew1", new ServiceNew1Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<ServiceNew1Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_ServiceNew1", model ?? new ServiceNew1Model());
    }
    public async Task<IActionResult> O_SudimostiForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_O_Sudimosti", new O_SudimostiModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<O_SudimostiModel>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_O_Sudimosti", model ?? new O_SudimostiModel());
    }
    public async Task<IActionResult> NarcoForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_Narco", new NarcoModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<NarcoModel>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_Narco", model ?? new NarcoModel());
    }
    public async Task<IActionResult> QuestionnaireInsuredPerson(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_QuestionnaireInsuredPerson", new QuestionnaireInsuredPerson());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<QuestionnaireInsuredPerson>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_QuestionnaireInsuredPerson", model ?? new QuestionnaireInsuredPerson());
    }
    public async Task<IActionResult> ExchangeSnils(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_ExchangeSnils", new ExchangeSnils());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<ExchangeSnils>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_ExchangeSnils", model ?? new ExchangeSnils());
    }
    public async Task<IActionResult> DuplicateExtraditionSnils(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_DuplicateExtraditionSnils", new DuplicateExtraditionSnils());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<DuplicateExtraditionSnils>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_DuplicateExtraditionSnils", model ?? new DuplicateExtraditionSnils());
    }
    public async Task<IActionResult> AllowanceBirthUpbringingChildrenForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_AllowanceBirthUpbringingChildren", new AllowanceBirthUpbringingChildrenModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AllowanceBirthUpbringingChildrenModel>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_AllowanceBirthUpbringingChildren", model ?? new AllowanceBirthUpbringingChildrenModel());
    }

    public async Task<IActionResult> AllowanceBirthUpbringingChildrenDeliveryMethodForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_AllowanceBirthUpbringingChildrenDeliveryMethod", new AllowanceBirthUpbringingChildrenDeliveryMethodModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AllowanceBirthUpbringingChildrenDeliveryMethodModel>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_AllowanceBirthUpbringingChildrenDeliveryMethod", model ?? new AllowanceBirthUpbringingChildrenDeliveryMethodModel());
    }

    public async Task<IActionResult> GasificationConnectionAgreementsForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_GasificationConnectionAgreements2", new GasificationConnectionAgreementsModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<GasificationConnectionAgreementsModel>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_GasificationConnectionAgreements2", model ?? new GasificationConnectionAgreementsModel());
    }
    public async Task<IActionResult> AccountingPersons1Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_AccountingPersons_1", new AccountingPersons1());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AccountingPersons1>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_AccountingPersons_1", model ?? new AccountingPersons1());
    }
    public async Task<IActionResult> AccountingPersons2Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_AccountingPersons_2", new AccountingPersons2());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AccountingPersons2>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_AccountingPersons_2", model ?? new AccountingPersons2());
    }
    public async Task<IActionResult> AccountingPersons3Form(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_AccountingPersons_3", new AccountingPersons3());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AccountingPersons3>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_AccountingPersons_3", model ?? new AccountingPersons3());
    }
    public async Task<IActionResult> InclusionVotingForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_InclusionVoting", new InclusionVoting());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<InclusionVoting>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_InclusionVoting", model ?? new InclusionVoting());
    }
    public async Task<IActionResult> СancelVotingForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Regional/_СancelVoting", new СancelVoting());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<СancelVoting>(id.Value);
        return PartialView("AdditionalForms/Altai/Regional/_СancelVoting", model ?? new СancelVoting());
    }
}