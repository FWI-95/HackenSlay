using System.Collections.Generic;

namespace HackenSlay.World.Transport;

public class Planet
{
    public string Name { get; }
    public Planet(string name)
    {
        Name = name;
    }
}

public class TransportSystem
{
    private readonly List<Planet> _planets = new();

    public void AddPlanet(string name)
    {
        _planets.Add(new Planet(name));
    }

    public Planet? FastTravel(string name)
    {
        return _planets.Find(p => p.Name == name);
    }
}
