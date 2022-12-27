using System;
using System.Text.Json.Serialization;

namespace BankingManagmentSystem.Dto
{
	public class BmsResponse
	{
		[JsonPropertyName("applicationError")]
		public string ApplicationError { get; set; }
	}
}

