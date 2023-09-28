using Godot;
using Model.GlobalVariables;

public partial class PlayerMovement : CharacterBody2D
{
	[Signal]
	public delegate void  DoorEnteredEventHandler();
	
	private Vector2 InputDirection;
	
	private AnimatedSprite2D Animation;

	// Ray casts
	private RayCast2D DoorRay;

	private string PlayerDirection;

	[Export]
	public int Speed { get; set; } = 100;

	public override void _Ready()
	{	
		Animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		DoorRay = GetNode<RayCast2D>("DoorRayCast2D");
		
		if (GlobalVariables.PlayerGlobalPosition != Vector2.Zero)
			{
				GlobalPosition = GlobalVariables.PlayerGlobalPosition;
			}

		if (GlobalVariables.PlayerDirection != null)
		{
			Animation.Play(GlobalVariables.PlayerDirection);
		}
	}
	public void GetInput()
	{
		InputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = InputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
		PlayAnimation();

		DoorRay.TargetPosition = InputDirection * 8;
		DoorRay.ForceRaycastUpdate();

		if (DoorRay.IsColliding())
		{
			EmitSignal(SignalName.DoorEntered, DoorRay.GetCollider().Get("Rid"));
		}
		
	}

	private void PlayAnimation()
	{
		if (Input.IsActionPressed("up"))
		{
			if (Input.IsActionPressed("left"))
				PlayerDirection = "WalkUpLeft";
			else if (Input.IsActionPressed("right"))
				PlayerDirection = "WalkUpRight";
			else
				PlayerDirection = "WalkUp";
		}
		else if (Input.IsActionPressed("down"))
		{
			if (Input.IsActionPressed("left"))
				PlayerDirection = "WalkDownLeft";
			else if (Input.IsActionPressed("right"))
				PlayerDirection = "WalkDownRight";
			else
				PlayerDirection = "WalkDown";
		}
		else if (Input.IsActionPressed("left"))
		{
			if (Input.IsActionPressed("up"))
				PlayerDirection = "WalkUpLeft";
			else if (Input.IsActionPressed("down"))
				PlayerDirection = "WalkDownLeft";
			else
				PlayerDirection = "WalkLeft";
		}
		else if (Input.IsActionPressed("right"))
		{
			if (Input.IsActionPressed("up"))
				PlayerDirection = "WalkUpRight";
			else if (Input.IsActionPressed("down"))
				PlayerDirection = "WalkDownRight";
			else
				PlayerDirection = "WalkRight";
		}
		
		if (Input.IsActionJustReleased("up"))
		{
			PlayerDirection = "IdleUp";
		}
		else if (Input.IsActionJustReleased("down"))
		{
			PlayerDirection = "IdleDown";
		}
		else if (Input.IsActionJustReleased("left"))
		{
			PlayerDirection = "IdleLeft";
		}
		else if (Input.IsActionJustReleased("right"))
		{
			PlayerDirection = "IdleRight";
		}

		Animation.Play(PlayerDirection);
		GlobalVariables.PlayerDirection = PlayerDirection;
	}
}
