namespace PrjRefDddSolid.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> Erros { get; private set; }

    public ResponseErrorJson(List<string> errorMessages) => Erros = errorMessages;

    public ResponseErrorJson(string errorMessage) => Erros = [errorMessage];
}
