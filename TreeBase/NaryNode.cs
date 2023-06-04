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

    private List<NaryNode<T>> TraversePreorder(NaryNode<T>? node)
    {
        var result = new List<NaryNode<T>>();

        if (node == null)
            return result;

        result.Add(node);

        foreach (var child in node.Children)
        {
            result.AddRange(TraversePreorder(child));
        }

        return result;
    }

    private List<NaryNode<T>> TraversePostorder(NaryNode<T>? node)
    {
        var result = new List<NaryNode<T>>();

        if (node == null)
            return result;

        foreach (var child in node.Children)
        {
            result.AddRange(TraversePostorder(child));
        }

        result.Add(node);

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

    public List<NaryNode<T>> TraversePreorder() => TraversePreorder(this);

    public List<NaryNode<T>> TraversePostorder() => TraversePostorder(this);

    public List<NaryNode<T>> BreadthFirst()
    {
        var result = new List<NaryNode<T>>();
        var queue = new Queue<NaryNode<T>>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            result.Add(item);

            foreach ( var child in item.Children )
            {
                queue.Enqueue(child);
            }
        }

        return result;
    }

    public override string ToString()
    {
        return ToString("");
    }

    #endregion
}
