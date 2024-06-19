using _Volcano_Jump._Scripts;
using _Volcano_Jump._Scripts.Windows;
using UnityEngine;

public class WindowMeneger : MonoBehaviour
{
    [SerializeField] private MenuScreen _menuScreen;
    [SerializeField] private SettingsWindow _settingsWindow;
    [SerializeField] private InfoScreen _infoScreen;
    [SerializeField] private CharacterInputs _inputs;
    [SerializeField] private Chaser _chaser;
    [SerializeField] private FinelScreen _finelScreen;
    [SerializeField] private ChanckFactory _chanckFactory;

    private BaseScreen _activeScreen;
    private BaseScreen _lastScreen;

    private void Start()
    {
        OpenMenuWindow();
    }

    public void StartGame()
    {
        _finelScreen.Restart();
        _chanckFactory.Reset();
        _inputs.gameObject.SetActive(true);
        _inputs.ResetValue();
        _activeScreen.gameObject.SetActive(false);
        _activeScreen = _inputs;
        Time.timeScale = 1;
        _chaser.Init();
    }

    private void OpenScreen(BaseScreen screen)
    {
        if (_activeScreen != null)
        {
            _lastScreen = _activeScreen;
            _lastScreen.gameObject.SetActive(false);
        }
        
        screen.gameObject.SetActive(true);
        _activeScreen = screen;
    }

    public void OpenSettingsWindow()
    {
        OpenScreen(_settingsWindow);
    }

    public void OpenInfoScreen()
    {
        OpenScreen(_infoScreen);
    }

    public void OpenMenuWindow()
    {
        OpenScreen(_menuScreen);
    }

    public void BackWindow()
    {
        OpenScreen(_lastScreen);
    }

    public void OpenFinelScreen()
    {
        OpenScreen(_finelScreen);
    }
}