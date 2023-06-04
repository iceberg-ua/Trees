namespace TreeBase;

public class BinaryNode<T>
{
    public BinaryNode(T value) => Value = value;

    public T Value { get; private set; }

    public BinaryNode<T>? LeftBranch { get; private set; } = null;

    public BinaryNode<T>? RightBranch { get; private set; } = null;

    public void AddLeft(BinaryNode<T> node) => LeftBranch = node;

    public void AddRight(BinaryNode<T> node) => RightBranch = node;

    public override string ToString()
    {
        return ToString("");
    }

    private string ToString(string indent)
    {
        var result = $"{indent}{Value}:";

        if (LeftBranch != null || RightBranch != null)
        {
            indent += "   ";
            result += Environment.NewLine + (LeftBranch == null ? indent + "None" : LeftBranch.ToString(indent));
            result += Environment.NewLine + (RightBranch == null ? indent + "None" : RightBranch.ToString(indent));
        }

        return result;
    }
}