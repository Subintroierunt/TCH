using Entities;
using Environment;
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

        private CharacterRoot player;

        public StartState(StateMachine stateMachine, EntityFactory entityFactory, MapNodes mapNodes) 
        {
            this.stateMachine = stateMachine;
            this.entityFactory = entityFactory;
            this.mapNodes = mapNodes;
        }

        public void Enter()
        {
            player = entityFactory.SpawnEntity(Entities.CharacterType.Kobold, 0);
            player.CharacterMove.SetTarget(mapNodes.GetNode(MapNodeType.StartPoint, 0));
            player.CharacterMove.Reached += PlayerCome;
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
