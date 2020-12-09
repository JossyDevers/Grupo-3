using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Areas
    {
        public Areas()
        {
            Asignaturas = new HashSet<Asignaturas>();
            Profesores = new HashSet<Profesores>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdDepartamento { get; set; }

        public virtual Departamentos IdDepartamentoNavigation { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
