using UnityEngine;

public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] private Sprite _jumpSprite;
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _extraJump;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private CharacterInputs _inputs;

    public Rigidbody2D RB => _rigidbody2D;

    private bool _fly = false;

    public bool Fly => _fly;
    
    private float _delay = 0.8f;

    public void Update()
    {
        if (_fly && _delay > 0)
        {
            _rigidbody2D.AddForce(new Vector2(0,5f),ForceMode2D.Force);
            _spriteRenderer.sprite = _extraJump;
            _delay -= Time.deltaTime;
            Debug.Log(_delay);
            return;
        }

        
        if (_delay <= 0)
            _fly = false;


        if (_rigidbody2D.velocity.y == 0 && _fly == false)
            _spriteRenderer.sprite = _idleSprite;

        if (_rigidbody2D.velocity.y > 0 && _fly == false)
            _spriteRenderer.sprite = _jumpSprite;
    }

    public void SetScore(int value) => _inputs.SetScore(value);

    public void ExtraJump()
    {
        if(_fly)
            return;
        _fly = true;
        _delay = 0.8f;
    }
}