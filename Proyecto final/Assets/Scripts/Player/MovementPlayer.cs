using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 10f)] float speed = 2f;

    public float cameraAxis = 0f;
    
    Vector3 directionPlayer;

    [SerializeField] Animator playerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        directionPlayer = Vector3.zero;
        RotatePlayer();

       if (Input.GetKey(KeyCode.A))
       { 
            directionPlayer += Vector3.left;
            if(!IsAnimation("LEFT")) playerAnimator.SetTrigger("LEFT");
       }
      
       if (Input.GetKey(KeyCode.W))
       {
           directionPlayer += Vector3.forward;
           if(!IsAnimation("FORWARD")) playerAnimator.SetTrigger("FORWARD");
       }
      
       if (Input.GetKey(KeyCode.D))
       {
           directionPlayer += Vector3.right;
           if(!IsAnimation("RIGHT")) playerAnimator.SetTrigger("RIGHT");
       }
       if (Input.GetKey(KeyCode.S))
       {
           directionPlayer += Vector3.back;
           if(!IsAnimation("BACK")) playerAnimator.SetTrigger("BACK");
       }

        if (directionPlayer != Vector3.zero)
        {
            MovePayer(directionPlayer);
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            if (!IsAnimation("IDLE")) playerAnimator.SetTrigger("IDLE");
        }
    }
    private bool IsAnimation(string animName)
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName(animName);
    }

    private void MovePayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RotatePlayer()
    {
        cameraAxis += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxis, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 10f * Time.deltaTime);
    }
}
