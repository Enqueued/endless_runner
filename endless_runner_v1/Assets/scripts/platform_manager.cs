using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_manager : MonoBehaviour {
    public spawner spawner;
    public GameObject[] tile_prefabs;
    private Transform player_transform;
    private float spawn_z = 0.0f;
    private float len = 6.0f;
    private int amt_on_screen = 6;
    private List<GameObject> active_tiles;
    private float del_buf = 7.0f;
    private int last_index = 0;
    // Use this for initialization

    private void Start () {
        active_tiles = new List<GameObject>();
        player_transform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amt_on_screen; i++)
        {
            if (i < 2)
                spawn_tile(0);
            else
                spawn_tile();
        }
    }
	
	// Update is called once per frame
	private void Update () {
        if ((player_transform.position.z - del_buf)> (spawn_z - amt_on_screen * len))
        {
            spawn_tile();
            delete_tile();
        }
	}

    private void spawn_tile(int prefab_base = -1)
    {
        GameObject go;
        int random_index = random_fab();
        if (prefab_base == -1)
        {
            go = Instantiate(tile_prefabs[random_index]) as GameObject;
        }
        else
        {
            go = Instantiate(tile_prefabs[prefab_base]) as GameObject;
        }
        
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawn_z;
        spawn_z += len;
        active_tiles.Add(go);
    }

    private void delete_tile()
    {
        Destroy(active_tiles[0]);
        active_tiles.RemoveAt(0);
       // Debug.Log("removed a tile;");
    }

    private int random_fab()
    {
        if (tile_prefabs.Length <= 1)
        {
            return 0;
        }

        int random_index = last_index;
        while (random_index == last_index)
        {
            random_index = Random.Range(0, tile_prefabs.Length);
        }

        last_index = random_index;
        return random_index;
    }
}
