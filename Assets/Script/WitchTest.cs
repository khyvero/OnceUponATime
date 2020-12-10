using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WitchTest : MonoBehaviour, ICatalog
{
    public const string ID = "MAMA";

    Animator animator;
    bool shouldMove;

    public Transform[] points;
    public Transform target_witchRm;
    int destPoint = 0;

    NavMeshAgent witchAgent;

    

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        animator.SetBool("Move", false);

        witchAgent = this.GetComponent<NavMeshAgent>();
        witchAgent.autoBraking = false;

        GotoNextPoint();
    }

    void Update()
    {

        //if (DoorWitchRm.Instance.GetIsOpen())
        //{
        //    GotoWitchRm();
        //}

        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!witchAgent.pathPending && witchAgent.remainingDistance < 0.5f)
        {
            
            CountDownTimer.GetInstance().CountDown(Random.Range(1f,5f), () =>
            {
                GotoNextPoint();
            });
            
            
        }

    }

    void GotoNextPoint()
    {
        Debug.Log(points.Length);

        //Returns if no points have been set up
        if (points.Length == 0)

            return;

        // Set the agent to go to the currently selected destination.
        witchAgent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;

        animator.SetBool("Move", true);
    }

    void GotoWitchRm()
    {
        witchAgent.destination = target_witchRm.position;
        destPoint = (destPoint + 1) % points.Length;
    }
        

    

    //void SetDestination()
    //{
    //    if (point != null)
    //    {

    //        Vector3 targetVector = point.transform.position;
    //        witchAgent.SetDestination(targetVector);

    //        //animator.SetBool("Move", true);
    //    }

    //}

   
    //void OnTriggerEnter()
    //{
    //    animator.SetBool("Move", false);
    //}

    void ICatalog.ShowCatalog(Object caller)
    {

        CatalogUtil.ShowMessage("Mama - Press T to talk with her \n press SPACE to close the conversation");

    }
}
