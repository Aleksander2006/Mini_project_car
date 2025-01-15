using UnityEngine;
using UnityEngine.Rendering;

public class Carmovement : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public GameObject lights;
    public Transform wheelmeshFL;
    public Transform wheelmeshRL;

    float translation = 0f;
    float speedModifier = 30;
    float speed = 80f;

    private bool isHighBeamOn = false;

    public void Update()
    {
        Steering();
        Lights_highbeam();
    }

    void Lights_highbeam(){

        if (Input.GetKeyDown(KeyCode.H)){
        isHighBeamOn = !isHighBeamOn;

            Light[] allLights = lights.GetComponentsInChildren<Light>();

            foreach (Light lights in allLights){

                lights.intensity = isHighBeamOn ? 5 : 1;
                
            } 
        }  
    }

    void Steering (){
        if (Input.GetKeyDown(KeyCode.W)){
            translation = speedModifier += 10; // 10 km steeds harder
            Debug.Log(speedModifier);
            if(speedModifier >= 100){ //limit voor snelheid (110km)
                speedModifier = 100;
            }
        }
        if (Input.GetKey(KeyCode.S)){
            translation = speedModifier -= 10;
            if(speedModifier <= 0){
                speedModifier = 0;
            }
        }
        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation * Time.deltaTime); // Pas de positie aan
        
        float steerAngle = Input.GetAxis("Horizontal") * rotationSpeed;
        float rotation = steerAngle;

        //Dit zorgt ervoor dat de steering angle wordt gelimiteerd.
        steerAngle = Mathf.Clamp(steerAngle, -5f, 5f);

        wheelmeshRL.transform.localRotation = Quaternion.Euler(-180, steerAngle, 0);
        wheelmeshFL.transform.localRotation = Quaternion.Euler(-0.433f, steerAngle, 0);
        
        rotation *= Time.deltaTime;

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);
    }
}
