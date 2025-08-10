using GameSystems;
using Root;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntryPoint
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private StateMachine stateMachine;

        private void Start()
        {
            stateMachine.Enter<StartState>();
            
            //entityFactory.SpawnEntity(Entities.CharacterType.Slime, 2);

            //targetPointer.DebugSetTarget();

            //turnOrder.CreateNewOrder();
        }

    }
}
