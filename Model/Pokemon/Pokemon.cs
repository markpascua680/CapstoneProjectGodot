using Model.Pokemon.Type;
using Model.Pokemon.Stats;

namespace Model.Pokemon
{
    public class Pokemon 
    {
        public const int Id { get; }

        public string Name { get; set; }

        public int Level { get; set; }

        public Type Type { get; set; }

        public Stats Stats { get; set; }

        public int CurrentXP { get; set; }
        
        public int XPNeededToLevelUp { get; set; }

        public int CatchChance { get; set; }
    }
}