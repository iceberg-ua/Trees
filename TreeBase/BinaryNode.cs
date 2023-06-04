namespace TreeBase;

public class BinaryNode<T>
{
    public BinaryNode(T value) => Value = value;

    public T Value { get; private set; }

    public BinaryNode<T>? LeftBranch { get; private set; } = null;

    public BinaryNode<T>? RightBranch { get; private set; } = null;

    private static string BranchToString(BinaryNode<T>? node, string indent) => Environment.NewLine + (node == null ? indent + "None" : node.ToString(indent));

    private List<BinaryNode<T>> TraversePreorder(BinaryNode<T>? node)
    {
        var result = new List<BinaryNode<T>>();

        if (node == null)
            return result;

        result.Add(node);

        result.AddRange(TraversePreorder(node.LeftBranch));
        result.AddRange(TraversePreorder(node.RightBranch));

        return result;
    }

    private List<BinaryNode<T>> TraverseInorder(BinaryNode<T>? node)
    {
        var result = new List<BinaryNode<T>>();

        if (node == null)
            return result;

        result.AddRange(TraverseInorder(node.LeftBranch));
        result.Add(node);
        result.AddRange(TraverseInorder(node.RightBranch));

        return result;
    }

    private List<BinaryNode<T>> TraversePostorder(BinaryNode<T>? node)
    {
        var result = new List<BinaryNode<T>>();

        if (node == null)
            return result;

        result.AddRange(TraversePostorder(node.LeftBranch));
        result.AddRange(TraversePostorder(node.RightBranch));
        result.Add(node);

        return result;
    }

    private string ToString(string indent)
    {
        var result = $"{indent}{Value}:";

        if (LeftBranch != null || RightBranch != null)
        {
            indent += "   ";
            result += BinaryNode<T>.BranchToString(LeftBranch, indent) + BinaryNode<T>.BranchToString(RightBranch, indent);
        }

        return result;
    }

    #region Public interface

    public void AddLeft(BinaryNode<T> node) => LeftBranch = node;

    public void AddRight(BinaryNode<T> node) => RightBranch = node;

    public BinaryNode<T>? FindNode(T value)
    {
        if (Value!.Equals(value))
            return this;

        BinaryNode<T>? result = null;

        if (LeftBranch is not null)
            result = LeftBranch.FindNode(value);

        if (result == null && RightBranch is not null)
            result = RightBranch.FindNode(value);

        return result;
    }

    public List<BinaryNode<T>> TraversePreorder() => TraversePreorder(this);

    public List<BinaryNode<T>> TraverseInorder() => TraverseInorder(this);

    public List<BinaryNode<T>> TraversePostorder() => TraversePostorder(this);

    public List<BinaryNode<T>> BreadthFirst()
    {
        var result = new List<BinaryNode<T>>();
        var queue = new Queue<BinaryNode<T>>();

        queue.Enqueue(this);
        
        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            result.Add(item);

            if (item.LeftBranch != null)
                queue.Enqueue(item.LeftBranch);

            if(item.RightBranch != null)
                queue.Enqueue(item.RightBranch);
        }

        return result;
    }

    public override string ToString()
    {
        return ToString("");
    }

    #endregion
}