using Godot;
using Moq;

namespace SuperMarioAllstarsTests.Objects.Characters.Mario;

public class MarioBuilder
{
    private readonly Mock<global::Mario> _mario = new();
    
    // .WithState("Idle", Vector2.Zero)
    // .WithGravity(new Vector2(42, 69))
    // .WithNewDirection(new Vector2(-1, 0))
    // .WithIsOnFloor(true)
    // .WithIsInputActionJustPressed("Button_A", true)

    public global::Mario Build()
    {
        _mario.Setup(m => m._PhysicsProcess(0.01f)).CallBase();
        
        // _mario.Setup(m => m.Velocity).Returns(new Vector2(1, 2));
        // _mario.Setup(m => m.GetGravity()).Returns(new Vector2(42, 69));
        // _mario.Setup(m => m.GetNewDirection()).Returns(new Vector2(-1, 0));
        // _mario.Setup(m => m.IsOnFloor()).Returns(true);
        // _mario.Setup(m => m.IsInputActionJustPressed("Button_A")).Returns(true);

        return _mario.Object;
    }
    
    public MarioBuilder WithVelocity(Vector2 vector2)
    {
        _mario.Setup(m => m.Velocity).Returns(vector2);
        
        return this;
    }

    public MarioBuilder FacingRight()
    {
        return this;
    }

    public MarioBuilder OnFloor(bool isOnFloor)
    {
        _mario.Setup(m => m.IsOnFloor()).Returns(isOnFloor);
        
        return this;
    }

    public MarioBuilder WithGravity(Vector2 gravity)
    {
        _mario.Setup(m => m.GetGravity()).Returns(gravity);
        
        return this;
    }
}
