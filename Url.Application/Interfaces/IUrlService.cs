using Url.Application.DTOs;

namespace Url.Application.Interfaces;
using Domain.Entities;
public interface IUrlService
{
    Task<IEnumerable<Url?>> ListAllUrls();
    Task<Url> GetUrlById(Guid id);
    Task<string> GetLongUrlByShortUrl(string shortUrl);
    Task DeleteUrl(Guid id);
    Task<Url> CreateShortUrl(CreateShortUrlDto urlDto);
}