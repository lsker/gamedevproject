using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BulletSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject asgorePrefab;
    [SerializeField] Transform playerChar;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject secondText;
    [SerializeField] GameObject finalText;
    [SerializeField] GameObject welcomeInText;

    [SerializeField] GameObject attackButton;
    [SerializeField] GameObject goodResponseButton;
    [SerializeField] GameObject badResponseButton;
    
    bool hasBeenAttacked=false;
    bool hasResponded=false;
    bool isntDone = true;
    bool tempBool=true;
    bool goodAttackTaken=false;
    bool goToVictoryScene=false;
     /*IEnumerator AttackManager(){
        
        yield return null;
     }*/

    
    void Start(){
        //SpawnBullets();
        //AsgoreAttack();
        //StartCoroutine(SpawnAsgoreAttack());
        startText.SetActive(false);
        secondText.SetActive(false);
        finalText.SetActive(false);
        welcomeInText.SetActive(false);
        attackButton.SetActive(false);
        goodResponseButton.SetActive(false);
        badResponseButton.SetActive(false);
        StartCoroutine(AttackScript());
    }

    public void attacked(){
        Debug.Log("attack bullet spawner gotten");
        finalText.SetActive(true);
        hasBeenAttacked=true;
    }
    
    public void goodIntroduction(){
        //GetComponent<SpriteRenderer>().color = new Color(178, 255, 188, 1f);
        Debug.Log("good intro pressed");
        goodAttackTaken=true;
        hasResponded=true;
        //GetComponent<AudioSource>().Play();
        goodResponseButton.SetActive(false);
        badResponseButton.SetActive(false);
    }

    public void badIntroduction(){
        //GetComponent<SpriteRenderer>().color = new Color(178, 255, 188, 1f);
        Debug.Log("bad intro pressed");
        hasResponded=true;
        goodAttackTaken=false;
        //GetComponent<AudioSource>().Play();
        goodResponseButton.SetActive(false);
        badResponseButton.SetActive(false);
    }
    
    //void AsgoreAttack(){
        

        IEnumerator SpawnAsgoreAttack()
        {
            int numAsgoreAtk = 13;
            while(numAsgoreAtk > 0){
                
                yield return new WaitForSeconds(1);
                int initDistance = 4;
                float safeRange = Random.Range(0,6*Mathf.PI);
                float upperSafeRange = (safeRange + ( Mathf.PI / 6 ));
                float lowerSafeRange = (safeRange - ( Mathf.PI / 6 ));
                
                for(int i =0; i<10; i++){
                
                float currentAngle = Random.Range(0,6*Mathf.PI);
                //Debug.Log(currentAngle);
                /*if(!(currentAngle < lowerSafeRange || upperSafeRange < currentAngle)){
                    currentAngle = Random.Range(0,6*Mathf.PI);
                }*/
                float xval = initDistance * Mathf.Cos(currentAngle);
                //Debug.Log(xval);
                float yval = initDistance * Mathf.Sin(currentAngle);
                //Debug.Log(yval);
                if(!(lowerSafeRange < currentAngle && currentAngle < upperSafeRange)){
                    GameObject newBox = Instantiate(asgorePrefab,new Vector3(xval,yval,0),Quaternion.identity);
                
                //transform.position += vel;

                Rigidbody2D rb = newBox.GetComponent<Rigidbody2D>();
                Vector3 vel = Vector3.zero;
                vel.x=-xval/3;
                vel.y=-yval/3;
                vel.z=0;
                rb.velocity =  new Vector3(-xval/initDistance, -yval/initDistance, 0);
                if(transform.position.x == 0){
                    Destroy(newBox);
                }
                Destroy(newBox,initDistance);
                }else{
                    //do nothing
                }
                
                }
                numAsgoreAtk--;
                //Launch();
                




                

            }


            yield return null;
        }
    

    

        IEnumerator AttackScript(){
            
            while(isntDone){
                startText.SetActive(true);
                yield return new WaitForSeconds(2);
                StartCoroutine(SpawnBullets());
                yield return new WaitForSeconds(10);
                startText.SetActive(false);
                StopCoroutine(SpawnBullets());
                while(!hasResponded){
                    //attackButton.SetActive(true);
                    secondText.SetActive(true);
                    goodResponseButton.SetActive(true);
                    badResponseButton.SetActive(true);
                    yield return new WaitForSeconds(3);
                }
                //attackButton.SetActive(false);
                goodResponseButton.SetActive(false);
                badResponseButton.SetActive(false);
                secondText.SetActive(false);
                if(goodAttackTaken==false){
                    StartCoroutine(SpawnAsgoreAttack());
                    yield return new WaitForSeconds(19);
                    StopCoroutine(SpawnAsgoreAttack());
                    //finalText.SetActive(true);
                    attackButton.SetActive(true);
                    while(!hasBeenAttacked){
                        yield return new WaitForSeconds(6);
                    }
                    finalText.SetActive(false);
                    attackButton.SetActive(false);
                    tempBool=false;
                }
                if(goodAttackTaken==true){
                    welcomeInText.SetActive(true);
                    yield return new WaitForSeconds(6);
                    goToVictoryScene=true;
                    
                }
                
            }
            isntDone=false;
            yield return null;
            //SpawnBullets();
            
        }
        
    

    /*void SpawnBullets(){
        StartCoroutine(SpawnBullets());

    }*/

    IEnumerator SpawnBullets()
        {
            int numNapstablookAtk = 9;
            while(numNapstablookAtk >0){

                
                yield return new WaitForSeconds(1);
                
                for(int i =0; i<4; i++){
                    int xval = Random.Range(-3,3);
                GameObject newBox = Instantiate(bulletPrefab,new Vector3(xval,Random.Range(4,5),0),Quaternion.identity);
                
                //transform.position += vel;

                Rigidbody2D rb = newBox.GetComponent<Rigidbody2D>();
                Vector3 vel = Vector3.zero;
                vel.x=-xval*Random.Range(0,2);
                vel.y=Random.Range(-8,-6);
                rb.velocity =  vel - transform.position;
                Destroy(newBox,10);
                //Launch();
                }
                numNapstablookAtk--;




                

            }


            yield return null;
        }

    void Update(){
        if(!tempBool ){
            SceneManager.LoadScene("JailScene");
            //SceneManager.LoadScene("CraigVictoryScene");
        }
        if(goToVictoryScene){
            SceneManager.LoadScene("MeetingTheBossScene");
        }
    }

}
