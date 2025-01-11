using AisLogistics.App.Data;
using AisLogistics.App.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace AisLogistics.App.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmployeeManager _employeeManager;
        private readonly IReferencesService _referencesService;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmployeeManager employeeManager,
            IReferencesService referencesService,
            ILogger<LoginModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _employeeManager = employeeManager;
            _referencesService = referencesService;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            public Guid? OfficeId { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnGetTosp(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user is null) return new JsonResult("");

            var employeeActiveOffice = await _referencesService.GetActiveEmployeeOfficeDtoAsync(user.Id);
            if (employeeActiveOffice is null) return new JsonResult("");

            var employeeOffices = await _referencesService.GetAuthorizationOfficesAsync(user.Id);
            if (employeeOffices is null) return new JsonResult("");

            return new JsonResult(employeeOffices.Select(s => new
            {
                id = s.Id,
                text = s.OfficeName,
                selected = s.Id == employeeActiveOffice.Id
            }));
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ReturnUrl = returnUrl;

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError(string.Empty, "Неверные данные для входа.");
                return Page();
            };
            var user = await _userManager.FindByNameAsync(Input.Username);
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Неверная попытка входа.");
                return Page();
            }
            if (Input.OfficeId is null)
            {
                ModelState.AddModelError(string.Empty, "Не найден офис для входа.");
                return Page();
            }
            if(!await _employeeManager.GetIsActiveStatusEmployees(user))
            {
                ModelState.AddModelError(string.Empty, "учетная запись заблокирована");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe,
                lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var claims = await _userManager.GetClaimsAsync(user);
                var claim = claims.FirstOrDefault(f => f.Type == "OfficeId");
                if (claim is not null) await _userManager.RemoveClaimAsync(user, claim);
              
                await _userManager.AddClaimAsync(user, new Claim("OfficeId", Input.OfficeId.Value.ToString()));
                
                try
                {
                    await _employeeManager.AddSEmployeesAuthorizationLog(user.Id, Input.OfficeId.Value);
                }
                catch
                {

                }

                if (Url.IsLocalUrl(returnUrl))
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa",
                    new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
            }

            if (result.IsLockedOut)
            {
                //_logger.LogWarning("Учетная запись пользователя заблокирована.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неверная попытка входа.");
                return Page();
            }

        }
    }
}
