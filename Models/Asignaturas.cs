using System;
using System.Collections.Generic;

namespace StudentService.Models
{
    public partial class Asignaturas
    {
        public Asignaturas()
        {
            AsignaturaEquivalentesIdAsignaturaEquivalenteNavigation = new HashSet<AsignaturaEquivalentes>();
            AsignaturaEquivalentesIdAsignaturaNavigation = new HashSet<AsignaturaEquivalentes>();
            AsignaturaIncompatiblesIdAsignaturaIncompatibleNavigation = new HashSet<AsignaturaIncompatibles>();
            AsignaturaIncompatiblesIdAsignaturaNavigation = new HashSet<AsignaturaIncompatibles>();
            EstudiantesAsignaturas = new HashSet<EstudiantesAsignaturas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public byte Tipo { get; set; }
        public int Duracion { get; set; }
        public int CreditosTeoricos { get; set; }
        public int CreditosPracticos { get; set; }
        public int GruposTeoricos { get; set; }
        public int GruposPracticos { get; set; }
        public bool LibConf { get; set; }
        public bool LimAdm { get; set; }
        public int IdProfesor { get; set; }
        public int IdArea { get; set; }
        public int IdCurso { get; set; }
        public int IdTitulacion { get; set; }

        public virtual Areas IdAreaNavigation { get; set; }
        public virtual Cursos IdCursoNavigation { get; set; }
        public virtual Profesores IdProfesorNavigation { get; set; }
        public virtual Titulaciones IdTitulacionNavigation { get; set; }
        public virtual ICollection<AsignaturaEquivalentes> AsignaturaEquivalentesIdAsignaturaEquivalenteNavigation { get; set; }
        public virtual ICollection<AsignaturaEquivalentes> AsignaturaEquivalentesIdAsignaturaNavigation { get; set; }
        public virtual ICollection<AsignaturaIncompatibles> AsignaturaIncompatiblesIdAsignaturaIncompatibleNavigation { get; set; }
        public virtual ICollection<AsignaturaIncompatibles> AsignaturaIncompatiblesIdAsignaturaNavigation { get; set; }
        public virtual ICollection<EstudiantesAsignaturas> EstudiantesAsignaturas { get; set; }
    }
}
