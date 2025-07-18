using System.Collections.Generic;

namespace HackenSlay.World.Map;

public record BiomeWeights(double StreetStepsFactor, double ObstacleFactor, double StructureFactor)
{
    public static readonly Dictionary<BiomeType, BiomeWeights> Presets = new()
    {
        { BiomeType.Plains, new BiomeWeights(1.0, 1.0, 1.0) },
        { BiomeType.Desert, new BiomeWeights(0.5, 0.3, 0.5) },
        { BiomeType.Forest, new BiomeWeights(1.0, 2.0, 1.0) },
        { BiomeType.Snow,   new BiomeWeights(0.8, 0.7, 0.8) }
    };
}
