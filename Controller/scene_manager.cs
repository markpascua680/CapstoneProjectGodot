using Godot;
using Model.GlobalVariables;
using System;

public partial class scene_manager : Node2D
{
	public string NextScenePath = null;

	private Node2D CurrentScene;
	
	private AnimationPlayer Animation;

	private ColorRect TransitionScreen;
	
	private CharacterBody2D PlayerBody;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Animation = (AnimationPlayer)FindChild("ScreenFade");
		CurrentScene = GetNode<Node2D>("CurrentScene");
		PlayerBody = (CharacterBody2D)CurrentScene.FindChild("PlayerBody2D");
		TransitionScreen = (ColorRect)FindChild("ColorRect");
		TransitionScreen.Color = new Color(0, 0, 0, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void TransitionToScene(string NewScenePath, Vector2 SpawnPositionAfterTransition)
	{
		GlobalVariables.PlayerGlobalPosition = SpawnPositionAfterTransition;
		NextScenePath = NewScenePath;
		Animation.Play("FadeToBlack");
	}

	private void TransitionFinished()
	{
		CurrentScene.RemoveChild(CurrentScene.GetChild(0));
		CurrentScene.AddChild(GD.Load<PackedScene>(NextScenePath).Instantiate());
		Animation.Play("FadeToScene");
	}
}
