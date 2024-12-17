using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class TripPlan
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public string UserId { get; set; } // Link to User

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Transportation { get; set; } // Car, Train, Plane, etc.
        public string Accommodation { get; set; } // Hotel, Airbnb, etc

    }
}
