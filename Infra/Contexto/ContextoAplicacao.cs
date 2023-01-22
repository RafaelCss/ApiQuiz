using Dominio.Entidades;
using Infra.Contexto.ConfigClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexto
{
	public class ContextoAplicacao : DbContext
	{

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ConfigUsuario());
			modelBuilder.ApplyConfiguration(new ConfigPerguntas());
		}

		public DbSet<Usuario> Usuarios{ get; set; }
		public DbSet<Pergunta> Perguntas { get; set; }


		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ContextoAplicacao>(ServiceLifetime.Scoped);
		}

	}
}
