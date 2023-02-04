using Dominio.Entidades;
using Dominio.Services.Comandos;

namespace ApiQuizTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		[DataRow("","","")]
		[DataRow(" "," "," ")]
		[DataRow("","teste@teste.com","teste.teste")]
		[DataRow("","","teste.teste")]
		[DataRow("","teste@teste.com","")]
		[DataRow("","teste","")]
		public void TestUsuarioFalse(string nome, string email, string senha)
		{
			var resultado = new Usuario(nome, email, senha).IsValid;
			Assert.IsFalse(resultado,"Passou");
		}

		[TestMethod]
		[DataRow("teste","teste@teste.com","teste.teste")]
		public void TestUsuarioTrue(string nome,string email,string senha)
		{
			var resultado = new Usuario(nome,email,senha).IsValid;
			Assert.IsTrue(resultado,"Passou");
		}

		[TestMethod]
		[DataRow("teste","teste@teste.com","teste.teste")]
		public void TestComandoTrue(string nome,string email,string senha)
		{
			var comando = new ComandoUsuario().CadastrarUsuario(nome,email,senha);
			
			Assert.AreNotEqual(comando,1);
		}
	}
}