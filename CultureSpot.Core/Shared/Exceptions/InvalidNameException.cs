﻿namespace CultureSpot.Core.Shared.Exceptions;

public sealed class InvalidNameException : Exception
{
    public string Name { get; }

    public InvalidNameException(string name) : base($"Cannot set: {name} as name.")
        => Name = name;
}