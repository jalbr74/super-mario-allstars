using FluentAssertions;
using Godot;
using Moq;
using NUnit.Framework;

namespace SuperMarioAllstarsTests;

public class TestMario
{
    [Test]
    public void TestOne()
    {
        var mario = new Mock<Mario>();
        
        mario.Setup(m => m.Velocity).Returns(new Vector2(1, 2));
        mario.Setup(m => m.GetGravity()).Returns(new Vector2(42, 69));
        
        mario.Object.GetMessage().Should().Be("Hello, Godot! Gravity is (42, 69).");
    }
}
