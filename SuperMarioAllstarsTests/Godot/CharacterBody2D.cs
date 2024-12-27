using SuperMarioAllstarsTests.Utils;

namespace Godot;

public class CharacterBody2D
{
    public virtual Vector2 Velocity { get; set; } = Vector2.Zero;
    public virtual Vector2 Gravity { get; set; } = Vector2.Zero;
    public virtual bool OnFloor { get; set; } = false;
    public virtual bool MoveAndSlideWasCalled { get; private set; }

    public virtual void _PhysicsProcess(double delta)
    {
        
    }

    public virtual void MoveAndSlide()
    {
        MoveAndSlideWasCalled = true;
    }

    public virtual Vector2 GetGravity()
    {
        return Gravity;
    }
    
    public virtual bool IsOnFloor()
    {
        return OnFloor;
    }
}
