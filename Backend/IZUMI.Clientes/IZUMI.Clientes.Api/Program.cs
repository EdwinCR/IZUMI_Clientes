using AutoMapper.Extensions.ExpressionMapping;
using IZUMI.Clientes.Application.Profiles;
using IZUMI.Clientes.Application.UseCase;
using IZUMI.Clientes.Application.UseCase.Interfaces;
using IZUMI.Clientes.Domain.IRepositories;
using IZUMI.Clientes.Domain.Services;
using IZUMI.Clientes.Domain.Services.Interfaces;
using IZUMI.Clientes.Infrastructure.Contexts;
using IZUMI.Clientes.Infrastructure.Profiles;
using IZUMI.Clientes.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlserverConnection"),
        sqlServerOptions => sqlServerOptions.CommandTimeout(180)
    );
});

builder.Services.AddControllers();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<InfrastructureProfile>();
    cfg.AddProfile<ApplicationProfile>();
    cfg.AddExpressionMapping();
});

builder.Services.AddScoped<IClienteUseCase, ClienteUseCase>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPlanUseCase, PlanUseCase>();
builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<ITipoDocumentoUseCase, TipoDocumentoUseCase>();
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();


builder.Services.AddScoped<Context>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://localhost:5294") 
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
