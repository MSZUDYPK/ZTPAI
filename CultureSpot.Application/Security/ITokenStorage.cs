﻿using CultureSpot.Application.DTO;

namespace CultureSpot.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);
    JwtDto Get();
}