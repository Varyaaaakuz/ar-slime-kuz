using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTimer : MonoBehaviour
{

    [SerializeField] public int _health;
    public void TakeFood(int heal)
    {
        if (_health + heal <= 15)
        {
            _health += heal;
        }
        else { _health = 15; }
    }
}
