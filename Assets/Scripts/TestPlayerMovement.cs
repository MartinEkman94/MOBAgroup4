using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestPlayerMovement : MonoBehaviour
{
    // Used for NavMesh as "Allow walk"
    public LayerMask ground;
    // Used as NavvMesh-agent
    public NavMeshAgent TestPlayer;

    // Ray cast from camera center until it collides with ground, pointing at a direction to move towards.
    public Ray moveToRay;

    // Start is called before the first frame update
    void Start()
    {
        TestPlayer = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // If you hold down c, follow player
        if (Input.GetKey(KeyCode.C))
        {
            // Sets cameraVector to player position, but the vertical position remains.
            Vector3 cameraVector = new Vector3(TestPlayer.transform.position.x, Camera.main.transform.position.y, TestPlayer.transform.position.z);
            Camera.main.transform.position = cameraVector;
        }

        // If you press S or H. Stop player from moving.
        if (Input.GetKeyDown(KeyCode.S))
        {
            TestPlayer.ResetPath();
        }

        // If you right-click
        if (Input.GetMouseButtonDown(1))
        {
            moveToRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(moveToRay, out hitInfo, 100, ground))
            {
                TestPlayer.angularSpeed = 150000 * Time.deltaTime;
                TestPlayer.SetDestination(hitInfo.point);
            }
        }
    }
}
