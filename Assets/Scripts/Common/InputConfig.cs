using UnityEngine;

namespace Gameplay.Player.Common
{
    public static class InputConfig
    {
        public static KeyCode AttackKey => KeyCode.Mouse0;
        public static KeyCode ReloadKey => KeyCode.R;
        public static KeyCode UseKey => KeyCode.E;
        public static KeyCode PauseKey => KeyCode.Escape;
    }
}