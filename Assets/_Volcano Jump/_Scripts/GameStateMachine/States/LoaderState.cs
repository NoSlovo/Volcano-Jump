using System;
using System.Threading.Tasks;
using _Volcano_Jump._Scripts.Game.States.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Volcano_Jump._Scripts.GameStateMachine.States
{
    public class LoaderState : IGameState
    {
        private IGameFSM _gameFsm;
        private int _nextSceneIndex;
        private GameObject _rotationLogo;
        private Vector3 _transformPosition;


        public LoaderState( IGameFSM gameFsm )
        {
            _gameFsm = gameFsm;
        }
        
        public async void Enter()
        {
           
            _nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            var progress =  SceneManager.LoadSceneAsync(_nextSceneIndex);
            var delay = TimeSpan.FromSeconds(1f);
            
            while (!progress.isDone)
            {
                await Task.Delay(delay);
            }
            _gameFsm.Enter<LevelInitializationState>();
        }

        public void Exit()
        {
            
        }
    }
}