﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using System;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Objects
{
    public class ObjectsManager
    {
        private Collection<IStatic> staticObjects;
        private Collection<IDynamic> dynamicObjects;
        private Collection<IObject> nonCollidableObjects;
        public static ObjectsManager Instance { get; } = new ObjectsManager();
        private ObjectsManager() { }
        private GameTime time;
        public void Initialize()
        {
            staticObjects = ObjectLoading.LoadStatics();
            dynamicObjects = ObjectLoading.LoadDynamics();
            nonCollidableObjects = ObjectLoading.LoadNonCollidable();
        }
        public void Update(GameTime gameTime)
        {
            time = gameTime;
            for (int i = (staticObjects.Count - 1); i >= 0; i--)
            {
                staticObjects[i].Update();
                InvalidCheck(staticObjects[i], gameTime);
                if (staticObjects[i].IsInvalid) Remove(staticObjects[i]);
            }
            for (int i = (dynamicObjects.Count - 1); i >= 0; i--)
            {
                dynamicObjects[i].Update(gameTime);
                InvalidCheck(dynamicObjects[i], gameTime);
                if (dynamicObjects[i].IsInvalid) Remove(dynamicObjects[i]);
            }
            for (int i = (nonCollidableObjects.Count - 1); i >= 0; i--)
            {
                if (nonCollidableObjects[i] is IStatic)
                    ((IStatic)nonCollidableObjects[i]).Update();
                else
                    ((IDynamic)nonCollidableObjects[i]).Update(gameTime);
            }

        }
        private void InvalidCheck(IObject obj, GameTime gameTime)
        {
            if (!obj.IsInvalid)
            {
                bool result = false;
                if (obj.Position.Y < 0) result = true;
                if (obj.Position.X < -100) result = true;
                if (obj.Position.X > 1000) result = true;
/*                if (obj.GetType() == typeof(StompedGoomba))
                {
                    StompedGoomba goomba = (StompedGoomba)obj;
                    if (goomba.Delete(gameTime)) result = true;
                }
                if (obj.GetType() == typeof(StompedKoopa))
                {
                    StompedKoopa koopa = (StompedKoopa)obj;
                    if (koopa.Delete(gameTime)) result = true;
                }*/
                obj.IsInvalid |= result;
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (IStatic obj in staticObjects)
                obj.Draw(spriteBatch);
            foreach (IDynamic obj in dynamicObjects)
                obj.Draw(spriteBatch);
            foreach (IObject obj in nonCollidableObjects)
                obj.Draw(spriteBatch);
        }

        public void Remove(IObject gameObject)
        {
            gameObject.Destroy();
            if (gameObject is IStatic)
            {
                staticObjects.Remove((IStatic)gameObject);
            }
            else
            {
                dynamicObjects.Remove((IDynamic)gameObject);
            }
        }
        public void RemoveFromNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Remove(gameObject);
        }
        public void AddNonCollidable(IObject gameObject)
        {
            nonCollidableObjects.Add(gameObject);
        }
        public void Add(IObject gameObject)
        {
            if (gameObject is IStatic)
            {
                staticObjects.Add((IStatic)gameObject);
            }
            else
            {
                dynamicObjects.Add((IDynamic)gameObject);
            }
        }
        /*  The following methods might not be put in the ObjetcsManager class
         *  They will be refactored later
         */
        public void Decoration(IMario oldMario, IMario newMario)
        {
            int index = dynamicObjects.IndexOf(oldMario);
            dynamicObjects[index] = newMario;
        }
        public void StarMario(IMario mario)
        {
            int index = dynamicObjects.IndexOf(mario);
            ((IMario)dynamicObjects[index]).NoMovementTimer = 0;
            dynamicObjects[index] = new StarMario(mario);
            // the usage of indeof is necessary here
            // if mario is flashing and hits a star
            // mario will end flashing state then become star mario
        }

        public IMario MarioObject()
        {
            return (IMario)dynamicObjects[0];
        }
    }
}
