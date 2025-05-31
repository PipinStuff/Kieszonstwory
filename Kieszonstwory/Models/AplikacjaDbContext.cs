using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kieszonstwory.Models
{
    public class AplikacjaDbContext : IdentityDbContext<IdentityUser>
    {
        public AplikacjaDbContext(DbContextOptions<AplikacjaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kieszonstwor> Kieszonstwory { get; set; }
        public DbSet<TypStwora> TypyStworow { get; set; }
        public DbSet<Trener> Trenerzy { get; set; }
        public DbSet<Lokalizacja> Lokalizacje { get; set; }
        public DbSet<DzikiStwor> DzikiStwor { get; set; }
        public DbSet<Walka> Walka { get; set; }
        public DbSet<Esencja> Esencja { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TypStwora>().HasData(
            new TypStwora { Id = 1, Nazwa = "ziemny", Opis = "Żyją w ziemi" },
            new TypStwora { Id = 2, Nazwa = "skalny", Opis = "Są z kamulca" },
            new TypStwora { Id = 3, Nazwa = "latający", Opis = "Latają, chociaż czasami nie" },
             new TypStwora { Id = 4, Nazwa = "roślinny", Opis = "Żyją w roślinach,jedzą rośliny" },
            new TypStwora { Id = 5, Nazwa = "wodny", Opis = "Bul bul bul" }
);
            modelBuilder.Entity<Lokalizacja>().HasData(
            new Lokalizacja { Id = 1, Nazwa = "Góry" },
            new Lokalizacja { Id = 2, Nazwa = "Polana" },
            new Lokalizacja { Id = 3, Nazwa = "Wybrzeże" }
);
            modelBuilder.Entity<DzikiStwor>().HasData(
                // GÓRY
                new DzikiStwor { Id = 1, Nazwa = "Skalniak", Poziom = 1, Moc = 4,BaseMoc=4, TypStworaId = 2, LokalizacjaId = 1, Obrazek = "skalniak.png" ,HP=50,BaseHP=50},
                new DzikiStwor { Id = 2, Nazwa = "Ziemok", Poziom = 1, Moc = 4,BaseMoc=4, TypStworaId = 1, LokalizacjaId = 1, Obrazek = "ziemok.png", HP = 40, BaseHP = 40 },
                new DzikiStwor { Id = 3, Nazwa = "Taktoperz", Poziom = 1, Moc = 5,BaseMoc=5, TypStworaId = 3, LokalizacjaId = 1, Obrazek = "taktoperz.png", HP = 30, BaseHP = 30 },

                // POLANA
                new DzikiStwor { Id = 4, Nazwa = "Szybkonóg", Poziom = 1, Moc = 4,BaseMoc=4, TypStworaId = 4, LokalizacjaId = 2, Obrazek = "szybkonog.png", HP = 15, BaseHP = 15 },
                new DzikiStwor { Id = 5, Nazwa = "Reed", Poziom = 1, Moc = 5, BaseMoc = 5, TypStworaId = 4, LokalizacjaId = 2, Obrazek = "reed.png", HP = 25, BaseHP = 25 },
                new DzikiStwor { Id = 6, Nazwa = "Głąp", Poziom = 1, Moc = 2, BaseMoc = 2, TypStworaId = 3, LokalizacjaId = 2, Obrazek = "glap.png", HP = 20, BaseHP = 20 },

                // WYBRZEŻE
                new DzikiStwor { Id = 7, Nazwa = "Bober", Poziom = 1, Moc = 3, BaseMoc=3, TypStworaId =5, LokalizacjaId = 3, Obrazek = "bober.png", HP = 30, BaseHP = 30 },
                new DzikiStwor { Id = 8, Nazwa = "Płetw", Poziom = 1, Moc = 5, BaseMoc=5, TypStworaId = 5, LokalizacjaId = 3, Obrazek = "pletw.png", HP = 40, BaseHP = 40 },
                new DzikiStwor { Id = 9, Nazwa = "Krak", Poziom = 1, Moc = 2, BaseMoc=2, TypStworaId = 5, LokalizacjaId =3, Obrazek = "krak.png", HP = 35, BaseHP = 35 }
            );
        }
    }

}
