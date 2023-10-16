using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("KillBox") == true ){
            /*GetComponent<SpriteRenderer>().color = Color.red;
            GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
            GetComponent<AudioSource>().Play();*/
            //SceneManager.LoadScene("MeepisPlayground");
            //other.setHealth(0);
            //SetHealth(0);
        }else{
            //GetComponent<Collider2D>().isTrigger = false;
        }
        
        /*other.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity * -1;

        GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
        GetComponent<AudioSource>().Play();
*/
    }
}
