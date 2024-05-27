using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public float destroyTimer = 2f;

    void Start()
    {
        
    }

    void Update()
    {
        destroyTimer = destroyTimer - Time.deltaTime;

        if (destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
