using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeMovement : MonoBehaviour
{
    float edgeSize = 30f;
    [SerializeField]
    float speed;

    bool EdgeScroll = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward = forward.normalized;
        right = right.normalized;
        if (Input.GetKeyDown(KeyCode.T))
        {
            EdgeScroll = !EdgeScroll;
        }
        keyboardScrolling(forward, right);
        EdgeScrolling(forward, right);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -100, 100), transform.position.y, Mathf.Clamp(transform.position.z, -100, 100));
    }


    void keyboardScrolling(Vector3 forward, Vector3 right)
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");

        forward = forward * speed * inputY * Time.deltaTime;
        right = right * speed * inputX * Time.deltaTime;
        Vector3 movement = forward + right;
        transform.Translate(movement, Space.World);
    }

    void EdgeScrolling(Vector3 forward,Vector3 right)
    {
        if (!EdgeScroll) { return; }
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            right = right * speed * Time.deltaTime;
        }
        else
        if (Input.mousePosition.x < edgeSize)
        {
            right = -right * speed * Time.deltaTime;
        }
        else
        {
            right *= 0;
        }

        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            forward = forward * speed * Time.deltaTime;
        }
        else
        if (Input.mousePosition.y < edgeSize)
        {
            forward = -forward * speed * Time.deltaTime;
        }
        else
        {
            forward *= 0;
        }


        Vector3 movement = forward + right;
        transform.Translate(movement, Space.World);
    }

}
