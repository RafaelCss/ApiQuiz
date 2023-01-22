namespace Api_quiz.Model.Resposta.Perguntas
{
    public class ViewsPerguntas
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }
        public Autor Autor { get; set; }
    }

    public class Autor
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
