using System;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private Transform player; 
    [SerializeField] private float normalSpeed = 2f; 
    [SerializeField] private float maxSpeed = 10f; 
    [SerializeField] private float acceptableDistance = 5f;
    [SerializeField] private WindowMeneger _windowMeneger;

    private bool _gameStart = false;

    public void Init()
    {
        _gameStart = true;
    }
    
   private void Update()
    {
        if (!_gameStart)
        {
            return;
        }
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

       
        float speed = normalSpeed;
        if (distanceToPlayer > acceptableDistance)
        {
            
            speed = Mathf.Lerp(normalSpeed, maxSpeed, (distanceToPlayer - acceptableDistance) / acceptableDistance);
        }

       
        Vector3 direction = Vector3.up;

       
        transform.position += direction * (speed * Time.deltaTime);
    }

   public void OnTriggerEnter2D(Collider2D other)
   {
       if (other.TryGetComponent(out CharacterPlayer _player))
       {
           Debug.Log("Попали");
           _windowMeneger.OpenFinelScreen();
           Time.timeScale = 0;
       }
   }
}