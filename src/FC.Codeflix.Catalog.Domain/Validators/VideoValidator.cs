using FC.Codeflix.Catalog.Domain.Entity;
using FC.Codeflix.Catalog.Domain.Validation;

namespace FC.Codeflix.Catalog.Domain.Validators;
internal class VideoValidator : Validator
{
    private readonly Video _video;

    private const int MaxTitleLength = 255;
    private const int MaxDescriptionLength = 4_000;

    public VideoValidator(Video video, ValidationHandler handler) : base(handler) 
        => _video = video;

    public override void Validate()
    {
        ValidateTitle();
        ValidateDescription();
    }

    private void ValidateTitle()
    {
        if (string.IsNullOrEmpty(_video.Title))
            _handler.HandleError(new ValidationError("'Title' is required"));
        if(_video.Title.Length > MaxTitleLength)
            _handler.HandleError(new ValidationError($"'Title' should be less than {MaxTitleLength} characters"));
    }

    private void ValidateDescription()
    {
        if (string.IsNullOrEmpty(_video.Description))
            _handler.HandleError(new ValidationError("'Description' is required"));
        if (_video.Description.Length > MaxDescriptionLength)
            _handler.HandleError(new ValidationError($"'Description' should be less than {MaxDescriptionLength} characters"));
    }
}
