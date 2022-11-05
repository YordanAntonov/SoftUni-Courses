using PersonsInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SortPersonsByNameAndAge
{
    public class Team
    {
		private string name;
		
		private List<Person> firstTeam;
		private List<Person> reserveTeam;

		public Team(string name)
		{
			Name = name;
			firstTeam = new List<Person>();
			reserveTeam = new List<Person>();
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}


		public IReadOnlyCollection<Person> FirstTeam
		{
			get
			{
				return firstTeam.AsReadOnly();
			}
		}

		public IReadOnlyCollection<Person> ReserveTeam
		{
			get
			{
				return reserveTeam.AsReadOnly();
			}
		}

		public void AddPlayer(Person person)
		{
			if (person.Age < 40)
			{
				firstTeam.Add(person);
			}
			else
			{
				reserveTeam.Add(person);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"First team has {firstTeam.Count} players.");
			sb.AppendLine($"Reserve team has {reserveTeam.Count} players.");

			return sb.ToString().Trim();
		}

	}
}
