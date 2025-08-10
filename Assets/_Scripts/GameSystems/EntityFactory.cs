using Entities;
using Environment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class EntityFactory : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private CharacterRoot player;
        [SerializeField] private CharacterRoot enemy;
        [SerializeField] private MapNodes mapNodes;
        [SerializeField] private KillCounter killCounter;

        private Queue<CharacterRoot> enemyPool = new Queue<CharacterRoot>();
        private List<CharacterRoot> enemyActive = new List<CharacterRoot>();

        private CharacterRoot playerRoot;

        public event Action EnemyKilled;

        public CharacterRoot Player => playerRoot;

        public List<CharacterRoot> GetActiveEnemy() =>
            enemyActive;

        public CharacterRoot SpawnEntity(CharacterType character, int spawnPoint)
        {
            CharacterRoot entity = null;

            switch (character)
            {
                case CharacterType.Kobold:
                    entity = CreateEntity(player);
                    playerRoot = entity;
                    break;
                case CharacterType.Slime:
                    if (enemyPool.Count > 0)
                    {
                        entity = enemyPool.Dequeue();
                        entity.CharacterHealth.Restore();
                    }
                    else
                    {
                        entity = CreateEntity(enemy);
                        entity.CharacterHealth.Killed += OnEnemyKilled;
                        entity.CharacterStrike.SetTarget(playerRoot.CharacterHealth);
                    }

                    enemyActive.Add(entity);
                    break;
            }
            entity.CharacterData.SetPos(spawnPoint);
            entity.CharacterMove.SetNodes(mapNodes);
            entity.transform.position = mapNodes.GetNode(MapNodeType.SpawnPoint, spawnPoint).position;
            entity.gameObject.SetActive(true);

            return entity;
        }

        private CharacterRoot CreateEntity(CharacterRoot prefab)
        {
            CharacterRoot root = Instantiate(prefab, parent);
            return root;
        }

        private void OnEnemyKilled(CharacterRoot entity)
        {
            killCounter.AddKill();
            enemyActive.Remove(entity);
            enemyPool.Enqueue(entity);
            EnemyKilled?.Invoke();
        }
    }
}
