namespace AisLogistics.App.Controllers.Cases
{
    public partial class CasesController
    {
        public async Task SetCaseFavorite(string id) => await _caseService.SetCaseFavoriteAsync(id);
        public async Task RemoveCaseFavorite(string id) => await _caseService.RemoveCaseFavoriteAsync(id);
        public async Task SetServiceFavorite(Guid id) => await _caseService.SetServiceFavoriteAsync(id);
        public async Task RemoveServiceFavorite(Guid id) => await _caseService.RemoveServiceFavoriteAsync(id);
    }
}
