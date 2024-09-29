using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(DropLogic))]
[RequireComponent(typeof(Destructible))]

public class Barrel : MonoBehaviour
{
    private DropLogic _dropLogic;
    private Destructible _destructible;

    private void Awake()
    {
        _dropLogic = GetComponent<DropLogic>();
        _destructible = GetComponent<Destructible>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            _dropLogic.Drop();
            _destructible.Explotion();
        }
    }
}