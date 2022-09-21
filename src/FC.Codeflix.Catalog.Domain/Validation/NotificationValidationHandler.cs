namespace FC.Codeflix.Catalog.Domain.Validation;

public class NotificationValidationHandler : ValidationHandler
{
    private readonly List<ValidationError> _errors;

    public NotificationValidationHandler() => _errors = new();

    public IReadOnlyCollection<ValidationError> GetErrors() => _errors.AsReadOnly();

    public bool HasErrors() => GetErrors().Count > 0;

    public override void HandleError(ValidationError validationError) => _errors.Add(validationError);
}