﻿using System;

namespace Solution
{
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message)
        {
        }
    }
}
