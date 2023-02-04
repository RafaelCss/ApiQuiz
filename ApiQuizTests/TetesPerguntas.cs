using Dominio.Entidades;


namespace ApiQuizTests
{
	[TestClass]
	public class TetesPerguntas
	{
		[TestMethod]
		[DataRow("","","")]
		[DataRow(" "," "," ")]
		[DataRow("","teste@teste.com","teste.teste")]
		[DataRow("","","teste.teste")]
		[DataRow("","teste@teste.com","")]
		[DataRow("","teste","")]
		public void TestUsuarioFalse(string nome,string email,string senha)
		{
			var resultado = new Usuario(nome,email,senha).IsValid;
			Assert.IsFalse(resultado,"Passou");
		}

	}
}
