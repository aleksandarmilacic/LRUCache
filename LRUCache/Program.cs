
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
namespace LRUCache
{
    public class LRUCache
    {
        private readonly int capacity;
        private readonly Dictionary<int, LinkedListNode<CacheItem>> cache;
        private readonly LinkedList<CacheItem> lruList;

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            this.cache = new Dictionary<int, LinkedListNode<CacheItem>>(capacity);
            this.lruList = new LinkedList<CacheItem>();
        }

        public int Get(int key)
        {
            if (cache.TryGetValue(key, out LinkedListNode<CacheItem> node))
            {
                int value = node.Value.Value;
                lruList.Remove(node);
                lruList.AddFirst(node);
                return value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (cache.Count >= capacity)
            {
                RemoveLastUsed();
            }

            CacheItem cacheItem = new CacheItem { Key = key, Value = value };
            LinkedListNode<CacheItem> newNode = new LinkedListNode<CacheItem>(cacheItem);
            lruList.AddFirst(newNode);
            cache.Add(key, newNode);
        }

        private void RemoveLastUsed()
        {
            LinkedListNode<CacheItem> lastNode = lruList.Last;
            cache.Remove(lastNode.Value.Key);
            lruList.RemoveLast();
        }

        private class CacheItem
        {
            public int Key { get; set; }
            public int Value { get; set; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(2);
            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine(cache.Get(1));       // returns 1
            cache.Put(3, 3);                       // evicts key 2
            Console.WriteLine(cache.Get(2));       // returns -1 (not found)
            cache.Put(4, 4);                       // evicts key 1
            Console.WriteLine(cache.Get(1));       // returns -1 (not found)
            Console.WriteLine(cache.Get(3));       // returns 3
            Console.WriteLine(cache.Get(4));       // returns 4
        }
    }

}