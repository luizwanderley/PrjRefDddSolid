namespace PrjRefDddSolid.Exception.ExceptionsBase;

public class ErrorOnValidationException : PrjRefDddSolidException
{
    //seguindo a documentação da Microsoft para nomes private readonly fields, prefixando com underscore

    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }

    public List<string> GetErrorMessages() => _errors;
}
