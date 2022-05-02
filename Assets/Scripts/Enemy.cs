using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]
    private int pointValue;

    private float m_speed = 2;

    // ENCAPSULATION
    public float speed
    {
        get { return m_speed; }
        set
        {
            if (value < 0.0f)
            {
                Debug.LogError("You can't set a negative value for speed!");
            }
            else
            {
                m_speed = value;
            }
        }
    }
    private float maxMoveZAxis = 8f;
    public UnityEvent<int> onDestroyed;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // POLYMORPHISM
    public virtual void OnCollisionWithPlayer(GameObject player)
    {
        // execute impact on player
        onDestroyed.Invoke(pointValue);
        Destroy(gameObject);
    }

    protected void Move()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Vector3 enemyPosition = transform.position;

        if (enemyPosition.z > -maxMoveZAxis)
        {
            if (!gameManager.m_GameOver)
            {
                enemyPosition.z -= m_speed * Time.deltaTime;
                transform.position = enemyPosition;
            }
        }
        else
        {
            if (gameManager != null) gameManager.GameOver();
            Destroy(gameObject);
        }
    }

}
