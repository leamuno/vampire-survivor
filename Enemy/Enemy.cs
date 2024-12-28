using Godot;

public partial class Enemy : CharacterBody2D
{
	[Export]
  public float movementSpeed = 20f;

  private Node2D player;
  private Sprite2D sprite; // Declare the Sprite2D variable
  private AnimationPlayer anim;
  public override void _Ready()
  {
    player = (Node2D)GetTree().GetFirstNodeInGroup("player");
    sprite = GetNode<Sprite2D>("Sprite2D");
    anim = GetNode<AnimationPlayer>("AnimationPlayer");
    anim.Play("walk");
  }

  public override void _PhysicsProcess(double delta)
  {
    // Calculate the direction vector
    Vector2 direction = GlobalPosition.DirectionTo(player.GlobalPosition);
    Velocity = direction * movementSpeed;
    MoveAndSlide();

    if (direction.X > 0.1)
    {
      sprite.FlipH = true; // Flip horizontally
    }
    else if (direction.X < -0.1)
    {
      sprite.FlipH = false; // Reset flip
    }
  }
}
