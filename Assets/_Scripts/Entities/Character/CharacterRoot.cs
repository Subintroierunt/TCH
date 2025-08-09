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

        public CharacterType CharacterType =>
            characterType;
        public CharacterShoot CharacterShoot =>
            characterShoot;
        public CharacterHealth CharacterHealth => 
            characterHealth;

        private void Awake()
        {
            characterInput?.Init(this);
        }
    }
}
