using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPlayerMovement : MonoBehaviour
{
    public LayerMask ground;
    public NavMeshAgent TestPlayer;

    // Ray cast from camera center until it collides with ground
    public Ray moveToRay;

    // Start is called before the first frame update
    void Start()
    {
        TestPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraVector = new Vector3(TestPlayer.transform.position.x, Camera.main.transform.position.y, TestPlayer.transform.position.z);
        Camera.main.transform.position = cameraVector;
        if (Input.GetMouseButtonDown(1))
        {
            moveToRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(moveToRay, out hitInfo, 100, ground))
            {
                TestPlayer.SetDestination(hitInfo.point);
            }
        }
    }
}
