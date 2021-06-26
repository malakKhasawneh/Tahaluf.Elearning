using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tahaluf.Elearning.API.Data
{
    public class Course
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
