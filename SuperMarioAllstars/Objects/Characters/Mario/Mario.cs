using Godot;
using System;

public partial class Mario : CharacterBody2D
{
    public const float Speed = 300.0f;
    public const float JumpVelocity = -400.0f;

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("Button_A") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }
        
        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        var direction = Input.GetVector("D_Pad_Left", "D_Pad_Right", "D_Pad_Up", "D_Pad_Down");
        if (direction != Vector2.Zero)
        {
            Scale = direction.X switch
            {
                < 0 => new Vector2(-1, 1),
                > 0 => new Vector2(1, 1),
                _ => Scale
            };

            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }
        
        Velocity = velocity;
        MoveAndSlide();
    }
    
    public virtual bool IsBig()
    {
        return false;
    }
}
