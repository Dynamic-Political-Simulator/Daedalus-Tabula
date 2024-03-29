using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace Daedalus_Orbis.Map
{

    public interface ITile
    {
        string Id { get; }
        int Q { get; }
        int R { get; }
        int S { get; }
        public TerrainType Terrain { get; }
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

        //Specific Display Data
        public List<Vector2> Corners { get; set; } = new List<Vector2>();
        public string? CornersViewportCoordinates { get; set; }
        public string? FillString { get; set; }

        public Vector2 Center { get; set; }
        public bool Highlighted { get; set; } = false;
        public bool Selected { get; set; } = false;
        public TerrainType Terrain { get; set; }

        public TileComponentData(Tile tile, Vector2 center, List<Vector2> corners)
        {
            Id = tile.Id;
            Q = tile.Q;
            R = tile.R;
            S = tile.S;
            Center = center;
            Corners = corners;
            CornersViewportCoordinates = "";
            foreach (var c in Corners)
            {
                CornersViewportCoordinates += $"{c.X},{c.Y} ";
            }
            Terrain = tile.Terrain;
            FillString = $"url(#{Terrain.ToString()})";
        }

        public void ShiftTile(Vector2 Offset)
        {
            Center.X += Offset.X;
            Center.Y += Offset.Y;
        }

        public void ScaleTile(float Scale)
        {
            Center.X = Center.X * Scale;
            Center.Y = Center.Y * Scale;
        }

        public void ChangeTerrain(TerrainType t)
        {
            Terrain = t;
            FillString = $"url(#{Terrain.ToString()})";
        }
    }
}
