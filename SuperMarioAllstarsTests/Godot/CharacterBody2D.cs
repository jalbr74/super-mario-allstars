using SuperMarioAllstarsTests.Utils;

namespace Godot;

public class CharacterBody2D
{
    public virtual Vector2 Velocity { get; set; } = Vector2.Zero;

    public virtual void _PhysicsProcess(double delta)
    {
    }

    public virtual void MoveAndSlide()
    {
    }

    public virtual Vector2 GetGravity()
    {
        return new Vector2(0, 1000);
    }
    
    public virtual bool IsOnFloor()
    {
        return false;
    }
}
