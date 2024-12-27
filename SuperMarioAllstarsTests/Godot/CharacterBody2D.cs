namespace Godot;

public class CharacterBody2D
{
    public virtual Vector2 Velocity { get; set; } = Vector2.Zero;
    public virtual Vector2 Gravity { get; set; } = Vector2.Zero;
    public virtual bool OnFloor { get; set; } = false;

    public virtual void _PhysicsProcess(double delta)
    {
    }

    public virtual Vector2 GetGravity()
    {
        return Gravity;
    }
    
    public virtual void MoveAndSlide()
    {
    }
    
    public virtual bool IsOnFloor()
    {
        return OnFloor;
    }
}
