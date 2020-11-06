using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    static class Input
    {
        //Tablica, słowink
        private static Dictionary<Keyboard.Key, bool> isKeysPressedInLastFrame = new Dictionary<Keyboard.Key, bool>();
        private static Dictionary<Keyboard.Key, bool> isKeysNoPressedInLastFrame = new Dictionary<Keyboard.Key, bool>();


        public static void Update()
        {

            foreach (var item in isKeysPressedInLastFrame.ToArray())
            {
                if (!Keyboard.IsKeyPressed(item.Key))
                {
                    isKeysPressedInLastFrame[item.Key] = false;
                }
            }
            
            foreach (var item in isKeysNoPressedInLastFrame.ToArray())
            {
                if (Keyboard.IsKeyPressed(item.Key))
                {
                    isKeysNoPressedInLastFrame[item.Key] = false;
                }
            } 
            
        }
        
        public static bool IsKeyDown(Keyboard.Key key)
        {
            if (!isKeysPressedInLastFrame.ContainsKey(key))
                isKeysPressedInLastFrame.Add(key, Keyboard.IsKeyPressed(key));

            if (isKeysPressedInLastFrame[key] == false && Keyboard.IsKeyPressed(key))
            {
                isKeysPressedInLastFrame[key] = true;
                return true;
            }
            else return false;
        }

        public static bool IsKeyUp(Keyboard.Key key)
        {
            if (!isKeysNoPressedInLastFrame.ContainsKey(key))
                isKeysNoPressedInLastFrame.Add(key, !Keyboard.IsKeyPressed(key));
                
            if (isKeysNoPressedInLastFrame[key] == false && !Keyboard.IsKeyPressed(key))
            {
                isKeysNoPressedInLastFrame[key] = true;
                return true;
            }
            else return false;
        }

        public static Vector2f GetMouseWorldPosition()
        {
            return Program.window.MapPixelToCoords(Mouse.GetPosition(Program.window));
        }
    }
}
