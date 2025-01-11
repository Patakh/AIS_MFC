using AisLogistics.App.Data;
using AisLogistics.App.Extensions;
using AisLogistics.App.Hubs;
using AisLogistics.App.Mapping;
using AisLogistics.App.Models.DTO.Identity;
using AisLogistics.App.Service;
using AisLogistics.App.Service.ApplicantPersonalAccount;
using AisLogistics.App.Service.MDM;
using AisLogistics.App.Service.Queue;
using AisLogistics.App.Service.Systems;
using AisLogistics.App.Settings;
using AisLogistics.DataLayer.Common.Mapper;
using AisLogistics.DataLayer.Concrete;
using AisLogistics.DataLayer.Core.Data;
using AisLogistics.DataLayer.Core.IConfiguration;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using SmartBreadcrumbs.Extensions;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<AisLogisticsContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
    {
        options.User.RequireUniqueEmail = true;

        options.SignIn.RequireConfirmedAccount = false;
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;

        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
    })
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServices<ApplicationDbContext, IdentityUserDto, ApplicationUser, ApplicationRole, Guid>();

builder.Services.Configure<Settings>(builder.Configuration.GetSection("Settings"));
builder.Services.Configure<SmevSettings>(builder.Configuration.GetSection("SmevSettings"));
builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection("QueueSettings"));
builder.Services.Configure<SpsSettings>(builder.Configuration.GetSection("SpsSettings"));
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.AisLogisticsIdentity";
});
builder.Services.Configure<SecurityStampValidatorOptions>(option =>
    option.ValidationInterval = TimeSpan.FromSeconds(0)
);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddBreadcrumbs(typeof(Program).Assembly, options =>
{
    options.TagName = "nav";
    options.TagClasses = "d-none d-sm-block";
    options.OlClasses = "breadcrumb breadcrumb-style1 mb-3";
    options.LiClasses = "breadcrumb-item";
    options.ActiveLiClasses = "breadcrumb-item active";
    options.SeparatorElement = "";
    options.DefaultAction = "<span>???</span>";
});

builder.Services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = false,
    PositionClass = ToastPositions.TopRight
}, new NToastNotifyOption()
{
    ScriptSrc = "/assets/vendor/libs/toastr/toastr.js",
    StyleHref = "/assets/vendor/libs/toastr/toastr.css"
});

var opt = Configuration.Options
    .EnableResponseAdditionalParameters()
    .EnableRequestAdditionalParameters();

builder.Services.RegisterDataTables(opt);
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddWebOptimizer(minifyJavaScript: false, minifyCss: false);
    //builder.Services.AddHostedService<Worker>(); //TODO на проде пока не запускаем
}
else
{
    builder.Services.AddWebOptimizer(pipeline =>
    {
        pipeline.MinifyJsFiles("assets/js/*.js", "assets/js/pages/*.js");
        pipeline.MinifyCssFiles("assets/css/*.css");
    });
}

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
    mc.AddProfile(new IdentityProfile());
});

builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IFilterManager, FilterManager>();
builder.Services.AddScoped<IArchiveService, ArchiveService>();
builder.Services.AddScoped<ICaseService, CaseService>();
builder.Services.AddScoped<ISmevService, SmevService>();
builder.Services.AddScoped<IFtpService, FtpService>();
builder.Services.AddScoped<IReferencesService, ReferencesService>();
builder.Services.AddScoped<IGarService, AisLogistics.App.Service.GarService>();
builder.Services.AddScoped<IReestrTransferDocuments, ReestrTransferDocuments>();
builder.Services.AddScoped<IElectronicQueueServiceClient, ElectronicQueueServiceClient>();
builder.Services.AddScoped<IElectronicQueueServiceApiClient, ElectronicQueueServiceApiClient>();
builder.Services.AddScoped<IElectronicQueueServiceRegistrationClient, ElectronicQueueServiceRegistrationClient>();
builder.Services.AddScoped<IReports, Reports>();
builder.Services.AddScoped<IMdmService, MdmService>();
builder.Services.AddScoped<IStatistics, Statistics>();
builder.Services.AddScoped<IReestrUnclaimedDocuments, ReestrUnclaimedDocuments>();
builder.Services.AddScoped<IReestrSentMessage, ReestrSentMessage>();
builder.Services.AddScoped<IInformationManager, InformationManager>();
builder.Services.AddScoped<INotificationManager, NotificationManager>();
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();
builder.Services.AddScoped<ISystemsService, SystemsService>();
builder.Services.AddScoped<IApplicantPersonalAccount, ApplicantPersonalAccount>();


builder.Services.AddSignalR();

builder.Services.AddHttpClient<ElectronicQueueServiceRegistrationClient>();

builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://fc85b65999d14a08ac39015cbb3dd360@o1193468.ingest.sentry.io/6315750";
    o.Debug = true;
    o.TracesSampleRate = 0.2;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    //app.UseStatusCodePagesWithRedirects("/Error/Page/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseWebOptimizer();

app.UseStaticFiles();

app.UseRouting();

app.UseFastReport();

app.UseAuthentication();
app.UseAuthorization();

app.UseNToastNotify();
app.UseSentryTracing();

app.MapHub<NotificationHub>("/NotificationHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

await app.RunAsync();