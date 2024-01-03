# NLayer Project 

# Proje Yapısı

Proje, aşağıdaki dört katmandan oluşmaktadır:

1. **API:** API katmanı, HTTP isteklerini karşılar ve iş mantığını yürütür.
2. **Core:** Core katmanında Modeller, Dtolar , Repository Interfaces, Servis Interfaces, UnitofWork Interface bulunur.
3. **Repository:** Veritabanı katmanı, veritabanı işlemlerini yürütür ve Entity Framework Core gibi bir ORM aracılığıyla veritabanı ile iletişim kurar.Migration , Repository implementation ve unitofwork implementation yapılır.
4. **Service:** Service katmanında mapping service implementation ve validations uygulanır.
# Kullanılan Teknolojiler

-.NET Core
-Entity Framework
-Fluent Validation
-UnitOfWork
-Microsoft SQL Server
# Entity'ler

1. **Team**
   - Takım bilgilerini içerir.
2. **User**
   - Kullanıcı bilgilerini içerir.
3. **UserProfile**
   - Kullanıcı profili bilgilerini içerir.
