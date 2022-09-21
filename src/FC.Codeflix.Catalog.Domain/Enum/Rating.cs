namespace FC.Codeflix.Catalog.Domain.Enum;

public enum Rating
{
    ER,
    L,
    Rate10,
    Rate12,
    Rate14,
    Rate16,
    Rate18
}

static class RatingExtensions
{
    public static string ToRatingSymbolString(this Rating enumValue) => enumValue switch
    {
        Rating.ER => nameof(Rating.ER),
        Rating.L => nameof(Rating.L),
        Rating.Rate10 => "10",
        Rating.Rate12 => "12",
        Rating.Rate14 => "14",
        Rating.Rate16 => "16",
        Rating.Rate18 => "18",
        _ => throw new ArgumentOutOfRangeException($"{nameof(enumValue)} not mapped on toString method.")
    };

    public static Rating ToRatingEnum(this string enumValueString) => enumValueString switch
    {
        "ER" => Rating.ER,
        "L" => Rating.L,
        "10" => Rating.Rate10,
        "12" => Rating.Rate12,
        "14" => Rating.Rate14,
        "16" => Rating.Rate16,
        "18" => Rating.Rate18,
        _ => throw new ArgumentException($"{enumValueString} is not a valid Rating")
    };
}
