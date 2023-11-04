using System;

namespace csharp;

public sealed class Rule
{
    public Rule(Predicate<Item> predicate, Action<Item> rule, int priority = 1)
    {
        Predicate = predicate;
        Action = rule;
        Priority = priority;
    }

    public Predicate<Item> Predicate { get; }
    public Action<Item> Action { get; }
    public int Priority { get; }
}