using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float powerUpForce = 15.0f;
    public bool hasPowerUp = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine("PowerUpDelay");
        }
    }

    IEnumerator PowerUpDelay()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp =false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            // Debug.Log("Working");
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = (other.gameObject.transform.position - transform.position).normalized;

            enemyRb.AddForce(forceDirection* powerUpForce, ForceMode.Impulse);
        }
    }
}
