using Godot;

public partial class Enemy : CharacterBody2D
{
	[Export]
  public float movementSpeed = 20f;

  private Node2D player;

  public override void _Ready()
  {
    player = (Node2D)GetTree().GetFirstNodeInGroup("player");
  }

  public override void _PhysicsProcess(double delta)
  {
    // Calculate the direction vector
    Vector2 direction = GlobalPosition.DirectionTo(player.GlobalPosition);
    Velocity = direction * movementSpeed;
    MoveAndSlide();
  }
}
