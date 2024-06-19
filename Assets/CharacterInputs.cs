using System;
using _Volcano_Jump._Scripts.Windows;
using TMPro;
using UnityEngine;

public class CharacterInputs : BaseScreen
{
    [SerializeField] private Rigidbody2D _characterRb;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private PauseScreen _screenPause;
    [SerializeField] private AudioSource _audio;

    private int _scoreValue = 0;

    private void Start() => SetScore(0);


    public void SetScore(int value)
    {
        _scoreValue += value;
        _scoreText.text = $"{_scoreValue}";
    }

    public void ResetValue()
    {
        _scoreValue = 0;
        _scoreText.text = $"{_scoreValue}";
    }

    public void MoveCharacterLeft()
    {
        _characterRb.AddForce(new Vector2(-1f, 0), ForceMode2D.Impulse);
    }

    public void CharacterJump()
    {
        if (_characterRb.velocity.y != 0)
            return;
        _audio.Play();
        _characterRb.AddForce(new Vector2(0,7f),ForceMode2D.Impulse);
    }

    public void MoveCharacterRight()
    {
        _characterRb.AddForce(new Vector2(1f,0),ForceMode2D.Impulse);
        
    }

    public void OpenPauseScreen()
    {
        _screenPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
