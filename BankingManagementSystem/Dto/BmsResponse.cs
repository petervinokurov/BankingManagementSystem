using System;
using System.Text.Json.Serialization;

namespace BankingManagementSystem.Dto
{
	public class BmsResponse
	{
		[JsonPropertyName("applicationError")]
		public string ApplicationError { get; set; }
	}
}

