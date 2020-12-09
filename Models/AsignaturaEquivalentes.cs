using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class AsignaturaEquivalentes
    {
        public int Id { get; set; }
        public int IdAsignatura { get; set; }
        public int IdAsignaturaEquivalente { get; set; }

        public virtual Asignaturas IdAsignaturaEquivalenteNavigation { get; set; }
        public virtual Asignaturas IdAsignaturaNavigation { get; set; }
    }
}
