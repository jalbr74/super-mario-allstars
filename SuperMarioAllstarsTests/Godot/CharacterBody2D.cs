namespace Godot;

public class CharacterBody2D
{
    public virtual Vector2 Velocity
    {
        get => throw new NotImplementedException();
        set=> throw new NotImplementedException();
    }
    
    public virtual void _PhysicsProcess(double delta) => throw new NotImplementedException();
    public virtual Vector2 GetGravity() => throw new NotImplementedException();
    public void MoveAndSlide() => throw new NotImplementedException();
    public bool IsOnFloor() => throw new NotImplementedException();
}
