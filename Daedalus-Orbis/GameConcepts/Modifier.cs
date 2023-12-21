using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Daedalus_Orbis.GameConcepts
{
    public class Modifier
    {
        [Key]
        public string Id { get; set; } = new Guid().ToString();
        public Scope Scope { get; set; } = Scope.This;
        public RessourceType Type { get; set; }
        public ModType ModType { get; set; }
        public double Value { get; set; }
        
        public Modifier(double value, RessourceType type, Scope scope = Scope.This) 
        {
            Scope = scope;
            Type = type;
            Value = value;
        }

        public Modifier(string Key, double value)
        {
            string[] keyArgs = Key.Split('_');
            foreach (string arg in keyArgs)
            {
                //God have mercy on my soul
                if (Enum.GetValues(typeof(ModType)).OfType<string>().ToList().Contains(arg))
                {
                    ModType = (ModType)Enum.Parse(typeof(ModType), arg);
                }
                else if (Enum.GetValues(typeof(RessourceType)).OfType<string>().ToList().Contains(arg))
                {
                    Type = (RessourceType)Enum.Parse(typeof (RessourceType), arg);
                }
                else if (Enum.GetValues(typeof(Scope)).OfType<string>().ToList().Contains(arg))
                {
                    Scope = (Scope)Enum.Parse(typeof(Scope), arg);
                }
            }
            Value = value;
        }
    }

    public enum ModType
    {
        Add,
        Mult
    }
}
