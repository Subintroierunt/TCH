using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class ProjectileHit : MonoBehaviour
    {
        private CharacterHealth targetHealth;
        private ProjectileRoot root;

        public event Action Hitted;

        public void Init(ProjectileRoot root) =>
            this.root = root;

        public void SetTarget(CharacterHealth targetHealth)
        {
            this.targetHealth = targetHealth;
        }

        public void DealDamage()
        {
            Hitted?.Invoke();
            targetHealth.TakeDamege(root.ProjectileData.Damage); //+ level mod
        }
    }
}
