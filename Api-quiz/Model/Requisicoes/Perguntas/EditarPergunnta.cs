﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiQuiz.Model.Requisicoes.Perguntas
{
	public class EditarPergunnta
	{
		public string? Titulo { get; set; }
		public string? Assunto { get; set; }
		[BsonRepresentation(BsonType.ObjectId)]
		public string? IdAutor { get; set; }
	}
}