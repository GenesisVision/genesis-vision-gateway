﻿using GV.Gateway.Common;
using System;

namespace GV.Gateway.Console.Interfaces
{
    public interface IManager
    {
        event Action<Order> NewOrder;
    }
}