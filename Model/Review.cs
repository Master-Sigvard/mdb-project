using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mdb_project.Model
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        [Required, Column(TypeName = "ntext")]
        public string Text { get; set; }
        public int UserId { get; set; } //foreign key to Users
        public int FilmId { get; set; } //foreign key to Films
        public User User { get; set; } = null!; // Required reference navigation to Users
        public Film Film { get; set; } = null!; // Required reference navigation to Films
    }
}
