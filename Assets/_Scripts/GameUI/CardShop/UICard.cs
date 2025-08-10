using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class UICard : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tileField;
        [SerializeField] private TextMeshProUGUI descriptionField;
        [SerializeField] private TextMeshProUGUI buttonField;
        [SerializeField] private Button button;

        private int cost;
        private CardType cardType;

        public event Action<UICard> ButtonPressed;

        public int Cost =>
            cost;
        public CardType CardType => 
            cardType;

        public void Init(string tile, string description, CardType cardType, int cost)
        {
            tileField.text = tile;
            descriptionField.text = description;
            buttonField.text = "Buy " + cost;
            this.cardType = cardType;
            this.cost = cost;
            button.onClick.AddListener(OnButtonPressed);
        }
    
        private void OnButtonPressed()
        {
            ButtonPressed?.Invoke(this);
        }
    }
}
