using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    [SerializeField] int healthPoints = 100;
    [SerializeField] GameObject tutorialText;
    [SerializeField] GameObject tutorialText2;
    [SerializeField] GameObject tutorialText3;
    [SerializeField] GameObject deathEffect;

    // Update is called once per frame
    

    [SerializeField] protected float speed = 5;
//    [SerializeField] private Transform groundCheck;
    //[SerializeField] AnimationStateChanger animationStateChanger;
    //[SerializeField] Transform body;
    protected Rigidbody2D rb;
    protected bool isAlive = true;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        tutorialText.SetActive(false);
        tutorialText2.SetActive(false);
        tutorialText3.SetActive(false);
        deathEffect.SetActive(false);
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveRB(Vector3 vel){
        rb.velocity = vel * speed;
        /*if(vel.magnitude > 0){
            //animationStateChanger?.ChangeAnimationState("Walk",speed/5);

            if(vel.x > 0){
                body.localScale = new Vector3(1,1,1);
            }else if(vel.x < 0){
                body.localScale = new Vector3(-1,1,1);
            }

        }else{
            //animationStateChanger?.ChangeAnimationState("Idle");
        }*/
    }

/*    private bool isGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
*/
    void Update()
    {
        if(isAlive){
               if(Input.GetKey(KeyCode.A)){
            MoveRB(new Vector3(-1,rb.velocity.y / speed,0));
        }else if(Input.GetKey(KeyCode.D)){
            MoveRB(new Vector3(1,rb.velocity.y / speed,0));
        }else{
            rb.velocity = new Vector3(0,rb.velocity.y,0);

        }}
        isDead();
        
    }
    
    public void SetHealth(int hp){
        healthPoints = hp;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag.Equals("KillBox") == true ){
            SetHealth(0);
        }
        if(other.gameObject.tag.Equals("Craig") == true){
            tutorialText.SetActive(true);
            //tutorialtext1.color = 1.0f;
        }else{
            tutorialText.SetActive(false);
        }


        if(other.gameObject.tag.Equals("Craig2") == true){
            tutorialText2.SetActive(true);
            //tutorialtext1.color = 1.0f;
        }else{
            tutorialText2.SetActive(false);
        }

        if(other.gameObject.tag.Equals("Craig3") == true){
            tutorialText3.SetActive(true);
            //tutorialtext1.color = 1.0f;
        }else{
            tutorialText3.SetActive(false);
        }


        if(other.gameObject.tag.Equals("YellowPortal") == true){
            moveToCraigBattle();
        }
        }

    public void isDead(){
        if(healthPoints<=0){
            deathEffect.SetActive(true);
            isAlive=false;
            StartCoroutine(DeathRoutine());
        }
    }

    IEnumerator DeathRoutine(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("DeathScene");
        yield return null;
    }

    public void moveToCraigBattle(){
        
        SceneManager.LoadScene("CraigBattleScene");
    }

    // public void StepMove(Vector3 direction){
    //     transform.position += direction;
    // }

    // public void MoveTransform(Vector3 vel){
    //     transform.position += vel * speed * Time.deltaTime;
    // }


}
