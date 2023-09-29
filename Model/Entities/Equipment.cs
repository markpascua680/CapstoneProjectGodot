using Model.Entities;

namespace Model.Entities
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
