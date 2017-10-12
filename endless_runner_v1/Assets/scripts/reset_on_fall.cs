using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class reset_on_fall : MonoBehaviour
{
    
    private void Update()
    {
        if (gameObject.transform.position.y <= -20)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        }
        
    }

   /* public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.name);
        if(collision.collider.gameObject.name == "Slime(Clone)")
        {
            Debug.Log("you have just bumped into a slime");
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        }
    }*/


}