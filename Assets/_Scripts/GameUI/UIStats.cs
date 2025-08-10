using Entities;
using GameSystems;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class UIStats : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;

        [SerializeField] private TextMeshProUGUI currency;
        [SerializeField] private TextMeshProUGUI health;
        [SerializeField] private TextMeshProUGUI damage;
        [SerializeField] private Slider healthBar;

        private CharacterRoot playerRoot;
        private UIRoot uIRoot;

        public void Init(UIRoot uIRoot)
        {
            this.uIRoot = uIRoot;
            uIRoot.UICardShop.UpgradePurchased += UpdateDamage;
            playerRoot = entityFactory.Player;
            playerRoot.CharacterHealth.HealthChanged += UpdateHealth;
            entityFactory.EnemyKilled += UpdateCurrency;
        }

        private void UpdateHealth(float damage, float curHealth)
        {
            healthBar.maxValue = playerRoot.CharacterData.Health;
            healthBar.value = curHealth;
            health.text = Mathf.RoundToInt(curHealth).ToString();
        }

        public void UpdateDamage()
        {
            damage.text = playerRoot.CharacterShoot.GetCurDamage().ToString();
        }

        public void UpdateCurrency()
        {
            currency.text = playerRoot.CharacterData.Currency.ToString();
        }
    }
}
