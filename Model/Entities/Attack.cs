namespace Model.Entities
{
    public enum AttackCategory
    {
        PHYSICAL = 0,
        
        SPECIAL,

        STATUS
    }

    public class Attack
    {
        public string Name { get; set; }

        public Type ElementalType { get; set; }

        public AttackCategory Category { get; set; }

        public double Accuracy { get; set; }

        public int PowerPoints { get; set; }

        public int MaxPowerPoints { get; set; }
    }
}