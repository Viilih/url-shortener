using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Url.Domain.Entities;
using Url.Domain.Errors;
using Url.Domain.Interfaces;
using Url.Infrastructure.Common.Interfaces;

namespace Url.Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly DbSet<UrlEntity> _urls;
        private readonly IUnitOfWork _unitOfWork;

        public UrlRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _urls = context.Urls;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UrlEntity>> ListAllUrls()
        {
            return await _urls.ToListAsync();
        }

        public async Task<UrlEntity> CreateShortUrl(UrlEntity url)
        {
            var createdUrl = await _urls.AddAsync(url);

            await _unitOfWork.SaveChangesAsync();
            return createdUrl.Entity;
        }

        public async Task DeleteUrlById(Guid entityId)
        {
            UrlEntity? urlEntitiy = await _urls.FirstOrDefaultAsync(u => u.Id == entityId);

            if (urlEntitiy is null)
            {
                throw new ResourceNotFoundException($"Unable to DELETE URL with ID '{entityId}'.");
            }

            _urls.Remove(urlEntitiy);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<UrlEntity?> GetUrlById(Guid id)
        {
            return await _urls.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UrlEntity> GetUrlByShortUrl(string shortenedUrl)
        {

            UrlEntity? urlEntity = await _urls.FirstOrDefaultAsync(u => u.ShortUrl == shortenedUrl);

            if (urlEntity is null)
            {
                throw new ResourceNotFoundException($"Unable to GET URL with Uri '{shortenedUrl}'.");
            }

            return urlEntity;
        }

        public async Task<bool> UrlAlreadyExist(string shortenedUrl)
        {
            return await _urls.AnyAsync(u => u.ShortUrl.Equals(shortenedUrl));
        }
    }
}
