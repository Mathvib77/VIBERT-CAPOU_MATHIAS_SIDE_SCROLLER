using System.Collections;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] myPatrol_Target;
    [SerializeField] Vector3 direction;

    int curTarget = 0;

    //STATS
    public float speed = 1.5f;
    public bool bwait = false;
    public float waitDuration = 0.5f;

    void Start()
    {
        GetDirection();
    }

    void GetDirection()
    {
        direction = Vector3.Normalize(myPatrol_Target[curTarget].position - transform.position);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitDuration);
        bwait = false;
        GetDirection();
    }

    void Update()
    {
        if (!bwait)
        {   
            transform.position += new Vector3(direction.x * speed * Time.deltaTime, direction.y,0f);

            if (Vector3.Distance(myPatrol_Target[curTarget].position, transform.position) <= 0)
            {
                curTarget++;
                bwait = true;

                if (curTarget >= myPatrol_Target.Length) curTarget = 0;
                StartCoroutine(Wait());
            }
                
        }
    }
}
