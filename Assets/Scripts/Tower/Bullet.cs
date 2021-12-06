using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float initialVelocity;
    public float range;
    public int damage;
    private Rigidbody2D myRigidbody;
    private Transform myTransform;
    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        initialPosition = myTransform.position;

        myRigidbody.velocity = myTransform.TransformDirection(Vector2.up * initialVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        RangeDestroy();
    }

    void RangeDestroy() {
        if(Vector3.Magnitude(initialPosition - myTransform.position) > range) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Debug.Log("Hit Enemy!");
            Destroy(this.gameObject);
        }
    }
}
