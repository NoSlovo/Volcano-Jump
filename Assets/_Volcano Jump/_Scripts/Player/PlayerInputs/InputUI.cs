using UnityEngine;
using UnityEngine.UI;

namespace _Volcano_Jump._Scripts.Player.PlayerInputs
{
    public class InputUI : MonoBehaviour
    {
        [SerializeField] private Button _buttonJump;
        [SerializeField] private Button _buttonLeft;
        [SerializeField] private Button _buttonRight;

        private GameObject _character;
    }
}