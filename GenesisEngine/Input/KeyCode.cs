using Silk.NET.Input;

namespace GenesisEngine.InputManager
{
    public static class KeyMapper
    {
        public static Key ToLibraryKey(KeyCode key) => key switch
        {
            KeyCode.A => Key.A,
            KeyCode.B => Key.B,
            KeyCode.C => Key.C,
            KeyCode.D => Key.D,
            KeyCode.E => Key.E,
            KeyCode.F => Key.F,
            KeyCode.G => Key.G,
            KeyCode.H => Key.H,
            KeyCode.I => Key.I,
            KeyCode.J => Key.J,
            KeyCode.K => Key.K,
            KeyCode.L => Key.L,
            KeyCode.M => Key.M,
            KeyCode.N => Key.N,
            KeyCode.O => Key.O,
            KeyCode.P => Key.P,
            KeyCode.Q => Key.Q,
            KeyCode.R => Key.R,
            KeyCode.S => Key.S,
            KeyCode.T => Key.T,
            KeyCode.U => Key.U,
            KeyCode.V => Key.V,
            KeyCode.W => Key.W,
            KeyCode.X => Key.X,
            KeyCode.Y => Key.Y,
            KeyCode.Z => Key.Z,
            KeyCode.Unknown => Key.Unknown,
            KeyCode.Space => Key.Space,
            KeyCode.Apostrophe => Key.Apostrophe,
            KeyCode.Comma => Key.Comma,
            KeyCode.Minus => Key.Minus,
            KeyCode.Period => Key.Period,
            KeyCode.Slash => Key.Slash,
            KeyCode.Num0 => Key.Number0,
            KeyCode.Num1 => Key.Number1,
            KeyCode.Num2 => Key.Number2,
            KeyCode.Num3 => Key.Number3,
            KeyCode.Num4 => Key.Number4,
            KeyCode.Num5 => Key.Number5,
            KeyCode.Num6 => Key.Number6,
            KeyCode.Num7 => Key.Number7,
            KeyCode.Num8 => Key.Number8,
            KeyCode.Num9 => Key.Number9,
            KeyCode.Semicolon => Key.Semicolon,
            KeyCode.Equal => Key.Equal,
            KeyCode.LeftBracket => Key.LeftBracket,
            KeyCode.BackSlash => Key.BackSlash,
            KeyCode.RightBracket => Key.RightBracket,
            KeyCode.GraveAccent => Key.GraveAccent,
            KeyCode.World1 => Key.World1,
            KeyCode.World2 => Key.World2,
            KeyCode.Escape => Key.Escape,
            KeyCode.Enter => Key.Enter,
            KeyCode.Tab => Key.Tab,
            KeyCode.Backspace => Key.Backspace,
            KeyCode.Insert => Key.Insert,
            KeyCode.Delete => Key.Delete,
            KeyCode.Right => Key.Right,
            KeyCode.Left => Key.Left,
            KeyCode.Down => Key.Down,
            KeyCode.Up => Key.Up,
            KeyCode.PageUp => Key.PageUp,
            KeyCode.PageDown => Key.PageDown,
            KeyCode.Home => Key.Home,
            KeyCode.End => Key.End,
            KeyCode.CapsLock => Key.CapsLock,
            KeyCode.ScrollLock => Key.ScrollLock,
            KeyCode.NumLock => Key.NumLock,
            KeyCode.PrintScreen => Key.PrintScreen,
            KeyCode.Pause => Key.Pause,
            KeyCode.F1 => Key.F1,
            KeyCode.F2 => Key.F2,
            KeyCode.F3 => Key.F3,
            KeyCode.F4 => Key.F4,
            KeyCode.F5 => Key.F5,
            KeyCode.F6 => Key.F6,
            KeyCode.F7 => Key.F7,
            KeyCode.F8 => Key.F8,
            KeyCode.F9 => Key.F9,
            KeyCode.F10 => Key.F10,
            KeyCode.F11 => Key.F11,
            KeyCode.F12 => Key.F12,
            KeyCode.F13 => Key.F13,
            KeyCode.F14 => Key.F14,
            KeyCode.F15 => Key.F15,
            KeyCode.F16 => Key.F16,
            KeyCode.F17 => Key.F17,
            KeyCode.F18 => Key.F18,
            KeyCode.F19 => Key.F19,
            KeyCode.F20 => Key.F20,
            KeyCode.F21 => Key.F21,
            KeyCode.F22 => Key.F22,
            KeyCode.F23 => Key.F23,
            KeyCode.F24 => Key.F24,
            KeyCode.F25 => Key.F25,
            KeyCode.Keypad0 => Key.Keypad0,
            KeyCode.Keypad1 => Key.Keypad1,
            KeyCode.Keypad2 => Key.Keypad2,
            KeyCode.Keypad3 => Key.Keypad3,
            KeyCode.Keypad4 => Key.Keypad4,
            KeyCode.Keypad5 => Key.Keypad5,
            KeyCode.Keypad6 => Key.Keypad6,
            KeyCode.Keypad7 => Key.Keypad7,
            KeyCode.Keypad8 => Key.Keypad8,
            KeyCode.Keypad9 => Key.Keypad9,
            KeyCode.KeypadDecimal => Key.KeypadDecimal,
            KeyCode.KeypadDivide => Key.KeypadDivide,
            KeyCode.KeypadMultiply => Key.KeypadMultiply,
            KeyCode.KeypadSubtract => Key.KeypadSubtract,
            KeyCode.KeypadAdd => Key.KeypadAdd,
            KeyCode.KeypadEnter => Key.KeypadEnter,
            KeyCode.KeypadEqual => Key.KeypadEqual,
            KeyCode.ShiftLeft => Key.ShiftLeft,
            KeyCode.ControlLeft => Key.ControlLeft,
            KeyCode.AltLeft => Key.AltLeft,
            KeyCode.SuperLeft => Key.SuperLeft,
            KeyCode.ShiftRight => Key.ShiftRight,
            KeyCode.ControlRight => Key.ControlRight,
            KeyCode.AltRight => Key.AltRight,
            KeyCode.SuperRight => Key.SuperRight,
            KeyCode.Menu => Key.Menu,
            _ => Key.Unknown,
        };

