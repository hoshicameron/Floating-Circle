using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{
    [SerializeField] private Vector2 RotateRange=new Vector2(-3f,3f);
    [SerializeField] private float deltaSpeed=3f;
    [SerializeField] private float delay = 6f;
    [SerializeField] private float targetRot = 15f;
    [SerializeField] private float rotationInterval=0.05f;

    private float rot;
    private bool rotate;
    private float targetRotation;
    void Start()
    {
        StartCoroutine(Rotation());
    }

    private IEnumerator Rot()
    {
        float t = 0;
        yield return new WaitForSeconds(delay);
        while (t<2)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, targetRotation),
                rotationInterval*deltaSpeed*Time.deltaTime);

            t += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    private IEnumerator Rotation()
    {
        while (true)
        {
            targetRotation = targetRot;
            yield return StartCoroutine(Rot());

            targetRotation = 0f;
            yield return StartCoroutine(Rot());

            targetRotation = -targetRot;
            yield return StartCoroutine(Rot());

            targetRotation = 0f;
            yield return StartCoroutine(Rot());


        }
    }

}// Class
