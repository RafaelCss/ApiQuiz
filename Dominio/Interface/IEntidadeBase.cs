using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
	public interface IEntidadeBase : INotifiable 
	{
		public Guid Id { get; set; }
		public DateTime DataDeCriacao { get; set; }
		protected void InserirData();
	}
}