        public static KeyCode ToKeyCode(Key key) => key switch
        {
            Key.A => KeyCode.A,
            Key.B => KeyCode.B,
            Key.C => KeyCode.C,
            Key.D => KeyCode.D,
            Key.E => KeyCode.E,
            Key.F => KeyCode.F,
            Key.G => KeyCode.G,
            Key.H => KeyCode.H,
            Key.I => KeyCode.I,
            Key.J => KeyCode.J,
            Key.K => KeyCode.K,
            Key.L => KeyCode.L,
            Key.M => KeyCode.M,
            Key.N => KeyCode.N,
            Key.O => KeyCode.O,
            Key.P => KeyCode.P,
            Key.Q => KeyCode.Q,
            Key.R => KeyCode.R,
            Key.S => KeyCode.S,
            Key.T => KeyCode.T,
            Key.U => KeyCode.U,
            Key.V => KeyCode.V,
            Key.W => KeyCode.W,
            Key.X => KeyCode.X,
            Key.Y => KeyCode.Y,
            Key.Z => KeyCode.Z,
            Key.Number0 => KeyCode.Num0,
            Key.Number1 => KeyCode.Num1,
            Key.Number2 => KeyCode.Num2,
            Key.Number3 => KeyCode.Num3,
            Key.Number4 => KeyCode.Num4,
            Key.Number5 => KeyCode.Num5,
            Key.Number6 => KeyCode.Num6,
            Key.Number7 => KeyCode.Num7,
            Key.Number8 => KeyCode.Num8,
            Key.Number9 => KeyCode.Num9,
            Key.Space => KeyCode.Space,
            Key.Enter => KeyCode.Enter,
            Key.Tab => KeyCode.Tab,
            Key.Backspace => KeyCode.Backspace,
            Key.Delete => KeyCode.Delete,
            Key.Up => KeyCode.Up,
            Key.Down => KeyCode.Down,
            Key.Left => KeyCode.Left,
            Key.Right => KeyCode.Right,
            Key.Escape => KeyCode.Escape,
            Key.CapsLock => KeyCode.CapsLock,
            Key.ScrollLock => KeyCode.ScrollLock,
            Key.NumLock => KeyCode.NumLock,
            Key.PrintScreen => KeyCode.PrintScreen,
            Key.Pause => KeyCode.Pause,
            Key.Keypad0 => KeyCode.Keypad0,
            Key.Keypad1 => KeyCode.Keypad1,
            Key.Keypad2 => KeyCode.Keypad2,
            Key.Keypad3 => KeyCode.Keypad3,
            Key.Keypad4 => KeyCode.Keypad4,
            Key.Keypad5 => KeyCode.Keypad5,
            Key.Keypad6 => KeyCode.Keypad6,
            Key.Keypad7 => KeyCode.Keypad7,
            Key.Keypad8 => KeyCode.Keypad8,
            Key.Keypad9 => KeyCode.Keypad9,
            Key.KeypadDecimal => KeyCode.KeypadDecimal,
            Key.KeypadDivide => KeyCode.KeypadDivide,
            Key.KeypadMultiply => KeyCode.KeypadMultiply,
            Key.KeypadSubtract => KeyCode.KeypadSubtract,
            Key.KeypadAdd => KeyCode.KeypadAdd,
            Key.KeypadEnter => KeyCode.KeypadEnter,
            Key.KeypadEqual => KeyCode.KeypadEqual,
            Key.ShiftLeft => KeyCode.ShiftLeft,
            Key.ControlLeft => KeyCode.ControlLeft,
            Key.AltLeft => KeyCode.AltLeft,
            Key.SuperLeft => KeyCode.SuperLeft,
            Key.ShiftRight => KeyCode.ShiftRight,
            Key.ControlRight => KeyCode.ControlRight,
            Key.AltRight => KeyCode.AltRight,
            Key.SuperRight => KeyCode.SuperRight,
            Key.Menu => KeyCode.Menu,
            _ => KeyCode.Unknown,
        };



    }
    public enum KeyCode
    {
        /// <summary>
        /// An unknown key.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// The spacebar key.
        /// </summary>
        Space = 32,

