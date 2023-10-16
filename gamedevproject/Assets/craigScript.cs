using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craigScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onAttack(){
        GetComponent<SpriteRenderer>().color = new Color(234, 109, 109, 0.5f);
        Debug.Log("button pressed");
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
