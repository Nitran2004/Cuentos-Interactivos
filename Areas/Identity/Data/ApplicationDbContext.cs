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
	}
}
