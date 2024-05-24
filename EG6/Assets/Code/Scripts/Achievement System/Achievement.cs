/// <summary>
/// Represents an achievement in the game.
/// </summary>
public class Achievement
{
    public string Name { get; }
    public string Description { get;}
    public string SpritePath { get; }
    public bool IsUnlocked { get; set;}

    public Achievement(string name, string description)
    {
        Name = name;
        Description = description;
        IsUnlocked = false;
    }   
}
