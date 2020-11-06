using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Projekt_SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Projekt_SFML
{
    class Camera
    {
        public readonly View view;
        public Color bgColor;
        
        public Camera(Vector2f position, int size, Color backgroundColor)
        {
            view = new View(position, new Vector2f(size, size));
            this.bgColor = backgroundColor;
        }

        public void ChangeSize(float size)
        {
            if (size < 1) size = 1;
            view.Size = new Vector2f(size, size);
        }

        //view.Center = button.rect.Position;//Przemieszczenie "kamery" na pozycję przycisku
       
            
            //view.Zoom(1.001f);
                //view.Rotate(0.005f);
                //view.Move(new Vector2f(1f, 0f)); //Przemieszczenie "kamery"
        
        //view.Size = new Vector2f(3000f, 3000f); //Zmienienie rozmiaru "kamery" 
                                                //view.Viewport = new FloatRect(0f, 0f, 0.5f, 0.5f); //Ustawienie rzutni na lewy górny róg okna i połowę wysokości i szerokości okna(tworzy coś jak duża minimapa)
    }
}
