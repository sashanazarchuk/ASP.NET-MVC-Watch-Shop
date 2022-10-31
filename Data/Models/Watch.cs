using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Watch
    {
        public int Id { get; set; }


        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The Model field is required.")]
        public string Model { get; set; }

        [Required, StringLength(100, MinimumLength = 20, ErrorMessage = "The Image field is required.")]
        public string img { get; set; }

        [Required, StringLength(100, MinimumLength = 3, ErrorMessage = "The Brand field is required.")]
        public string Brand { get; set; }

        [Required, StringLength(100, MinimumLength = 10, ErrorMessage = "The Material field is required.")]
        public string Material { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "The Guarantee field is required.")]
        public string Guarantee { get; set; }

        [Required, Range(0, 200_000)]
        public decimal Price { get; set; }
        public int ClockFaceId { get; set; }
        public ClockFace? ClockFace { get; set; }
    }
}