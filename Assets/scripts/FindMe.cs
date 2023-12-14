using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMe : MonoBehaviour
{
    [SerializeField] public Transform target;
    public float speed = 1f;
   

    public float minDistance = 5f; // Минимальное расстояние между объектами


    private void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        // Переместите нашу позицию на шаг ближе к цели.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance < minDistance)
        {
            // Преследуем цель, двигаясь в ее направлении
            transform.position = target.position - direction * minDistance;
        }
    }
}
