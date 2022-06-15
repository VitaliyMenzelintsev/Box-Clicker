using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; // библиотека сцен 
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets; // переменная лист таргертов
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public Button RestartButton;
    public GameObject TitleScreen;
    public bool IsGameActive;

    private int _score;
    private float _spawnRate = 1.0f;
    

    public void StartGame(int difficulty)
    {
        IsGameActive = true;
        StartCoroutine(SpawnTarget()); // запускаем итератор
        UpdateScore(0);
        _spawnRate /= difficulty;
        TitleScreen.gameObject.SetActive(false);
    }
    IEnumerator SpawnTarget() // итератор 
    {
        while (IsGameActive) // оператор итераций
        {
            yield return new WaitForSeconds(_spawnRate); // yield возвращает значение итерации через указанное время
            int index = Random.Range(0, Targets.Count); // переменная индекс рандомная от значения 0 до длинны листа
            Instantiate(Targets[index]); // спавн из листа Targets
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true); // активируем надпись геймовер
        RestartButton.gameObject.SetActive(true);
        IsGameActive = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
