namespace Model.Game
{
	public enum GameStates
	{
		TITLE_SCREEN = 0,

		//Gameplay 
		FREE_ROAM,

		WILD_POKEMON_BATTLE,

		TRAINER_POKEMON_BATTLE,

		PAUSE,

		// Menus
		POKEMON_MENU,

		INVENTORY_MENU,

		// Fade to black when loading an area, then fade in to the scene
		FADE_OUT,

		FADE_IN
	}
}
