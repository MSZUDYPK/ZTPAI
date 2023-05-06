﻿namespace CultureSpot.Application.Exceptions;

public class UserNotFoundException : Exception
{
    public Guid UserId { get; private set; }

    public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
    {
        UserId = userId;
    }
}