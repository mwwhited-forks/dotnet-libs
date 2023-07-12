namespace Eliassen.System.ResponseModel;

public interface ICaptureResultMessage
{
    void Publish(params ResultMessage[] resultMessage);
    IReadOnlyCollection<ResultMessage> Peek();
    void Clear();
    IReadOnlyCollection<ResultMessage> Capture();
}
