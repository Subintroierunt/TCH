using Entities;
using Environment;
using GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class StartState : IState
    {
        private StateMachine stateMachine;
        private EntityFactory entityFactory;
        private MapNodes mapNodes;
        private UIRoot uIRoot;

        private CharacterRoot player;

        public StartState(StateMachine stateMachine, EntityFactory entityFactory, MapNodes mapNodes, UIRoot uIRoot) 
        {
            this.stateMachine = stateMachine;
            this.entityFactory = entityFactory;
            this.mapNodes = mapNodes;
            this.uIRoot = uIRoot;
        }

        public void Enter()
        {
            player = entityFactory.SpawnEntity(Entities.CharacterType.Kobold, 0);
            player.CharacterMove.SetTarget(mapNodes.GetNode(MapNodeType.StartPoint, 0));
            player.CharacterMove.Reached += PlayerCome;
            uIRoot.Init();
        }

        public void Exit()
        {
            player.CharacterMove.Reached -= PlayerCome;
        }

        private void PlayerCome()
        {
            stateMachine.Enter<WalkState>();
        }
    }
}
