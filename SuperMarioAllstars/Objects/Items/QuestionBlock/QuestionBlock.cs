using Godot;
using System;

public partial class QuestionBlock : StaticBody2D
{
    private AnimationPlayer _animationPlayer;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    
    public void OnCollisionWithMario(Node body)
    {
        if (body is Mario mario)
        {
            Console.WriteLine("Mario hit the question block!");
            _animationPlayer.Play("block_bounce");
        }
    }
}
