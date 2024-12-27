using Godot;
using System;

public enum GiftType
{
    Coin,
    Mushroom,
    Flower,
    Star
}

public partial class QuestionBlock : StaticBody2D
{
    // [Export] public NodePath AnimatedSprite2DPath { get; set; }
    [Export] public GiftType GiftType { get; set; }
    
    private AnimationPlayer _animationPlayer;
    private AnimatedSprite2D _animatedSprite2D;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
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
            _animatedSprite2D.Play("question_block_used");
            _animationPlayer.Play("block_bounce");
        }
    }
}
