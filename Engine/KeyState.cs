using Microsoft.Xna.Framework.Input;
using System;

namespace Engine
{
    class KeyState
    {
        bool[] pressed = new bool[255];
        int[] state = new int[255];
        public KeyState()
        {
            for (int i = 0; i < pressed.Length; i++)
            {
                pressed[i] = false;
            }
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = -1;
            }
        }
        public bool IsKeyReleased(Microsoft.Xna.Framework.Input.Keys key)
        {
            if (pressed[Convert.ToInt32(key)])
            {
                if (Keyboard.GetState().IsKeyUp(key))
                {
                    pressed[Convert.ToInt32(key)] = false;
                    return true;
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(key))
                {
                    pressed[Convert.ToInt32(key)] = true;
                }
            }
            return false;
        }
        public bool IsKeyPressed(Microsoft.Xna.Framework.Input.Keys key, int delay)
        {
            if (Keyboard.GetState().IsKeyDown(key))
            {
                if (state[Convert.ToInt32(key)] == -1 || state[Convert.ToInt32(key)] >= delay)
                {
                    state[Convert.ToInt32(key)] = 0;
                    return true;
                }
                else
                {
                    state[Convert.ToInt32(key)] += 100;
                    return false;
                }
            }
            else
            {
                state[Convert.ToInt32(key)] = -1;
                return false;
            }
        }

    }
}
