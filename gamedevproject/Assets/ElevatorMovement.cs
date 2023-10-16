using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] protected bool mustWait = true;
    protected Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
        //rb.AddForce(new Vector3(0,4,0),ForceMode2D.Force);
        //rb.velocity = new Vector3(0,4,0);
    }


    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!mustWait){
            Ascend(4);
            IEnumerator 
        }*/
    }

    /*void SpawnBoxesOverTime(){
        StartCoroutine(SpawnBoxesOverTimerRoutine());

        IEnumerator SpawnBoxesOverTimerRoutine()
        {

            while(true){
                yield return new WaitForSeconds(1);
                GameObject newBox = Instantiate(boxPrefab,new Vector3(Random.Range(-10,10),Random.Range(-10,10),0),Quaternion.identity);
                Destroy(newBox,10);

            }


            yield return null;
        }
    }*/


    IEnumerator StartDelay()
    {
        while(true){
        yield return new WaitForSeconds(3);
        mustWait = false;
        Ascend(2);
        yield return new WaitForSeconds(3);
        Ascend(0);
        yield return new WaitForSeconds(3);
        Ascend(-2);
        yield return new WaitForSeconds(3);
        Ascend(0);
        }
        yield return null;

    }

    

    private void Ascend(int height){
        rb.velocity = new Vector3(0,height,0);
    }




}
