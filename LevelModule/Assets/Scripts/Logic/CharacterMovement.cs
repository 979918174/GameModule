using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController character;
    public float speed = 0.5f;
    public float RotateSpeed = 1f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("T_isAttack");
        }
        
        MoveTypeA();
        SwitchAnimation();
    }
    private void MoveTypeA()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var move = transform.forward * speed * vertical * Time.deltaTime;
        character.Move(move);

        transform.Rotate(Vector3.up, horizontal * RotateSpeed);
    }

    private void SwitchAnimation()
    {
        animator.SetFloat("Speed",Input.GetAxis("Vertical"));
    }
}
