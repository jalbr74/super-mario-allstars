using Godot;
using System;

public partial class WorldOneDashOne : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Connect the collision signal to the OnCollision method
        // GetNode<CollisionObject2D>("CollisionObject2D").Connect("body_entered", this, nameof(OnCollision));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    
    // Method to handle the collision event
    public void OnCollision(Node body)
    {
        if (body is Mario mario)
        {
            GD.Print("Collision detected with: " + mario.Name);
            mario.Position = new Vector2(100, -200);
        }
    }
}
