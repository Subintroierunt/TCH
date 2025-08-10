using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class DefeatState : IState
    {
        private StateMachine stateMachine;
        private UIRoot uIRoot;

        public DefeatState(StateMachine stateMachine, UIRoot uIRoot) 
        {
            this.stateMachine = stateMachine;
            this.uIRoot = uIRoot;
        }

        public void Enter()
        {
            uIRoot.UICardShop.HideCards();
            uIRoot.UIRestart.ShowButton();
        }

        public void Exit()
        {

        }
    }
}
