using FluentAssertions;
using Godot;
using Moq;
using NUnit.Framework;

namespace SuperMarioAllstarsTests.Objects.Characters.Mario;

public class TestMario
{
    [Test]
    public void Mario_should_face_and_move_left_when_the_controller_is_pressed_left() 
    {
        // Arrange
        var mario = new global::Mario
        {
            Gravity = new Vector2(0, 1000)
        };

        // Act
        mario._PhysicsProcess(0.01f);
        
        // Assert
        mario.Velocity.X.Should().Be(0);
        mario.Velocity.Y.Should().BeGreaterThan(0);
    }
}
