using Dominio.Entidades;
using Infra.Contexto.ConfigClasses;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;


namespace Infra.Contexto
{
	public class ContextoAplicacao : DbContext
	{
		public ContextoAplicacao(DbContextOptions<ContextoAplicacao> options) : base(options)
		{ }


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
 