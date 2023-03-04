using System;
namespace BankingManagementSystem.Dto
{
    public class CustomerDto
    {
        //TODO How to map form entity to dto with private set;
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }
    }
}
