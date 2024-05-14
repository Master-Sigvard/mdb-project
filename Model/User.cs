using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mdb_project.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string? Email { get; set; }
        [StringLength(40)]
        public string? Password { get; set; }
        [StringLength(40)]
        public string? Name { get; set; }

        // Collection navigation containing dependents
        public ICollection<Review> reviews { get; } = new List<Review>();
    }
}
