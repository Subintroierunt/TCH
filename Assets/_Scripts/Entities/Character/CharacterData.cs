using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private float health = 3;
        [SerializeField] private float damage = 1;

        public float Health =>
            health;
        public float Damage =>
            damage;

    }
}
