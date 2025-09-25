namespace OopExamples.Tests;

public class ValidComputer : NewComputerTests
{
    
    [Fact]
    public void NewComputer_WithComponents()
    {
        IsValidComputer(Computer);
    }
    
    [Fact]
    public void NewComputer_WithoutOwnerAndMonitors()
    {
        Assert.Null(Computer.Owner);
        Assert.Empty(Computer.Monitors);

        IsValidComputer(Computer);
    }
    
}