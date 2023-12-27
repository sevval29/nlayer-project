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
        public DbSet<Team> Teams {  get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }


        //Entity sınıfları içinde farklı özellikler bulundururuz. Eğer bu özelliklere özel bir düzenleme
        //yapmazsak, özellik alanları rastgele bir şekilde veri tabanına kaydedilebilir. Veri tabanında gereksiz yer
        //tutmamak için bu ayarlamaları Entity Framework (EF) Core üzerinde yapabiliriz.
        //Entitylerle ilgili ayarları yapmak için, migration işlemi sırasında override etmemiz gereken bir metodumuz vardır:
        //OnModelCreating (model oluştururken çalıştırılacak metod).

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


        }

    }
}
