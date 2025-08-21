using Silk.NET.Input;

namespace GenesisEngine.InputManager
{
    public static class Input
    {
        private static HashSet<KeyCode> keysDown = new HashSet<KeyCode>();
        private static HashSet<KeyCode> keysPressed = new HashSet<KeyCode>();


        public static void OnKeyDown(IKeyboard keyboard, Key key, int code)
        {
            KeyCode keyCode = KeyMapper.ToKeyCode(key);
            if (!keysPressed.Contains(keyCode))
            {
                keysPressed.Add(keyCode);
            }

            keysDown.Add(keyCode);
        }

        public static void OnKeyUp(IKeyboard keyboard, Key key, int code)
        {
            KeyCode keyCode = KeyMapper.ToKeyCode(key);
            keysDown.Remove(keyCode);
            keysPressed.Remove(keyCode);
        }

        public static bool GetKeyPressed(KeyCode key)
        {
            return keysPressed.Contains(key);
        }
        public static bool GetKeyDown(KeyCode key)
        {
            if (keysDown.Contains(key))
            {
                keysDown.Remove(key);
                return true;
            }
            return false;
        }
    }

}
