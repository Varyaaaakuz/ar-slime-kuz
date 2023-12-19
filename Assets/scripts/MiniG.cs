using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniG : MonoBehaviour
{
    public Transform[] spawnPoints; // Массив мест, где объект должен появляться
    public GameObject objectPrefab; // Префаб объекта для спавна
    public float spawnDelay = 3f; // Задержка перед появлением объекта
    public float despawnDelay = 2f; // Задержка перед исчезновением объекта
    public float spawnSpeed = 3f; // Скорость появления объекта

    private GameObject spawnedObject;

    private void Start()
    {
        StartCoroutine(SpawnObject()); // Стартуем корутину для появления объекта
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            // Получаем случайное место спавна из массива
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[spawnIndex].position;

            // Создаем объект и помещаем его в место спавна
            spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // Устанавливаем задержку перед исчезновением объекта
            yield return new WaitForSeconds(despawnDelay);

            // Уничтожаем объект
            Destroy(spawnedObject);

            // Устанавливаем задержку перед следующим появлением объекта
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        // Прибавляем к задержке перед появлением объекта значение времени прошедшего с последнего фрейма, умноженного на скорость появления
        spawnDelay += Time.deltaTime * spawnSpeed;

        // Ограничиваем задержку перед появлением объекта в допустимых пределах
        spawnDelay = Mathf.Clamp(spawnDelay, 0f, float.MaxValue);
    }
}
