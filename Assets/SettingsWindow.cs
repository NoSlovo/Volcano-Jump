using _Volcano_Jump._Scripts.Windows;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : BaseScreen
{
    [SerializeField] private Slider _musickSlider;
    [SerializeField] private Slider _efexctSlider;
    [SerializeField] private AudioMeneger _audioMeneger;

    private void OnEnable()
    {
        _musickSlider.value = PlayerPrefs.GetFloat("Musick");
        _efexctSlider.value = PlayerPrefs.GetFloat("Efex");
    }

    public void SaveValueMusik()
    {
        _audioMeneger.SetValueMusickSound(_musickSlider.value);
        PlayerPrefs.SetFloat("Musick", _musickSlider.value);
    }

    public void SaveValueEfex()
    {
        _audioMeneger.SetValueEfexSound(_efexctSlider.value);
        PlayerPrefs.SetFloat("Efex", _efexctSlider.value);
    }
}