using Daedalus_Orbis.Map;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Storage;



namespace Daedalus_Tabula.Hubs
{
    public class SelectionHub : Hub
    {
        public async Task NewSelection(TileComponentData tile, string user,UXEvents uX)
        {
            Console.WriteLine(tile.Id);
            uX?.NewTileSelected(tile);
        }
    }
}
