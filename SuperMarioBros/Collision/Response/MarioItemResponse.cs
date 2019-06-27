﻿using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioItemResponse : GeneralResponse
    {
        private IMario mario;
        private IItem item;
        private delegate void MarioItemHandler(IMario mario, IItem item);

        public MarioItemResponse(IObject mario, IObject item , Direction direction)
        {
            this.mario = (IMario)mario;
            this.item = (IItem)item;
        }
        public override void HandleCollision()
        {            
             handlerDictionary.TryGetValue(item.GetType(), out var handler);
             handler?.Invoke(mario, item);              
        }
        private readonly Dictionary<Type, MarioItemHandler> handlerDictionary = new Dictionary<Type, MarioItemHandler>
        {
            {typeof(Star), TakeStar},
            {typeof(RedMushroom),TakeRedMushroom},
            {typeof(Flower), TakeFlower},
            {typeof(GreenMushroom), TakeGreenMushroom},
            {typeof(Coin), TakeCoin},
        };
        private static void TakeStar(IMario mario, IItem item)
        {
            mario.TakeStar();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeRedMushroom(IMario mario, IItem item) 
        {
            mario.TakeRedMushroom();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeFlower(IMario mario, IItem item)
        {
            mario.TakeFlower();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeGreenMushroom(IMario mario, IItem item)
        {
            //Do Nothing for Mario Right now
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeCoin(IMario mario, IItem item)
        {
            //Do Nothing for Mario Right now
            item.ObjState = ObjectState.Destroy;
        }
    }
}