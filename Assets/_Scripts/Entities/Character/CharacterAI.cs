using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterAI : MonoBehaviour, ICharacterAction
    {
        private CharacterRoot root;

        public void Init(CharacterRoot root)
        {
            this.root = root;
        }

        public void DoAction()
        {
            if (root.CharacterMove.CurReach < 3)
            {
                root.CharacterMove.MoveNextNode();
            }
            else
            {
                //attack
            }
        }
    }
}
