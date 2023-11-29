using Godot;
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
		GD.Print(GetParent());
		
	}
	private void OnItemPressed()
	{
		// Replace with function body.
	}
	private void OnFightPressed()
	{
		Control focusTest;
		focusTest = GetParent().GetNode<Control>("AttackMenu");
		focusTest.FocusMode = FocusModeEnum.All;
		//Move1
		focusTest.GetChild(0).GetChild(0).GetChild(0).GetChild<Button>(0).GrabFocus();
	}
	private void OnSwitchPressed()
	{
		// Replace with function body.
	}
	
	private void OnRunPressed()
	{
		// Replace with function body.
	}
	private void _on_focus_exited()
	{
		BoxContainer.Hide();	
	}
	
	private void _on_focus_entered()
	{
		BoxContainer.Show();
	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
