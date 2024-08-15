namespace Url.Infrastructure.Common.Interfaces;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}