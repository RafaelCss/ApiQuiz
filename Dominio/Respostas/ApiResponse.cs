using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Respostas
{
	internal class ApiResponse<T>
	{
			public bool Success { get; set; }
			public string Message { get; set; }
			public T Data { get; set; }
			public int? TotalCount { get; set; }
			public int? PageSize { get; set; }
			public int? PageIndex { get; set; }

			public ApiResponse(bool success,string message,T data,int totalCount = 0,int pageSize = 0,int pageIndex = 0)
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
