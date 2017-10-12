using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_motion : MonoBehaviour {

    //setup the character to watch
    private Transform sight;
    private Vector3 starting_point;
    private Vector3 movement;

    private float initialization = 0.0f;
    private float animate_timer = 1.0f;
    private Vector3 animate_start = new Vector3(0,5,5);
	// Use this for initialization
	void Start () {
        sight=GameObject.FindGameObjectWithTag("Player").transform;
        starting_point = transform.position - sight.position;
	}
	
	// Update is called once per frame
	void Update () {
        movement = sight.position + starting_point;
        camera_locks();
        if (initialization > 1.0f)
        {
            transform.position = movement;
        }
        else
        {
            transform.position = Vector3.Lerp(movement + animate_start, movement, initialization);
            initialization += Time.deltaTime * 1 / animate_timer;
            transform.LookAt(sight.position + Vector3.up);
        }
        

	}

    void camera_locks()
    {
        movement.x = 0;
        movement.y = Mathf.Clamp(movement.y, 1, 6);

    }
}
