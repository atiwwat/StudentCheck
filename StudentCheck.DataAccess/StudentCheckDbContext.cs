using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudentCheck.DataAccess.Models;

namespace StudentCheck.DataAccess
{
    public partial class StudentCheckDbContext : DbContext
    {
        public StudentCheckDbContext()
        {
        }

        public StudentCheckDbContext(DbContextOptions<StudentCheckDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Abstain> Abstain { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Branch> Branch { get; set; }
        public virtual DbSet<BranchProfessors> BranchProfessors { get; set; }
        public virtual DbSet<CheckStudent> CheckStudent { get; set; }
        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<FacultyProfessors> FacultyProfessors { get; set; }
        public virtual DbSet<Homework> Homework { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Professors> Professors { get; set; }
        public virtual DbSet<Qrcode> Qrcode { get; set; }
        public virtual DbSet<Register> Register { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<ScheduleClass> ScheduleClass { get; set; }
        public virtual DbSet<StatusStudent> StatusStudent { get; set; }
        public virtual DbSet<StudentList> StudentList { get; set; }
        public virtual DbSet<StudentListSubjects> StudentListSubjects { get; set; }
        public virtual DbSet<SubjectList> SubjectList { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public virtual DbSet<Year> Year { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MOD-NATTASIT;Database=StudentCheck;User Id=sa;Password=mod_nattasit;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Abstain>(entity =>
            {
                entity.Property(e => e.AbstainId)
                    .HasColumnName("AbstainID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AbstainCause)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AbstainTime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AbstainWeek)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Abstaincompensate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Abstainroom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleClassId).HasColumnName("Schedule_Class_Id");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .HasColumnName("AdminID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminFirstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminLastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AdminTel)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.AdminUsername)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Adminemail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BranchProfessors>(entity =>
            {
                entity.HasKey(e => e.BranchIdP);

                entity.Property(e => e.BranchIdP).HasColumnName("BranchId_P");

                entity.Property(e => e.BrachNameP)
                    .HasColumnName("BrachName_P")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CheckStudent>(entity =>
            {
                entity.HasKey(e => e.Seq);

                entity.Property(e => e.Seq).ValueGeneratedNever();

                entity.Property(e => e.IdQr).HasColumnName("id_Qr");

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.DayId).HasColumnName("Day_id");

                entity.Property(e => e.DayNameEng)
                    .IsRequired()
                    .HasColumnName("DayName_Eng")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DayNameThai)
                    .IsRequired()
                    .HasColumnName("DayName_Thai")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.Facultyname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacultyProfessors>(entity =>
            {
                entity.HasKey(e => e.FacultyIdP);

                entity.Property(e => e.FacultyIdP).HasColumnName("FacultyID_P");

                entity.Property(e => e.FacultynameP)
                    .IsRequired()
                    .HasColumnName("Facultyname_P")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(e => e.HomeworkId).HasColumnName("HomeworkID");

                entity.Property(e => e.Homeworkdescription)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Homeworkname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Homeworkubmit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.Property(e => e.LoginId)
                    .HasColumnName("LoginID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorsId)
                    .HasColumnName("ProfessorsID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professors>(entity =>
            {
                entity.Property(e => e.ProfessorsId)
                    .HasColumnName("ProfessorsID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchIdP).HasColumnName("BranchID_P");

                entity.Property(e => e.FacultyIdP).HasColumnName("FacultyID_P");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.ProfessorsEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorsFacebookId)
                    .HasColumnName("ProfessorsFacebookID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorsFirstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorsLastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorsTel)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ProfessorslineId)
                    .HasColumnName("ProfessorslineID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Qrcode>(entity =>
            {
                entity.HasKey(e => e.IdQr);

                entity.Property(e => e.IdQr)
                    .HasColumnName("id_Qr")
                    .ValueGeneratedNever();

                entity.Property(e => e.GenTime).HasColumnType("datetime");

                entity.Property(e => e.QrcodeId)
                    .IsRequired()
                    .HasColumnName("QrcodeID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduleClassId).HasColumnName("Schedule_Class_Id");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.Property(e => e.RegisterId).HasColumnName("RegisterID");

                entity.Property(e => e.ScheduleClassId).HasColumnName("Schedule_Class_Id");

                entity.Property(e => e.StudentId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Roomname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ScheduleClass>(entity =>
            {
                entity.Property(e => e.ScheduleClassId)
                    .HasColumnName("Schedule_Class_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DayId).HasColumnName("Day_id");

                entity.Property(e => e.ProfessorsId)
                    .HasColumnName("ProfessorsID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RoomId)
                    .HasColumnName("RoomID")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Semester)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectGroup)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasColumnName("SubjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearStudy)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<StatusStudent>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId).HasColumnName("Status_id");

                entity.Property(e => e.Statusname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentList>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.BranchId).HasColumnName("BranchID");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.StudentAddress)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.StudentEducationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentFacebook)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentFirstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentLastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentLine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentParentEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentParentLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentParentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentParentNumber)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StudentPrefix)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StudentTel)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.StudentlineParent)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentListSubjects>(entity =>
            {
                entity.HasKey(e => e.Seq);

                entity.Property(e => e.StudentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasColumnName("SubjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubjectList>(entity =>
            {
                entity.HasKey(e => e.Seq);

                entity.Property(e => e.ProfessorsId)
                    .HasColumnName("ProfessorsID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasColumnName("SubjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.Property(e => e.SubjectId)
                    .HasColumnName("SubjectID")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.SubjectNameEng)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectNameThai)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.Seq);

                entity.ToTable("sysdiagrams");

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.DiagramId).HasColumnName("diagram_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Year>(entity =>
            {
                entity.ToTable("year");

                entity.Property(e => e.YearId)
                    .HasColumnName("yearID")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Education)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sector)
                    .HasColumnName("sector")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Semester)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
