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
        [SerializeField] private Transform healthBar;

        private float maxHealth;

        private void Start()
        {
            maxHealth = characterRoot.CharacterData.Health;

            characterRoot.CharacterHealth.HealthChanged += UpdateBar;
        }

        private void UpdateBar(float damage, float curHealth)
        {
            Vector3 newScale = Vector3.one;
            newScale.x = curHealth / maxHealth;

            healthBar.transform.localScale =  newScale;
        }

        private void OnDestroy()
        {
            characterRoot.CharacterHealth.HealthChanged -= UpdateBar;
        }
    }
}
