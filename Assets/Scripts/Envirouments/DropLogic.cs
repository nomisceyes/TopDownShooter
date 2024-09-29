using System.Collections.Generic;
using UnityEngine;

public class DropLogic : MonoBehaviour
{
    readonly private int _minItemDrops = 1;  

    [SerializeField] private List<PickUp> _items;

    public void Drop()
    {
        int numbersOfDrop = Random.Range(_minItemDrops, _items.Count + 1);

        for (int i = 0; i < numbersOfDrop; i++)
        {
            Instantiate(_items[Random.Range(0, _items.Count)], transform.position, transform.rotation);
        }
    }
}