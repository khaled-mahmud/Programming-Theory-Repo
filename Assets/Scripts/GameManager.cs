using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text ScoreText;
    [SerializeField]
    private GameObject GameOverText;
    [SerializeField]
    private Text playerNameScoreText;
    [SerializeField]
    private GameObject backButton;
    [SerializeField]
    private Enemy enemyPrefab;
    private int m_Points;
    public bool m_GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameUI(); // Abstraction
        InvokeRepeating("InstantiatePrefab", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameOver)
        {
            CancelInvoke();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void InstantiatePrefab()
    {
        var enemy = Instantiate(enemyPrefab, new Vector3(0, 2, 4), Quaternion.identity);
        enemy.onDestroyed.AddListener(AddPoint);
    }

    private void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        GameOverText.SetActive(true);
        backButton.SetActive(true);
        m_GameOver = true;
        UpdateGameUI(); // Abstraction
    }

    private void UpdateGameUI()
    {
        if (m_Points > DataManager.Instance.score)
        {
            DataManager.Instance.score = m_Points;
            DataManager.Instance.playerName = DataManager.Instance.currentPlayerName;
            DataManager.Instance.SavePlayerData();
        }
        playerNameScoreText.text = $"Best Score: {DataManager.Instance.playerName} : {DataManager.Instance.score}";
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
