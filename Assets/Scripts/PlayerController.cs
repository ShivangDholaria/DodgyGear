using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Setting movement and rotation speed
    [SerializeField] private float movementSpeed = 0f;
    [SerializeField] private float rotationSpeed = 0f;
    [SerializeField] private AudioSource AS = null;

    internal static bool isGameOver = false;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {
        //Game Loop
        if (!isGameOver)
        {
            MoveAndRotatePlayer();
            ScreenWrapPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Getting gear component to destroy it
            collision.gameObject.GetComponent<GearController>().isDestroyed = true;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //Disableing Sprite of player
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            //Enabling the particle effect
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //Playing destroy effect sound
            AS.Play();

            isGameOver = true;
        }
    }
    public void MoveAndRotatePlayer()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);

        //Rotates player to left side
        if (TouchControlHandler.left)
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }

        //Rotates player to right side
        if (TouchControlHandler.right)
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
    }


    public void ScreenWrapPlayer()
    {
        //Clamps player within the screen view and 
        //changes the postion if the beyond the bounds of play area
        if (transform.position.x > 2.7 || transform.position.x < -2.7)
        {
            //Clamping position so that player doesnt go out of bound
            float pos = -Mathf.Clamp(transform.position.x, -2.7f, 2.7f);
            Vector2 newPos = new Vector2(pos, transform.position.y);
            transform.position = newPos;

        }
        if (transform.position.y > 4.7 || transform.position.y < -4.7)
        {
            //Clamping position so that player doesnt go out of bound
            float pos = -Mathf.Clamp(transform.position.y, -4.7f, 4.7f);
            Vector2 newPos = new Vector2(transform.position.x, pos);
            transform.position = newPos;

        }
    }
}
