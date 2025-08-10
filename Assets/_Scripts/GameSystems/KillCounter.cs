using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class KillCounter : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;

        private CharacterRoot playerRoot;
        private int kills;

        public void AddKill()
        {
            if (playerRoot == null)
            {
                playerRoot = entityFactory.Player;
            }

            playerRoot.CharacterData.GiveCurrency(1);
            kills++;
        }
    }
}
