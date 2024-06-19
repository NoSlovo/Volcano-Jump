using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplay : MonoBehaviour
{
    public Transform object1; // Ссылка на первый объект
    public Transform object2; // Ссылка на второй объект
    public Slider distanceSlider; // Ссылка на слайдер
    public float fillFactor = 1f; // Коэффициент заполнения слайдера
    public float distanceOffset = 0f; // Отступ расстояния

    private float initialDistance; // Начальное расстояние между объектами

    void Start()
    {
        if (distanceSlider == null)
        {
            Debug.LogError("Distance slider is not assigned.");
            return;
        }


        initialDistance = Vector3.Distance(object1.position, object2.position) + distanceOffset;


        distanceSlider.maxValue = initialDistance;
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(object1.position, object2.position);


        float adjustedDistance = Mathf.Max(0, initialDistance - (currentDistance - distanceOffset));
        distanceSlider.value = adjustedDistance * fillFactor;
    }
}