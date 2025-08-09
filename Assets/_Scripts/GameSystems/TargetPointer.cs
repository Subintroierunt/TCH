using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class TargetPointer : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;
        private CharacterRoot player;

        public void DebugSetTarget()
        {

        }

        public void SetPlayerTarget(CharacterRoot enemy)
        {
            if (player == null)
            {
                player = entityFactory.Player;
            }

            player.CharacterShoot.SetTarget(enemy);
        }
    }
}
