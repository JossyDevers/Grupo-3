using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Estudiantes
    {
        public Estudiantes()
        {
            EstudiantesAsignaturas = new HashSet<EstudiantesAsignaturas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public byte Edad { get; set; }
        public string Matricula { get; set; }

        public virtual ICollection<EstudiantesAsignaturas> EstudiantesAsignaturas { get; set; }
    }
}
