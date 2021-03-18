using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{

    public static cameraShake instance;

    private float shakeTimeRemaining, shakePower, shakeFadeTime;
    private Vector3 oldCamPosition;
    // Start is called before

    private void Start()
    {
        oldCamPosition = transform.position;
        instance = this;
    }

    private void Update()
    {

        transform.position = oldCamPosition;
    }


    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float yAmount = Random.Range(-1f, 1f) * shakePower;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);
        }
    }

    public void initializeShake(float strength, float timer)
    {
        shakePower = strength;
        shakeTimeRemaining = timer;
        shakeFadeTime = strength / timer;
    }
}
