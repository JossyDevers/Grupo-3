using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            Areas = new HashSet<Areas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Areas> Areas { get; set; }
    }
}
