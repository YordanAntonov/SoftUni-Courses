namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            PartsCars = new HashSet<PartCar>();

            Sales = new HashSet<Sale>();
        }
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = null!;

        public virtual ICollection<PartCar> PartsCars { get; set; } = null!;
    }
}
