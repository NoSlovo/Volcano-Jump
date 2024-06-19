using UnityEngine;

public class FireBaff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out CharacterPlayer player))
        {
            if (player.Fly)
                return;

            player.ExtraJump();
            gameObject.SetActive(false);
        }
    }
}