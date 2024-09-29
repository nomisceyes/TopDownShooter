using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject _particle;

    public void Explotion()
    {
        Instantiate(_particle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}