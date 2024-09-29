using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private LevelWindow _levelWindow;
    LevelSystem _levelSystem;

    private void Awake()
    {
        _levelSystem = new LevelSystem();
        
        _levelWindow.SetLevelSystem(_levelSystem);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exp"))
        {        
            
            _levelSystem.AddExperience(collision.GetComponent<ExperiencePoint>().Experience);            
            Destroy(collision.gameObject);
        }
    }
}