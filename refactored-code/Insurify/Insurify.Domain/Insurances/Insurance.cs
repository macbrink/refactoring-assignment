using Insurify.Domain.Abstractions;
using Insurify.Domain.Insurances.Events;
using Insurify.Domain.Shared;

namespace Insurify.Domain.Insurances;

/// <summary>
/// Model representing an insurance
/// </summary>
public sealed class Insurance : Entity
{
    /// <summary>
    /// Constructor for insurance
    /// </summary>
    /// <param name="idCreator">Creator for a new Id</param>
    /// <param name="name">The insurance name</param>
    /// <param name="description">Rhe insurance description</param>
    /// <param name="price">The insurance proce</param>
    private Insurance(
        IIdCreator idCreator,
        Name name, 
        Description description, 
        Money price)
        : base(idCreator)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    /// <summary>
    /// Constructor for insurance
    /// </summary>
    private Insurance()
    {
    }

    /// <summary>
    /// The insurance name
    /// </summary>
    public Name Name { get; private set; } = default!;

    /// <summary>
    /// The insurance description
    /// </summary>
    public Description Description { get; private set; } = default!;

    /// <summary>
    /// The insurance base price
    /// <para>
    /// The insurance policy price is based on this price.
    /// </para>
    /// </summary>
    public Money Price { get; private set; } = default!;

    /// <summary>
    /// Create a new insurance
    /// </summary>
    /// <param name="idCreator">Creator for a new Id</param>
    /// <param name="name">The insurance name</param>
    /// <param name="description">The insurance description</param>
    /// <param name="price">The isurance priice</param>
    /// <returns>An Insurance instance</returns>
    public static Result<Insurance> Create(
        IIdCreator idCreator,
        Name name,
        Description description,
        Money price)
    {
        var insurance = new Insurance(
            idCreator.CreateId().Result,
            name, 
            description, 
            price);
        return Result.Success(insurance);
    }

    /// <summary>
    /// Update the insurance description    
    /// </summary>
    /// <param name="description"></param>
    /// <returns><see cref="Result"/></returns>
    public Result UpdateDescription(
        Description description)
    {
        Description = description;
        return Result.Success();
    }

    /// <summary>
    /// Update the insurance price
    /// <para>
    /// aises a <see cref="InsurancePriceChangedDomainEvent"/> domain event.
    /// </para>
    /// </summary>
    /// <param name="price"></param>
    /// <returns><see cref="Result"/></returns>
    public Result UpdatePrice(
        Money price)
    {
        Price = price;
        RaiseDomainEvent(new InsurancePriceChangedDomainEvent(Id));
        return Result.Success();
    }
}

