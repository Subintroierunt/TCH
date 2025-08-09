using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectileData : MonoBehaviour
    {
        [SerializeField] private float speed = 3;
        [SerializeField] private float damage = 1;

        public float Speed =>
            speed;
        public float Damage => 
            damage;
    }
}
