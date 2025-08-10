using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterRoot : MonoBehaviour
    {
        [SerializeField] private CharacterType characterType;
        [SerializeField] private CharacterShoot characterShoot;
        [SerializeField] private CharacterInput characterInput;
        [SerializeField] private CharacterHealth characterHealth;
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterData characterData;
        [SerializeField] private CharacterAI characterAI;

        private ICharacterAction characterAction;

        public CharacterType CharacterType =>
            characterType;
        public CharacterShoot CharacterShoot =>
            characterShoot;
        public CharacterHealth CharacterHealth => 
            characterHealth;
        public CharacterMove CharacterMove =>
            characterMove;
        public CharacterData CharacterData => 
            characterData;
        public CharacterAI CharacterAI =>
            characterAI;


        private void Awake()
        {
            characterInput?.Init(this);
            characterMove?.Init(this);
            characterHealth?.Init(this);
            characterAI?.Init(this);
            TryGetComponent<ICharacterAction>(out characterAction);
        }

        public void InvokeCharacterAction() =>
            characterAction?.DoAction();
    }
}
