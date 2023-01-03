using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform viewTarget;

    [SerializeField] float XOverlap = 0;
    [SerializeField] float YOverlap = 2.5f;
    [SerializeField] float ZOverlap = -8;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = viewTarget.transform.position + new Vector3(XOverlap, YOverlap, ZOverlap);
        if (PlayerInfo.reachEnd)
        {
            transform.position = viewTarget.transform.position + new Vector3(10, 1, -1);
        }

        transform.LookAt(viewTarget);


    }
}
