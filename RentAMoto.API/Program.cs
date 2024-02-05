using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentAMoto.Application.Commom.Behaviours;
using RentAMoto.Application.Commom.Http;
using RentAMoto.Application.Interfaces;
using RentAMoto.Application.Services;
using RentAMoto.Infrastructure.Context;
using RentAMoto.Infrastructure.Interfaces;
using RentAMoto.Infrastructure.Repositories;
using RentAMoto.Infrastructure.Services;
using RentAMoto.Messages.Consumo;
using RentAMoto.Messages.Intefarces;
using RentAMoto.Messages.Notificacao;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var caminhoFotos = Path.Combine(builder.Environment.ContentRootPath, "../RentAMoto.Infrastructure/ImagensCNHs");
Directory.CreateDirectory(caminhoFotos);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


builder.Services.AddScoped<IEntregadorRepository, EntregadorRepository>();
builder.Services.AddScoped<IMotoRepository, MotoRepository>();
builder.Services.AddScoped<ILocacaoRepository, LocacaoRepository>();
builder.Services.AddScoped<IFotoCNHService>(serviceProvider =>
    new FotoCNHService(caminhoFotos));
builder.Services.AddScoped<IPedidoNotificationProducer, PedidoNotificationProducer>();
builder.Services.AddScoped<IPedidoNotificationConsumer, PedidoNotificationConsumer>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
builder.Services.AddScoped(typeof(IBaseHttpService<>), typeof(BaseHttpService<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
