using Dominio.Interface;
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Infra.Repositorio.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var connectioDataBase = builder.Configuration.GetConnectionString("connectionMysql");
builder.Services.AddDbContext<ContextoAplicacao>(opt =>
	opt.UseMySql(connectioDataBase,ServerVersion.AutoDetect(connectioDataBase)));
// Add services to the container
builder.Services.AddTransient<IUnitOfWork,GenericUnitOfWork>();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
