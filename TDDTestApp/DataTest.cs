using Xunit.Abstractions;
using TDDConsoleApp;
using TDDConsoleApp.Objects;


namespace TDDTestApp;

public class DataTest
{
    private readonly Data _sut;
    private readonly ITestOutputHelper _output;


    public DataTest(ITestOutputHelper output)
    {
        _sut = new Data();
        _output = output;
    }


    [Fact]
    public void Should_Output()
    {
        IList<string> list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("100");
        _sut.Input(list);
        Assert.Equal($"Level: P1, Price: 100.{Environment.NewLine}Fin.", _sut.Output());
    }


    [Fact(Skip = "Sandbox")]
    public void SandBox()
    {
        _output.WriteLine(""/*_sut....("...")*/);
    }
}