using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Daedalus_Orbis.GameConcepts
{
    public interface IHoldingType
    {
        string Key { get; }
        string Name { get; }
        string Description { get; }
    }
    public class HoldingType : IHoldingType
    {
        [Key]
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
