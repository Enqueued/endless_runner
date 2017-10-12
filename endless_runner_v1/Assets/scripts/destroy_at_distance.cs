using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_at_distance : MonoBehaviour
{

    public float distance = 10;
    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.z > gameObject.transform.position.z + 10) {

            Destroy(gameObject);
        }
    }
   
}
