using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private UICardShop uICardShop;
        [SerializeField] private UIStats uIStats;
        [SerializeField] private UIRestart uIRestart;

        public UICardShop UICardShop =>
            uICardShop;
        public UIStats UIStats => 
            uIStats;
        public UIRestart UIRestart =>
            uIRestart;

        public void Init()
        {
            uIStats.Init(this);
        }
    }
}
