using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
    class SpriteRenderer
    {
        private Texture originalTexture;
        private Texture rotatedTexture;
        private Object parent;

        public Sprite sprite { get; private set; } = new Sprite();
        public bool isRotated { get; private set; }


        public SpriteRenderer(Object parent)
        {
            this.parent = parent;
        }
        
        public void Update()
        {
            sprite.Position = parent.transform.position;
            sprite.Scale = parent.transform.scale;
            sprite.Rotation = parent.transform.rotation;
            sprite.Origin = parent.transform.origin;
        }
        
        
        
        public void ChangeTexture(string filePath, bool isMakeRotate)
        {
            if (File.Exists(filePath))
            {
                originalTexture = new Texture(filePath);
                sprite.Texture = originalTexture;
                if(isMakeRotate)
                {
                    Image image = originalTexture.CopyToImage();
                    image.FlipHorizontally();
                    rotatedTexture = new Texture(image);
                }
            }
            else
                throw new Exception("File doesn't exists!");
        }

        public void ChangeTexture(Texture originalTexture, bool isMakeRotate)
        {
            this.originalTexture = originalTexture;
            sprite.Texture = originalTexture;
            if (isMakeRotate)
            {
                Image image = originalTexture.CopyToImage();
                image.FlipHorizontally();
                rotatedTexture = new Texture(image);
            }
        }

        public void ChangeTexture(string filePath, Texture rotatedTexture)
        {
            if (File.Exists(filePath))
            {
                originalTexture = new Texture(filePath);
                sprite.Texture = originalTexture;

                if (rotatedTexture != null)
                    this.rotatedTexture = rotatedTexture;
            }
            else
                throw new Exception("File doesn't exists!");
        }
        
        public void ChangeTexture(Texture originalTexture, Texture rotatedTexture)
        {
            this.originalTexture = originalTexture;
            sprite.Texture = originalTexture;

            if (rotatedTexture != null)
                this.rotatedTexture = rotatedTexture;
        }





        public void Rotate()
        {
            if (isRotated)
            {
                sprite.Texture = originalTexture;
                isRotated = false;
            }
            else if(rotatedTexture != null)
            {
                sprite.Texture = rotatedTexture;
                isRotated = true;
            }
        }

        public void Rotate(bool reverse)
        {
            if (reverse == false)
            {
                sprite.Texture = originalTexture;
                isRotated = false;
            }
            else if (rotatedTexture != null)
            {
                sprite.Texture = rotatedTexture;
                isRotated = true;
            }   
        }
    }
}
