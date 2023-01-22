using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Contexto.ConfigClasses
{
	internal class ConfigPerguntas : IEntityTypeConfiguration<Pergunta>
	{
		public void Configure(EntityTypeBuilder<Pergunta> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Titulo).IsRequired();
			builder.Property(x => x.Autor).IsRequired();
			builder.Property(x => x.Assunto).IsRequired();


			builder.HasOne(x => x.Autor).WithMany().HasForeignKey(x => x.Autor.Id).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
