using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mdb_project.Model
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = null!;
        public string? Poster { get; set; } //URL to poster
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public int Year { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? Premiere { get; set; }
        public string? Actors { get; set; }
        public string? Director { get; set; }
        [StringLength(200)]
        public string? Studio { get; set; }
        [StringLength(200)]
        public string? Country { get; set; }
        public int? Rating { get; set; }
    }
}
