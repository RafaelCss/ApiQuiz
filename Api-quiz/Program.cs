
using Configuracao.ConfigDominio;
using Configuracao.ConfigInfra;
using Configuracao.Configs;
using Configuracao.MongoConfig;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
var config = builder.Configuration;

builder.Services.AddConfigInfra(config);
builder.Services.AddConfigDominio(config);

builder.Services.AddControllers();
builder.Services.AddMongoConfig(config);
builder.Services.AddConfig(config);

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
