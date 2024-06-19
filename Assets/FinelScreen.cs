using _Volcano_Jump._Scripts.Windows;
using TMPro;
using UnityEngine;

public class FinelScreen : BaseScreen
{
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private CharacterPlayer _player;
    [SerializeField] private Transform _cameraStartPosition;
    [SerializeField] private Transform _chaserStartPosition;
    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private TextMeshProUGUI _textValue;
    [SerializeField] private TextMeshProUGUI _Score;

    private void OnEnable()
    {
        _Score.text = _textValue.text;
    }

    public void Restart()
    {
        _camera.transform.position = _cameraStartPosition.position;
        _chaser.transform.position = _chaserStartPosition.position;
        _player.transform.position = _playerStartPosition.position;
        Time.timeScale = 1;
    }
}
