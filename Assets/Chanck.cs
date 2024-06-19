using System.Collections.Generic;
using UnityEngine;

public class Chanck : MonoBehaviour
{
   [SerializeField] private List<GameObject> _chanckLements;

   public void Reset()
   {
      foreach (var item in _chanckLements)
      {
         item.gameObject.SetActive(true);
      }
   }
}
