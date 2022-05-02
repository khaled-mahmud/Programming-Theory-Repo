using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class ScaleEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        float scaleAmount = Random.Range(1f, 1.5f);
        transform.localScale = new Vector3(
            scaleAmount,
            transform.localScale.y,
            scaleAmount
        );
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            OnCollisionWithPlayer(collision.gameObject);
    }

    // POLYMORPHISM
    public override void OnCollisionWithPlayer(GameObject player)
    {
        player.transform.localScale = transform.localScale;
        base.OnCollisionWithPlayer(player);
    }
}
