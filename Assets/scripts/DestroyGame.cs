using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGame : MonoBehaviour
{
    // Объект, с которым будет происходить столкновение
    public GameObject otherObject;
    public PlayerMoney playerMoney;
    public int _pointsForFlower = 20;

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем столкновение с нужным объектом
        if (collision.gameObject == otherObject)
        {
            // Делаем объект исчезающим (деактивируем его)
            Destroy(gameObject);
            playerMoney.ProcessWin(_pointsForFlower);
        }
    }
}
