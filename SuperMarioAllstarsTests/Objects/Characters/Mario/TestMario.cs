using FluentAssertions;
using Godot;
using Moq;
using NUnit.Framework;

namespace SuperMarioAllstarsTests.Objects.Characters.Mario;

public class TestMario
{
    private Mock<global::Mario> _mario;
    
    [SetUp]
    public void Setup()
    {
        _mario = new Mock<global::Mario> { CallBase = true };
    }
    
    [Test]
    public void Mario_should_respect_gravity_when_not_on_the_floor() 
    {
        // Arrange
        _mario.Setup(x => x.IsOnFloor()).Returns(false);
        
        // Act
        _mario.Object._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Object.Velocity.X.Should().Be(0);
        _mario.Object.Velocity.Y.Should().BeGreaterThan(0);
        
        _mario.Verify(x => x.MoveAndSlide(), Times.Once);
    }

    [Test]
    public void Mario_should_ignore_gravity_when_on_the_floor() 
    {
        // Arrange
        _mario.Setup(x => x.IsOnFloor()).Returns(true);

        // Act
        _mario.Object._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Object.Velocity.Should().Be(new Vector2(0, 0));
        
        _mario.Verify(x => x.MoveAndSlide(), Times.Once);
    }
    
    [Test]
    public void Mario_should_jump_when_Button_A_is_pressed_and_is_on_the_floor()
    {
        // Arrange
        _mario.Setup(x => x.IsOnFloor()).Returns(true);
        Input.PressAction("Button_A");

        // Act
        _mario.Object._PhysicsProcess(0.01f);

        // Assert
        _mario.Object.Velocity.X.Should().Be(0);
        _mario.Object.Velocity.Y.Should().BeLessThan(0);
        
        _mario.Verify(x => x.MoveAndSlide(), Times.Once);
    }

    [Test]
    public void Mario_should_face_and_move_left_when_the_DPad_is_pressed_left()
    {
        // Arrange
        _mario.Setup(x => x.IsOnFloor()).Returns(true);
        Input.PressAndHoldAction("D_Pad_Left");

        // Act
        _mario.Object._PhysicsProcess(0.01f);

        // Assert
        _mario.Object.Velocity.X.Should().BeLessThan(0);
        _mario.Object.Velocity.Y.Should().Be(0);
        
        _mario.Verify(x => x.MoveAndSlide(), Times.Once);
    }

    [Test]
    public void Mario_should_slow_down_and_stop_when_the_DPad_is_released()
    {
        // Arrange
        _mario.Setup(x => x.IsOnFloor()).Returns(true);
        _mario.Object.Velocity = new Vector2(-100, 0);

        // Act
        _mario.Object._PhysicsProcess(0.01f);

        // Assert
        _mario.Object.Velocity.X.Should().BeGreaterThan(-100);
        _mario.Object.Velocity.X.Should().BeLessThanOrEqualTo(0);
        _mario.Object.Velocity.Y.Should().Be(0);

        _mario.Verify(x => x.MoveAndSlide(), Times.Once);
    }
}
