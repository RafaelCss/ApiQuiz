
using Configuracao.ConfigDominio;

using Configuracao.Configs;
using Configuracao.MongoConfig;
using Microsoft.OpenApi.Models;
using ServicoExterno;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container
var config = builder.Configuration;

builder.Services.AddConfigDominio(config);

builder.Services.AddControllers();
builder.Services.AddMongoConfig(config);
builder.Services.AddConfig(config);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
	// ... código omitido

	options.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
	{
		Description = "JWT Authorization header using the Bearer scheme.",
		Type = SecuritySchemeType.Http,
		Scheme = "bearer"
	});

	options.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type = ReferenceType.SecurityScheme,
					Id = "Bearer"
				}
			},
			Array.Empty<string>()
		}
	});
});
var app = builder.Build();

//while(true)
//{
var servicoBusca = new ServicoExternoBusca();
await servicoBusca.FazerBusca();
// Armazenando o resultado no MongoDB

Console.WriteLine($"Resultado armazenado no MongoDB. Próxima busca em 3 horas.");

//	// Aguardar 3 horas antes da próxima busca
//	await Task.Delay(TimeSpan.FromHours(3));
//	return;
//}
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
