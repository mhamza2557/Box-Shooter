using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDistructor : MonoBehaviour
{
    public float timeOut = 1.0f;
    public bool detachChildren = true;

    private void Awake() {
        Invoke("DestroyNow", timeOut);
    }

    void DestroyNow() {
        if (detachChildren)
        {
            transform.DetachChildren();
        }

        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
