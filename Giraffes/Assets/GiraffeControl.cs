using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(GiraffeMotor))]
public class GiraffeControl : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = .1f;
    NavMeshAgent agent;
    Animator anim;
    public LayerMask movementMask;
    Camera cam;
    GiraffeMotor motor;
    Transform Transform;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Transform = GetComponent<Transform>();
        cam = Camera.main;
        motor = GetComponent<GiraffeMotor>();

        agent.speed = agent.speed * transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }

        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
       
    }
}
