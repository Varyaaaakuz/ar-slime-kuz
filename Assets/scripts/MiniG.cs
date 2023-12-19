using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniG : MonoBehaviour
{
    public Transform[] spawnPoints; // ������ ����, ��� ������ ������ ����������
    public GameObject objectPrefab; // ������ ������� ��� ������
    public float spawnDelay = 3f; // �������� ����� ���������� �������
    public float despawnDelay = 2f; // �������� ����� ������������� �������
    public float spawnSpeed = 3f; // �������� ��������� �������

    private GameObject spawnedObject;

    private void Start()
    {
        StartCoroutine(SpawnObject()); // �������� �������� ��� ��������� �������
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            // �������� ��������� ����� ������ �� �������
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Vector3 spawnPosition = spawnPoints[spawnIndex].position;

            // ������� ������ � �������� ��� � ����� ������
            spawnedObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            // ������������� �������� ����� ������������� �������
            yield return new WaitForSeconds(despawnDelay);

            // ���������� ������
            Destroy(spawnedObject);

            // ������������� �������� ����� ��������� ���������� �������
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void Update()
    {
        // ���������� � �������� ����� ���������� ������� �������� ������� ���������� � ���������� ������, ����������� �� �������� ���������
        spawnDelay += Time.deltaTime * spawnSpeed;

        // ������������ �������� ����� ���������� ������� � ���������� ��������
        spawnDelay = Mathf.Clamp(spawnDelay, 0f, float.MaxValue);
    }
}
