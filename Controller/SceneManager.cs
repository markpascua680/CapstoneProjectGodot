using Godot;
using Model.Game;
using Model.GlobalVariables;
using System;

public partial class SceneManager : Node2D
{
	public string NextScenePath = null;

	public GameStates CurrentGameState;

	private Node2D CurrentScene;
	
	private AnimationPlayer Animation;

	private ColorRect TransitionScreen;
	
	private CharacterBody2D PlayerBody;

	private AudioStreamPlayer2D MusicPlayer;

	private float MusicLoopAtTime;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Animation = (AnimationPlayer)FindChild("ScreenFade");
		CurrentScene = GetNode<Node2D>("CurrentScene");
		//PlayerBody = (CharacterBody2D)CurrentScene.FindChild("PlayerBody2D");
		TransitionScreen = (ColorRect)FindChild("ColorRect");
		TransitionScreen.Color = new Color(0, 0, 0, 0);
		CurrentGameState = GameStates.TITLE_SCREEN;
		
		MusicPlayer = GetNode<AudioStreamPlayer2D>("MusicPlayer");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GD.Print(MusicPlayer.GetPlaybackPosition());
		//if (!MusicPlayer.Playing)
		//	LoopMusic(MusicLoopAtTime);
	}

	public void LoopMusic(float LoopAtTime)
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
