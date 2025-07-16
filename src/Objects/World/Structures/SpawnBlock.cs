namespace HackenSlay.World.Structures;

public class SpawnBlock
{
    public string StructureName { get; }
    public SpawnBlock(string structureName)
    {
        StructureName = structureName;
    }

    public void Spawn()
    {
        // In a real game this would procedurally generate a structure.
    }
}
