using Environment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private float health = 3;
        [SerializeField] private float damage = 1;
        [SerializeField] private float speed = 2;

        private int curPos;
        private int currency;

        public float Health =>
            health;
        public float Damage =>
            damage;
        public float Speed =>
            speed;
        public int CurPos => 
            curPos;
        public int Currency =>
            currency;


        public void SetPos(int pos) =>
            curPos = pos;

        public bool GiveCurrency(int value)
        {
            if (value > 0)
            {
                currency += value;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TakeCurrency(int value)
        {
            if (value > 0)
            {
                if (currency - value < 0)
                {
                    return false;
                }
                else
                {
                    currency -= value;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public void HealthUpgrade(int value)
        {
            health += value;
        }
    }
}
