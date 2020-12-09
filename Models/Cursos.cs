using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Asignaturas = new HashSet<Asignaturas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdTipo { get; set; }

        public virtual TiposCursos IdTipoNavigation { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
    }
}
