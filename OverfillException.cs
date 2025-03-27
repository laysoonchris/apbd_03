namespace apbd_03.Properties;
using System;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }

    public OverfillException(string message)
        : base(message)
    {
    }

    public OverfillException(string message, Exception inner)
        : base(message, inner)
    {
    }
}