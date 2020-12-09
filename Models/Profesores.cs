using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Profesores
    {
        public Profesores()
        {
            Asignaturas = new HashSet<Asignaturas>();
            HorarioDeConsultas = new HashSet<HorarioDeConsultas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Despacho { get; set; }
        public int IdArea { get; set; }

        public virtual Areas IdAreaNavigation { get; set; }
        public virtual ICollection<Asignaturas> Asignaturas { get; set; }
        public virtual ICollection<HorarioDeConsultas> HorarioDeConsultas { get; set; }
    }
}
