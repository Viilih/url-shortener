namespace Url.Domain.Interfaces;
using Url.Domain.Entities;

public interface IUrlRepository
{
    Task<Url> CreateShortUrl(Url url);
    Task<IEnumerable<Url>> ListAllUrls();
    Task<Url> GetUrlByShortUrl(string urlPath);
    Task<bool> UrlAlreadyExist(string urlPath);
    Task<Url?> GetUrlById(Guid id);
    Task DeleteUrlById(Guid id);
}