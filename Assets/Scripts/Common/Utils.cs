using System;
using System.Collections;
using UnityEngine;

namespace Common
{
    public static partial class Utils
    {
        public static IEnumerator MakeActionDelay(float time, Action action)
        {
            yield return new WaitForSeconds(time);
            action.Invoke();
        }

    }
}