namespace Url.Domain.Entities;
﻿using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;

public class Url : Entity
{
    public Url(
        Guid id,
        string longUrl,
        string shortUrl,
        DateTime expirationTime) : base(id)
    {
        if (!IsValidUrl(longUrl)) 
        {
            throw new ArgumentException("The provided URL is not valid.");
        }
        
        LongUrl = longUrl;
        ShortUrl = shortUrl;
        ExpirationTime = expirationTime;
    }
    
    public string LongUrl { get; private set; }
    
    public string ShortUrl { get; private set; }
    
    public DateTime ExpirationTime { get; private set; }
    
    private bool IsValidUrl(string url)
    {
        var regex = new Regex(@"^https?:\/\/[\w\-\.]+(\.[\w\-]+)+[/#?]?.*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        
        return regex.IsMatch(url);
    }
}