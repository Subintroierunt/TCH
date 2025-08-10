using GameUI;
using Root;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class BattleState : IState
    {
        private StateMachine stateMachine;
        private TurnOrder turnOrder;
        private EntityFactory entityFactory;
        private TargetPointer targetPointer;
        private UIRoot uIroot;

        public BattleState(StateMachine stateMachine, TurnOrder turnOrder, EntityFactory entityFactory, TargetPointer targetPointer, UIRoot uIRoot)
        {
            this.stateMachine = stateMachine;
            this.turnOrder = turnOrder;
            this.entityFactory = entityFactory;
            this.targetPointer = targetPointer;
            this.uIroot = uIRoot;
        }

        public void Enter()
        {
            Debug.Log("enter BS");
            targetPointer.CreateTargetQueue(entityFactory.GetActiveEnemy());
            turnOrder.CreateNewOrder();
            turnOrder.OrderEnd += BattleEnd;
        }

        public void Exit()
        {

        }

        private void BattleEnd(bool isPlayerWin)
        {
            turnOrder.OrderEnd -= BattleEnd;
            if (isPlayerWin)
            {
                uIroot.UICardShop.ShowCards();
                stateMachine.Enter<WalkState>();
            }
            else
            {
                Debug.Log("Defeat");
                stateMachine.Enter<DefeatState>();
            }    
        }
    }
}
