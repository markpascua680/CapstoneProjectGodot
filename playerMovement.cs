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
	[Export]
	public int Speed { get; set; } = 100;

	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
		Velocity = inputDirection * Speed;
	}

	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
}
