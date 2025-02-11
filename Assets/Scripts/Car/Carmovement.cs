
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Carmovement : MonoBehaviour
{
    private LightControl carLights;
    public Transform wheelmeshFL;
    public Transform wheelmeshRL;
    float translation = 0f;
    float speed = 0; //Variabele om snelheid op te slaan
    [SerializeField] float maxSpeed = 80; //Variabele om de maximale snelheid aan te geven
    [SerializeField] float addSpeed = 10;
    [SerializeField] float rotationSpeed = 100.0f;
    float steerAngle;

    void Start(){
        carLights = GetComponent<LightControl>();
    }

    public void Update(){
        AccelerateOrBrake();
        Steering();
    }

    private void AccelerateOrBrake (){
        if (Input.GetKeyDown(KeyCode.W)){
            if (speed < maxSpeed) //Als de snelheid kleiner is dan de maxSpeed kan je gas blijven geven
            {
               translation = speed += addSpeed; // 10 km steeds harder 
               rotationSpeed -= 17; //Hoe sneller je gaat des te langzamer de rotatie wordt
            }
            //Debug.Log(speed);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            if (speed > 0){ //Als de snelheid groter is dan 0, kan je remmen
               translation = speed -= addSpeed;
               rotationSpeed += 17;
            }
            //Debug.Log(speed);
            carLights.BrakeLights(); //Als de auto wordt geremd, gaan de remlichten aan
        } 
        transform.Translate(0, 0, translation * Time.deltaTime); // Pas de positie aan 
    }

    private void Steering(){
        transform.Translate(0, 0, translation * Time.deltaTime); // Pas de positie aan
        
        if (speed >= 10){
            steerAngle = Input.GetAxis("Horizontal") * rotationSpeed;   
        }

        float rotation = steerAngle;

        steerAngle = Mathf.Clamp(steerAngle, -7f, 7f); //Dit zorgt ervoor dat de steering angle wordt gelimiteerd

        wheelmeshRL.transform.localRotation = Quaternion.Euler(-180, steerAngle, 0);
        wheelmeshFL.transform.localRotation = Quaternion.Euler(-0.433f, steerAngle, 0);
        
        rotation *= Time.deltaTime;

        transform.Rotate(0, rotation, 0);
    }
}