using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemy : MonoBehaviour
{
    public float moveVelocity;
    private Transform coreTransform;
    private Transform myTransform;
    private Rigidbody2D myRigid;
    // Start is called before the first frame update
    void Start()
    {
        GameObject core = GameObject.Find("Core");
        if(core != null) {
            coreTransform = core.GetComponent<Transform>();
        } else Debug.Log("SampleEnemy.cs: Core Not Found!");

        myTransform = GetComponent<Transform>();
        myRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SetVelocity();
    }

    void SetVelocity() {
        Vector2 target = coreTransform.position - myTransform.position;
        target = target.normalized;
        myRigid.velocity = target * moveVelocity;
        myTransform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.down, target));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Core") {
            Debug.Log("Core Attacked!");
            Destroy(this.gameObject);
        }
    }
}
