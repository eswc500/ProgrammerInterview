using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Camera_Follow : MonoBehaviour
{
    [Header("Main Config")]
    public Camera mainCamera;
    public Transform target;
    public float smoothSpeed = 0.125f; 
    public float originalCameraSize = 5f;
    public Vector3 offset = Vector3.zero;


    [Space(10)]
    [Header("Shop Config")]
    public float newCameraSize = 2.25f;
    public Vector3 targetVector;
    public float duration = 2.0f;


    private void OnEnable()
    {
        mainCamera = this.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null)
        {
            return; 
        }

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void setShop()
    {
        mainCamera.DOOrthoSize(newCameraSize, duration);

        DOTween.To(() => offset, x => offset = x, targetVector , duration)            
            .OnComplete(() =>
            {
                Debug.Log("Shop Ready");
                target.gameObject.GetComponent<Movement_Controller>().enabled = false;
            });
    }

    public void exitShop()
    {
        mainCamera.DOOrthoSize(originalCameraSize, duration);

        DOTween.To(() => offset, x => offset = x, Vector3.zero, duration)
            .OnComplete(() =>
            {
                Debug.Log("Shop Closed");
                target.gameObject.GetComponent<Movement_Controller>().enabled = true;
            });
    }
}
