using CultureSpot.Application.Shared;
using Microsoft.AspNetCore.Http;

namespace CultureSpot.Application.Commands;

public record UploadEventImage(Guid EventId, IFormFile ImageFile) : CommandBase;
