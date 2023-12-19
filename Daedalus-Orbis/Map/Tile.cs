using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace Daedalus_Orbis.Map
{

    public interface ITile
    {
        string Id { get; }
        int Q { get; }
        int R { get; }
        int S { get; }
    }

    public class Tile : ITile
    {
        public string Id { get; set; } = new Guid().ToString();
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
        public Tile(string id, int q,int r)
        {
            Id = id;
            Q = q;
            R = r;
            S = -q - r;
        }
    }

    public class TileDTO : ITile
    {
        [AllowNull]
        public string Id { get; set; } = null;
        public int Q { get; set; }
        public int R { get; set; }
        public int S { get; set; }
    }
}
