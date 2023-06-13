using CultureSpot.Application.Shared;
using CultureSpot.Core.Events.Repositories;

namespace CultureSpot.Application.Commands.Handlers;

internal sealed class UploadEventImageHandler : ICommandHandler<UploadEventImage>
{
    private readonly IEventRepository _eventRepository;

    public UploadEventImageHandler(IEventRepository eventRepository) =>
        (_eventRepository) = (eventRepository);

    public async Task Handle(UploadEventImage request, CancellationToken cancellationToken)
    {
        var projectDirectory = Directory.GetCurrentDirectory();
        var parentDirectory = Directory.GetParent(projectDirectory).FullName;

        var filePath = Path.Combine(parentDirectory, "nginx", "images", request.ImageFile.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.ImageFile.CopyToAsync(stream, cancellationToken);
        }

        await _eventRepository.AddImageAsync(request.EventId, "images/" + request.ImageFile.FileName);
    }
}