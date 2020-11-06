using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    class Button
    {
        RenderWindow window;

        public RectangleShape rect = new RectangleShape();

        public delegate void OnClick();
        public event OnClick ListOfSubsribes;

        public Button(Vector2f position, Vector2f size, Color fillColor)
        {
            rect.Size = size;
            rect.Origin = new Vector2f(rect.Size.X / 2, rect.Size.Y / 2);
            rect.Position = position;
            rect.FillColor = fillColor;
            this.window = Program.window;
            this.window.MouseButtonPressed += Window_MouseButtonPressed;
        }

        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (IsMouseIn(window.MapPixelToCoords(new Vector2i(e.X, e.Y))) && e.Button == Mouse.Button.Left)
            {
                //Kliknieto w przycisk
                RaiseEventOnClick();
            }
        }

        public bool IsMouseIn(Vector2f mouse_position)
        {
            return rect.GetGlobalBounds().Contains(mouse_position.X, mouse_position.Y);
        }

        void RaiseEventOnClick()
        {
            ListOfSubsribes?.Invoke(); //if  (ListOfSubsribes != null) ListOfSubsribes.Invoke();
        }
    }
}
