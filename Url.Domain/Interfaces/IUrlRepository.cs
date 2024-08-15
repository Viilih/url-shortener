namespace Url.Domain.Interfaces;
using Url.Domain.Entities;

public interface IUrlRepository
{
    Task<UrlEntity> CreateShortUrl(UrlEntity url);
    Task<IEnumerable<UrlEntity>> ListAllUrls();
    Task<UrlEntity> GetUrlByShortUrl(string urlPath);
    Task<bool> UrlAlreadyExist(string urlPath);
    Task<UrlEntity?> GetUrlById(Guid id);
    Task DeleteUrlById(Guid id);
}