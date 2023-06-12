using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelCreator_Input : MonoBehaviour
{
    // Start is called before the first frame update
    const int max_width = 20;
    const int max_height = 20;
    Ray ray;
    RaycastHit hit;
    [SerializeField]
    private Camera cam;
    private Vector3 lpos;
    [SerializeField]
    private LayerMask pMask;

    public event Action OnClicked, OnExit, OnRightClicked;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Clicked");
            OnClicked?.Invoke();
        }
        if(Input.GetMouseButtonDown(1)) {
            OnRightClicked?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            OnExit?.Invoke();
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        // CAM MOVEMENT, CAREFUL IT RETURNS
        if (cam.transform.position.x > 65.0f) {
            if (horizontal > 0) {return;}
        }
        if (cam.transform.position.x < -65.0f) {
            if (horizontal < 0) {return;}
        }
        if (cam.transform.position.z > 65.0f) {
            if (vertical > 0) {return;}
        }
        if (cam.transform.position.z < -65.0f) {
            if (vertical < 0) {return;}
        }
        cam.transform.position  = Vector3.Lerp(cam.transform.position, cam.transform.position + Vector3.right * horizontal, 0.4f); 
        cam.transform.position  = Vector3.Lerp(cam.transform.position, cam.transform.position + Vector3.forward * vertical, 0.4f);    

    }

    public bool isHoverUI() => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetMapPos() {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
        Ray ray = cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, pMask)) {
            lpos = hit.point;
        }
        return lpos;
    }
}
