namespace GadgetGrove.Service.Exceptions;

public class GadgetGroveException : Exception
{
    public int StatusCode { get; set; }
    public GadgetGroveException(int code,string message) : base(message)
    {
        StatusCode = code;
    }
}
