using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ �������
    public Transform[] spawnPoints; // ������ ����� ���������
    public float spawnInterval = 1f; // �������� ����� ���������� ��������

    private float spawnTimer; // ������ ��� ������������ ������� ��������� ��������

    private void Start()
    {
        spawnTimer = spawnInterval; // ������������� ��������� �������� �������
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime; // ��������� ������ ������ ����

        // ���� ������ �����, ������� ����� ������ � ���������� ������
        if (spawnTimer <= 0f)
        {
            SpawnObject();
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnObject()
    {
        // �������� ��������� ����� ��������� �� ������� �����
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ������� ������ �� ��������� �����
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
