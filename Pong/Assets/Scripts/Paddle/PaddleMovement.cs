using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10;
    
    public GameObject paddleLeft;
    public GameObject paddleRight;

    void Update()
    {
        Vector3 padLeftPos = paddleLeft.transform.position;
        Vector3 padRightPos = paddleRight.transform.position;
        padLeftPos += new Vector3(Input.GetAxis("PaddleRight") * speed * Time.deltaTime, 0, 0);
        padRightPos += new Vector3(Input.GetAxis("PaddleLeft") * speed * Time.deltaTime, 0, 0);
        
        if (padLeftPos.x > 4f)
        {
            padLeftPos.x = 4f;
        }
        if (padLeftPos.x < -4f)
        {
            padLeftPos.x = -4f;
        }
        if (padRightPos.x > 4f)
        {
            padRightPos.x = 4f;
        }
        if (padRightPos.x < -4f)
        {
            padRightPos.x = -4f;
        }
        paddleLeft.transform.position = padLeftPos;
        paddleRight.transform.position = padRightPos;
        //V1
        //Vector3 force = Vector3.right * (Input.GetAxis("Vertical") * speed);
        //_rb.AddForce(force, ForceMode.Force);
    }
}
