using System.Collections.Generic;

namespace mdb_project.Model
{
    public class FilmViewModel
    {
        public Film Film { get; set; }
        public List<Review> Reviews { get; set; }
        public List<User> Users { get; set; }
    }
}