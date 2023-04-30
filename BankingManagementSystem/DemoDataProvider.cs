using System;
using System.Collections.Generic;
using System.Linq;
using BankingManagementSystem.Entities;
using BankingManagementSystem.Services;

namespace BankingManagementSystem
{
	public class DemoDataProvider
	{
		public readonly int UserCount = 1000;
		private readonly List<string> _lastNames = new()
		{
					"Smith","Johnson","Williams","Brown","Jones","Garcia","Miller","Davis","Rodriguez","Martinez","Hernandez","Lopez",
					"Gonzales","Wilson","Anderson","Thomas","Taylor","Moore","Jackson","Martin",
					"Lee",
					"Perez",
					"Thompson",
					"White",
					"Harris",
					"Sanchez",
					"Clark",
					"Ramirez",
					"Lewis",
					"Robinson",
					"Walker",
					"Young",
					"Allen",
					"King",
					"Wright",
					"Scott",
					"Torres",
					"Nguyen",
					"Hill",
					"Flores",
					"Green",
					"Adams",
					"Nelson",
					"Baker",
					"Hall",
					"Rivera",
					"Campbell",
					"Mitchell",
					"Carter",
					"Roberts",
					"Gomez",
					"Phillips",
					"Evans",
					"Turner",
					"Diaz",
					"Parker",
					"Cruz",
					"Edwards",
					"Collins",
					"Reyes",
					"Stewart",
					"Morris",
					"Morales",
					"Murphy",
					"Cook",
					"Rogers",
					"Gutierrez",
					"Ortiz",
					"Morgan",
					"Cooper",
					"Peterson",
					"Bailey",
					"Reed",
					"Kelly",
					"Howard",
					"Ramos",
					"Kim",
					"Cox",
					"Ward",
					"Richardson",
					"Watson",
					"Brooks",
					"Chavez",
					"Wood",
					"James",
					"Bennet",
					"Gray",
					"Mendoza",
					"Ruiz",
					"Hughes",
					"Price",
					"Alvarez",
					"Castillo",
					"Sanders",
					"Patel",
					"Myers",
					"Long",
					"Ross",
					"Foster",
					"Jimenez"
				};
		private readonly List<string> _maleFirstNames = new()
		{
					"James",
					"Robert",
					"John",
					"Michael",
					"David",
					"William",
					"Richard",
					"Joseph",
					"Thomas",
					"Charles",
					"Christopher",
					"Daniel",
					"Matthew",
					"Anthony",
					"Mark",
					"Donald",
					"Steven",
					"Paul",
					"Andrew",
					"Joshua",
					"Kenneth",
					"Kevin",
					"Brian",
					"George",
					"Timothy",
					"Ronald",
					"Edward",
					"Jason",
					"Jeffrey",
					"Ryan",
					"Jacob",
					"Gary",
					"Nicholas",
					"Eric",
					"Jonathan",
					"Stephen",
					"Larry",
					"Justin",
					"Scott",
					"Brandon",
					"Benjamin",
					"Samuel",
					"Gregory",
					"Alexander",
					"Frank",
					"Patrick",
					"Raymond",
					"Jack",
					"Dennis",
					"Jerry",
					"Tyler",
					"Aaron",
					"Jose",
					"Adam",
					"Nathan",
					"Henry",
					"Douglas",
					"Zachary",
					"Peter",
					"Kyle",
					"Ethan",
					"Walter",
					"Noah",
					"Jeremy",
					"Christian",
					"Keith",
					"Roger",
					"Terry",
					"Gerald",
					"Harold",
					"Sean",
					"Austin",
					"Carl",
					"Arthur",
					"Lawrence",
					"Dylan",
					"Jesse",
					"Jordan",
					"Bryan",
					"Billy",
					"Joe",
					"Bruce",
					"Gabriel",
					"Logan",
					"Albert",
					"Willie",
					"Alan",
					"Juan",
					"Wayne",
					"Elijah",
					"Randy",
					"Roy",
					"Vincent",
					"Ralph",
					"Eugene",
					"Russell",
					"Bobby",
					"Mason",
					"Philip",
					"Louis"
				};
		private readonly List<string> _femaleFirstName = new()
		{
					"Mary",
					"Patricia",
					"Jennifer",
					"Linda",
					"Elizabeth",
					"Barbara",
					"Susan",
					"Jessica",
					"Sarah",
					"Karen",
					"Lisa",
					"Nancy",
					"Betty",
					"Margaret",
					"Sandra",
					"Ashley",
					"Kimberly",
					"Emily",
					"Donna",
					"Michelle",
					"Carol",
					"Amanda",
					"Dorothy",
					"Melissa",
					"Deborah",
					"Stephanie",
					"Rebecca",
					"Sharon",
					"Laura",
					"Cynthia",
					"Kathleen",
					"Amy",
					"Angela",
					"Shirley",
					"Anna",
					"Brenda",
					"Pamela",
					"Emma",
					"Nicole",
					"Helen",
					"Samantha",
					"Katherine",
					"Christine",
					"Debra",
					"Rachel",
					"Carolyn",
					"Janet",
					"Catherine",
					"Maria",
					"Heather",
					"Diane",
					"Ruth",
					"Julie",
					"Olivia",
					"Joyce",
					"Virginia",
					"Victoria",
					"Kelly",
					"Lauren",
					"Christina",
					"Joan",
					"Evelyn",
					"Judith",
					"Megan",
					"Andrea",
					"Cheryl",
					"Hannah",
					"Jacqueline",
					"Martha",
					"Gloria",
					"Teresa",
					"Ann",
					"Sara",
					"Madison",
					"Frances",
					"Kathryn",
					"Janice",
					"Jean",
					"Abigail",
					"Alice",
					"Julia",
					"Judy",
					"Sophia",
					"Grace",
					"Denise",
					"Amber",
					"Doris",
					"Marilyn",
					"Danielle",
					"Beverly",
					"Isabella",
					"Theresa",
					"Diana",
					"Natalie",
					"Brittany",
					"Charlotte",
					"Marie",
					"Kayla",
					"Alexis",
					"Lori",
				};
		

