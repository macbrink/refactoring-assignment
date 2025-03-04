using Dapper;
using Insurify.Application.Abstractions.Data;
using Insurify.Domain.Abstractions;

namespace Insurify.MVC.Extensions;

public static class SeedDataExtensions
{
    private const int SeedCount = 100;

    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var idCreator = scope.ServiceProvider.GetRequiredService<IIdCreator>();
        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();

        var insurance = new
        {
            Id = idCreator.CreateId(),
            Name = "Home Insurance",
            Description = "Home Insurance is a type of property insurance that provides financial protection against damage or loss to a home and its contents. It typically covers risks such as fire, theft, vandalism, and natural disasters, depending on the policy. Home insurance may also include liability coverage, protecting homeowners if someone is injured on their property",
            PriceAmount = 100.00m,
            PriceCurrency = "EUR"
        };

        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
            INSERT INTO t_insurances (ins_pk, ins_name, ins_description, ins_priceamount, ins_pricecurrency, is_active)   
            VALUES (@Id, @Name, @Description, @PriceAmount, @PriceCurrency, 1 )
            """;

        var rows = connection.Execute(sql, insurance);

        Console.WriteLine($"{rows} Insurances inserted into the database.");
    }
}
