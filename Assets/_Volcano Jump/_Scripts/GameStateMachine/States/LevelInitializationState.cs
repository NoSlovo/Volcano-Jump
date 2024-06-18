using _Volcano_Jump._Scripts.Game.States.Interfaces;
using _Volcano_Jump._Scripts.GameStateMachine.GamePlay;
using VContainer;

namespace _Volcano_Jump._Scripts.GameStateMachine.States
{
    public class LevelInitializationState : IGameState
    {
        private readonly IObjectResolver _resolver;

        private GameLevel _gameLevel;
        
        public LevelInitializationState(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void Enter()
        {

        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}