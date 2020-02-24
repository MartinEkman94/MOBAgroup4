using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour
{
    public GameObject TestPlayer = new GameObject();

    // Current positions
    public Vector3 currentPosition;
    public Vector3 currentRotation;

    // Desired positions
    public Vector3 targetPosition;
    public Vector3 targetRotation;

    // Ray cast from camera center until it collides with ground
    public Ray moveToRay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveToRay.origin = Camera.main.transform.position;
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TestPlayer.transform.rotation = Quaternion.Euler(0, Mathf.Atan(Input.mousePosition.x / Input.mousePosition.z), 0);
            Debug.Log(Input.mousePosition);
        }
    }
}
