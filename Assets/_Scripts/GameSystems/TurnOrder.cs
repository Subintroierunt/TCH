using Entities;
using GameSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Root
{
    public class TurnOrder : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;
        [SerializeField] private float nextTurnDelay = 3;

        private Dictionary<int, CharacterRoot> entityList;

        public event Action<bool> OrderEnd;

        public void CreateNewOrder()
        {
            entityList = new Dictionary<int, CharacterRoot>();
            entityList.Add(0, entityFactory.Player);
            List<CharacterRoot> enemies = new List<CharacterRoot>();
            enemies.AddRange(entityFactory.GetActiveEnemy());
                

            enemies.ForEach(enemy => { entityList.Add(enemy.CharacterData.CurPos, enemy); });

            StartCoroutine(Round());
        }

        private IEnumerator Round()
        {
            while (!IsBattleEnd())
            {
                for (int i = 0; i < entityList.Count; i++)
                {
                    if (IsBattleEnd())
                    {
                        break;
                    }
                    else
                    {
                        if (entityList[i].CharacterHealth.IsDead)
                        {
                            continue;
                        }
                        entityList.ElementAt(i).Value.InvokeCharacterAction();
                        yield return new WaitForSeconds(nextTurnDelay);
                    }    
                }
            }
            Debug.Log("Order end");
            OrderEnd?.Invoke(!entityList[0].CharacterHealth.IsDead);
        }

        private bool IsBattleEnd()
        {
            if (!entityList[0].CharacterHealth.IsDead)
            {
                for (int i = 1; i < entityList.Count; i++)
                {
                    if (entityList[i].CharacterHealth.IsDead)
                    {
                        continue;
                    }
                    return false;
                }
                return true;
            }

            return true;
        }
    }
}
