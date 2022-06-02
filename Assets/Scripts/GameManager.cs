using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // ���������� � �������
using UnityEngine.SceneManagement; // ���������� ����, ����� �������� �����(������)
using UnityEngine.UI; // ���������� �����������, ����� �������� � ��������

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; // ���������� ���� ���������
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
        StartCoroutine(SpawnTarget()); // ��������� ��������
        UpdateScore(0);
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
    }
    IEnumerator SpawnTarget() // �������� 
    {
        while (isGameActive) // �������� ��������
        {
            yield return new WaitForSeconds(spawnRate); // yield ���������� �������� �������� ����� ��������� �����
            int index = Random.Range(0, targets.Count); // ���������� ������ ��������� �� �������� 0 �� ������ �����
            Instantiate(targets[index]); // ����� �� ����� Targets
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // ���������� ������� ��������
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
