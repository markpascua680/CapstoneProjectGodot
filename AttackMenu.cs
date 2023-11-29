using Godot;
using System;

public partial class AttackMenu : Control
{

	private BoxContainer BoxContainer;
	private Button Move1Button;
	private Button Move2Button;
	private Button Move3Button;
	private Button Move4Button;
	private Button BackButton;
	public override void _Ready()
	{

		BoxContainer = GetChild(0).GetChild<BoxContainer>(0);
		BoxContainer.Hide();
		Move1Button = BoxContainer.GetChild(0).GetChild<Button>(0);
		Move2Button = BoxContainer.GetChild(1).GetChild<Button>(0);
		Move3Button = BoxContainer.GetChild(0).GetChild<Button>(1);
		Move4Button = BoxContainer.GetChild(1).GetChild<Button>(1);
		BackButton = BoxContainer.GetChild<Button>(2);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_move_1_focus_entered()
	{
			BoxContainer.Show();
	}
	private void _on_focus_entered()
	{

	}


	private void _on_focus_exited()
	{
		// Replace with function body.
	}



	private void _on_move_3_pressed()
	{
		// Replace with function body.
	}


	private void _on_move_1_pressed()
	{
		// Replace with function body.
	}


	private void _on_move_2_pressed()
	{
		// Replace with function body.
	}


	private void _on_move_4_pressed()
	{
		// Replace with function body.
	}


	private void _on_back_pressed()
	{
		// Replace with function body.
	}
}



