using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Titulaciones
    {
        public Titulaciones()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
