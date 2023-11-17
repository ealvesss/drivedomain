namespace Challenge.Crosscutting.Common.BuilderGeneric;

//Builder Inheritance Approach
public abstract class BuilderBase<TBuilder, TEntity> where TBuilder 
    : BuilderBase<TBuilder, TEntity>, new() where TEntity : new()
{
    protected TEntity _instance = new();

    public static TBuilder Create()
    {
        return new TBuilder();
    }

    public TEntity Build()
    {
        return _instance;
    }
    
    protected virtual void Validate()
    {
        //here comes the validations (should use only to a generic validation) case it exists.
    }
}