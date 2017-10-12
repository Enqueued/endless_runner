using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {
    public GameObject[] death_things;
    public Vector3 vals_spawn;
    public float wait_spawn;
    public float max_wait;
    public float min_wait;
    public int start_wait;
    public bool stop;
    private int death_index;
    private Transform me;
    // Use this for initialization
	void Start () {
        me = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawning_wait());
	}
	
	// Update is called once per frame
	void Update () {
        wait_spawn = Random.Range(min_wait, max_wait);
	}

    IEnumerator spawning_wait()
    {
        yield return new WaitForSeconds(start_wait);
        while (!stop)
        {
            death_index = Random.Range(0, death_things.Length);
           // Debug.Log("Index =" + death_index);
            float z_range = me.position.z + vals_spawn.z;
            Vector3 spawn_pos;
            if (death_index == 2 || death_index==3)
            {
                spawn_pos = new Vector3(Random.Range(-vals_spawn.x, vals_spawn.x), Random.Range(-1,3), Random.Range(z_range, z_range + vals_spawn.z));
            }else if(death_index==4 && player_motion.one_hit == true)
            {
                continue;
            }
            else
            {
                spawn_pos = new Vector3(Random.Range(-vals_spawn.x, vals_spawn.x), 0, Random.Range(z_range, z_range + vals_spawn.z));
            }
            Instantiate(death_things[death_index], spawn_pos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            yield return new WaitForSeconds(wait_spawn);
        }
    }
}