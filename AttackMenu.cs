using Godot;

namespace AttackMenu;
public partial class AttackMenu : Control
{

	private BoxContainer BoxContainer;
	private Button Move1Button;
	private Button Move2Button;
	private Button Move3Button;
	private Button Move4Button;
	private Button BackButton;
	private Variant ButtonGrabbed;

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
		BoxContainer.Hide();
	}


	private void _on_focus_exited()
	{

	}



	private void _on_move_3_pressed()
	{
		ButtonGrabbed = 2;
		this.GrabFocus();
		// Replace with function body.
	}


	private void _on_move_1_pressed()
	{
		ButtonGrabbed = 0;
		this.GrabFocus();
		// Replace with function body.
	}


	private void _on_move_2_pressed()
	{
		ButtonGrabbed = 1;
		this.GrabFocus();
		// Replace with function body.
	}


	private void _on_move_4_pressed()
	{
		ButtonGrabbed = 3;
		this.GrabFocus();
		// Replace with function body.
	}


	private void _on_back_pressed()
	{

		ButtonGrabbed = 5;
		this.GrabFocus();
		// Replace with function body.
	}
}



