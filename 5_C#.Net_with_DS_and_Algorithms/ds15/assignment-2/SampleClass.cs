public class SampleClass : ISampleInterface
{
    public string Name { get; set; } = "Naveen";
    public int Age { get; set; } = 22;
    public string Occupation { get; set; } = "Software Developer";

    public string Field1;
    
    public string Property1 { get; set; }
}

public interface ISampleInterface
{
}
