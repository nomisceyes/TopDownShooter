using System;

public class LevelSystem
{
    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;

    private int _level;
    private int _experience;
    private int _experienceToNextLevel;

    public LevelSystem()
    {
        _level = 0;
        _experience = 0;
        _experienceToNextLevel = 100;
    }

    public void AddExperience(int amount)
    {
        _experience += amount;

        if (_experience >= _experienceToNextLevel)
        {
            _level++;
            _experience -= _experienceToNextLevel;

            OnLevelChanged?.Invoke(this, new EventArgs());
        }
        OnExperienceChanged?.Invoke(this, new EventArgs());
    }

    public int GetLevelNumber()
    {
        return _level;
    }

    public float GetExperienceNormalized()
    {
        return (float)_experience / _experienceToNextLevel;
    }
}