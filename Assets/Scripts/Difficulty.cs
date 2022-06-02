using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
