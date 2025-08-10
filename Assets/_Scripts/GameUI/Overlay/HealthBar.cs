using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private CharacterRoot characterRoot;
        [SerializeField] private Slider healthBar;

        private void Start()
        {
            UpdateMaxHealth();
            healthBar.value = characterRoot.CharacterData.Health;

            characterRoot.CharacterHealth.HealthChanged += UpdateBar;
        }

        public void UpdateMaxHealth()
        {
            healthBar.maxValue = characterRoot.CharacterData.Health;
        }

        private void UpdateBar(float damage, float curHealth)
        {
            UpdateMaxHealth();
            healthBar.value = curHealth;
        }

        private void OnDestroy()
        {
            characterRoot.CharacterHealth.HealthChanged -= UpdateBar;
        }
    }
}
