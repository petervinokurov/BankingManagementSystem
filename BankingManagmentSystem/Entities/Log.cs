using System;
using System.Net.Http;

namespace BankingManagmentSystem.Entities
{
	public class Log
	{
		public int Id { get; set; }
		public string MachineName { get; set; }
		public string Logged  { get; set; }
		public string Level { get; set; }
		public string Message { get; set; }
		public string Logger { get; set; }
		public string Callsite { get; set; }
		public string Exception { get; set; }
		public string RequestMethod { get; set; }
		public string Route { get; set; }
		public string QueryParameters { get; set; }
		public string UserPermissions { get; set; }
	}
}

