using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
            PlayerControlHandler();
    }

    void PlayerControlHandler()
    {
        float xMove = Input.GetAxisRaw("Horizontal");
        float yMove = Input.GetAxisRaw("Vertical") + 0.01f;
        int defaultAngle = 90;
        if (yMove < 0) defaultAngle += 180;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, defaultAngle - Mathf.Atan(xMove / yMove) * 180 / Mathf.PI);

    }

}
