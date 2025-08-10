using Entities;
using GameSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class UICardShop : MonoBehaviour
    {

        [SerializeField] private EntityFactory entityFactory;
        [SerializeField] private UICard cardPrefab;
        [SerializeField] private int cardCount;
        [SerializeField] private Transform cardPanel;

        private CharacterRoot playerRoot;
        private List<UICard> cards;

        public event Action UpgradePurchased;
        
        private List<string> tiles = new List<string>() { "Damage", "Health" };
        private List<string> descriptions = new List<string>() { "Damage +1", "Health +1" };
        private List<CardType> cardTypes = new List<CardType>() { CardType.Damage, CardType.Health};
        //Take data from BDs

        private void Start()
        {
            playerRoot = entityFactory.Player;
            cards = new List<UICard>();
            for (int i = 0; i < cardCount; i++)
            {
                cards.Add(Instantiate(cardPrefab, cardPanel));
                cards[i].Init(tiles[i], descriptions[i], cardTypes[i], 1);
                cards[i].ButtonPressed += UpgradeByCard;
            }
        }

        public void ShowCards()
        {
            cardPanel.gameObject.SetActive(true);
        }

        public void HideCards()
        {
            cardPanel.gameObject.SetActive(false);
        }

        private void UpgradeByCard(UICard card)
        {
            if (playerRoot == null)
            {
                playerRoot = entityFactory.Player;
            }
            if (playerRoot.CharacterData.TakeCurrency(card.Cost))
            {
                switch (card.CardType)
                {
                    case CardType.Damage:
                        playerRoot.CharacterShoot.AddDamageMod(1);
                        break;
                    case CardType.Health:
                        playerRoot.CharacterData.HealthUpgrade(1);
                        playerRoot.CharacterHealth.TakeDamege(-1);
                        break;
                }

                UpgradePurchased?.Invoke();
                HideCards();
            }
        }
    }
}
