namespace Url.Application.Interfaces;
using Url.Application.DTOs;
using Url.Domain.Entities;
public interface IUrlService
{
    Task<IEnumerable<Url?>> ListAllUrls();
    Task<Url> GetUrlById(Guid id);
    Task<string> GetLongUrlByShortUrl(string shortUrl);
    Task DeleteUrl(Guid id);
    Task<Url> CreateShortUrl(CreateShortUrlDto urlDto);
}