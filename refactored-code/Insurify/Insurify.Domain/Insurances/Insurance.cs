using Insurify.Domain.Abstractions;
using Insurify.Domain.Shared;

namespace Insurify.Domain.Insurances;

public sealed class Insurance : Entity
{
    private Insurance(Guid id, 
        Name name, 
        Description description, 
        Money price)
        : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    private Insurance()
    {
    }

    public Name Name { get; private set; } = default!;

    public Description Description { get; private set; } = default!;

    public Money Price { get; private set; } = default!;

    public static Result<Insurance> Create(
        Name name,
        Description description,
        Money price)
    {
        var insurance = new Insurance(Guid.NewGuid(), name, description, price);
        return Result.Success(insurance);
    }

    public Result Update(
        Description description,
        Money price)
    {
        Description = description;
        Price = price;
        return Result.Success();
    }
}

