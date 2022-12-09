using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipment;
        private List<IGym> gyms;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != nameof(Boxer) && athleteType != nameof(Weightlifter))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym currGym = gyms.FirstOrDefault(g => g.Name == gymName);

            if ((athleteType == nameof(Boxer) && currGym.GetType().Name == nameof(WeightliftingGym)) || (athleteType == nameof(Weightlifter) && currGym.GetType().Name == nameof(BoxingGym)))
            {
                return OutputMessages.InappropriateGym;
            }

            IAthlete athlete;
            switch (athleteType)
            {
                case nameof(Boxer):
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;

                case nameof(Weightlifter):
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    return null;
            }

            currGym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            IEquipment currEquipment;
            switch (equipmentType)
            {
                case nameof(BoxingGloves):
                    currEquipment = new BoxingGloves();
                    break;
                    
                case nameof(Kettlebell):
                    currEquipment = new Kettlebell();
                    break;
                default:
                    return null;
            }

            equipment.Add(currEquipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != nameof(BoxingGym) && gymType != nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            IGym currGym;
            switch (gymType)
            {
                case nameof(BoxingGym):
                    currGym = new BoxingGym(gymName);
                    break;

                case nameof(WeightliftingGym):
                    currGym = new WeightliftingGym(gymName);
                    break;
                default:
                    return null;
            }

            gyms.Add(currGym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(g => g.Name == gymName);
            double totalGymWeight = currGym.Equipment.Sum(e => e.Weight);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, Math.Round(totalGymWeight, 2));
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            //Remove the equipment from repo if added to gym
            IEquipment currEquipment = equipment.FindByType(equipmentType);
            if (currEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            //if (equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            //{
            //    throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            //}

            equipment.Remove(currEquipment);

            IGym currGym = gyms.FirstOrDefault(g => g.Name == gymName);

            currGym.AddEquipment(currEquipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym currGym = gyms.FirstOrDefault(g => g.Name == gymName);
            currGym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, currGym.Athletes.Count);
        }
    }
}
