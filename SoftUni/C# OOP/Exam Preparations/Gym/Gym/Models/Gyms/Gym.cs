using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private HashSet<IEquipment> equipment;
        private HashSet<IAthlete> athletes;
        protected Gym()
        {
            equipment = new HashSet<IEquipment>();
            athletes = new HashSet<IAthlete>();
        }

        protected Gym(string name, int capacity) : this()
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => this.equipment.Sum(e => e.Weight);

        public ICollection<IEquipment> Equipment => equipment;

        public ICollection<IAthlete> Athletes => athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            string equipmentWeight = $"{EquipmentWeight:f2}";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");
            if (athletes.Count == 0)
            {
                sb.AppendLine("No athletes");
            }
            else
            {
                Queue<string> athleteNames = new Queue<string>();
                foreach (var athlete in athletes)
                {
                    athleteNames.Enqueue(athlete.FullName);
                }
                sb.AppendLine($"{String.Join(", ", athleteNames)}");
            }
            sb.AppendLine($"Equipment total count: {equipment.Count}");
            sb.AppendLine($"Equipment total weight: {equipmentWeight} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
