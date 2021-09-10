using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.Models
{
    public class CourseDto
    {
        public Guid Id {get;set;}
        public string title { get; set; }
        public string Description { get; set; }

        public Guid AuthorId { get; set; }
    }
}
