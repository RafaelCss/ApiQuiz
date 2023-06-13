using Dominio.Interface.Resposta;


namespace Dominio.Respostas
{
	public class ApiResponse<T> : IApiResposta<T>
	{
		public bool Success { get; set; }
		public string Message { get; set; }
		public object Data { get; set; }
		public int? TotalCount { get; set; }
		public int? PageSize { get; set; }
		public int? PageIndex { get; set; }


		public ApiResponse(bool success,string message,object data,int totalCount = 0,int pageSize = 0,int pageIndex = 0)
		{
			Success = success;
			Message = message;
			Data = data;
			TotalCount = totalCount;
			PageSize = pageSize;
			PageIndex = pageIndex;

		}
	}
}
