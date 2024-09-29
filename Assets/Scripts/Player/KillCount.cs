using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    [SerializeField] private Text _killCount;
    private int _kills = 0;

    private void Start()
    {
        _killCount.text = _kills.ToString();
    }

    private void OnEnable()
    {
        Enemy.OnDead += UpdateKillCount;
    }

    private void OnDisable()
    {
        Enemy.OnDead -= UpdateKillCount;
    }

    private void UpdateKillCount()
    {
        _kills++;

        _killCount.text = _kills.ToString();
    }
}