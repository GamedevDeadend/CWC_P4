using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody playerRb;

    public GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float forceForward = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward* forceForward* speed* Time.deltaTime, ForceMode.VelocityChange);
    }
}
