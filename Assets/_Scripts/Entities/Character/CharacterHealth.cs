using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterHealth : MonoBehaviour
    {
        private CharacterRoot root;

        private float curHealth;
        private bool isDead;

        public bool IsDead =>
            isDead;

        public event Action<CharacterRoot> Killed;

        public void Init(CharacterRoot root)
        {
            this.root = root;
            curHealth = root.CharacterData.Health;
        }

        public void TakeDamege(float damage)
        {
            if (!isDead)
            {
                if (curHealth - damage <= 0)
                {
                    curHealth = 0;
                    Death();
                }
                else
                {
                    curHealth -= damage;
                    //popup
                }    
            }
        }
    
        public void Restore()
        {
            isDead = false;
            curHealth = root.CharacterData.Health;
        }

        private void Death()
        {
            isDead = true;
            Killed?.Invoke(root);
            gameObject.SetActive(false);
        }    
    }
}
