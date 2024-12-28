using Godot;
using Moq;

namespace SuperMarioAllstarsTests.Objects.Characters.Mario;

public class MarioTestBuilder
{
    private readonly Mock<global::Mario> _mario = new() { CallBase = true };

    public MarioTestBuilder()
    {
        Input.Reset();
    }

    public (global::Mario mario, Mock<global::Mario> marioBehavior) Build()
    {
        return (_mario.Object, _mario);
    }

    public MarioTestBuilder WithOnFloor(bool isOnFloor)
    {
        _mario.Setup(x => x.IsOnFloor()).Returns(isOnFloor);

        return this;
    }

    public MarioTestBuilder WithGravity(Vector2 gravity)
    {
        _mario.Setup(x => x.GetGravity()).Returns(gravity);
        
        return this;
    }

    public MarioTestBuilder WithButtonPressed(string name)
    {
        Input.PressAction(name);

        return this;
    }

    public MarioTestBuilder WithButtonPressedAndHeld(string name)
    {
        Input.PressAndHoldAction(name);

        return this;
    }

    public MarioTestBuilder WithVelocity(Vector2 velocity)
    {
        _mario.Object.Velocity = velocity;
        
        return this;
    }
}
