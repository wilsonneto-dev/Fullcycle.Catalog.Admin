using Bogus;
using FC.Codeflix.Catalog.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace FC.Codeflix.Catalog.IntegrationTests.Base;
public class BaseFixture
{
    public BaseFixture() 
        => Faker = new Faker("pt_BR");

    protected Faker Faker { get; set; }

    public CodeflixCatalogDbContext CreateDbContext(bool preserveData = false)
    {
        var context = new CodeflixCatalogDbContext(
            new DbContextOptionsBuilder<CodeflixCatalogDbContext>()
            .UseSqlServer(@"Server=localhost;Database=company02;User Id=sa;Password=Str0ngP455W0RD;trustServerCertificate=true;")
            //.UseInMemoryDatabase("ok")
            .Options
        );
        if (preserveData == false)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
        return context;
    }
}
