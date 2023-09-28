using Godot;
using System;

var enemySprite = @GDScript.load("res://Assets/Pokemon-Tutorial-Art-Assets-master/Art/gfx/cuttable tree.png");


public partial class Enemy : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Texture.set_texture(enemySprite);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
