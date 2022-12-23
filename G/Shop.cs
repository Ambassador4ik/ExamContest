using System;
using System.Collections.Generic;
using System.Linq;

internal class Shop
{
    public static Shop GetShop() => new Shop();


    private static readonly Queue<string> Line = new Queue<string>();
    private static readonly HashSet<string> Buyers = new HashSet<string>();
    public string ProcessCommand(string command)
    {
        var parts = command.Split(' ');
        var result = string.Empty;
        switch (parts[0])
        {
            case "come":
                Buyers.Add(parts[1]);
                result = $"{parts[1]} come in shop";
                break;
            case "enqueue":
                if (!Buyers.Contains(parts[1])) {
                    throw new ArgumentException("No such user in shop");
                }
                result = Line.Contains(parts[1]) ? throw new ArgumentException("Such user already in queue") : $"{parts[1]} in queue now";
               
                Line.Enqueue(parts[1]);
                break;
            case "dequeue":
                if (Line.Count == 0) {
                    throw new ArgumentException("Queue is empty");
                }
                result = $"{Line.Dequeue()} leave queue";
                break;
            case "leave":
                if (Line.Contains(parts[1]))
                {
                    throw new ArgumentException("User in queue now");
                }
                result = Buyers.Contains(parts[1]) ? $"{parts[1]} leave shop" : throw new ArgumentException("No such user in shop");
                Buyers.Remove(parts[1]);
                break;
        }

        return result;
    }
}