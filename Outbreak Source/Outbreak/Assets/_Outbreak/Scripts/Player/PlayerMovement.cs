using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float dashSpeed = 15.0f;
    public float rotationSpeed = 540.0f;
    private bool isFiring = false;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.CurrentState != GameState.Running)
            return;

        if (Input.GetKey(KeyCode.S) && !isFiring)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, -45, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.A) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 45, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) && !isFiring)
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (Input.GetKey(KeyCode.S) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, -45, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.W) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, -135, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, -90, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
        }
        if (Input.GetKey(KeyCode.W) && !isFiring)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, -135, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.A) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 135, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
        }
        if (Input.GetKey(KeyCode.A) && !isFiring)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            if (Input.GetKey(KeyCode.S) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 45, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else if (Input.GetKey(KeyCode.W) && !isFiring)
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 135, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
            else
            {
                Quaternion currentRotation = transform.rotation;
                Quaternion wantedRotation = Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
            }
        }

        //For three keys being pressed
        if ((Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W)) && Input.GetKeyDown(KeyCode.D))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, -90, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion wantedRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotationSpeed);
        }

        //For firing
        //if (Input.GetMouseButtonDown(1))
        //    isFiring = true;
        
        //if (Input.GetMouseButtonUp(1))
        //    isFiring = false;

        //For Dodging
        //if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
        //    transform.Translate(forward.position);
    }
}
