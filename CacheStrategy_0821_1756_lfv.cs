// 代码生成时间: 2025-08-21 17:56:26
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace CacheStrategyDemo
{
    public class CacheStrategy<T>
    {
        private Dictionary<string, CacheItem> cache = new Dictionary<string, CacheItem>();

        // Adds or updates an item in the cache.
        public void Set(string key, T value, TimeSpan expiration)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            cache[key] = new CacheItem
            {
                Value = value,
                Expiration = DateTimeOffset.Now.Add(expiration),
                LastAccessed = DateTimeOffset.Now
            };
        }

        // Retrieves an item from the cache.
        public T Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            if (cache.TryGetValue(key, out CacheItem item) && item.IsValid())
            {
                item.LastAccessed = DateTimeOffset.Now;
                return item.Value;
            }
            else
            {
                throw new InvalidOperationException("Item not found in cache or has expired.");
            }
        }

        // Removes an item from the cache.
        public void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            if (cache.ContainsKey(key))
            {
                cache.Remove(key);
            }
        }

        // Clears all items from the cache.
        public void Clear()
        {
            cache.Clear();
        }

        // Checks if an item exists in the cache and is not expired.
        public bool Exists(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            return cache.ContainsKey(key) && cache[key].IsValid();
        }

        // Private class to represent a cached item.
        private class CacheItem
        {
            public T Value { get; set; }
            public DateTimeOffset Expiration { get; set; }
            public DateTimeOffset LastAccessed { get; set; }

            public bool IsValid()
            {
                return DateTimeOffset.Now < Expiration;
            }
        }
    }
}
