using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

internal class InputManager {
    private static KeyboardState keyboardState;
    private static List<Keys> framePresses;
    public static bool IsKeyDown(Keys key) {return keyboardState.IsKeyDown(key);}
    public static bool IsKeyUp(Keys key) {return keyboardState.IsKeyUp(key);}
    public static bool IsKeyPress(Keys key) { if (!framePresses.Contains(key) && keyboardState.IsKeyDown(key)) { framePresses.Add(key); return true; } else { if (keyboardState.IsKeyUp(key) && framePresses.Contains(key)) { framePresses.Remove(key); } return false; }}
    public static void Update() {if (framePresses == null) { framePresses = new(); } keyboardState = Keyboard.GetState(); }
}