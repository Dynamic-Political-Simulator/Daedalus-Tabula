using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus_Orbis.Map
{
    public interface IMapObject
    {
        string Id { get; set; }
        MapObjectType Type { get; set; }
        string ObjectId { get; set; }
    }

    public class MapObject : IMapObject
    {
        public string Id { get; set; }

        public MapObjectType Type { get; set; }
        public string ObjectId { get; set; }
    }

    public class MapObjectComponentData : IMapObject
    {
        public string Id { get; set; }

        public MapObjectType Type { get; set; }
        public string ObjectId { get; set; }

        public string SpriteInfo { get; set; }
    }

    public enum MapObjectType
    {
        Holding,
        Army
    }
}
