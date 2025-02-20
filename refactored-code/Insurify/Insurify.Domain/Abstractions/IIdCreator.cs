namespace Insurify.Domain.Abstractions;

/// <summary>
/// Interface for creating Ids.
/// </summary>
public interface IIdCreator
{
    /// <summary>
    /// Creates a new Id.
    /// </summary>
    /// <returns>int Id</returns>
    int CreateId();
}
