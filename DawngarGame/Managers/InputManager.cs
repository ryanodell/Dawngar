using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Dawngar
{
    public class InputManager
    {
        public static InputManager _instance;
        private static KeyboardState _previousKeyState;
        private static KeyboardState _currentKeyState;

        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputManager();
                }
                return _instance;
            }
        }

        public void Update(GameTime gameTime)
        {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
        }

        // public bool IsInputAction(eInputAction action)
        // {
        //     if (action == eInputAction.Right)
        //     {
        //         return IsKeyPressed(Keys.Right);
        //     }
        //     if (action == eInputAction.Left)
        //     {
        //         return IsKeyPressed(Keys.Left);
        //     }
        //     if (action == eInputAction.Up)
        //     {
        //         return IsKeyPressed(Keys.Up);
        //     }
        //     if (action == eInputAction.Down)
        //     {
        //         return IsKeyPressed(Keys.Down);
        //     }
        //     if (action == eInputAction.Select)
        //     {
        //         return IsKeyPressed(Keys.Space);
        //     }
        //     if (action == eInputAction.Combat)
        //     {
        //         return IsKeyPressed(Keys.OemTilde);
        //     }
        //     return false;
        // }
        public bool IsKeyDown(Keys key)
        {
            return _currentKeyState.IsKeyDown(key);
        }

        public bool IsKeyPressed(Keys key)
        {
            return _currentKeyState.IsKeyDown(key) && !_previousKeyState.IsKeyDown(key);
        }
    }
}