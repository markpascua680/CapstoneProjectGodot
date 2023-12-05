using Godot;
using System;
// PseudoCode
// using Player.Trainer
// using NPCList
// 



public partial class Enemy : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// currEnemyEntity = NPCList 
		var enemySprite = (Texture2D)GD.Load("res://Assets/Pokemon-Tutorial-Art-Assets-master/Art/gfx/cuttable tree.png");
		
		this.Texture = enemySprite;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
