using Godot;
using Model.GlobalVariables;
using System;
using System.ComponentModel;

// public class Button
// {
// 	public Node up;
// 	public Node down;
// 	public Node right;
// 	public Node left;
// 	public Button CurrentButton;
// 	public bool hovered;

// }

// public class LinkedList
// {
// 	private Node head;

// }
public partial class FightMenu : Control
{
	private BoxContainer BoxContainer;
	private Button FightButton;
	private Button ItemButton;
	private Button SwitchButton;
	private Button RunButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Gets BoxContainer
		BoxContainer = GetChild(0).GetChild<BoxContainer>(0);
		FightButton = BoxContainer.GetChild(0).GetChild<Button>(0);
		ItemButton = BoxContainer.GetChild(0).GetChild<Button>(1);
		SwitchButton = BoxContainer.GetChild(1).GetChild<Button>(0);
		RunButton = BoxContainer.GetChild(1).GetChild<Button>(1);
		FightButton.GrabFocus();
	}
	private void OnItemPressed()
	{
		// Replace with function body.
	}
	private void OnFightPressed()
	{
		Control AttackMenu;
		AttackMenu = GetParent().GetNode<Control>("AttackMenu");
		AttackMenu.FocusMode = FocusModeEnum.All;
		//Move1
		AttackMenu.GetChild(0).GetChild(0).GetChild(0).GetChild<Button>(0).GrabFocus();
		AttackMenu.Show();
		BoxContainer.Hide();	
	}
	private void OnSwitchPressed()
	{
		// Replace with function body.
	}
	
	private void OnRunPressed()
	{
		var NextScenePath = "res://overworld.tscn";
		var battleScene = GetParent();
		battleScene.Call("StartHometownMusic");
		GetTree().Root.GetChild(0).Call("TransitionToScene", NextScenePath, GlobalVariables.PlayerGlobalPosition);
	}
	private void _on_focus_exited()
	{
		BoxContainer.Hide();	
	}
	
	private void _on_focus_entered()
	{

	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
