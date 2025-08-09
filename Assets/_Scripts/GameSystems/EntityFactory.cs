using Entities;
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
        [Tooltip("0 - player; 1,2,3 - enemies")]
        [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

        private Queue<CharacterRoot> enemyPool = new Queue<CharacterRoot>();
        private List<CharacterRoot> enemyActive = new List<CharacterRoot>();

        private CharacterRoot playerRoot;

        public CharacterRoot Player => playerRoot;

        public CharacterRoot GetActiveEnemy() =>
            enemyActive.Count > 0 ? enemyActive[0] : null;

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
                    entity = CreateEntity(enemy);
                    //set target for enemy
                    break;
            }

            return entity;
        }

        private CharacterRoot CreateEntity(CharacterRoot prefab)
        {
            CharacterRoot root = Instantiate(prefab, parent);
            return root;
        }
    }
}
