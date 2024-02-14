namespace todoRazor;

public class BaseClass
{   
    public class RootObject
{
    public required List<BaseComponent> Content { get; set; }
}
    
    public abstract class BaseComponent
    {
        public int Id { get; set; }

        public string Component { get; set; } = "todo";
    }

    public interface IComponentContent
    {
        // Define common properties for content if any
    }

}
