namespace Memento;

public record Info(string name, string gender, string address) : Originator
{
    public string name { get; set; } = name;
    public string gender { get; set; } = gender;
    public string address { get; set; } = address;

    public Memento save()
    {
        return new InfoMemento(this, name, gender, address);
    }
}