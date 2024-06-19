using System;
using TMPro;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private WindowMeneger _windowMeneger;
    [SerializeField] private TextMeshProUGUI _textValue;
    [SerializeField] private TextMeshProUGUI _score;

    private void OnEnable()
    {
        _score.text = _textValue.text;
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        _windowMeneger.OpenMenuWindow();
        gameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OpenSettins()
    {
        Time.timeScale = 0;
        _windowMeneger.OpenSettingsWindow();
    }
}