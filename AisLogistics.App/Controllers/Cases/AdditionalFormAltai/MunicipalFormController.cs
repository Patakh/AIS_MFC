using AisLogistics.App.Models.AdditionalForms.Municipal;
namespace AisLogistics.App.Controllers.Cases;

public partial class CasesController
{
    public async Task<IActionResult> _1_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_1_1_", new _1_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_1_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_1_1_", model ?? new _1_1_Model());
    }
    public async Task<IActionResult> _1_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_Dou2", new Dou2Model());

        var model = await _caseService.GetAdditionalDataByServiceIdAsync<Dou2Model>(id.Value);

        return PartialView("AdditionalForms/Altai/Municipal/_Dou2", model ?? new Dou2Model());

    }
    public async Task<IActionResult> AddDouForm(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_AddDou", new AddDouModel());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<AddDouModel>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_AddDou", model ?? new AddDouModel());
    }
    public async Task<IActionResult> _1_3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_1_3_", new _1_3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_1_3_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_1_3_", model ?? new _1_3_Model());
    }
    public async Task<IActionResult> _1_4_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_1_4_", new _1_4_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_1_4_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_1_4_", model ?? new _1_4_Model());
    }
    public async Task<IActionResult> _2_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_2_1_", new _2_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_2_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_2_1_", model ?? new _2_1_Model());
    }
    public async Task<IActionResult> _2_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_2_2_", new _2_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_2_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_2_2_", model ?? new _2_2_Model());
    }
    public async Task<IActionResult> _3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_3_", new _3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_3_Model>(id.Value);

        return PartialView("AdditionalForms/Altai/Municipal/_3_", model ?? new _3_Model());
    }
    public async Task<IActionResult> _4_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_4_", new _4_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_4_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_4_", model ?? new _4_Model());
    }
    public async Task<IActionResult> _5_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_5_", new _5_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_5_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_5_", model ?? new _5_Model());
    }
    public async Task<IActionResult> _6_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_6_1_", new _6_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_6_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_6_1_", model ?? new _6_1_Model());
    }
    public async Task<IActionResult> _6_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_6_2_", new _6_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_6_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_6_2_", model ?? new _6_2_Model());
    }
    public async Task<IActionResult> _6_3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_6_3_", new _6_3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_6_3_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_6_3_", model ?? new _6_3_Model());
    }
    public async Task<IActionResult> _7_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_7_", new _7_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_7_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_7_", model ?? new _7_Model());
    }
    public async Task<IActionResult> _8_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_8_1_", new _8_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_8_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_8_1_", model ?? new _8_1_Model());
    }
    public async Task<IActionResult> _8_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_8_2_", new _8_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_8_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_8_2_", model ?? new _8_2_Model());
    }
    public async Task<IActionResult> _9_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_9_1_", new _9_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_9_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_9_1_", model ?? new _9_1_Model());
    }
    public async Task<IActionResult> _9_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_9_2_", new _9_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_9_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_9_2_", model ?? new _9_2_Model());
    }
    public async Task<IActionResult> _10_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_10_", new _10_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_10_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_10_", model ?? new _10_Model());
    }
    public async Task<IActionResult> _11_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_11_", new _11_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_11_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_11_", model ?? new _11_Model());
    }
    public async Task<IActionResult> _12_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_12_", new _12_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_12_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_12_", model ?? new _12_Model());
    }
    public async Task<IActionResult> _13_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_13_", new _13_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_13_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_13_", model ?? new _13_Model());
    }
    public async Task<IActionResult> _14_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_14_", new _14_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_14_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_14_", model ?? new _14_Model());
    }
    public async Task<IActionResult> _15_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_15_", new _15_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_15_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_15_", model ?? new _15_Model());
    }
    public async Task<IActionResult> _16_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_16_", new _16_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_16_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_16_", model ?? new _16_Model());
    }
    public async Task<IActionResult> _17_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_17_1_", new _17_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_17_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_17_1_", model ?? new _17_1_Model());
    }
    public async Task<IActionResult> _17_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_17_2_", new _17_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_17_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_17_2_", model ?? new _17_2_Model());
    }
    public async Task<IActionResult> _18_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_18_1_", new _18_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_18_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_18_1_", model ?? new _18_1_Model());
    }
    public async Task<IActionResult> _18_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_18_2_", new _18_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_18_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_18_2_", model ?? new _18_2_Model());
    }
    public async Task<IActionResult> _19_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_19_", new _19_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_19_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_19_", model ?? new _19_Model());
    }
    public async Task<IActionResult> _20_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_20_", new _20_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_20_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_20_", model ?? new _20_Model());
    }
    public async Task<IActionResult> _21_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_21_1_", new _21_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_21_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_21_1_", model ?? new _21_1_Model());
    }
    public async Task<IActionResult> _21_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_21_2_", new _21_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_21_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_21_2_", model ?? new _21_2_Model());
    }
    public async Task<IActionResult> _22_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_22_1_", new _22_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_22_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_22_1_", model ?? new _22_1_Model());
    }
    public async Task<IActionResult> _22_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_22_2_", new _22_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_22_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_22_2_", model ?? new _22_2_Model());
    }
    public async Task<IActionResult> _23_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_23_1_", new _23_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_23_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_23_1_", model ?? new _23_1_Model());
    }
    public async Task<IActionResult> _23_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_23_2_", new _23_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_23_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_23_2_", model ?? new _23_2_Model());
    }
    public async Task<IActionResult> _23_3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_23_3_", new _23_3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_23_3_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_23_3_", model ?? new _23_3_Model());
    }
    public async Task<IActionResult> _24_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_24_", new _24_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_24_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_24_", model ?? new _24_Model());
    }
    public async Task<IActionResult> _25_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_25_", new _25_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_25_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_25_", model ?? new _25_Model());
    }
    public async Task<IActionResult> _26_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_26_", new _26_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_26_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_26_", model ?? new _26_Model());
    }
    public async Task<IActionResult> _27_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_27_1_", new _27_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_27_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_27_1_", model ?? new _27_1_Model());
    }
    public async Task<IActionResult> _27_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_27_2_", new _27_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_27_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_27_2_", model ?? new _27_2_Model());
    }
    public async Task<IActionResult> _28_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_28_", new _28_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_28_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_28_", model ?? new _28_Model());
    }
    public async Task<IActionResult> _29_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_29_", new _29_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_29_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_29_", model ?? new _29_Model());
    }
    public async Task<IActionResult> _30_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_30_1_", new _30_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_30_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_30_1_", model ?? new _30_1_Model());
    }
    public async Task<IActionResult> _30_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_30_2_", new _30_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_30_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_30_2_", model ?? new _30_2_Model());
    }
    public async Task<IActionResult> _30_3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_30_3_", new _30_3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_30_3_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_30_3_", model ?? new _30_3_Model());
    }
    public async Task<IActionResult> _30_4_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_30_4_", new _30_4_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_30_4_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_30_4_", model ?? new _30_4_Model());
    }
    public async Task<IActionResult> _31_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_31_1_", new _31_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_31_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_31_1_", model ?? new _31_1_Model());
    }
    public async Task<IActionResult> _31_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_31_2_", new _31_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_31_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_31_2_", model ?? new _31_2_Model());
    }
    public async Task<IActionResult> _32_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_32_1_", new _32_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_32_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_32_1_", model ?? new _32_1_Model());
    }
    public async Task<IActionResult> _32_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_32_2_", new _32_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_32_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_32_2_", model ?? new _32_2_Model());
    }
    public async Task<IActionResult> _32_3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_32_3_", new _32_3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_32_3_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_32_3_", model ?? new _32_3_Model());
    }
    public async Task<IActionResult> _33_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_33_", new _33_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_33_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_33_", model ?? new _33_Model());
    }
    public async Task<IActionResult> _34_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_34_", new _34_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_34_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_34_", model ?? new _34_Model());
    }
    public async Task<IActionResult> _35_1_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_35_1_", new _35_1_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_35_1_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_35_1_", model ?? new _35_1_Model());
    }
    public async Task<IActionResult> _35_2_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_35_2_", new _35_2_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_35_2_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_35_2_", model ?? new _35_2_Model());
    }
    public async Task<IActionResult> _35_3_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_35_3_", new _35_3_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_35_3_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_35_3_", model ?? new _35_3_Model());
    }
    public async Task<IActionResult> _35_4_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_35_4_", new _35_4_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_35_4_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_35_4_", model ?? new _35_4_Model());
    }
    public async Task<IActionResult> _35_5_(Guid? id)
    {
        if (!id.HasValue) return PartialView("AdditionalForms/Altai/Municipal/_35_5_", new _35_5_Model());
        var model = await _caseService.GetAdditionalDataByServiceIdAsync<_35_5_Model>(id.Value);
        return PartialView("AdditionalForms/Altai/Municipal/_35_5_", model ?? new _35_5_Model());
    }
}