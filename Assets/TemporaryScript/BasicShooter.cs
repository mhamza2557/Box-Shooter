using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : MonoBehaviour {
    public GameObject projectile;
    public float power = 50.0f;

    public AudioClip shootSFX;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) {
            //Instantiate the Projectile
            GameObject newProjectile = Instantiate (projectile, transform.position + transform.forward, transform.rotation) as GameObject;
            if (!newProjectile.GetComponent<Rigidbody>()) {
                newProjectile.AddComponent<Rigidbody>();
            }

            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);

            if (shootSFX) {
                if (newProjectile.GetComponent<AudioSource>()) {
                    newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                } else {
                    AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
                }
            }
        }
    }
}