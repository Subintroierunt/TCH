using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterStrike : MonoBehaviour
    {
        private CharacterRoot root;
        private CharacterHealth targetHealth;

        public event Action Hitted;

        public void Init(CharacterRoot root)
        {
            this.root = root;
        }

        public void SetTarget(CharacterHealth targetHealth) =>
            this.targetHealth = targetHealth;

        public void DealDamage()
        {
            Hitted?.Invoke();
            targetHealth.TakeDamege(root.CharacterData.Damage);
        }
    }
}
