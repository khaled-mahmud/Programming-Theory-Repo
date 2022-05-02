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
    private Enemy[] enemyPrefabs;
    private int m_Points;
    public bool m_GameOver { get; set; }
    private float maxMoveXAxis = 5.0f; //{ get; set; }
    private float timeCount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameUI(); // Abstraction
        InvokeRepeating("InstantiatePrefab", 1, 2);
        m_GameOver = false;
        // MaxMoveXAxis = 5.0f;
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

        timeCount += Time.deltaTime * 0.1f;
    }

    private void InstantiatePrefab()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-maxMoveXAxis, maxMoveXAxis), 2, 8);
        var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos, Quaternion.identity);
        enemy.onDestroyed.AddListener(AddPoint);
        enemy.speed += timeCount;
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
