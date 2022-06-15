using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; // ���������� ���� 
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets; // ���������� ���� ���������
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
        StartCoroutine(SpawnTarget()); // ��������� ��������
        UpdateScore(0);
        _spawnRate /= difficulty;
        TitleScreen.gameObject.SetActive(false);
    }
    IEnumerator SpawnTarget() // �������� 
    {
        while (IsGameActive) // �������� ��������
        {
            yield return new WaitForSeconds(_spawnRate); // yield ���������� �������� �������� ����� ��������� �����
            int index = Random.Range(0, Targets.Count); // ���������� ������ ��������� �� �������� 0 �� ������ �����
            Instantiate(Targets[index]); // ����� �� ����� Targets
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = "Score: " + _score;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true); // ���������� ������� ��������
        RestartButton.gameObject.SetActive(true);
        IsGameActive = false;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
