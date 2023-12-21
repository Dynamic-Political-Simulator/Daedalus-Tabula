using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daedalus_Orbis.GameConcepts;
using System.ComponentModel.DataAnnotations;

namespace Daedalus_Orbis.GameConcepts
{
    public interface IHolding
    {
        string Id { get; }
        string Name { get; }
        List<Building> Buildings { get; }
        List<HoldingLevel> HoldingLevels { get; }

        bool IncreaseHoldingLevel(HoldingType holdingType);

        bool DecreaseHoldingLevel(HoldingType holdingType);
        void BuildBuilding(BuildingType buildingType);
    }
    public class Holding : IHolding
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Building> Buildings { get; set; } = new List<Building>();
        public List<HoldingLevel> HoldingLevels { get; set; } = new List<HoldingLevel> { };

        //Eventually List of MAA Regiments

        public bool IncreaseHoldingLevel(HoldingType holdingType)
        {
            if (GetHoldingLevel() == 5)
            {
                return false;
            }
            HoldingLevel? holdingLevel = HoldingLevels.FirstOrDefault(hl => hl.Type.Key == holdingType.Key);
            if (holdingLevel == null)
            {
                holdingLevel = new HoldingLevel()
                {
                    Type = holdingType,
                    Level = 1,
                };
                HoldingLevels.Add(holdingLevel);
                return true;
            }
            if (holdingLevel.Level == 3)
            {
                return false;
            }
            holdingLevel.Level++;
            return true;
        }

        public bool DecreaseHoldingLevel(HoldingType holdingType)
        {
            return false;
        }

        public int GetHoldingLevel()
        {
            int i = 0;
            foreach(HoldingLevel level in HoldingLevels)
            {
                i += level.Level;
            }
            return i;
        }

        public int GetBuildingSlots()
        {
            int level = GetHoldingLevel();
            return (int)(3 * Math.Pow(2, level-1));
            //Levels Slots are:
            //1: 3
            //2: 6
            //3: 12
            //4: 24
            //5: 48
        }

        public int GetOccupiedBuildingSlots()
        {
            int i = 0;
            foreach(Building b in Buildings)
            {
                i += b.Level;
            }
            return i;
        }

        public int GetFreeBuildingSlots()
        {
            return GetBuildingSlots() - GetOccupiedBuildingSlots();
        }

        public void BuildBuilding(BuildingType buildingType) 
        {
            int i = GetFreeBuildingSlots();
            if(i <= 0)
            {
                return;
            }
            Building? b = Buildings.FirstOrDefault(bui => bui.Type.Id == buildingType.Id);

            if(b == null)
            {
                b = new Building()
                {
                    Type = buildingType,
                    Level = 1,
                };
                Buildings.Add(b);
                return;
            }
            b.Level++;
        }

        public string BuildSpriteInfo()
        {
            StringBuilder str = new StringBuilder();
            List<HoldingType> HoldingTypes = new List<HoldingType>();
            foreach(HoldingLevel lvl in HoldingLevels)
            {
                if (!HoldingTypes.Contains(lvl.Type))
                {
                    str.Append(lvl.Type);
                    str.Append("_");
                    HoldingTypes.Add(lvl.Type);
                }
            }

            str.Remove(str.Length - 1,1);
            return str.ToString();
        }

    }
}
