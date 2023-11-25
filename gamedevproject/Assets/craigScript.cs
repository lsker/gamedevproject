using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craigScript : MonoBehaviour
{
    [SerializeField] GameObject atkButton;
    [SerializeField] GameObject goodResponseButton;
    [SerializeField] GameObject badResponseButton;
    // Start is called before the first frame update
    void Awake(){
        
    }
    void Start()
    {
        
    }

    public void onAttack(){
        GetComponent<SpriteRenderer>().color = new Color(234, 109, 109, 0.5f);
        Debug.Log("button pressed");
        GetComponent<AudioSource>().Play();
        atkButton.SetActive(false);
    }

    /*public void goodIntroduction(){
        GetComponent<SpriteRenderer>().color = new Color(178, 255, 188, 1f);
        Debug.Log("good intro pressed");
        GetComponent<AudioSource>().Play();
        goodResponseButton.SetActive(false);
        badResponseButton.SetActive(false);
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
