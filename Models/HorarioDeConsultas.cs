using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class HorarioDeConsultas
    {
        public int Id { get; set; }
        public string Dia { get; set; }
        public DateTime Hora { get; set; }
        public int IdProfesor { get; set; }

        public virtual Profesores IdProfesorNavigation { get; set; }
    }
}
