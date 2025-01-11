using AisLogistics.API.Service;
using AisLogistics.API.Settings;
using AisLogistics.DataLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AisLogisticsContext>(options =>
    options.UseNpgsql(connectionString));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=> {
    c.EnableAnnotations();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AisLogistics", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        b =>
        {
            b.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
});

builder.Services.Configure<QueueSettings>(builder.Configuration.GetSection("QueueSettings"));
builder.Services.AddScoped<IElectronicQueueServiceClientAPI, ElectronicQueueServiceClientAPI>();
builder.Services.AddScoped<IReferencesServiceAPI, ReferencesServiceAPI>();
builder.Services.AddScoped<IIasMkguQuestionServiceAPI, IasMkguQuestionServiceAPI>();
builder.Services.AddScoped<IPersonalAccountServicesAPI, PersonalAccountServicesAPI>();
builder.Services.AddScoped<IJitsiServicesAPI, JitsiServicesAPI>();
builder.Services.AddScoped<IFtpService, FtpService>();

//builder.Services.AddHttpClient<ElectronicQueueServiceClientAPI>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseCors();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
