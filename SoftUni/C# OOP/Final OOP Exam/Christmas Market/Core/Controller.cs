using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth currBooth = new Booth(boothId, capacity);
            booths.AddModel(currBooth);
            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != nameof(Hibernation) && cocktailTypeName != nameof(MulledWine))
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            ICocktail currCocktail = currBooth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size);

            if (currCocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            switch (cocktailTypeName)
            {
                case nameof(Hibernation):
                    currCocktail = new Hibernation(cocktailName, size);
                    break;
                case nameof(MulledWine):
                    currCocktail = new MulledWine(cocktailName, size);
                    break;
                default:
                    return null;
            }
            currBooth.CocktailMenu.AddModel(currCocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != nameof(Gingerbread) && delicacyTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth currBooth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            IDelicacy currDelicacy = currBooth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (currDelicacy != null)
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            switch (delicacyTypeName)
            {
                case nameof(Gingerbread):
                    currDelicacy = new Gingerbread(delicacyName);
                    break;
                case nameof(Stolen):
                    currDelicacy = new Stolen(delicacyName);
                    break;
                default:
                    return null;
            }

            currBooth.DelicacyMenu.AddModel(currDelicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(booth.ToString());

            return sb.ToString().Trim();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            ICollection<IBooth> freeBooths = booths.Models.Where(b => b.IsReserved == false && b.Capacity >= countOfPeople).ToList();
            ICollection<IBooth> orderedBooths = freeBooths.OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).ToList();
            if (freeBooths.Count == 0)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            IBooth currBooth = orderedBooths.First();
            currBooth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, currBooth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            bool isCocktail = false;
            string[] orderedItems = order.Split('/');
            string itemTypeName = orderedItems[0];
            string itemName = orderedItems[1];
            int countOfOrderedPieces = int.Parse(orderedItems[2]);
            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                isCocktail = true;
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (itemTypeName != nameof(MulledWine) && itemTypeName != nameof(Hibernation) && itemTypeName != nameof(Gingerbread) && itemTypeName != nameof(Stolen))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }


            if (isCocktail)
            {
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, itemTypeName, itemName);
                }
            }
            else
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
            }


            if (isCocktail)
            {
                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName && c.Size == orderedItems[3]);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, orderedItems[3], itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }
            else
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }
        }
    }
}
