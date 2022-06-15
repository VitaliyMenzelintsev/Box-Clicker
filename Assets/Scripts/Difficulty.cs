using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;
    public int DifficultyLevel;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(DifficultyLevel);
    }
}
