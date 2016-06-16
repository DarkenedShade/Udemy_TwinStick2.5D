using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0.0f && volume <= 1.0f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master Volume out of range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Level unlock out of range");
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        bool levelIsUnlocked = false;
        string levelToCheckKey = LEVEL_KEY + level.ToString();

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            if (PlayerPrefs.HasKey(levelToCheckKey))
            {
                int levelUnlockedVal = PlayerPrefs.GetInt(levelToCheckKey);
                levelIsUnlocked = (levelUnlockedVal == 1);
            }
        }
        else
        {
            Debug.LogError("Level unlock out of range");
        }
        return levelIsUnlocked;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1.0f && difficulty <= 3.0f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty set out of range");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
