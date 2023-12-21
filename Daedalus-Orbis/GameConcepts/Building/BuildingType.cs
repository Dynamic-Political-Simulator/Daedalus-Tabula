using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Daedalus_Orbis.GameConcepts
{
    public class BuildingType
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HoldingType { get; set; }
        public bool Coastal {  get; set; } = false;
        public bool RiverSide { get; set; } = false;
        public List<Modifier> Modifiers { get; set; } = new List<Modifier>();
        public int MaaRegiments { get; set; } = 0;


    }
}
