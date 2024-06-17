using System;
using System.Collections.Generic;
using _Volcano_Jump._Scripts.Game.States.Interfaces;

namespace _Volcano_Jump._Scripts.GameStateMachine
{
    public class GameFSM
    {
        private Dictionary<Type, IGameState> _gameStates = new Dictionary<Type, IGameState>()
        {
            
        };

        private IGameState _lastState;
    
        public void Enter<T>() where T  : IGameState
        {
            _lastState?.Exit();
            var gameState = _gameStates[typeof(T)];
            gameState.Enter();
        }
    }
}