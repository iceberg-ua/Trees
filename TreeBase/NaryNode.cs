namespace TreeBase;

public class NaryNode<T>
{
    public NaryNode(T value)
    {
        Value = value;
    }

    public T Value { get; }

    public List<NaryNode<T>> Children { get; } = new();

    public void AddChild(NaryNode<T> child) => Children.Add(child);

    public override string ToString()
    {
        return ToString("");
    }

    private string ToString(string indent)
    {
        var result = $"{indent}{Value}: ";

        indent += "  ";

        foreach (var child in Children)
        {
            result += Environment.NewLine + child.ToString(indent);
        }

        return result;
    }
}
