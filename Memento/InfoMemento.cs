namespace Memento;

public class InfoMemento(Info originator, string name, string gender, string address)
    : Memento
{
    public void restore()
    {
        originator.name = name;
        originator.gender = gender;
        originator.address = address;
    }
}