using UnityEngine;

namespace Common
{
    public static class GameMath
    {
        public static Vector3 GetDirection(Vector3 begin, Vector3 end)
        {
            //Vector3 heading = begin - end;
            //float distance = heading.magnitude;
            //return heading / distance;
            return end - begin;
        }
    }
}