﻿using UnityEngine;

namespace Common
{
    public static class GameMath
    {
        public static Vector3 GetDirection(Vector3 begin, Vector3 end)
        {
            return end - begin;
        }
    }
}