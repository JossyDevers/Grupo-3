using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class TiposCursos
    {
        public TiposCursos()
        {
            Cursos = new HashSet<Cursos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
