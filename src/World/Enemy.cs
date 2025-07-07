namespace HackenSlay;

public class Enemy : TextureObject
{
    public Enemy(string name)
    {
        _name = name;
        _isActive = true;
        _isVisible = true;
    }
}
