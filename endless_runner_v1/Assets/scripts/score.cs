using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace score_space
{
    public class score : MonoBehaviour
    {
        private float score_float = 0.0f;
        public static float timeleft;
        private float actual;
        public Text score_text;
        public Text cur_level;
        private int lvl = 1;
        // Use this for initialization
        void Start()
        {
            timeleft = 30.0f;
            actual = timeleft;
            cur_level.text = lvl.ToString();
            //score_text.text = score_float.ToString();
            score_text.text = timeleft.ToString();
        }

        // Update is called once per frame
        void Update()
        {
            time_left();
            int time_var = Mathf.RoundToInt(timeleft);
            //Debug.Log(time_var + " = time_var");
            if (timeleft > 0)
            {
                score_text.GetComponent<Text>().text = time_var.ToString();
                next_level();
            }
            else
            {
                score_text.text = "DEAD";
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            }
        }

        public void time_left(float bonus = -1f)
        {
            if (bonus == -1f)
            {
                timeleft -= Time.deltaTime;
            }
            else
            {
                //Debug.Log(bonus + "=bonus");
                timeleft += bonus;
                //Debug.Log(timeleft + "=timeleft");
            }
            actual -= Time.deltaTime; 
        }

        public void next_level()
        {
            if (actual < 0 && timeleft > 0)
            {
                lvl++;
                cur_level.GetComponent<Text>().text = lvl.ToString();
                actual = 30.0f;
            }
        }
    }
}
