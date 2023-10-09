using Godot;

public partial class playerMovement : CharacterBody2D
{
	public float moveSpeed;
	public bool isMoving;
	public bool isSprinting;
	private Vector2 input;
	private float acceleration = 1.0001f;
	private float topSpeed = 0.5f; //boots = 0.025 
	private float sprintSpeed = 0.75f;
	private float movementTime = 0.0f;
	private AnimatedSprite2D animation;

	[Export]
	public int Speed { get; set; } = 100;

	public override void _Ready()
	{
		animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}
	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
		
		if (Input.IsActionPressed("up"))
		{
			animation.Play("WalkUp");
		}
		else if (Input.IsActionPressed("down"))
		{
			animation.Play("WalkDown");
		}
		else if (Input.IsActionPressed("left"))
		{
			animation.Play("WalkLeft");
		}
		else if (Input.IsActionPressed("right"))
		{
			animation.Play("WalkRight");
		}
		else
		{
			animation.Stop();
		}
	}
}
