namespace Homies.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Homies.Common.EntityConstraints;
    public class Event
    {
        public Event()
        {
            this.EventsParticipants = new List<EventParticipant>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EventNameMaxChar)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(EventDescriptionMaxChar)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Organiser))]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public virtual IdentityUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required]
        public virtual Data.Models.Type Type { get; set; } = null!;

        public virtual ICollection<EventParticipant> EventsParticipants { get; set; }
    }
}
