using Environment;
using GameUI;
using Root;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private EntityFactory entityFactory;
        [SerializeField] private TargetPointer targetPointer;
        [SerializeField] private TurnOrder turnOrder;
        [SerializeField] private UIRoot uIRoot;

        [SerializeField] private MapNodes mapNodes;
        [SerializeField] private MotionEffect backgroundScroll;

        private Dictionary<Type, IState> states;
        private IState activeState;

        private void Awake()
        {
            states = new Dictionary<Type, IState>();
            Add(new StartState(this, entityFactory, mapNodes, uIRoot));
            Add(new WalkState(this, entityFactory, backgroundScroll, mapNodes));
            Add(new BattleState(this, turnOrder, entityFactory, targetPointer, uIRoot));
            Add(new DefeatState(this, uIRoot));
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Add<TState>(TState state) where TState : class, IState =>
            states.Add(typeof(TState), state);

        public TState GetState<TState>() where TState : class, IState =>
            states[typeof(TState)] as TState;

        private TState ChangeState<TState>() where TState : class, IState
        {
            activeState?.Exit();

            TState state = GetState<TState>();
            activeState = state;

            return state;
        }
    }
}
