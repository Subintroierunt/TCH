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
        private List<CharacterRoot> enemies;

        public void CreateTargetQueue(List<CharacterRoot> enemies)
        {
            if (player == null)
            {
                player = entityFactory.Player;
            }
            this.enemies = new List<CharacterRoot>();
            this.enemies.AddRange(enemies);

            NextEnemy(0);
        }

        private void NextEnemy(int number)
        {
            player.CharacterShoot.SetTarget(enemies[number]);
            enemies[number].CharacterHealth.Killed += OnTargetKilled;
        }

        private void OnTargetKilled(CharacterRoot enemy)
        {
            enemy.CharacterHealth.Killed -= OnTargetKilled;
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i] == enemy)
                {
                    if (enemies.Count == i + 1)
                    {
                        //next state
                        Debug.Log("all killed");
                        player.CharacterShoot.SetTarget(null);
                    }
                    else
                    {
                        NextEnemy(i + 1);
                    }
                }
            }
        }    
    }
}
