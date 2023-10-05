using Model.Entities;
using System.Collections.Generic;

namespace Model.Characters
{
	public class Character
	{
		public string Name { get; set; }

		// Insert sprite object later when it's developed
		// public ??? Sprite { get; set; }

		public List<Entity> EntityTeam { get; set; }

		public bool AlreadyFought { get; set; } = false;
	}
}
