using System.ComponentModel.DataAnnotations;

namespace CarManagement.Data
{
    public class Car
    {
       
        public int Id { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? CarName { get; set; }

        [Required]
        public string? Model { get; set; }

        [Required]
        public string? Color { get; set; }

        [Required]
        public string? Transmition { get; set; }

        [Required]
        public string? FuelType { get; set; }

        [Required]
        public string? SeatCapacity { get; set; }

        [Required]
        public string? BodyType { get; set; }

        [Required]
        public double? Price { get; set; }
    }
}