using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float xRange = 10.0f;
    public float zRange = 10.0f;
    public float speed = 10.0f;
    
    private float horizontalInput;
    private float verticalInput;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ApplyBoundaries();

        ShootProjectile();
    }

    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(
             new Vector3(
                 GetMovementValue(horizontalInput),
                 0,
                 GetMovementValue(verticalInput)));
    }

    public float GetMovementValue(float inputValue)
    {
        return inputValue * Time.deltaTime * speed;
    }

    private void ApplyBoundaries()
    {
        transform.position =
            new Vector3(
                ApplyRangeBoundary(transform.position.x, xRange),
                transform.position.y,
                ApplyRangeBoundary(transform.position.z, zRange));
    }

    private float ApplyRangeBoundary(float value, float range)
    {
        if (value < -range)
        {
            return -range;
        }
        if (value > range)
        {
            return range;
        }
        else
        {
            return value;
        }
    }

    private void ShootProjectile()
    {
        float degrees = -1;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            degrees = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            degrees = 270;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            degrees = 90;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            degrees = 180;
        }
        if (degrees >= 0)
        {
            CreateProjectile(degrees);
        }
    }

    private void CreateProjectile(float rotationDegrees)
    {
        Quaternion projectileRotation = Quaternion.Euler(
                projectilePrefab.transform.rotation.eulerAngles.x,
                rotationDegrees,
                projectilePrefab.transform.rotation.eulerAngles.z);
        Instantiate(projectilePrefab, transform.position, projectileRotation);
    }
}
