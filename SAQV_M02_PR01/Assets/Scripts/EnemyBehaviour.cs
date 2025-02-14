using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameBehaviour gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            UnityEngine.Debug.Log("Player detected - attack!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            UnityEngine.Debug.Log("Player out of range, resume patrol");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            UnityEngine.Debug.Log("Ouch");
            gameManager.HP -= 1;
        }
    }
}
