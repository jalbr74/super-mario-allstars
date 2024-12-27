using FluentAssertions;
using Godot;
using Moq;
using NUnit.Framework;

namespace SuperMarioAllstarsTests.Objects.Characters.Mario;

public class TestMario
{
    private global::Mario _mario;
    
    [SetUp]
    public void SetUp()
    {
        Input.Reset();
        
        _mario = new global::Mario()
        {
            Gravity = new Vector2(0, 1000),
            Velocity = new Vector2(0, 0),
            OnFloor = true,
        };
    }
    
    [Test]
    public void Mario_should_respect_gravity_when_not_on_the_floor() 
    {
        // Arrange
        _mario.OnFloor = false;
        
        // Act
        _mario._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Velocity.X.Should().Be(0);
        _mario.Velocity.Y.Should().BeGreaterThan(0);
        _mario.MoveAndSlideWasCalled.Should().BeTrue();
    }
    
    [Test]
    public void Mario_should_ignore_gravity_when_on_the_floor() 
    {
        // Arrange
        _mario.OnFloor = true;

        // Act
        _mario._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Velocity.Should().Be(new Vector2(0, 0));
        _mario.MoveAndSlideWasCalled.Should().BeTrue();
    }
    
    [Test]
    public void Mario_should_jump_when_Button_A_is_pressed_and_is_on_the_floor() 
    {
        // Arrange
        Input.PressAction("Button_A");

        // Act
        _mario._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Velocity.X.Should().Be(0);
        _mario.Velocity.Y.Should().BeLessThan(0);
        _mario.MoveAndSlideWasCalled.Should().BeTrue();
    }

    [Test]
    public void Mario_should_face_and_move_left_when_the_DPad_is_pressed_left() 
    {
        // Arrange
        Input.PressAndHoldAction("D_Pad_Left");

        // Act
        _mario._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Velocity.X.Should().BeLessThan(0);
        _mario.Velocity.Y.Should().Be(0);
        _mario.MoveAndSlideWasCalled.Should().BeTrue();
    }

    [Test]
    public void Mario_should_slow_down_and_stop_when_the_DPad_is_released() 
    {
        // Arrange
        const int initialLeftVelocityX = -100;
        _mario.Velocity = new Vector2(initialLeftVelocityX, 0);

        // Act
        _mario._PhysicsProcess(0.01f);
        
        // Assert
        _mario.Velocity.X.Should().BeGreaterThan(initialLeftVelocityX);
        _mario.Velocity.X.Should().BeLessThanOrEqualTo(0);
        _mario.Velocity.Y.Should().Be(0);
        _mario.MoveAndSlideWasCalled.Should().BeTrue();
    }
}
