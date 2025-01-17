
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class Carmovement : MonoBehaviour
{
    public GameObject lights;
    public Transform wheelmeshFL;
    public Transform wheelmeshRL;
    private bool isHighBeamOn = false;

    //Steering Function
    float translation = 0f;
    float speedModifier = 0; //Variabele om snelheid op te slaan
    [SerializeField] float maxSpeed = 80; //Variabele om de maximale snelheid aan te geven
    [SerializeField] float addSpeed = 10;
    public float rotationSpeed = 100.0f;

    public void Update(){
        AccelerateOrBrake();
        Steering();
        Lights_highbeam();
    }

    private void Lights_highbeam(){

        if (Input.GetKeyDown(KeyCode.H)){ //Met de knop H kan het dimlicht of grootlicht getoggled worden
        isHighBeamOn = !isHighBeamOn;

            Light[] allLights = lights.GetComponentsInChildren<Light>();

            foreach (Light lights in allLights){
                lights.intensity = isHighBeamOn ? 5 : 1;
            } 
        }  
    }

    private void AccelerateOrBrake (){
        if (Input.GetKeyDown(KeyCode.W)){
            if (speedModifier < maxSpeed) //Als de snelheid kleiner is dan de maxSpeed kan je gas blijven geven
            {
               translation = speedModifier += addSpeed; // 10 km steeds harder 
            }
            Debug.Log(speedModifier);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            if (speedModifier > 0){ //Als de snelheid groter is dan 0, kan je remmen
               translation = speedModifier -= addSpeed; 
            }
            Debug.Log(speedModifier);
        } 
        transform.Translate(0, 0, translation * Time.deltaTime); // Pas de positie aan 
    }

    void Steering(){
        transform.Translate(0, 0, translation * Time.deltaTime); // Pas de positie aan
        
        float steerAngle = Input.GetAxis("Horizontal") * rotationSpeed;
        float rotation = steerAngle;

        steerAngle = Mathf.Clamp(steerAngle, -5f, 5f); //Dit zorgt ervoor dat de steering angle wordt gelimiteerd

        wheelmeshRL.transform.localRotation = Quaternion.Euler(-180, steerAngle, 0);
        wheelmeshFL.transform.localRotation = Quaternion.Euler(-0.433f, steerAngle, 0);
        
        rotation *= Time.deltaTime;

        transform.Rotate(0, rotation, 0);
    }
}