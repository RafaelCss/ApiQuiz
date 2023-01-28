using Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiQuiz.Tests
{
	[TestClass]
	public class TesteFuncoesServicos
	{
		
		[TestMethod]
		[DataRow("","","")]
		public void Return_false_Ao_Cadastrar_usuario (string email, string senha, string nome) 
		{
			var result = new Usuario(nome,email,senha).IsValid;

			Assert.IsFalse(result,"1 should not be prime");
		}
	}
}