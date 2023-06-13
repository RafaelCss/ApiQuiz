

namespace Dominio.Interface.Resposta
{
	public interface IApiResposta<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public object Data { get; set; }
		public int? TotalCount { get; set; }
		public int? PageSize { get; set; }
		public int? PageIndex { get; set; }
	}

}
