using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    private Rigidbody rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0, 0, GameManager.instance.scroll);
    }
    void Update()
    {
        if (GameManager.instance.gameOver == true)
        {
            rigidBody.velocity = Vector3.zero;
        }
    }
}
