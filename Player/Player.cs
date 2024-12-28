using Godot;

public partial class Player : CharacterBody2D
{
  private float movementSpeed = 40f;
  private int hp = 80;

  private Sprite2D sprite; // Declare the Sprite2D variable
  private Timer walkTimer;

  public override void _Ready()
  {
    // Get the Sprite2D node
    sprite = GetNode<Sprite2D>("Sprite2D");
    walkTimer = GetNode<Timer>("WalkTimer");
  }
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
    if (mov.X > 0)
    {
      sprite.FlipH = true; // Flip horizontally
    }
    else if (mov.X < 0)
    {
      sprite.FlipH = false; // Reset flip
    }

    if (mov != Vector2.Zero)
    {
      if (walkTimer.IsStopped())
      {
        if (sprite.Frame >= sprite.Hframes - 1)
        {
          sprite.Frame = 0;
        }
        else
        {
          sprite.Frame += 1;
        }
        walkTimer.Start();
      }
    }

    Velocity = mov.Normalized() * movementSpeed;
    // Move and slide
    MoveAndSlide();
  }

  public void _OnHurtBoxHurt(int damage)
  {
    hp -= damage;
    GD.Print(hp, damage);
  }
}
