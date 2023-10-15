using Godot;
using System;
using Model.Characters;
public partial class node_2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	var enemySprite = (Texture2D)GD.Load("res://Assets/Pokemon-Tutorial-Art-Assets-master/Art/gfx/cuttable tree.png");
	GetNode<Sprite2D>("enemyEntity").Texture = enemySprite;
	} 

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
