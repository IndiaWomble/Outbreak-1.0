using UnityEngine;
using Outbreak;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isMoving = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.CurrentState != GameState.Running)
            return;

        //For mouse click
        if (Input.GetMouseButtonDown(0))
            animator.SetBool("left mouse button", true);
        if (Input.GetMouseButtonUp(0))
            animator.SetBool("left mouse button", false);

        //For single keys
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("WASD", true);
            isMoving = true;
        }

        //For idle motion and double keys being pressed
        if (!Input.anyKey || (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("WASD", false);
            isMoving = false;
        }

        if (Input.GetMouseButton(0) && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D)))
            animator.SetBool("WASD", false);

        //For three keys being pressed
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) ||
            (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) ||
            (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) ||
            (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)))
        {
            animator.SetBool("WASD", true);
            isMoving = true;
        }

        //For four keys being pressed
        if ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("WASD", false);
            isMoving = false;
        }

        //For sword attack
        if (Input.GetMouseButton(0))
            animator.SetBool("swinging", true);
        if (Input.GetMouseButtonUp(0))
            animator.SetBool("swinging", false);
    }
}
