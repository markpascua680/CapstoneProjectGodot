using Godot;
using System;
using Model.Characters;
using System.IO;
using Godot.Collections;
using System.Linq;
using System.Collections;
using System.Text.Json.Serialization;
using HelperFiles.trainerConstantHandler;
public partial class node_2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

		var fileLocation = "res://Model/Characters/trainerConstant.json";
		var file = Godot.FileAccess.Open(fileLocation, Godot.FileAccess.ModeFlags.Read);
		var tmp = Json.ParseString(file.GetAsText());
		GD.Print(tmp.AsString()[0]);
		//var dict = Json.ParseString(tmp).AsGodotDictionary<string, Dictionary>();
		//GD.Print(dict["trainerInfo"]["defaultTestEnemy"].GetType());

		var statSheetDict = Json.ParseString(file.GetAsText());
		
		//GD.Print(statSheetDict.AsGodotDictionary<string, Variant.>);
		//GD.Print(statSheetDict["trainerInfo"]);
		
		

		//var dude1 = new Character{EntityTeam = };
		var enemySprite = (Texture2D)GD.Load("res://Assets/Pokemon-Tutorial-Art-Assets-master/Art/gfx/cuttable tree.png");
		GetNode<Sprite2D>("enemyEntity").Texture = enemySprite;
	} 

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
