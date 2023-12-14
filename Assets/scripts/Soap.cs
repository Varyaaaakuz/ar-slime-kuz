using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soap : MonoBehaviour
{
    [SerializeField] private int _washAmount;
    private Player _player;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Washing();
        }
    }
    public void Washing()
    {
        if (_player._dirt > 0 && _player._dirt < 100)
        {
            _player.TakeWash(_washAmount);
        }
    }

}
