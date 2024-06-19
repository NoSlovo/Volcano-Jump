using _Volcano_Jump._Scripts.GameStateMachine;
using _Volcano_Jump._Scripts.GameStateMachine.States;
using DG.Tweening;
using UnityEngine;

namespace _Volcano_Jump._Scripts.Bootstrapper
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameLifeTineScope _gameLifeTineScope;
        [SerializeField] private RectTransform _rotationLogo;

        private GameFSM _gameFsm;

        private void Start()
        {
            _rotationLogo.DORotate(new Vector3(0, 0, -360f), 1f, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
            _gameFsm = new GameFSM(_gameLifeTineScope.Container);
            _gameFsm.Init();
            _gameFsm.Enter<LoaderState>();

            DontDestroyOnLoad(this);
        }
    }
}