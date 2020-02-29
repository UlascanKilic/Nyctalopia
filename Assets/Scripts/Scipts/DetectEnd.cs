using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectEnd : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Canvası göster
            if(SceneManager.GetActiveScene().name != "Level3"){
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else{
                Debug.Log("You reached the house!");
            }
           
            // yeni level
            // repeat SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
            Debug.Log("level wonnn");
        }
    }
}
