using AisLogistics.App.Models;
using Microsoft.AspNetCore.Authorization;
using SmartBreadcrumbs.Attributes;
using System.Diagnostics;
using AisLogistics.App.Service;
using Sentry;

namespace AisLogistics.App.Controllers
{
    [Authorize]
    public class InformationController : AbstractController
    {
        private readonly IInformationManager _informationManager;
        public InformationController(IInformationManager informationManager)
        {
            _informationManager = informationManager;
        }

        public async Task<IActionResult> InformationListPartial(int count = 5)
        {
            var list = await _informationManager.GetInformationListAsync(count);
            return PartialView(list);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            return View();
        }
    }
}