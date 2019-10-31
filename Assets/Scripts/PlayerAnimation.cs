using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public Animator anim;
    public Controller2D controller2D;

    private void Update()
    {
        anim.SetBool("isGrounded", controller2D.collisions.below);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

    public void SetJumpTrigger()
    {
        anim.SetTrigger("Jump");
    }


    //public Animator anim;
    //[SerializeField] Controller2D controller;

    //// Update is called once per frame
    //void Update()
    //{
    //    anim.SetBool("isGrounded", controller.collisions.below);
    //    anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    //}

    //public void SetJumpTrigger()
    //{
    //    anim.SetTrigger("Jump");
    //}

}
