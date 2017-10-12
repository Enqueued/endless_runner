using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kill_me_now : MonoBehaviour {
    CharacterController char_char;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "base_runner")
        {
            if (player_motion.one_hit == true)
            {
                Debug.Log("You survived one hit");
                player_motion.one_hit = false;
            }
            else
            {
                Debug.Log("you have just bumped into a slime");
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
