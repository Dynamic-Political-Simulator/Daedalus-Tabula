using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Daedalus_Orbis.Map
{
    public interface IMap
    {
    }
    /// <summary>
    /// Class <c>Map</c> contains a list of all Tiles of the Map.
    /// It provides functionality to return the pixel position of each Tile of the map.
    /// </summary>
    public class Map : IMap
    {
        /// <summary>
        /// List of all Tiles included in the Map
        /// </summary>
        public List<Tile> Tiles { get; set; } = new List<Tile>();

        public Map()
        {
            /*for (int q = -10; q < 10; q++)
            {
                for (int r = -10; r < 10; r++)
                {
                    int s = -r - q;
                    if (r + s + q > 20)
                    {
                        continue;
                    }
                    Tiles.Add(new Tile($"{q}.{r}.{s}",q, r));
                }
            }*/
            /*for (int s = 0; s < 10; s++)
            {
                for (int r = -10;r < 10; r++)
                {
                    int q = -r-s;
                    if (r + s + q > 20)
                    {
                        continue;
                    }
                    Tile tile = new Tile($"{q}.{r}.{-q - r}", q, r);
                    if (Tiles.FirstOrDefault(t => t.Id == tile.Id) != null)
                    {
                        continue;
                    }
                    else
                    {
                        Tiles.Add(tile);
                    }
                }
                for (int q = -10; q < 10; q++)
                {
                    int r = -q - s;
                    if (r + s + q > 20)
                    {
                        continue;
                    }
                    Tile tile = new Tile($"{q}.{r}.{-q - r}", q, r);
                    if (Tiles.FirstOrDefault(t => t.Id == tile.Id) != null)
                    {
                        continue;
                    }
                    else
                    {
                        Tiles.Add(tile);
                    }
                }
            }*/
            int size = 125;
            int half = (int)(size / 2);
            for (int row = 0; row < size; row++)
            {
                int cols = size - Math.Abs(row-half);
                for (int col = 0; col < cols; col++)
                {
                    int r = 0;
                    if (row < half)
                    {
                        r = col - row;
                    }
                    else
                    {
                        r = col - half;
                    }
                    int q = row - half;
                    int s = -r - q;
                    
                    Tiles.Add(new Tile($"{r}.{q}.{s}", q, r)
                    {
                        Terrain = TerrainType.Plains
                    });
                }
            }
        }
    }

    public class MapComponentData : IMap
    {
        public List<TileComponentData> Tiles { get; set; } = new List<TileComponentData>();
        public Vector2yOrientation Orientation { get; set; } = new Vector2yOrientation();
        public Vector2 Origin { get; set; }
        public Vector2 Size { get; set; }

        public MapComponentData(Map map, Vector2 origin, Vector2 size)
        {
            Origin = origin;
            Size = size;
            Console.WriteLine($"{Size.X}:{Size.Y}");
            foreach (Tile tile in map.Tiles)
            {
                
                Tiles.Add(new TileComponentData(tile, HexagonCenter(tile)));
            }
        }

        /// <summary>
        /// Method <c>PolygonCenter</c> calculates the center Vector2 of a given Tile.
        /// </summary>
        /// <param name="tile">Tile</param>
        /// <returns>Center Vector2 of Tile</returns>
        public Vector2 HexagonCenter(ITile tile)
        {
            double x = (Orientation.F0 * tile.Q + Orientation.F1 * tile.R) * ((Size.X+(Size.X*0.05)) * 0.5);
            double y = (Orientation.F2 * tile.Q + Orientation.F3 * tile.R) * ((Size.Y+(Size.Y*0.05)) * 0.5);

            return new Vector2(x + Origin.X, y+Origin.Y);
        }
        public Vector2 HexagonOrigin(ITile tile)
        {
            return null;
        }
    }

    public class Vector2yOrientation
    {
        public double F0 = Math.Sqrt(3.0);
        public double F1 = Math.Sqrt(3.0) / 2.0;
        public double F2 = 0.0;
        public double F3 = 3.0 / 2.0;
        public double B0 = Math.Sqrt(3.0) / 3.0;
        public double B1 = -1.0 / 3.0;
        public double B2 = 0.0;
        public double B3 = 2.0 / 3.0;
        public double StartAngle = 0.5;
    }
}
