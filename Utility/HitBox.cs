using Godot;

public partial class HitBox : Area2D
{
  [Export]
  public int damage = 1;
  private CollisionShape2D collision;
  private Timer disableTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    collision = GetNode<CollisionShape2D>("CollisionShape2D");
    disableTimer = GetNode<Timer>("DisableHitBoxTimer");
	}

  public void TempDisable()
  {
    collision.CallDeferred("set", "disabled", true);
    disableTimer.Start();
  }

	public void _OnDisableHitBoxTimerTimeout()
  {
    collision.CallDeferred("set", "disabled", false);
  }
}