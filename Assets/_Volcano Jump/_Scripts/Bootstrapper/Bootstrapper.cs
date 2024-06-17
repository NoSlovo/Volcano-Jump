using _Volcano_Jump._Scripts.GameStateMachine;
using UnityEngine;

namespace _Volcano_Jump._Scripts.Bootstrapper
{
    public class Bootstrapper : MonoBehaviour
    {
        private GameFSM _gameFsm = new GameFSM();

        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
