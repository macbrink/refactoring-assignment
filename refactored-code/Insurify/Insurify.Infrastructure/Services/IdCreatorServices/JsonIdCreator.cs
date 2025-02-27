using Insurify.Domain.Abstractions;

namespace Insurify.Infrastructure.Services.IdCreatorServices;

/// <summary>
/// JsonIdCreator is a class that implements IIdCreator interface.
/// </summary>
public class JsonIdCreator : IIdCreator
{
    private const string _jsonIdFile = "id.json";

    /// <summary>
    /// Constructor of JsonIdCreator class.
    /// </summary>
    public JsonIdCreator()
    {
        if(!File.Exists(_jsonIdFile))
        {
            File.WriteAllText(_jsonIdFile, "0");
        }
    }

    private int GetId()
    {
        return int.Parse(File.ReadAllText(_jsonIdFile));
    }

    private void SetId(int id)
    {
        File.WriteAllText(_jsonIdFile, id.ToString());
    }

    /// <summary>
    /// CreateId method is used to create a new id.
    /// </summary>
    /// <returns>new Id</returns>
    public int CreateId()
    {
        var lastId = GetId();
        var newId = lastId + 1;
        SetId(newId);
        return newId;
    }
}

