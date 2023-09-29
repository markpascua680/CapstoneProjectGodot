using Model.Entities;
using System.Collections.Generic;

namespace Model.Entities	
{
	public class Entity 
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Level { get; set; }

		public Type Type { get; set; }

		public Stats Stats { get; set; }

		public int CurrentXP { get; set; }
		
		public int XPNeededToLevelUp { get; set; }

		public int CatchChance { get; set; }

		public List<Equipment> Equipment { get; set; }
	}
}
