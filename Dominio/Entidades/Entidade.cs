using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
	public abstract class Entidade<T> : AbstractValidator<T>
	{
		public Guid Id { get; set; }
		public DateTime DataDeCriacao { get; set; }
	}
}
