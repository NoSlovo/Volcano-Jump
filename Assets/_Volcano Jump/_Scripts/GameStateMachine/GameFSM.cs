using System;
using System.Collections.Generic;
using _Volcano_Jump._Scripts.Game.States.Interfaces;
using _Volcano_Jump._Scripts.GameStateMachine.States;

namespace _Volcano_Jump._Scripts.GameStateMachine
{
    public class GameFSM : IGameFSM
    {
        private Dictionary<Type, IGameState> _gameStates;
        
        private IGameState _lastState;
        
        public void Init()
        {
            _gameStates = new()
            {
                [typeof(LoaderState)] = new LoaderState(this),
                [typeof(LevelInitializationState)] = new LevelInitializationState()
            };
        }

        public void Enter<T>() where T : IGameState
        {
            _lastState?.Exit();
            var gameState = _gameStates[typeof(T)];
            gameState.Enter();
        }
    }

    public interface IGameFSM
    {
        public void Enter<T>() where T : IGameState;
    }
}