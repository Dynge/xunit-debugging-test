namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var a = 1;
        var b = 2;
        Assert.True(a != b);
    }
}
