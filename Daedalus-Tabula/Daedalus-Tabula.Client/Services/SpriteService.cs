using Daedalus_Orbis.Map;

public class SpriteService
{
    public string TerrainSprite(TerrainType terrainType)
    {
        switch (terrainType)
        {
            case TerrainType.None:
                return "sprites/terrain/None.png";
            case TerrainType.Plains:
                return "sprites/terrain/Plains.png";
            case TerrainType.Farmland:
                return "sprites/terrain/Farmland.png";
            case TerrainType.Swamp:
                return "sprites/terrain/Swamp.png";
            case TerrainType.Forest:
                return "sprites/terrain/Forest.png";
            case TerrainType.Hills:
                return "sprites/terrain/Hills.png";
            case TerrainType.Mountains:
                return "sprites/terrain/Mountains.png";
            case TerrainType.Ocean:
                return "sprites/terrain/Ocean.png";
            case TerrainType.River:
                return "sprites/terrain/River.png";
            case TerrainType.Urban:
                return "sprites/terrain/Urban.png";
            default:
                return "sprites/terrain/None.png";
        }
    }
}

