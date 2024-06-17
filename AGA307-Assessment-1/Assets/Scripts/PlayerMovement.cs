using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    [Header(" ----- Projectile Settings-----")]
    public Transform projectileSpawn;
    public GameObject projectilePrefab;
    public int projectileSpeed = 10;
    public int projectileLifetime = 2;

    public GameObject myCamera;


    //Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)        
            velocity.y = -2f;
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)        
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        // instantiated the projectile

        //get the rotation of the camera, and mak ethe bullet rotate
        GameObject proj = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);
        // set projectile speed
        proj.GetComponent<Rigidbody>().velocity = myCamera.transform.forward  * projectileSpeed;
        // destory projectile after set time *
        Destroy(proj, projectileLifetime);
    }

}




