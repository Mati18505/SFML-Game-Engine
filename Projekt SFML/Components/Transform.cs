using MathTrigonometry;
using SFML.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    class Transform
    {
        public Transform()
        {

        }

        //public delegate void OnChangePosition();
        //public event OnChangePosition ListOfSubsribes;

        public Vector2 position;
        /*public Vector2f Position
        {
            get => position; //get { return position; }
            set
            {
                position = value;
                ListOfSubsribes?.Invoke();
            }
        }*/

        public void Translate(float x, float y) => Translate(new Vector2f(x, y));
        
        public void Translate(Vector2f offset)
        {
            Vector2 spriteUpDirection = Matht.NormalAngleToVector(rotation); //Kierunek do góry sprite
            Vector2 spriteRightDirection = Matht.NormalAngleToVector(rotation+90); //Kierunek do prawej sprite
            
            spriteUpDirection.y = -spriteUpDirection.y;//
            spriteRightDirection.y = -spriteRightDirection.y;//Trzeba to robić ze względu na to że y ma odwrotny kierunek w sfml: rośnie ku dołu
            
            spriteUpDirection.Round(5);
            spriteRightDirection.Round(5);
            


            if (offset.Y != 0)
            {
                //Console.WriteLine(-spriteUpDirection * ((Vector2)offset).y);
                position += -spriteUpDirection * ((Vector2)offset).y;
            }
            if (offset.X != 0)
            {
                //Console.WriteLine(spriteRightDirection * ((Vector2)offset).x);
                position += spriteRightDirection * ((Vector2)offset).x;
            }
            //Console.WriteLine(offset);
        }


        public float rotation;
        /*public float Rotation
        {
            get => rotation;
            set
            {
                rotation = value;
                ListOfSubsribes?.Invoke();
            }
        }*/

        public void Rotate(float angle)
        {
            rotation += angle;
            rotation %= 360;
        }


        public Vector2 scale;
        /*public Vector2f Scale
        {
            get => scale;
            set
            {
                scale = value;
                if (scale.X < 0) scale.X = 0;
                if (scale.Y < 0) scale.Y = 0;
                ListOfSubsribes?.Invoke();
            }
        }*/

        public void ChangeScale(Vector2 factors)
        {
            scale += factors;
        }
        public void ChangeScale(float scaleX, float scaleY)
        {
            scale += new Vector2(scaleX, scaleY);
        }

        
        public Vector2f origin;
        /*public Vector2f Origin
        {
            get => origin;
            set
            {
                origin = value;
                ListOfSubsribes?.Invoke();
            }
        }*/



    }
}
