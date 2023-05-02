using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    public AudioClip verticalforceClip;
    public AudioClip gameoverClip;
    public float yForce;
    public float xForce;
    public bool isGameover = false;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (isGameover == false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.AddForce(new Vector3(0, yForce, 0));
                PlaySound(verticalforceClip);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidBody.AddForce(new Vector3(-xForce, 0, 0));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidBody.AddForce(new Vector3(xForce, 0, 0));
            }
        }
    }
    private void OnCollisionEnter()
    {
        rigidBody.velocity = Vector3.zero;
        isGameover = true;
        PlaySound(gameoverClip);
        Debug.Log("Game Over!");
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
