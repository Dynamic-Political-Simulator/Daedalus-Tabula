using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace Daedalus_Orbis.Map
{

    public interface ITile
    {
        string Id { get; }
        int Q { get; }
        int R { get; }
        int S { get; }
        public TerrainType Terrain { get; set; }
    }

    public class Tile : ITile
    {
        public string Id { get; set; } = new Guid().ToString();
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
        public TerrainType Terrain { get; set; }
        public Tile(string id, int q,int r)
        {
            Id = id;
            Q = q;
            R = r;
            S = -q - r;
        }
    }

    public class TileComponentData : ITile
    {
        [AllowNull]
        public string Id { get; set; } = null;
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }

        public Vector2 Center { get; set; }
        public bool Highlighted { get; set; } = false;
        public bool Selected { get; set; } = false;
        public TerrainType Terrain { get; set; }

        public TileComponentData(Tile tile, Vector2 center)
        {
            Id = tile.Id;
            Q = tile.Q;
            R = tile.R;
            S = tile.S;
            Center = center;
            Terrain = tile.Terrain;
        }

        public void ShiftTile(Vector2 Offset)
        {
            Center.X = Center.X + Offset.X;
            Center.Y = Center.Y + Offset.Y;

        }
    }
}
