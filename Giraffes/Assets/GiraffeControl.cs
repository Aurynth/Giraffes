using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GiraffeMotor))]
public class GiraffeControl : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;
    Animator anim;
    public LayerMask movementMask;
    Camera cam;
    GiraffeMotor motor;
    

    //random point on nav mesh to wander too
    private float wanderRadius;


    private float wanderTimer;
    private float MinWanderTime;
    private float MaxWanderTime;

    private Transform Transform;
    private NavMeshAgent agent;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        wanderTimer = Random.Range(MinWanderTime, MaxWanderTime);
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Transform = GetComponent<Transform>();

        cam = Camera.main;
        timer = wanderTimer;
        motor = GetComponent<GiraffeMotor>();

        MinWanderTime = 4;
        MaxWanderTime = 16;
        wanderRadius = 50;

        agent.speed = agent.speed * transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition); Old Version using OnMouseClick to Move Giraffes
            //RaycastHit hit;

            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            motor.MoveToPoint(newPos);
            timer = 0;

            wanderTimer = Random.Range(MinWanderTime, MaxWanderTime);

            //if (Physics.Raycast(ray, out hit, 100, movementMask)) Old Raycast hit movement



        }

        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
       
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;

    }
}
