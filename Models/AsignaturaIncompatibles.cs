using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class AsignaturaIncompatibles
    {
        public int Id { get; set; }
        public int IdAsignatura { get; set; }
        public int IdAsignaturaIncompatible { get; set; }

        public virtual Asignaturas IdAsignaturaIncompatibleNavigation { get; set; }
        public virtual Asignaturas IdAsignaturaNavigation { get; set; }
    }
}
