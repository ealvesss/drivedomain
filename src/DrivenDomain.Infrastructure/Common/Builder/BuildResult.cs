namespace DrivenDomain.Crosscutting.Common.BuilderGeneric;

public class BuildResult<T>
{
    public T Object { get; private set; } = default!;
    public List<string> Errors { get; private set; } = new();
    public bool IsSuccess => Errors.Count == 0;

    public void SetObject(T obj)
    {
        Object = obj;
    }

    public void AddError(string error)
    {
        Errors.Add(error);
    }
}