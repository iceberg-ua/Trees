namespace TreeBase;

public class BinaryNode<T>
{
    public BinaryNode(T value) => Value = value;

    public T Value { get; private set; }

    public BinaryNode<T>? LeftBranch { get; private set; } = null;

    public BinaryNode<T>? RightBranch { get; private set; } = null;

    private static string BranchToString(BinaryNode<T>? node, string indent) => Environment.NewLine + (node == null ? indent + "None" : node.ToString(indent));

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

    public override string ToString()
    {
        return ToString("");
    }

    #endregion
}