
using Configuracao.ConfigDominio;
using Configuracao.ConfigInfra;
using Configuracao.Configs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
var config = builder.Configuration;

builder.Services.AddConfig(config);
builder.Services.AddConfigInfra(config);
builder.Services.AddConfigDominio(config);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
