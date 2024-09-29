using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;

    private float _spawnDelay = 3f;
    private int _maxCoundEnemies = 30;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        CreateEnemy();

        yield return new WaitForSeconds(_spawnDelay);

        StartCoroutine(Spawn());
    }

    private void CreateEnemy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < _maxCoundEnemies)
            Instantiate(_enemies[Random.Range(0, _enemies.Count)], transform.position, Quaternion.identity);
    }
}
