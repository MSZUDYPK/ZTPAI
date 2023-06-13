using CultureSpot.Core.Shared.ValueObjects;

namespace CultureSpot.Core.Shared.Exceptions;

internal class InvalidImageUrlException : CustomException
{
    public string ImageUrl { get; set; }

    public InvalidImageUrlException(string imageUrl) : base($"Cannot set: {imageUrl} as imageUrl.")
        => ImageUrl = imageUrl;
}