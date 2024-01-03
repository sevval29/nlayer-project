using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Repository.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Repository
{
    public class AppDbContext :DbContext
    {
        

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        public DbSet<Team> Teams { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        //Entity sınıfları içinde farklı özellikler bulundururuz. Eğer bu özelliklere özel bir düzenleme
        //yapmazsak, özellik alanları rastgele bir şekilde veri tabanına kaydedilebilir. Veri tabanında gereksiz yer
        //tutmamak için bu ayarlamaları Entity Framework (EF) Core üzerinde yapabiliriz.
        //Entitylerle ilgili ayarları yapmak için, migration işlemi sırasında override etmemiz gereken bir metodumuz vardır:
        //OnModelCreating (model oluştururken çalıştırılacak metod).

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                entityReference.UpdatedDate = null;
                                break;
                            }
                        case EntityState.Deleted:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly üzerinden çekmek yerine tek tek de aşağıdaki şekilde tanımlayabiliriz 
            // Ama  her konfigürasyon oluşturduğunuzda buraya ekleme yapmamız gerekecektir.
            //Bu da çok sağlıklı bir yaklaşım olmayabilir. ÖNERİLMEZ !!!
            //   modelBuilder.ApplyConfiguration(new TeamConfiguration());
            //  modelBuilder.ApplyConfiguration(new UserConfiguration());
            //  modelBuilder.ApplyConfiguration(new UserProfileConfiguration());


            //Aşağıdaki kod satırı Entity Framework Core tarafından sağlanan Fluent API konfigürasyonlarını uygulamamızı kolaylaştıran
            //bir yöntemi temsil eder. Bu satır, aynı assembly içinde yer alan ve IEntityTypeConfiguration<TEntity> arayüzünü uygulayan
            //tüm Fluent API konfigürasyon sınıflarını otomatik olarak tanımlar ve uygular.

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }

    }
}
