using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Action<AnimationCurve> OnJump;
    public AnimationCurve Curve;
    public Vector3 MousePosition;
    public Vector3 StartPosition;
    public float currentTime;
    private void Awake()
    {
    }

    private void Jump(AnimationCurve obj)
    {
        currentTime += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, obj.Evaluate(currentTime), transform.position.z);
        if(currentTime > 1)
        {
            OnJump -= Jump;
            currentTime = 0;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartPosition = (Input.mousePosition / new Vector2(Screen.width, Screen.height)) - Vector2.one * 0.5f;
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            MousePosition = StartPosition - ((Vector3)(Input.mousePosition / new Vector2(Screen.width, Screen.height)) - Vector3.one * 0.5f);
            transform.eulerAngles = new Vector3(MousePosition.y, -MousePosition.x) * 135;
        }

        var horizontal=Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.position+=(transform.forward * vertical + transform.right* horizontal) * 2 * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump += Jump;
        }

        OnJump?.Invoke(Curve);




    }
}
