using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using score_space;

public class power_ups : MonoBehaviour {
    //public CharacterController char_char;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Stopwatch(Clone)")
        {
            //Debug.Log("youve just collided with " + other.gameObject.name);
            float bonus = 5.0f;
            score score_class = new score();
            score_class.time_left(bonus);
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Diamond(Clone)")
        {
            //Debug.Log("youve just collided with " + other.gameObject.name);
            float bonus = 2.0f;
            player_motion.speed += bonus;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "FirstAid(Clone)")
        {
            //Debug.Log("youve just collided with " + other.gameObject.name);
            player_motion.one_hit = true;
            Destroy(other.gameObject);
        }
    }
}
