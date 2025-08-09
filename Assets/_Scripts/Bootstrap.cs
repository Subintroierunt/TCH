using GameSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntryPoint
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;

        private void Start()
        {
            entityFactory.SpawnEntity(Entities.CharacterType.Kobold, 0);
            entityFactory.SpawnEntity(Entities.CharacterType.Slime, 2);
        }

    }
}
