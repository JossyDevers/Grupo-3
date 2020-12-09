using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class EstudiantesAsignaturas
    {
        public int Id { get; set; }
        public int IdAsignatura { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime FechaMatriculacion { get; set; }
        public DateTime FechaTermino { get; set; }
        public byte? Calificacion { get; set; }

        public virtual Asignaturas IdAsignaturaNavigation { get; set; }
        public virtual Estudiantes IdEstudianteNavigation { get; set; }
    }
}
