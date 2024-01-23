using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTranslate : MonoBehaviour
{
    // Calculate the distance of the user from the center of the area
    public float translate_gain = 1.26f;
    public float rotation_gain = 1.5f;
    public float curvature_gain = 0.1f;

    public float m_speed = 0.1f;
    public float r_speed = 0.3f;
    GameObject playerCam;
    GameObject playerReal;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = GameObject.Find("PlayerCam");
        playerReal = GameObject.Find("PlayerReal");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            smartUserDisplace(1.0f, 0.0f);
            playerCam.transform.position += playerCam.transform.forward * m_speed;
            playerReal.GetComponentInChildren<Animator>().SetBool("Walk", true);
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            smartUserDisplace(-1.0f, 0.0f);
            playerCam.transform.position += -playerCam.transform.forward * m_speed;
            playerReal.GetComponentInChildren<Animator>().SetBool("Walk", true);
        }
        else
        {
            playerReal.GetComponentInChildren<Animator>().SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            smartUserDisplace(0.0f, -1.0f);
            playerCam.transform.eulerAngles -= new Vector3(0.0f, r_speed, 0.0f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            smartUserDisplace(0.0f,1.0f);
            playerCam.transform.eulerAngles += new Vector3(0.0f, r_speed, 0.0f);
        }
        
        
        
    }

    void smartUserDisplace(float trans=0.0f, float rot =0.0f)
    {
        float distanceFromCenter = Vector3.Distance(new Vector3(playerReal.transform.position.x, 0, playerReal.transform.position.z), Vector3.zero);

        // Adjust translation and rotation gains based on the distance
        float translate_gain = Mathf.Lerp(0.86f, 1.26f, distanceFromCenter / (10 / 2));
        float rotation_gain = Mathf.Lerp(0.67f, 1.24f, distanceFromCenter / (10 / 2));

        translateUser(trans);
        rotateUser(rot);
        curveUser(trans);
    }

    //to complete
    void translateUser(float trans)
    {  
        playerReal.transform.position += playerReal.transform.forward * m_speed * trans / translate_gain;
    }

    //to complete
    void rotateUser(float rot)
    {
        playerReal.transform.eulerAngles += (new Vector3(0.0f, r_speed * rot, 0.0f) / rotation_gain);
    }

    //to complete
    void curveUser(float trans)
    {
        Vector3 camTrans = playerCam.transform.forward * m_speed;
        float distanceFromCenter = Vector3.Distance(new Vector3(playerReal.transform.position.x, -1f, playerReal.transform.position.z), new Vector3(-11.13f, -1f, -1f ));
        Debug.Log("distance from center: "+distanceFromCenter);
        curvature_gain = Mathf.Lerp(0.01f, .5f, distanceFromCenter);
        float rotationAngle = 360f * trans * curvature_gain * camTrans.magnitude/ (2 * Mathf.PI); 
        playerReal.transform.Rotate(Vector3.up, rotationAngle);
    }   

}
