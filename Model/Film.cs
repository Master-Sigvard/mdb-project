using System.ComponentModel.DataAnnotations;

namespace mdb_project.Model
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public DateTime? Year { get; set; }
        public DateTime? Premiere { get; set; }
        public string? Actors { get; set; }
        public string? Director { get; set; }
        [StringLength(200)]
        public string? Studio { get; set; }
        [StringLength(200)]
        public string? Country { get; set; }
    }
}
