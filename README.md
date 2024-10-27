## Introduction
A really simple and easy to use input manager. Helps with performance so you don't have to call Keyboard.GetState so many times, and also is static so you don't need to make instantiate it. Drag it into your project and here is how to use it.

## How To Use
There is `IsKeyPress` to get if the key was pressed that frame. This is good for jumping and stuff. There is also `IsKeyUp`, and `IsKeyDown`, for constant values. You can also just access keyboardState and mouseState for position and other things.
All you have to do is call InputManager.Update() in the Update loop **before** everything else. There is some example code below. I would also look at the source for more information on all of the possible functions.
```csharp

 if (InputManager.IsKeyPress(Keys.A))
        {
            Console.WriteLine("A was pressed.");
        }
        if (InputManager.IsLeftPress())
        {
            Console.WriteLine("Left was pressed.");
        }
         if (InputManager.IsRightPress())
        {
            Console.WriteLine("Right was pressed.");
        }
         if (InputManager.IsMiddlePress())
        {
            Console.WriteLine("Middle was pressed.");
        }
        if (InputManager.mouseState.LeftButton == ButtonState.Pressed)
        {
            Console.WriteLine("Left is pressed");
        }

```

## Source
```csharp
using System.Collections.Generic;
using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

internal class InputManager {
    public static KeyboardState keyboardState {get; private set;}
    public static MouseState mouseState {get; private set;}
    private static List<Keys> framePressesKeyboard;
    private static List<int> framePressesMouse;
    public static bool IsKeyDown(Keys key) {return keyboardState.IsKeyDown(key);}
    public static bool IsKeyUp(Keys key) {return keyboardState.IsKeyUp(key);}
    public static bool IsKeyPress(Keys key) { if (!framePressesKeyboard.Contains(key) && keyboardState.IsKeyDown(key)) { framePressesKeyboard.Add(key); return true; } else { if (keyboardState.IsKeyUp(key) && framePressesKeyboard.Contains(key)) { framePressesKeyboard.Remove(key); } return false; }}
    public static bool IsLeftPress() {int key = 1; if (!framePressesMouse.Contains(key) && mouseState.LeftButton == ButtonState.Pressed) { framePressesMouse.Add(key); return true; } else { if (mouseState.LeftButton == ButtonState.Released && framePressesMouse.Contains(key)) { framePressesMouse.Remove(key); } return false; }}
    public static bool IsRightPress() {int key = 2; if (!framePressesMouse.Contains(key) && mouseState.RightButton == ButtonState.Pressed) { framePressesMouse.Add(key); return true; } else { if (mouseState.RightButton == ButtonState.Released && framePressesMouse.Contains(key)) { framePressesMouse.Remove(key); } return false; }}
    public static bool IsMiddlePress() {int key = 3; if (!framePressesMouse.Contains(key) && mouseState.MiddleButton == ButtonState.Pressed) { framePressesMouse.Add(key); return true; } else { if (mouseState.MiddleButton == ButtonState.Released && framePressesMouse.Contains(key)) { framePressesMouse.Remove(key); } return false; }}
    public static void Update() {if (framePressesKeyboard == null) { framePressesKeyboard = new(); }if (framePressesMouse == null) { framePressesMouse = new(); }   mouseState = Mouse.GetState(); keyboardState = Keyboard.GetState(); }
    public static Vector2 GetMousePosition() { return mouseState.Position.ToVector2(); }
    public static int GetMouseX() { return mouseState.Position.X; }
    public static int GetMouseY() { return mouseState.Position.Y; }
    public static int GetScrollWheel() { return mouseState.ScrollWheelValue; }
}
```
