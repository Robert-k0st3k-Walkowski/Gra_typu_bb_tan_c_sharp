using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using project;

namespace project.Tests;

[TestClass]
[TestSubject(typeof(Player))]
public class PlayerTest
{

    [TestMethod]
    public void METHOD()
    {
        Form2 Window = new Form2(true, Form1.difficultyModes.easy);

        Player p1 = new Player(Window);
        Player p2 = new Player(Window);

        Assert.IsNotNull(p1);
        Assert.IsNotNull(p2);
    }
}