        /// <summary>
        /// The apostrophe key.
        /// </summary>
        Apostrophe = 39 /* ' */,

        /// <summary>
        /// The comma key.
        /// </summary>
        Comma = 44 /* , */,

        /// <summary>
        /// The minus key.
        /// </summary>
        Minus = 45 /* - */,

        /// <summary>
        /// The period key.
        /// </summary>
        Period = 46 /* . */,

        /// <summary>
        /// The slash key.
        /// </summary>
        Slash = 47 /* / */,

        /// <summary>
        /// The 0 key.
        /// </summary>
        Num0 = 48,

        /// <summary>
        /// The 1 key.
        /// </summary>
        Num1 = 49,

        /// <summary>
        /// The 2 key.
        /// </summary>
        Num2 = 50,

        /// <summary>
        /// The 3 key.
        /// </summary>
        Num3 = 51,

        /// <summary>
        /// The 4 key.
        /// </summary>
        Num4 = 52,

        /// <summary>
        /// The 5 key.
        /// </summary>
        Num5 = 53,

        /// <summary>
        /// The 6 key.
        /// </summary>
        Num6 = 54,

        /// <summary>
        /// The 7 key.
        /// </summary>
        Num7 = 55,

        /// <summary>
        /// The 8 key.
        /// </summary>
        Num8 = 56,

        /// <summary>
        /// The 9 key.
        /// </summary>
        Num9 = 57,

        /// <summary>
        /// The semicolon key.
        /// </summary>
        Semicolon = 59 /* ; */,

        /// <summary>
        /// The equal key.
        /// </summary>
        Equal = 61 /* = */,

        /// <summary>
        /// The A key.
        /// </summary>
        A = 65,

        /// <summary>
        /// The B key.
        /// </summary>
        B = 66,

        /// <summary>
        /// The C key.
        /// </summary>
        C = 67,

        /// <summary>
        /// The D key.
        /// </summary>
        D = 68,

        /// <summary>
        /// The E key.
        /// </summary>
        E = 69,

        /// <summary>
        /// The F key.
        /// </summary>
        F = 70,

        /// <summary>
        /// The G key.
        /// </summary>
        G = 71,

        /// <summary>
        /// The H key.
        /// </summary>
        H = 72,

        /// <summary>
        /// The I key.
        /// </summary>
        I = 73,

        /// <summary>
        /// The J key.
        /// </summary>
        J = 74,