		private readonly ICryptographyService _cryptographyService = new CryptographyService();

		public IEnumerable<User> Fake1000Users()
		{
			var userList = new Dictionary<string, User>();
			var random = new Random();
			var maleOrFemale = true;
			while (userList.Count < UserCount)
			{
				var lastNamePointer = random.Next(_lastNames.Count());
				int namePointer;
				if (maleOrFemale)
				{
					namePointer = random.Next(_maleFirstNames.Count());
				}
				else
				{
					namePointer = random.Next(_femaleFirstName.Count());
			    }
				var lastName = _lastNames[lastNamePointer];
				var firstName = maleOrFemale ? _maleFirstNames[namePointer] : _femaleFirstName[namePointer];
				var userName = $"{firstName} {lastName}";

				var user = new User
				{
					Id = Guid.NewGuid(),
					UserName = userName,
					Email = $"{firstName}_{lastName}@irocbank.com",
					NormalizedEmail = $"{firstName}_{lastName}@irocbank.com".ToUpperInvariant(),
					PasswordHash = _cryptographyService.GetPasswordHash(Guid.NewGuid().ToString()),
					SecurityStamp = Guid.NewGuid().ToString(),
					TwoFactorEnabled = false
				};
				if (userList.TryAdd(userName, user))
				{
					maleOrFemale = !maleOrFemale;
				}
			}

			return userList.Values;
		}

		public User GetSystemAdmin()
		{
			return new User
            {
                Id = new Guid("779f3783-e69a-4265-b92f-188943ed3be8"),
                UserName = "Admin",
                Email = $"admin@irocbank.com",
                NormalizedEmail = $"admin@irocbank.com".ToUpperInvariant(),
                PasswordHash = _cryptographyService.GetPasswordHash("admin"),
                SecurityStamp = new Guid("748a2661-93d0-41e1-9241-7272efa184da").ToString(),
                ConcurrencyStamp = new Guid("748a2661-93d0-41e1-9241-7272efa184da").ToString(),
                TwoFactorEnabled = false
            };
        }

		public IEnumerable<Role> GetDefaultSystemRoles()
		{
			return new List<Role>
			{
				new Role
				{
					ConcurrencyStamp = new Guid("7caea4ba-7575-4131-9285-1b96caa2546b").ToString(),
					Id = new Guid("aa0bfc24-66aa-4b2e-8be4-71c50cb86e17"),
					Name = "Admin",
					NormalizedName = "Admin".ToUpperInvariant()
				},
				new Role
				{
					ConcurrencyStamp = new Guid("e713754f-9c6a-48a8-b76d-e0bdacf43586").ToString(),
					Id = new Guid("54b5f558-fe32-4f74-aa74-1ce1b7ca2ac0"),
					Name = "Sales",
					NormalizedName = "Sales".ToUpperInvariant()
				}
			};
        }
	}
}