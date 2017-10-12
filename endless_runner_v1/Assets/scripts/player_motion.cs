using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_motion : MonoBehaviour {
    Animator anim;
    int jumpHash = Animator.StringToHash("Jump");
    int runStateHash = Animator.StringToHash("run_base.PlayerRun");

    private CharacterController controller;
    private Vector3 move_vect;
    public static float speed;
    private static bool init_jump;
    private float verticle_velocity = 0.0f;
    private float gravity = 12.0f;
    private float jump_force = 8.0f;
    private bool jumping;
    private Animator animator;
    public static bool one_hit;

    private float animate_timer = 1.0f;
    // Use this for initialization
    void Start () {
        one_hit = false;
        speed = 3.0f;
        init_jump = false;
        jumping = false;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time < (animate_timer+0.5f))
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        check_ground();
        anim.SetBool("jump", jumping);
        move_vect = Vector3.zero;
        move_vect.x = Input.GetAxisRaw("Horizontal")*speed;
        move_vect.y = verticle_velocity;
        move_vect.z = speed;
        controller.Move(move_vect * Time.deltaTime); //moving per second instead of per frame
	}

    void check_ground()
    {
        if (controller.isGrounded)
        {
            //verticle_velocity = -0.5f;
            init_jump = false;
            Debug.Log(init_jump);
            verticle_velocity = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && init_jump == false)
            {
               // Debug.Log("trying to jump");
                verticle_velocity = jump_force;
                jumping = true;
                anim.SetBool("jump", jumping);
                AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.fullPathHash == runStateHash)
                {
                    anim.SetTrigger(jumpHash);
                }
            }
            else
            {
                jumping = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && init_jump == true)
            {
               // Debug.Log("trying to double jump");
                verticle_velocity += jump_force;
                jumping = true;
                anim.SetBool("jump", jumping);
                AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
                init_jump = false;
                anim.SetTrigger(jumpHash);
            }
            else
            {
                init_jump = true;
            }
            
            verticle_velocity -= gravity*Time.deltaTime;
        }
    }
}
