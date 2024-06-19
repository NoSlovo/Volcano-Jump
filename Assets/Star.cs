using UnityEngine;

public class Star : MonoBehaviour
{
    private int _value = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CharacterPlayer player))
        {
            player.SetScore(_value);
            gameObject.SetActive(false);
        }
    }
}