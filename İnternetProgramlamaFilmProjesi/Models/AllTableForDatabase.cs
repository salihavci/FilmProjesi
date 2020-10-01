namespace İnternetProgramlamaFilmProjesi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AllTableForDatabase : DbContext
    {
        public AllTableForDatabase()
            : base("name=AllTableForDatabase2")
        {
        }

        public virtual DbSet<film> films { get; set; }
        public virtual DbSet<member> members { get; set; }
        public virtual DbSet<post> posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<film>()
                .Property(e => e.fragman_iframe)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.film_iframe)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.acilklama)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.resim)
                .IsUnicode(false);

            modelBuilder.Entity<film>()
                .Property(e => e.film_adi)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.ad)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.soyad)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.kullanici)
                .IsUnicode(false);

            modelBuilder.Entity<member>()
                .Property(e => e.parola)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.kullanici)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.yorum)
                .IsUnicode(false);
        }
    }
}
