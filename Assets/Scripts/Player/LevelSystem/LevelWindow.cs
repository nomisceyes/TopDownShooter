using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    private Text _levelText;
    private Image _experienceBarImage;
    private LevelSystem _levelSystem;

    private void Awake()
    {
        _levelText = transform.Find("levelText").GetComponent<Text>();
        _experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        _levelSystem = levelSystem;

        SetLevelNumber(_levelSystem.GetLevelNumber());
        SetExperienceBarSize(_levelSystem.GetExperienceNormalized());

        _levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        _levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(_levelSystem.GetLevelNumber());
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        SetExperienceBarSize(_levelSystem.GetExperienceNormalized());
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        _experienceBarImage.fillAmount = experienceNormalized;
    }

    private void SetLevelNumber(int levelNumber)
    {
        _levelText.text = (levelNumber + 1).ToString();
    }
}