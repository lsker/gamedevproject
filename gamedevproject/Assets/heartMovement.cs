using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartMovement : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    int health = 100;
    protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale=0;
        rb.velocity=new Vector3(0,0,0);
    }

    IEnumerator ColorChanger(){
        while(true){
            yield return new WaitForSeconds(1);
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        yield return null;
    }

    void Start()
    {
        StartCoroutine(ColorChanger());
        //rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)){
        if(Input.GetKey(KeyCode.A)){
            transform.Translate(new Vector3(-1 *Time.deltaTime,1 *Time.deltaTime,0));
            //why do i need to move the y up???????

            //rb.velocity=new Vector3(0,0,0);
            //MoveRB(new Vector3(-1,rb.velocity.y / speed,0));
        }else if(Input.GetKey(KeyCode.D)){
            //MoveRB(new Vector3(1,rb.velocity.y / speed,0));
            transform.Translate(new Vector3(1*Time.deltaTime,1 *Time.deltaTime,0));
            //why do i need this
            //rb.velocity=new Vector3(0,0,0);
        }
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(new Vector3(0,1*Time.deltaTime,0));
            //rb.velocity = new Vector3(rb.velocity.x,1,0);
        }else{
            transform.Translate(new Vector3(0,-1*Time.deltaTime,0));
            //rb.velocity = new Vector3(rb.velocity.x,-1,0);
        }}else{
            rb.velocity=new Vector3(0,0,0);

        }
        
    }

    public void MoveRB(Vector3 vel){
        rb.velocity = vel * speed;
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("Bullet") == true ){
            health -= 5;
            GetComponent<AudioSource>().pitch = Random.Range(.9f,1.1f);
            GetComponent<AudioSource>().Play();
            GetComponent<SpriteRenderer>().color = Color.black;

        }else{
            GetComponent<SpriteRenderer>().color = Color.red;

        }

    

    }
}