        /// <summary>
        /// The K key.
        /// </summary>
        K = 75,

        /// <summary>
        /// The L key.
        /// </summary>
        L = 76,

        /// <summary>
        /// The M key.
        /// </summary>
        M = 77,

        /// <summary>
        /// The N key.
        /// </summary>
        N = 78,

        /// <summary>
        /// The O key.
        /// </summary>
        O = 79,

        /// <summary>
        /// The P key.
        /// </summary>
        P = 80,

        /// <summary>
        /// The Q key.
        /// </summary>
        Q = 81,

        /// <summary>
        /// The R key.
        /// </summary>
        R = 82,

        /// <summary>
        /// The S key.
        /// </summary>
        S = 83,

        /// <summary>
        /// The T key.
        /// </summary>
        T = 84,

        /// <summary>
        /// The U key.
        /// </summary>
        U = 85,

        /// <summary>
        /// The V key.
        /// </summary>
        V = 86,

        /// <summary>
        /// The W key.
        /// </summary>
        W = 87,

        /// <summary>
        /// The X key.
        /// </summary>
        X = 88,

        /// <summary>
        /// The Y key.
        /// </summary>
        Y = 89,

        /// <summary>
        /// The Z key.
        /// </summary>
        Z = 90,

        /// <summary>
        /// The left bracket(opening bracket) key.
        /// </summary>
        LeftBracket = 91 /* [ */,

        /// <summary>
        /// The backslash.
        /// </summary>
        BackSlash = 92 /* \ */,

        /// <summary>
        /// The right bracket(closing bracket) key.
        /// </summary>
        RightBracket = 93 /* ] */,

        /// <summary>
        /// The grave accent key.
        /// </summary>
        GraveAccent = 96 /* ` */,

        /// <summary>
        /// Non US keyboard layout key 1.
        /// </summary>
        World1 = 161 /* non-US #1 */,

        /// <summary>
        /// Non US keyboard layout key 2.
        /// </summary>
        World2 = 162 /* non-US #2 */,

        /// <summary>
        /// The escape key.
        /// </summary>
        Escape = 256,

        /// <summary>
        /// The enter key.
        /// </summary>
        Enter = 257,

        /// <summary>
        /// The tab key.
        /// </summary>
        Tab = 258,

        /// <summary>
        /// The backspace key.
        /// </summary>
        Backspace = 259,

        /// <summary>
        /// The insert key.
        /// </summary>
        Insert = 260,

        /// <summary>
        /// The delete key.
        /// </summary>
        Delete = 261,

        /// <summary>
        /// The right arrow key.
        /// </summary>
        Right = 262,

        /// <summary>
        /// The left arrow key.
        /// </summary>
        Left = 263,

        /// <summary>
        /// The down arrow key.
        /// </summary>
        Down = 264,

        /// <summary>
        /// The up arrow key.
        /// </summary>
        Up = 265,

        /// <summary>
        /// The page up key.
        /// </summary>
        PageUp = 266,

        /// <summary>
        /// The page down key.
        /// </summary>
        PageDown = 267,

        /// <summary>
        /// The home key.
        /// </summary>
        Home = 268,

        /// <summary>
        /// The end key.
        /// </summary>
        End = 269,

        /// <summary>
        /// The caps lock key.
        /// </summary>
        CapsLock = 280,

        /// <summary>
        /// The scroll lock key.
        /// </summary>
        ScrollLock = 281,

        /// <summary>
        /// The num lock key.
        /// </summary>
        NumLock = 282,

        /// <summary>
        /// The print screen key.
        /// </summary>
        PrintScreen = 283,

        /// <summary>
        /// The pause key.
        /// </summary>
        Pause = 284,

        /// <summary>
        /// The F1 key.
        /// </summary>
        F1 = 290,

        /// <summary>
        /// The F2 key.
        /// </summary>
        F2 = 291,

        /// <summary>
        /// The F3 key.
        /// </summary>
        F3 = 292,

        /// <summary>
        /// The F4 key.
        /// </summary>
        F4 = 293,

        /// <summary>
        /// The F5 key.
        /// </summary>
        F5 = 294,

        /// <summary>
        /// The F6 key.
        /// </summary>
        F6 = 295,

        /// <summary>
        /// The F7 key.
        /// </summary>
        F7 = 296,

