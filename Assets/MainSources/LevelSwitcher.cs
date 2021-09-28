using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSwitcher : MonoBehaviour
{
    [SerializeField] private int _mainMenuIndex = 0;
    [SerializeField] private int _shopIndex = 1;
    [SerializeField] private int _level1Index = 2;

    private int _currentLevelIndex;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _currentLevelIndex = _level1Index;
    }

    public void LoadNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;

        if (index >= _level1Index)
        {
            _currentLevelIndex = index;
        }

        if (_currentLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(_currentLevelIndex + 1);
        }
        else
        {
            throw new InvalidOperationException("wrong level index");
        }
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(_shopIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(_mainMenuIndex);
    }
}
