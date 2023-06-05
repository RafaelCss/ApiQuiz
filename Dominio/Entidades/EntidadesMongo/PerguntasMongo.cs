
using Flunt.Validations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dominio.Entidades.PerguntasMongo
{
	public class PerguntasMongo : Entidade
	{
		[BsonId]
		public ObjectId Id { get; set; }

		public string Titulo { get; set; }

		public string Assunto { get; set; }

		public string? Autor_id { get; set; }
		public virtual Usuario Usuario { get; private set; }
		public PerguntasMongo()
		{
		}

		public PerguntasMongo(string titulo,string? autor,string assunto)
		{
			ValidarTitulo(titulo);
			ValidarAssunto(assunto);
			ValidarAutor(autor);
		}

		private PerguntasMongo ValidarTitulo(string titulo)
		{
			Titulo = titulo;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNull(Titulo,"Titulo","Este campo não pode ficar vazio")
			);
			return this;
		}

		private PerguntasMongo ValidarAutor(string? autor)
		{
			Autor_id = autor;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNull(Autor_id,"Autor","Este campo não pode ficar vazio")
			);
			return this;
		}

		private PerguntasMongo ValidarAssunto(string assunto)
		{
			Assunto = assunto;
			AddNotifications(new Contract<Pergunta>()
				.Requires()
				.IsNotNullOrWhiteSpace(Assunto,"Assunto","Este campo não pode ficar vazio")
			);
			return this;
		}
	}
}
