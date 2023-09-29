using Model.Entity.Stats;

namespace Model.Entity.Equipment
{
    public enum EquipmentType
    {
        HEAD = 0,

        HAND,

        SHOE
    }

    public class Equipment
    {
        public Stats EquipmentStats { get; }

        public EquipmentType EquipmentType { get; }
    }
}