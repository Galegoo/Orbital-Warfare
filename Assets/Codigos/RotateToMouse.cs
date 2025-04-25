using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour {
    public Camera cam;
    public float maxLenght;

    public Ray rayMouse;

    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    public GunController theGun;
    public RaycastHit hit;

    public bool atingeObjecto = false;

    // Update is called once per frame
    void Update() {
        if (cam != null) {
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maxLenght)) {
                atingeObjecto = true;
                RotateToMouseDirection(this.gameObject, hit.point);

                /*check object collider tag
                if (hit.collider.gameObject.tag == "Asteroide")
                {
                    Debug.Log("yayaya");
                    maxLenght = hit.collider.gameObject.transform.position.z;
                }
                else
                {
                    Debug.Log("simsimsim");
                    maxLenght = 50;
                }
                */


            } else {
                atingeObjecto = false;
                var pos = rayMouse.GetPoint(maxLenght);
                RotateToMouseDirection(this.gameObject, pos);
            }

        } else {
            Debug.Log("No camera");
        }

        if (Input.GetMouseButtonDown(0))
            theGun.isFiring = true;
        if (Input.GetMouseButtonUp(0)) {
            theGun.isFiring = false;
        }
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination) {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion getRotation() {
        return rotation;
    }
}
