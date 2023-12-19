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
    /// <summary>
    /// Class <c>Map</c> contains a list of all Tiles of the Map.
    /// It provides functionality to return the pixel position of each Tile of the map.
    /// </summary>
    public class Map : ComponentBase
    {
        /// <summary>
        /// List of all Tiles included in the Map
        /// </summary>
        [Parameter]
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
                    Tiles.Add(new Tile($"{r}.{q}.{s}", q, r));
                }
            }
        }
    }
}
