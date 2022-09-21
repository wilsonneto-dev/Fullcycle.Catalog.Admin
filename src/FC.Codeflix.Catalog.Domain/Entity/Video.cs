using FC.Codeflix.Catalog.Domain.Enum;
using FC.Codeflix.Catalog.Domain.SeedWork;
using FC.Codeflix.Catalog.Domain.Validation;
using FC.Codeflix.Catalog.Domain.Validators;
using FC.Codeflix.Catalog.Domain.ValueObject;

namespace FC.Codeflix.Catalog.Domain.Entity;

public class Video : AggregateRoot
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int YearLaunched { get; private set; }
    public int Duration { get; private set; }
    public bool Opened { get; private set; }
    public bool Published { get; private set; }

    public DateTime CreatedAt { get; set; }

    public Rating Rating { get; private set; }

    public Image? Thumb { get; private set; }
    public Image? ThumbHalf { get; private set; }
    public Image? Banner { get; private set; }

    public Media? Trailer { get; private set; }
    public Media? Media { get; private set; }

    private List<Guid> _categories { get; set; }
    public IReadOnlyList<Guid> Categories => _categories;

    private List<Guid> _genres { get; set; }
    public IReadOnlyList<Guid> Genres => _genres;

    private List<Guid> _castMembers { get; set; }
    public IReadOnlyList<Guid> CastMembers => _genres;

    public Video(
        string title,
        string description,
        int yearLaunched,
        bool opened,
        Rating rating,
        int duration,
        bool published)
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Opened = opened;
        Rating = rating;
        Duration = duration;
        Published = published;

        _categories = new List<Guid>();
        _genres = new List<Guid>();
        _castMembers = new List<Guid>();

        CreatedAt = DateTime.Now;
    }

    public void Update(
        string title,
        string description,
        int yearLaunched,
        bool opened,
        Rating rating,
        int duration,
        bool published)
    {
        Title = title;
        Description = description;
        YearLaunched = yearLaunched;
        Opened = opened;
        Rating = rating;
        Duration = duration;
        Published = published;
    }

    public void UpdateThumb(string path) => Thumb = new Image(path);

    public void UpdateThumbHalf(string path) => ThumbHalf = new Image(path);

    public void UpdateBanner(string path) => Banner = new Image(path);

    public void UpdateTrailer(string path) => Trailer = new Media(path);

    public void UpdateMedia(string path) => Media = new Media(path);

    public void UpdateToSentToEncoding() => Media!.UpdateToSentToEncoding();

    public void UpdateToEncoded(string path) => Media!.UpdateToEncoded(path);

    public void AddCategory(Guid categoryId) => _categories.Add(categoryId);

    public void RemoveCategory(Guid categoryId) => _categories.Remove(categoryId);

    public void RemoveAllCategories() => _categories.Clear();

    public void AddGenre(Guid id) => _genres.Add(id);

    public void RemoveGenre(Guid id) => _genres.Remove(id);

    public void RemoveAllGenres() => _genres.Clear();

    public void AddCastMembers(Guid id) => _castMembers.Add(id);

    public void RemoveCastMember(Guid id) => _castMembers.Remove(id);

    public void RemoveAllMembers() => _castMembers.Clear();

    public void Validate(ValidationHandler validationHandler) 
        => (new VideoValidator(this, validationHandler)).Validate();
}
