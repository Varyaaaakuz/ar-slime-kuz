using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public GameObject objectToSpawn; // Префаб объекта
    public Transform[] spawnPoints; // Массив точек появления
    public float spawnInterval = 1f; // Интервал между появлением объектов

    private float spawnTimer; // Таймер для отслеживания времени появления объектов

    private void Start()
    {
        spawnTimer = spawnInterval; // Устанавливаем начальное значение таймера
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime; // Уменьшаем таймер каждый кадр

        // Если таймер истек, создаем новый объект и сбрасываем таймер
        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        // Выбираем случайное место появления из массива точек
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Создаем объект на выбранной точке
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
