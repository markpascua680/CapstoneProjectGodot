using Godot;
using Model;
using System;

public partial class Door : Area2D
{

	[Export(PropertyHint.File, "*.tscn,")]
	public string NextScenePath;
	
	[Export]
	public Vector2 SpawnPositionAfterTransition;

	public Rid Rid;

	private Node2D Player;

	private CharacterBody2D PlayerBody;

	private Callable FunctionCall;

	private bool IsPlayerEntered;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Rid = GetRid();
		var CurrentScene = GetTree().Root.GetChild(0).GetChild(0).GetChild(0);
		Player = (Node2D)CurrentScene.FindChild("Player");
		
		PlayerBody = (CharacterBody2D)Player.FindChild("PlayerBody2D");
		FunctionCall = new Callable(this, MethodName.EnterDoor);
		PlayerBody.Connect("DoorEntered", FunctionCall);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void EnterDoor(Rid InvokedRid)
	{
		if (Rid == InvokedRid)
		{
			GetTree().Root.GetChild(0).Call("TransitionToScene", NextScenePath, SpawnPositionAfterTransition);
		}
	}
}
