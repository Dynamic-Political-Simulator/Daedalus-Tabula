using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Daedalus_Orbis.GameConcepts
{
    public interface IBuilding
    {

    }
    public class Building
    {
        [Key]
        public string Id { get; set; }
        public BuildingType Type { get; set; }
        public int Level { get; set; }
    }
}
