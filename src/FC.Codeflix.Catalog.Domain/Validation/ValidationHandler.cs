namespace FC.Codeflix.Catalog.Domain.Validation;

public abstract class ValidationHandler
{
    public abstract void HandleError(ValidationError validationError);
}