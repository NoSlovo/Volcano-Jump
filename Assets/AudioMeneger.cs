using System.Collections.Generic;
using UnityEngine;

public class AudioMeneger : MonoBehaviour
{
    [Header("Musick")]
    [SerializeField] private List<AudioSource> _audioSources;
    [Header("Exects")]
    [SerializeField] private List<AudioSource> _audioSourcesExects;
    private void Awake()
    {
        LoadSettingsSound();
    }

    private void LoadSettingsSound()
    {
        if(PlayerPrefs.GetFloat("Musick") == 0 || PlayerPrefs.GetFloat("Efex") == 0 )
            return;
        
        foreach (var source in _audioSources)
        {
            source.volume = PlayerPrefs.GetFloat("Musick");
        }
        foreach (var source in _audioSourcesExects)
        {
            source.volume = PlayerPrefs.GetFloat("Efex");
        }
    }

    public void SetValueMusickSound(float value)
    {
        foreach (var source in _audioSources)
        {
            source.volume = value;
        }
    }
    public void SetValueEfexSound(float value)
    {
        foreach (var source in _audioSources)
        {
            source.volume = value;
        }
    }
}

