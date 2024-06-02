using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureAssetManager.Areas.Identity.Data;
using SecureAssetManager.Models;
using System;
using System.IO;
using System.Threading;

namespace SecureAssetManager.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			builder.ApplyConfiguration(new AppUserEntityConfiguration());
		}

		public class AppUserEntityConfiguration : IEntityTypeConfiguration<AppUser>
		{
			public void Configure(EntityTypeBuilder<AppUser> builder)
			{
				builder.Property(p => p.FirstName).HasMaxLength(50);
				builder.Property(p => p.LastName).HasMaxLength(50);
			}
		}

		public DbSet<Asset> Assets { get; set; }
		public DbSet<AssetVulnerability> AssetVulnerabilitys { get; set; }
		public DbSet<AssetThreat> AssetThreats { get; set; }

		public DbSet<Threat> Threats { get; set; }

        public DbSet<Vulnerability> Vulnerabilities { get; set; }

        public DbSet<Risk> Risks { get; set; }

        public DbSet<Control> Controls { get; set; }

        public async Task<string> SaveImage(IFormFile file)
		{
			var fileName = $"{Guid.NewGuid()}_{file.FileName}";
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			return fileName;
		}

        public DbSet<SecureAssetManager.Models.Dieta>? Dieta { get; set; }

        public DbSet<SecureAssetManager.Models.Conducta>? Conducta { get; set; }

        public DbSet<SecureAssetManager.Models.Montaña>? Montaña { get; set; }

        public DbSet<SecureAssetManager.Models.Fin>? Fin { get; set; }

        public DbSet<SecureAssetManager.Models.Salida>? Salida { get; set; }

        public DbSet<SecureAssetManager.Models.Atorado>? Atorado { get; set; }

        public DbSet<SecureAssetManager.Models.Codigo>? Codigo { get; set; }

        public DbSet<SecureAssetManager.Models.Mapa>? Mapa { get; set; }

        public DbSet<SecureAssetManager.Models.Rusa>? Rusa { get; set; }

        public DbSet<SecureAssetManager.Models.Victoria>? Victoria { get; set; }

        public DbSet<SecureAssetManager.Models.Video>? Video { get; set; }

        public DbSet<SecureAssetManager.Models.Oso>? Oso { get; set; }

        public DbSet<SecureAssetManager.Models.Pistola>? Pistola { get; set; }

        public DbSet<SecureAssetManager.Models.Rapel>? Rapel { get; set; }

        public DbSet<SecureAssetManager.Models.Gps>? Gps { get; set; }

        public DbSet<SecureAssetManager.Models.Cueva>? Cueva { get; set; }

        public DbSet<SecureAssetManager.Models.Rio>? Rio { get; set; }

        public DbSet<SecureAssetManager.Models.Fogata>? Fogata { get; set; }

        public DbSet<SecureAssetManager.Models.Escalada>? Escalada { get; set; }

        public DbSet<SecureAssetManager.Models.Militar>? Militar { get; set; }

        public DbSet<SecureAssetManager.Models.Bosque>? Bosque { get; set; }

        public DbSet<SecureAssetManager.Models.Confianza>? Confianza { get; set; }

        public DbSet<SecureAssetManager.Models.Cerca>? Cerca { get; set; }

        public DbSet<SecureAssetManager.Models.Caja>? Caja { get; set; }

        public DbSet<SecureAssetManager.Models.Descenso>? Descenso { get; set; }

        public DbSet<SecureAssetManager.Models.Cable>? Cable { get; set; }

        public DbSet<SecureAssetManager.Models.Fusible>? Fusible { get; set; }

        public DbSet<SecureAssetManager.Models.Luz>? Luz { get; set; }

        public DbSet<SecureAssetManager.Models.Investigador>? Investigador { get; set; }

        public DbSet<SecureAssetManager.Models.Tienda>? Tienda { get; set; }

        public DbSet<SecureAssetManager.Models.Boma>? Boma { get; set; }

        public DbSet<SecureAssetManager.Models.Vuelta>? Vuelta { get; set; }

        public DbSet<SecureAssetManager.Models.Safari>? Safari { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve>? Nieve { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve2>? Nieve2 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve3>? Nieve3 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve4>? Nieve4 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve5>? Nieve5 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve6>? Nieve6 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve7>? Nieve7 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve8>? Nieve8 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve9>? Nieve9 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve10>? Nieve10 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve11>? Nieve11 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve12>? Nieve12 { get; set; }

        public DbSet<SecureAssetManager.Models.Nieve13>? Nieve13 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe>? Heroe { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe2>? Heroe2 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe3>? Heroe3 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe4>? Heroe4 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe5>? Heroe5 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe6>? Heroe6 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe7>? Heroe7 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe8>? Heroe8 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe9>? Heroe9 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe10>? Heroe10 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe11>? Heroe11 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe12>? Heroe12 { get; set; }

        public DbSet<SecureAssetManager.Models.Heroe13>? Heroe13 { get; set; }

        public DbSet<SecureAssetManager.Models.Medi1>? Medi1 { get; set; }

        public DbSet<SecureAssetManager.Models.Medi2>? Medi2 { get; set; }

        public DbSet<SecureAssetManager.Models.Medi3>? Medi3 { get; set; }

        public DbSet<SecureAssetManager.Models.Medi4>? Medi4 { get; set; }

        public DbSet<SecureAssetManager.Models.Medi5>? Medi5 { get; set; }

        public DbSet<SecureAssetManager.Models.Medi6>? Medi6 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre1>? Entre1 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre2>? Entre2 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre3>? Entre3 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre4>? Entre4 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre5>? Entre5 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre6>? Entre6 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre7>? Entre7 { get; set; }

        public DbSet<SecureAssetManager.Models.Entre8>? Entre8 { get; set; }

        public DbSet<SecureAssetManager.Models.Alpez1>? Alpez1 { get; set; }

        public DbSet<SecureAssetManager.Models.Alpez2>? Alpez2 { get; set; }

        public DbSet<SecureAssetManager.Models.Alpez3>? Alpez3 { get; set; }

        public DbSet<SecureAssetManager.Models.Alpez4>? Alpez4 { get; set; }

        public DbSet<SecureAssetManager.Models.Alpez5>? Alpez5 { get; set; }

        public DbSet<SecureAssetManager.Models.Alpez6>? Alpez6 { get; set; }

        public DbSet<SecureAssetManager.Models.Super1>? Super1 { get; set; }

        public DbSet<SecureAssetManager.Models.Super2>? Super2 { get; set; }

        public DbSet<SecureAssetManager.Models.Super3>? Super3 { get; set; }

        public DbSet<SecureAssetManager.Models.Super4>? Super4 { get; set; }

        public DbSet<SecureAssetManager.Models.Super5>? Super5 { get; set; }

        public DbSet<SecureAssetManager.Models.Super6>? Super6 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli1>? Peli1 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli2>? Peli2 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli3>? Peli3 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli4>? Peli4 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli5>? Peli5 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli6>? Peli6 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli7>? Peli7 { get; set; }

        public DbSet<SecureAssetManager.Models.Peli8>? Peli8 { get; set; }

        public DbSet<SecureAssetManager.Models.Veneno1>? Veneno1 { get; set; }

        public DbSet<SecureAssetManager.Models.Veneno2>? Veneno2 { get; set; }

        public DbSet<SecureAssetManager.Models.Veneno3>? Veneno3 { get; set; }

        public DbSet<SecureAssetManager.Models.Veneno4>? Veneno4 { get; set; }

        public DbSet<SecureAssetManager.Models.Veneno5>? Veneno5 { get; set; }

        public DbSet<SecureAssetManager.Models.Veneno6>? Veneno6 { get; set; }
	}
}
