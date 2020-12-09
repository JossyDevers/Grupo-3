using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentService.Models
{
    public partial class StudentServiceContext : DbContext
    {
        public StudentServiceContext()
        {
        }

        public StudentServiceContext(DbContextOptions<StudentServiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<AsignaturaEquivalentes> AsignaturaEquivalentes { get; set; }
        public virtual DbSet<AsignaturaIncompatibles> AsignaturaIncompatibles { get; set; }
        public virtual DbSet<Asignaturas> Asignaturas { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<EstudiantesAsignaturas> EstudiantesAsignaturas { get; set; }
        public virtual DbSet<HorarioDeConsultas> HorarioDeConsultas { get; set; }
        public virtual DbSet<Profesores> Profesores { get; set; }
        public virtual DbSet<TiposCursos> TiposCursos { get; set; }
        public virtual DbSet<Titulaciones> Titulaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=StudentService;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Areas__IdDeparta__3B75D760");
            });

            modelBuilder.Entity<AsignaturaEquivalentes>(entity =>
            {
                entity.ToTable("Asignatura_Equivalentes");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.AsignaturaEquivalentesIdAsignaturaNavigation)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdAsi__3C69FB99");

                entity.HasOne(d => d.IdAsignaturaEquivalenteNavigation)
                    .WithMany(p => p.AsignaturaEquivalentesIdAsignaturaEquivalenteNavigation)
                    .HasForeignKey(d => d.IdAsignaturaEquivalente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdAsi__3D5E1FD2");
            });

            modelBuilder.Entity<AsignaturaIncompatibles>(entity =>
            {
                entity.ToTable("Asignatura_Incompatibles");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.AsignaturaIncompatiblesIdAsignaturaNavigation)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdAsi__3E52440B");

                entity.HasOne(d => d.IdAsignaturaIncompatibleNavigation)
                    .WithMany(p => p.AsignaturaIncompatiblesIdAsignaturaIncompatibleNavigation)
                    .HasForeignKey(d => d.IdAsignaturaIncompatible)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdAsi__3F466844");
            });

            modelBuilder.Entity<Asignaturas>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdAre__403A8C7D");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdCur__2F10007B");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdPro__412EB0B6");

                entity.HasOne(d => d.IdTitulacionNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.IdTitulacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IdTit__4222D4EF");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cursos__IdTipo__2C3393D0");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiantes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Matricula)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstudiantesAsignaturas>(entity =>
            {
                entity.ToTable("Estudiantes_Asignaturas");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FechaMatriculacion).HasColumnType("datetime");

                entity.Property(e => e.FechaTermino).HasColumnType("datetime");

                entity.HasOne(d => d.IdAsignaturaNavigation)
                    .WithMany(p => p.EstudiantesAsignaturas)
                    .HasForeignKey(d => d.IdAsignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Asignaturas_Asignaturas");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.EstudiantesAsignaturas)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Estudiantes_Asignaturas_Estudiantes");
            });

            modelBuilder.Entity<HorarioDeConsultas>(entity =>
            {
                entity.Property(e => e.Dia)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Hora).HasColumnType("datetime");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.HorarioDeConsultas)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HorarioDe__IdPro__44FF419A");
            });

            modelBuilder.Entity<Profesores>(entity =>
            {
                entity.Property(e => e.Despacho)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Profesores)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Profesore__IdAre__45F365D3");
            });

            modelBuilder.Entity<TiposCursos>(entity =>
            {
                entity.ToTable("Tipos_Cursos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Titulaciones>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false);
            });
        }
    }
}