        /// <summary>
        /// The F8 key.
        /// </summary>
        F8 = 297,

        /// <summary>
        /// The F9 key.
        /// </summary>
        F9 = 298,

        /// <summary>
        /// The F10 key.
        /// </summary>
        F10 = 299,

        /// <summary>
        /// The F11 key.
        /// </summary>
        F11 = 300,

        /// <summary>
        /// The F12 key.
        /// </summary>
        F12 = 301,

        /// <summary>
        /// The F13 key.
        /// </summary>
        F13 = 302,

        /// <summary>
        /// The F14 key.
        /// </summary>
        F14 = 303,

        /// <summary>
        /// The F15 key.
        /// </summary>
        F15 = 304,

        /// <summary>
        /// The F16 key.
        /// </summary>
        F16 = 305,

        /// <summary>
        /// The F17 key.
        /// </summary>
        F17 = 306,

        /// <summary>
        /// The F18 key.
        /// </summary>
        F18 = 307,

        /// <summary>
        /// The F19 key.
        /// </summary>
        F19 = 308,

        /// <summary>
        /// The F20 key.
        /// </summary>
        F20 = 309,

        /// <summary>
        /// The F21 key.
        /// </summary>
        F21 = 310,

        /// <summary>
        /// The F22 key.
        /// </summary>
        F22 = 311,

        /// <summary>
        /// The F23 key.
        /// </summary>
        F23 = 312,

        /// <summary>
        /// The F24 key.
        /// </summary>
        F24 = 313,

        /// <summary>
        /// The F25 key.
        /// </summary>
        F25 = 314,

        /// <summary>
        /// The 0 key on the key pad.
        /// </summary>
        Keypad0 = 320,

        /// <summary>
        /// The 1 key on the key pad.
        /// </summary>
        Keypad1 = 321,

        /// <summary>
        /// The 2 key on the key pad.
        /// </summary>
        Keypad2 = 322,

        /// <summary>
        /// The 3 key on the key pad.
        /// </summary>
        Keypad3 = 323,

        /// <summary>
        /// The 4 key on the key pad.
        /// </summary>
        Keypad4 = 324,

        /// <summary>
        /// The 5 key on the key pad.
        /// </summary>
        Keypad5 = 325,

        /// <summary>
        /// The 6 key on the key pad.
        /// </summary>
        Keypad6 = 326,

        /// <summary>
        /// The 7 key on the key pad.
        /// </summary>
        Keypad7 = 327,

        /// <summary>
        /// The 8 key on the key pad.
        /// </summary>
        Keypad8 = 328,

        /// <summary>
        /// The 9 key on the key pad.
        /// </summary>
        Keypad9 = 329,

        /// <summary>
        /// The decimal key on the key pad.
        /// </summary>
        KeypadDecimal = 330,

        /// <summary>
        /// The divide key on the key pad.
        /// </summary>
        KeypadDivide = 331,

        /// <summary>
        /// The multiply key on the key pad.
        /// </summary>
        KeypadMultiply = 332,

        /// <summary>
        /// The subtract key on the key pad.
        /// </summary>
        KeypadSubtract = 333,

        /// <summary>
        /// The add key on the key pad.
        /// </summary>
        KeypadAdd = 334,

        /// <summary>
        /// The enter key on the key pad.
        /// </summary>
        KeypadEnter = 335,

        /// <summary>
        /// The equal key on the key pad.
        /// </summary>
        KeypadEqual = 336,

        /// <summary>
        /// The left shift key.
        /// </summary>
        ShiftLeft = 340,

        /// <summary>
        /// The left control key.
        /// </summary>
        ControlLeft = 341,

        /// <summary>
        /// The left alt key.
        /// </summary>
        AltLeft = 342,

        /// <summary>
        /// The left super key.
        /// </summary>
        SuperLeft = 343,

        /// <summary>
        /// The right shift key.
        /// </summary>
        ShiftRight = 344,

        /// <summary>
        /// The right control key.
        /// </summary>
        ControlRight = 345,

        /// <summary>
        /// The right alt key.
        /// </summary>
        AltRight = 346,

        /// <summary>
        /// The right super key.
        /// </summary>
        SuperRight = 347,

        /// <summary>
        /// The menu key.
        /// </summary>
        Menu = 348
    }
}
