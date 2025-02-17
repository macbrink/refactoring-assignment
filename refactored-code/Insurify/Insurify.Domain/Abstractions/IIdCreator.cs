namespace Insurify.Domain.Abstractions;

/// <summary>
/// Interface for creating Ids.
/// </summary>
public interface IIdCreator
{
    Task<int> CreateId();
}
