using Godot;

public partial class Player : CharacterBody2D
{
  private float movementSpeed = 40f;

  public override void _PhysicsProcess(double delta)
  {
    Movement();
  }

  private void Movement()
  {
    // Get input
    float xMov = Input.GetActionStrength("right") - Input.GetActionStrength("left");
    float yMov = Input.GetActionStrength("down") - Input.GetActionStrength("up");

    // Calculate movement vector
    Vector2 mov = new Vector2(xMov, yMov);
    Velocity = mov.Normalized() * movementSpeed;

    // Move and slide
    MoveAndSlide();
  }
}
