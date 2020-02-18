using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectorScript : MonoBehaviour
{

    public GameObject cursor;
    private GameObject selected = null;
    // private Rigidbody rb;

    // public float movementSpeed = 10f;
    // public float fastMovementSpeed = 100f;
    // public float freeLookSensitivity = 3f;
    // public float zoomSensitivity = 10f;
    /// Set to true when free looking (on right mouse button).
    private bool looking = false;
    private Vector3 yDisp = new Vector3(0, 2, 0);

    private Transform xForm = null;
    private Vector3 point = Vector3.zero;

    void Start()
    {
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit/*, 100*/))
        {
            xForm = hit.transform;
            point = hit.point;
            cursor.transform.gameObject.SetActive(true);
        }
        else
        {
            xForm = null;
            point = Vector3.zero;
            cursor.transform.gameObject.SetActive(false);
        }
    }

    void LateUpdate()
    {
        if (xForm != null)
        {
            bool isAgent = xForm.CompareTag("Agent");
            cursor.transform.position = isAgent ? xForm.position + yDisp : point;
            if (Input.GetAxis("Fire1") > 0)
            {
                if (isAgent)
                {
                    selected?.GetComponent<ClickToMove>()?.Deselect();
                    selected = xForm.gameObject;
                    selected.GetComponent<ClickToMove>().Select();
                }
                else
                {
                    selected?.GetComponent<ClickToMove>().Destination(xForm.gameObject.GetComponent<Collider>().ClosestPointOnBounds(point));
                }
            }
        }

        // if (looking)
        // {
        //     float newRotationX = Camera.main.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
        //     float newRotationY = Camera.main.transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
        //     Camera.main.transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        // }

        // float axis = Input.GetAxis("Mouse ScrollWheel");
        // if (axis != 0)
        // {
        //     var zoomSensitivity = this.zoomSensitivity;
        //     Camera.main.transform.position = Camera.main.transform.position + Camera.main.transform.forward * axis * zoomSensitivity;
        // }

        // if (Input.GetKeyDown(KeyCode.Mouse1))
        // {
        //     StartLooking();
        // }
        // else if (Input.GetKeyUp(KeyCode.Mouse1))
        // {
        //     StopLooking();
        // }

    }

    // void OnDisable()
    // {
    //     StopLooking();
    // }

    // public void StartLooking()
    // {
    //     looking = true;
    //     Cursor.visible = false;
    //     Cursor.lockState = CursorLockMode.Locked;
    // }

    // public void StopLooking()
    // {
    //     looking = false;
    //     Cursor.visible = true;
    //     Cursor.lockState = CursorLockMode.None;
    // }
}
