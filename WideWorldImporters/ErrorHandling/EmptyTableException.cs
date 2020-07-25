using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class EmptyTableException : Exception
{
    private string _message;
    private string _text;

    public EmptyTableException(string message)
    {
        _message = message;
    }

    public string Message()
    {
        return _message;
    }

    public string Text()
    {
        _text = "The tables ParentsChildren is empty. First load data.";
        return _text;
    }
}