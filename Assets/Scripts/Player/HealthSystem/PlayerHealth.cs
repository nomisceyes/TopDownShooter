using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Sprite _fullHearts;
    [SerializeField] private Sprite _emptyHearts;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _deathScreen;

    PlayerAnimations _anims;

    private int _maxHealth = 3;
    private bool _godMode;

    public int Health { get; private set; }
    public bool IsAlive { get; private set; }

    private void Awake()
    {
        _anims = GetComponent<PlayerAnimations>();
    }

    private void Start()
    {
        Health = _maxHealth;
        _godMode = false;
        IsAlive = true;

        HealthBarUpdate();     
    }

    private void OnEnable()
    {
        Enemy.OnTakedDamage += TakeDamage;
    }

    private void OnDisable()
    {
        Enemy.OnTakedDamage -= TakeDamage;
    }

    private void TakeDamage()
    {
        if (!_godMode)
        {
            Health--;
            HealthBarUpdate();
            StartCoroutine(GodMode());
        }

        if (Health <= 0)
        {
            StartCoroutine(DeathScreen());
        }
    }

    private void HealthBarUpdate()
    {
        if (Health > _maxHealth)
            Health = _maxHealth;

        for (int i = 0; i < _hearts.Length; i++)
        {
            if (i < Health)
                _hearts[i].sprite = _fullHearts;
            else
                _hearts[i].sprite = _emptyHearts;

            if (i < _maxHealth)
                _hearts[i].enabled = true;
            else
                _hearts[i].enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Health"))
        {
            Health++;
            HealthBarUpdate();
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator DeathScreen()
    {
        _anims.IsDeath();
        _weapon.SetActive(false);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        IsAlive = false;

        yield return new WaitForSeconds(1);

        _deathScreen.SetActive(true);
    }

    private IEnumerator GodMode()
    {
        _godMode = true;

        yield return new WaitForSeconds(1);

        _godMode = false;
    }
}