using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float jumpSpeed = 2f;
    public float jumpHeight = 1.5f;
    public float jumpHeightSpeedFactor = 0.5f;
    bool jumping = false;
    bool up = false;
    bool down = false;

    Rigidbody rb;

    float normalHeigt;
    // Start is called before the first frame update
    void Start()
    {
        normalHeigt = this.transform.position.y;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // TODO: Touch input
    void Update()
    {
        if (jumping)
        {
            Jump();
            return;
        }


        if (Input.GetMouseButtonDown(0))
        {
            //print("Jump!");
            jumping = true;
            up = true;
        }



    }

    // TODO: use Rigidbody instead of transform.position 

    void Jump()
    {

        // Jump up and down slower when near the highest point

        // 1- (0.5 *   (aktuelle höhe / zielhöhe)) 
        // 1 wenn unten. 0.5 wenn oben

        float jumpSpeedHeightModifier = 1 - ((jumpHeightSpeedFactor) * (this.transform.position.y / (normalHeigt + jumpHeight)));

        // Attention: deltaTime added. 
        float currentJumpSpeed = Time.deltaTime * jumpSpeed * jumpSpeedHeightModifier;
        //print("jumpspeed: " + currentJumpSpeed);

        if (up)
        {
            //rb.velocity = new Vector3(0f, 1f, 0f) * currentJumpSpeed;
            //rb.velocity.Set(0f,currentJumpSpeed, 0f);
            this.transform.position += new Vector3(0f, 1f, 0f) * currentJumpSpeed;
            if (this.transform.position.y >= normalHeigt + jumpHeight)
            {
                // down
                up = false;
                down = true;
            }
            //print("up");
            return;
        }

        if (down)
        {

            if (this.transform.position.y <= normalHeigt)
            {
                down = false;
                jumping = false;
                //rb.velocity = new Vector3(0f, 0f,0f);
            }
            //rb.velocity = new Vector3(0f, -1f, 0f) * currentJumpSpeed;
            this.transform.position -= new Vector3(0f, 1f, 0f) * currentJumpSpeed;
            //print("down");
        }

    }

}
