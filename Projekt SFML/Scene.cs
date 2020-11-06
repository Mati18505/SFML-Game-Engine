using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projekt_SFML
{
    class Scene : IUpdateable
    {
        public bool isActive;
        public Camera currentCamera;
        List<Object> objects = new List<Object>();
        Dictionary<string, int> objectsDictionary = new Dictionary<string, int>();

        public void Start()
        {
            foreach (Object obj in objects)
                obj.Start();
        }

        public void Update()
        {
            foreach (Object obj in objects)
                obj.Update();
        }

        public void AddObject(Object obj, string objectName)
        {
            if (objectName == null || objectName == "")
                throw new Exception("objectName can not be null!");
            objects.Add(obj);
            objectsDictionary.Add(objectName, objects.Count - 1);
        }

        public void Draw()
        {
            foreach (Object obj in objects)
                if (obj.spriteRenderer != null)
                    Program.window.Draw(obj.spriteRenderer.sprite);
        }

        public void WriteObjects()
        {
            foreach (var item in objectsDictionary)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}


