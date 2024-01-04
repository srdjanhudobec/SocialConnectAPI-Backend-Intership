using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocialConnectAPI.Models;
using System;

namespace SocialConnectAPI.Repositorys
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Korisnik> korisnici { get; set; }
        public DbSet<Komentar> komentari { get; set; }

        public DbSet<Lajk> Lajkovi { get; set; }

        public DbSet<Objava> objave { get; set; }

        public DbSet<Pratioci> pratioci { get; set; }

        public DbSet<Tag> tagovi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Komentar>()
                .HasOne(k => k.objava)
                .WithMany(o => o.Komentari)
                .HasForeignKey(k => k.objavaId);
            //modelBuilder.Entity<Objava>()
            //    .HasOne<Objava>()
            //    .WithMany()
            //    .HasForeignKey(k => k.KreatorId) // Postavljamo spoljni ključ
            //    .OnDelete(DeleteBehavior.Restrict);
            foreach (var rel in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                rel.DeleteBehavior = DeleteBehavior.Restrict;//ako postoji foreign key zabrani brisanje!
            }
            
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Objava>(entity =>
            //{
            //    entity.Property(e => e.kreator.pratioci).IsRequired(false); // Postavlja LastName kao neobavezno polje
            //});
            modelBuilder.Entity<Pratioci>().HasKey(k => new { k.pratiocId, k.zapracenId });//slozeni kljuc,test podaci itd. idu ovde            /*modelBuilder.Entity<Korisnik>().HasIndex(u => u.Email).IsUnique();*///ogranicenja na novou baze,apija i fronta,najbolje da ide na nivou baze,tu se osiguras,a na frontu bi trebalo da bude dosya rastereceno.Za api on kontrolise sta pusta u bazu
            modelBuilder.Entity<Korisnik>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<Korisnik>()
            .HasMany<Objava>() //korisnik moze postaviti vise objava
                .WithOne(); // svaki post ima tacno jednog vlasnika
            modelBuilder.Entity<Objava>()
                .HasMany<Komentar>() //objava moze postaviti vise komentara
                .WithOne(); // svaki komentar se odnosi na tacno jednu objavu
            //modelBuilder.Entity<Objava>()
            //    .Property(p => p.Tagovi)
            //    .HasConversion(
            //        v => string.Join(',', v),
            //        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            //    );
        }

    }
}