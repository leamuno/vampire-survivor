using Godot;

public partial class HurtBox : Area2D
{
  [Signal]
  public delegate void HurtEventHandler(int damage);
  public enum HurtBoxTypes
  {
    Cooldown,
    HitOnce,
    DisableHitBox
  }
  [Export]
  public HurtBoxTypes HurtBoxType = HurtBoxTypes.Cooldown;
  private CollisionShape2D collision; // Declare the CollisionShape2D variable
  private Timer disableTimer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    collision = GetNode<CollisionShape2D>("CollisionShape2D");
    disableTimer = GetNode<Timer>("DisableTimer");
	}
  private void _OnAreaEntered(Area2D area)
  {
    GD.Print("Area entered: ", area.Name);
    if (area.IsInGroup("attack"))
    {
      GD.Print("Area is in attack group.");
      if (area.HasMeta("damage"))
      {
        // Handle HurtBoxType
        switch (HurtBoxType)
        {
          case HurtBoxTypes.Cooldown:
            collision.CallDeferred("set", "disabled", true);
            disableTimer.Start();
            break;
          case HurtBoxTypes.HitOnce:
            break;
          case HurtBoxTypes.DisableHitBox:
            if (area is HitBox hitBox)
            {
              hitBox.TempDisable(); // Call TempDisable on HitBox
            }
            break;
        }
        int damage = (int)area.GetMeta("damage");
        EmitSignal(SignalName.Hurt, damage);
      }
    }
  }
  private void _OnDisableTimerTimeout()
  {
    collision.CallDeferred("set", "disabled", false);
  }
}
