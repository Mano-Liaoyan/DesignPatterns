namespace Memento;

public static class Caretaker
{
    private static readonly Stack<Memento> redo_stack = new();
    private static readonly Stack<Memento> undo_stack = new();

    public static void undo()
    {
        var m = undo_stack.Pop();
        m.restore();
        redo_stack.Push(m);
    }

    public static void redo()
    {
        var m = redo_stack.Pop();
        m.restore();
        undo_stack.Push(m);
    }

    public static void addMemento(Memento m)
    {
        undo_stack.Push(m);
    }
}