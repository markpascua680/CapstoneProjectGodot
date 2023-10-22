using Godot;
using HelperFiles.trainerConstantHandler;
using Newtonsoft;
using Newtonsoft.Json;
public partial class node_2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var enemyDictionaryMain = new trainerConstant();
		var dictated = enemyDictionaryMain.getTrainerDict();
		GD.Print(dictated["defaultTestEnemy"].entityTeam[1].lvl);

		var enemySprite = (Texture2D)GD.Load("res://Assets/Pokemon-Tutorial-Art-Assets-master/Art/gfx/cuttable tree.png");
		GetNode<Sprite2D>("enemyEntity").Texture = enemySprite;
	} 

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
