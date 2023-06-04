namespace TreeBase;

public class NaryNode<T>
{
    public NaryNode(T value)
    {
        Value = value;
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

    #region Public interface

    public T Value { get; }

    public List<NaryNode<T>> Children { get; } = new();

    public void AddChild(NaryNode<T> child) => Children.Add(child);

    public NaryNode<T>? FindNode(T value)
    {
        if (Value!.Equals(value))
            return this;

        NaryNode<T>? result = null;

        foreach (var child in Children)
        {
            result = child.FindNode(value);

            if (result is not null)
                break;
        }

        return result;
    }

    public override string ToString()
    {
        return ToString("");
    }

    #endregion
}
