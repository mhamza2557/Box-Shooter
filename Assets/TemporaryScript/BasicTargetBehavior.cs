using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetBehavior : MonoBehaviour
{
    public int scoreAmount = 0;
    public float timeAmount = 0.0f;

    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (GameManager.gm) {
            if (GameManager.gm.gameIsOver) {
                return;
            }
        }

        if (collision.gameObject.tag == "Projectile") {
            if (explosionPrefab) {
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }

            if (GameManager.gm) {
                GameManager.gm.targetHit(scoreAmount, timeAmount);
            }

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
