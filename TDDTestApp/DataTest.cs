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
    public void Should_Output0()
    {
        var list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("100");
        _sut.Input(list);
        var n = Environment.NewLine;
        Assert.Equal($"Output{n}Level: P1, Price: 100.{n}End", _sut.Output());
    }

    [Fact]
    public void Should_Output1()
    {
        var list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add("50");
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("100");
        _sut.Input(list);
        var n = Environment.NewLine;
        Assert.Equal($"Output{n}Level: G2, Price: 100.{n}Level: V2, Price: 100.{n}Level: P1, Price: 50.{n}End", _sut.Output());
    }

    [Fact]
    public void Should_Output2()
    {
        var list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G5"); list.Add("V2"); list.Add("P1"); list.Add("100");
        _sut.Input(list);
        var n = Environment.NewLine;
        Assert.Equal($"Output{n}Level: P1, Price: 100.{n}End", _sut.Output());
    }


    [Fact]
    public void Should_Output3()
    {
        var list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G5"); list.Add("V3"); list.Add("P1"); list.Add("100");
        _sut.Input(list);
        var n = Environment.NewLine;
        Assert.Equal($"Output{n}Level: P1, Price: 100.{n}End", _sut.Output());
    }


    [Fact]
    public void Should_Output4()
    {
        var list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add(null);
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("100");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("100");
        _sut.Input(list);
        var n = Environment.NewLine;
        Assert.Equal($"Output{n}Level: G2, Price: 100.{n}Level: V2, Price: 100.{n}End", _sut.Output());
    }


    [Fact]
    public void Should_Output5()
    {
        var list = new List<string>();
        list.Add("G1"); list.Add("V1"); list.Add("P1"); list.Add("50");
        list.Add("G2"); list.Add("V1"); list.Add("P1"); list.Add("70");
        list.Add("G3"); list.Add("V2"); list.Add("P1"); list.Add("100");
        list.Add("G4"); list.Add("V2"); list.Add("P1"); list.Add("90");
        _sut.Input(list);
        var n = Environment.NewLine;
        Assert.Equal($"Output{n}Level: G2, Price: 70.{n}Level: G3, Price: 100.{n}Level: V2, Price: 90.{n}Level: P1, Price: 50.{n}End", _sut.Output());
    }


    [Fact(Skip = "Sandbox")]
    public void SandBox()
    {
        _output.WriteLine(""/*_sut....("...")*/);
    }
}