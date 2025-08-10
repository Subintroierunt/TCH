using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}
