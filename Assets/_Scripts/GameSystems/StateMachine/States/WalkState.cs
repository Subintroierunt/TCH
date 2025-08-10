using Entities;
using Environment;
using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class WalkState : IState
    {
        private StateMachine stateMachine;
        private EntityFactory entityFactory;
        private MotionEffect backgroundScroll;
        private MapNodes mapNodes;

        private List<CharacterRoot> enemy = new List<CharacterRoot>();

        public WalkState(StateMachine stateMachine, EntityFactory entityFactory, MotionEffect backgroundScroll, MapNodes mapNodes) 
        {
            this.stateMachine = stateMachine;
            this.entityFactory = entityFactory;
            this.backgroundScroll = backgroundScroll;
            this.mapNodes = mapNodes;
        }

        public void Enter()
        {
            Debug.Log("enter WS");
            backgroundScroll.PlayScroll();

            for (int i = 1; i <= Random.Range(1, 4); i++)
            {
                enemy.Add(entityFactory.SpawnEntity(Entities.CharacterType.Slime, i));
                enemy[i - 1].CharacterMove.SetTarget(mapNodes.GetNode(MapNodeType.StartPoint, i));
            }
            
            enemy[0].CharacterMove.Reached += EnemyCome;
        }

        public void Exit()
        {
            enemy[0].CharacterMove.Reached -= EnemyCome;
            enemy.Clear();
            backgroundScroll.StopScroll();
        }

        private void EnemyCome()
        {
            stateMachine.Enter<BattleState>();
        }
    }
}
