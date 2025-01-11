using AisLogistics.App.Data;
using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Service;

namespace AisLogistics.App.Components
{
    public class IdentityUserInformationComponent : ViewComponent
    {
        private readonly IIdentityService<IdentityUserDto, ApplicationUser, ApplicationRole, Guid> _identityService;

        public IdentityUserInformationComponent(IIdentityService<IdentityUserDto, ApplicationUser, ApplicationRole, Guid> identityService)
        {
            _identityService = identityService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var user = await _identityService.GetUserAsync(id);
            return View(user);
        }
    }
}
