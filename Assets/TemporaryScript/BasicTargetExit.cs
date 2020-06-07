using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetExit : MonoBehaviour
{
    public float exitAfterSenonds = 10f;
    public float exitAnimationSeconds = 1f;

    private bool startDestroy = false;
    private float targetTime;
    // Start is called before the first frame update
    void Start()
    {
        targetTime = Time.time + exitAfterSenonds;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= targetTime) {
            if (this.GetComponent<Animator>() == null) {
                Destroy(gameObject);
            } else if (!startDestroy) {
                startDestroy = true;
                this.GetComponent<Animator>().SetTrigger("Exit");
                Invoke("KillTarget", exitAnimationSeconds);
            }
        }
    }

    public void KillTarget() {
        Destroy(gameObject);
    }
}
