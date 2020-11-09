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
        private Texture reverseTexture;
        private Object parent;

        public Sprite sprite { get; private set; } = new Sprite();
        public bool isReverse { get; private set; }


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
        
        
        
        public void ChangeTexture(string filePath, bool isMakeReverse)
        {
            if (File.Exists(filePath))
            {
                originalTexture = new Texture(filePath);
                sprite.Texture = originalTexture;
                if(isMakeReverse)
                {
                    Image image = originalTexture.CopyToImage();
                    image.FlipHorizontally();
                    reverseTexture = new Texture(image);
                }
            }
            else
                throw new Exception("File doesn't exists!");
        }

        public void ChangeTexture(Texture originalTexture, bool isMakeReverse)
        {
            this.originalTexture = originalTexture;
            sprite.Texture = originalTexture;
            if (isMakeReverse)
            {
                Image image = originalTexture.CopyToImage();
                image.FlipHorizontally();
                reverseTexture = new Texture(image);
            }
        }

        public void ChangeTexture(string filePath, Texture reverseTexture)
        {
            if (File.Exists(filePath))
            {
                originalTexture = new Texture(filePath);
                sprite.Texture = originalTexture;

                if (reverseTexture != null)
                    this.reverseTexture = reverseTexture;
            }
            else
                throw new Exception("File doesn't exists!");
        }
        
        public void ChangeTexture(Texture originalTexture, Texture reverseTexture)
        {
            this.originalTexture = originalTexture;
            sprite.Texture = originalTexture;

            if (reverseTexture != null)
                this.reverseTexture = reverseTexture;
        }





        public void Reverse()
        {
            if (isReverse)
            {
                sprite.Texture = originalTexture;
                isReverse = false;
            }
            else if(reverseTexture != null)
            {
                sprite.Texture = reverseTexture;
                isReverse = true;
            }
        }
    }
}
