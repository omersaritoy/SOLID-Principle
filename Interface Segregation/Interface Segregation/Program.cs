



// Interface representing a documen
public interface IDocument
{
    void Edit();
    void Print();
    void Fax();
}

public interface IPrintableDocument
{
    void Print();
}

public interface IEditableDocument
{
    void Edit();
}

public interface IFaxableDocument
{
    void Fax();
}
public class TextDocument : IPrintableDocument, IEditableDocument
{
    public void Edit()
    {
        Console.WriteLine("Editing text document...");
    }

    public void Print()
    {
        Console.WriteLine("Printing text document...");
    }
}
public class PdfDocument : IPrintableDocument, IFaxableDocument
{
    public void Print()
    {
        Console.WriteLine("Printing PDF document...");
    }

    public void Fax()
    {
        Console.WriteLine("Faxing PDF document...");
    }
}