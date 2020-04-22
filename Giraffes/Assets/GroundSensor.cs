using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public GiraffeParent CurrentGiraffe;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentGiraffe != null)
            {
                CurrentGiraffe.Motor.MoveToPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out hit, 1000.0f))
            //{
            //    if (hit.transform.GetComponent<GameObject>())
            //    {
            //        CurrentGiraffe.Motor.MoveToPoint(Input.mousePosition);
            //    }
            //}
        }
    }
}

