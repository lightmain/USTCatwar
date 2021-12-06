using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCannon : MonoBehaviour
{
    public Object bullet;
    public float rotateSpeed;
    public float fireOffsetAngle;
    public float range;
    public float muzzleVelocity;
    public int damage;
    public float cooldown;
    private float cooldownCount;
    private Transform bulletInstantiateTransform;
    private Transform myTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldownCount = 0;
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownCount = Mathf.Min(cooldownCount + Time.deltaTime, cooldown + 1);
        if(cooldownCount > cooldown && Input.GetKey(KeyCode.J)) {
            cooldownCount = 0;
            Shoot();
        }
        Turn();
    }

    void Shoot() {
        if(bullet != null) {
            Vector3 positionOffset = myTransform.TransformDirection(new Vector3(0, 1, 0));
            Vector3 angleOffset = new Vector3(0, 0, Random.Range(-fireOffsetAngle, fireOffsetAngle));
            GameObject bulletClone = Instantiate(bullet, positionOffset + GetComponent<Transform>().position, Quaternion.Euler(angleOffset + GetComponent<Transform>().eulerAngles)) as GameObject;
            bulletClone.GetComponent<Bullet>().range = range;
            bulletClone.GetComponent<Bullet>().damage = damage;
            bulletClone.GetComponent<Bullet>().initialVelocity = muzzleVelocity;
        }
    }

    void Turn() {
        myTransform.eulerAngles +=
            new Vector3(0, 0, -Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime);
        
    }
}
