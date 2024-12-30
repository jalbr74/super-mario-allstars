using Godot;
using Moq;

namespace SuperMarioAllstarsTests.Objects.Characters.Mario;

public class MarioBuilder
{
    private readonly Mock<global::Mario> _mario = new() { CallBase = true };

    public MarioBuilder()
    {
        Input.Reset();
    }

    public (global::Mario mario, Mock<global::Mario> marioBehavior) Build()
    {
        return (_mario.Object, _mario);
    }

    public MarioBuilder WithOnFloor(bool isOnFloor)
    {
        _mario.Setup(x => x.IsOnFloor()).Returns(isOnFloor);

        return this;
    }

    public MarioBuilder WithGravity(Vector2 gravity)
    {
        _mario.Setup(x => x.GetGravity()).Returns(gravity);
        
        return this;
    }

    public MarioBuilder WithButtonPressed(string name)
    {
        Input.PressAction(name);

        return this;
    }

    public MarioBuilder WithButtonPressedAndHeld(string name)
    {
        Input.PressAndHoldAction(name);

        return this;
    }

    public MarioBuilder WithVelocity(Vector2 velocity)
    {
        _mario.Object.Velocity = velocity;
        
        return this;
    }

    public MarioBuilder WithMainAnimatedSprite(AnimatedSprite2D mainAnimatedSprite)
    {
        _mario.Object.MainAnimatedSprite = mainAnimatedSprite;
        
        return this;
    }
}
