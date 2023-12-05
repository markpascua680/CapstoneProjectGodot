using Godot;
using System;

public partial class PauseMenu : CanvasLayer
{
	private NinePatchRect Selector; 

	private enum MenuStates
	{
		HIDDEN = 0,
		VISIBLE,
		PAUSE,
		ENTITIES,
		BAG,
		OPTIONS,
		SAVE,
		EXIT

	};

	private MenuStates MenuState;

	private CharacterBody2D Player;

	private Button EntityButton;

	private Button BagButton;

	private Button OptionsButton;

	private Button SaveButton;

	private Button ExitButton;

	private Vector2 SelectorOffset;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		InitializeButtons();

		MenuState = MenuStates.HIDDEN;

		Visible = false;
		
		Selector =  (NinePatchRect)GetChild(0).FindChild("NinePatchRect").FindChild("Selector");
		Selector.Visible = false;

		Player = (CharacterBody2D)GetParent().GetNode<Node2D>("CurrentScene").GetChild(0).GetNode<Node2D>("Player").GetChild(0);
	}

	public override void _Process(double delta)
	{
		if (Visible)
		{
			if (IsButtonFocused(EntityButton))
				ShowSelector(EntityButton);
			if (IsButtonFocused(BagButton))
				ShowSelector(BagButton);
			if (IsButtonFocused(OptionsButton))
				ShowSelector(OptionsButton);
			if (IsButtonFocused(SaveButton))
				ShowSelector(SaveButton);
			if (IsButtonFocused(ExitButton))
				ShowSelector(ExitButton);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _UnhandledInput(InputEvent @event)
	{
		switch (MenuState)
		{
			// Open menu
			case MenuStates.HIDDEN:
				if (@event.IsActionReleased("Pause"))
				{
					StopPlayerAnimation();
					Player.SetPhysicsProcess(false);
					MenuState = MenuStates.VISIBLE;
					Visible = true;
				}
			break;
			// Close menu
			case MenuStates.VISIBLE:
				if (@event.IsActionReleased("Pause"))
				{
					Player.SetPhysicsProcess(true);
					MenuState = MenuStates.HIDDEN;
					Visible = false;
					Selector.Visible = false;
				}
			break;
			default:
			break;
		}
	}

	public void InitializeButtons()
	{
		var vBoxContainer = GetNode<Control>("Control").GetNode<NinePatchRect>("NinePatchRect").GetNode<VBoxContainer>("VBoxContainer");
		
		EntityButton = vBoxContainer.GetNode<Button>("Entities");
		BagButton = vBoxContainer.GetNode<Button>("Bag");
		OptionsButton = vBoxContainer.GetNode<Button>("Options");
		SaveButton = vBoxContainer.GetNode<Button>("Save");
		ExitButton = vBoxContainer.GetNode<Button>("Exit");

		SelectorOffset = new Vector2 (4, 4);
	}

	public bool IsButtonFocused(Button button)
	{
		if (button.HasFocus())
			return true;
		return false;
	}

	public void ShowSelector(Button button)
	{
		Selector.Visible = true;
		Selector.SetPosition(button.Position + SelectorOffset);
	}

	private void StopPlayerAnimation()
	{
		// Prevent residual animation from playing when nothing is being inputted after closing menu
		var PlayerDirection = Player.Get("PlayerDirection").AsString();
		if (PlayerDirection.Contains("Walk"))
		{
			PlayerDirection = PlayerDirection.Replace("Walk", "Idle");
			Player.Set("PlayerDirection", PlayerDirection);
		}

		Player.Get("Animation").AsGodotObject().Call("stop");
	}

	private void OnEntitiesButtonUp()
	{
	}

	private void OnBagButtonUp()
	{
	}

	private void OnOptionsButtonUp()
	{
	}

	private void OnSaveButtonUp()
	{
	}

	private void OnExitButtonUp()
	{
		GetTree().Quit();
	}

	private void OnEntitiesButtonMouseEntered()
	{
		Selector.Visible = true;
		ShowSelector(EntityButton);
	}

	private void OnEntitiesButtonMouseExited()
	{
		Selector.Visible = false;
	}

	private void OnBagButtonMouseEntered()
	{
		Selector.Visible = true;
		ShowSelector(BagButton);
	}

	private void OnBagButtonMouseExited()
	{
		Selector.Visible = false;
	}

	private void OnOptionsButtonMouseEntered()
	{
		Selector.Visible = true;
		ShowSelector(OptionsButton);
	}

	private void OnOptionsButtonMouseExited()
	{
		Selector.Visible = false;
	}

	private void OnSaveButtonMouseEntered()
	{
		Selector.Visible = true;
		ShowSelector(SaveButton);
	}

	private void OnSaveButtonMouseExited()
	{
		Selector.Visible = false;
	}

	private void OnExitButtonMouseEntered()
	{
		Selector.Visible = true;
		ShowSelector(ExitButton);
	}

	private void OnExitButtonMouseExited()
	{
		Selector.Visible = false;
	}
}
