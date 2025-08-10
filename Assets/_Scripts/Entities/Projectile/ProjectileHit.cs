using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectileHit : MonoBehaviour
    {
        private CharacterHealth targetHealth;

        private float damage = 1;

        public event Action Hitted;

        public void SetDamage(float value) =>
            damage = value;

        public void SetTarget(CharacterHealth targetHealth)
        {
            this.targetHealth = targetHealth;
        }

        public void DealDamage()
        {
            Hitted?.Invoke();
            targetHealth.TakeDamege(damage); //+ level mod
        }
    }
}
