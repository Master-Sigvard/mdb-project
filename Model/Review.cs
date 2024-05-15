using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        [BindNever]
        public User? User { get; set; } // Required reference navigation to Users
        [BindNever]
        public Film? Film { get; set; } // Required reference navigation to Films
    }
}
