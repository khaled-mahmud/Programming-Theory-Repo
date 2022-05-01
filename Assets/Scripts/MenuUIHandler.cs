using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField]
    private Text playerNameText;
    [SerializeField]
    private Text UIText;
    [SerializeField]
    private Text placeholderText;
    // Start is called before the first frame update
    void Start()
    {
        UIText.text = $"Best Score: {DataManager.Instance.playerName} : {DataManager.Instance.score}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        if (playerNameText.text == "")
            return;

        DataManager.Instance.currentPlayerName = playerNameText.text;
        SceneManager.LoadScene(1);
        Debug.Log(Application.persistentDataPath);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
