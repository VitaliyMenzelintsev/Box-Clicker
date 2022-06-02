using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // библиотека с текстом
using UnityEngine.SceneManagement; // библиотека сцен, чтобы включать сцены(уровни)
using UnityEngine.UI; // библиотека интерфейсов, чтобы работать с кнопками

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // переменная лист таргертов
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;

    private float spawnRate = 1.0f;
    public bool isGameActive;

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget()); // запускаем итератор
        UpdateScore(0);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
    }
    IEnumerator SpawnTarget() // итератор 
    {
        while (isGameActive) // оператор итераций
        {
            yield return new WaitForSeconds(spawnRate); // yield возвращает значение итерации через указанное время
            int index = Random.Range(0, targets.Count); // переменная индекс рандомная от значения 0 до длинны листа
            Instantiate(targets[index]); // спавн из листа Targets
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // активируем надпись геймовер
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
