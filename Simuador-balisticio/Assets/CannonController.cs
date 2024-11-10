using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class CannonController : MonoBehaviour
{
    public Transform cannon;           
    public GameObject projectilePrefab; 
    public Slider horizontalSlider;    
    public Slider verticalSlider;      
    public Slider forceSlider;         

    public float maxHorizontalAngle = 90f;  
    public float minVerticalAngle = -30f;   
    public float maxVerticalAngle = 60f;    

    private void Start()
    {
        
        horizontalSlider.value = 0;  
        verticalSlider.value = 50;     
        forceSlider.value = 50;       
    }

    private void Update()
    {
        
        float horizontalRotation = horizontalSlider.value * maxHorizontalAngle / 100f;
        cannon.rotation = Quaternion.Euler(cannon.rotation.eulerAngles.x, horizontalRotation, cannon.rotation.eulerAngles.z);

        
        
        float verticalRotation = Mathf.Lerp(minVerticalAngle, maxVerticalAngle, verticalSlider.value / 100f);
        cannon.rotation = Quaternion.Euler(verticalRotation, cannon.rotation.eulerAngles.y, cannon.rotation.eulerAngles.z);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireCannon(forceSlider.value);
        }
    }

    
    void FireCannon(float force)
    {
        
        GameObject proj = Instantiate(projectilePrefab, cannon.position, cannon.rotation);

        
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            Vector3 direction = cannon.forward;

            
            rb.AddForce(direction * force, ForceMode.Impulse);
        }
    }
}


