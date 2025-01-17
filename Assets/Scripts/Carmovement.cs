
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class Carmovement : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject Headlights;
    public GameObject Brakelights;
    public Transform wheelmeshFL;
    public Transform wheelmeshRL;
    private bool isHighBeamOn = false;

    //Steering Function
    float translation = 0f;
    float speed = 0; //Variabele om snelheid op te slaan
    [SerializeField] float maxSpeed = 80; //Variabele om de maximale snelheid aan te geven
    [SerializeField] float addSpeed = 10;

    [SerializeField] float test = 10;
    public float rotationSpeed = 100.0f;
    float steerAngle;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    public void Update(){
        FrontLightsHighbeam();
        BrakeLights();
        AccelerateOrBrake();
        Steering();
    }

    void FixedUpdate(){
        ApplyDownforce();
    }

    void ApplyDownforce()
    {
        if (!IsGrounded()) // Alleen downforce toepassen als de auto niet op de grond is
        {
            rb.AddForce(-transform.up * 100f); // Pas de kracht aan op basis van je behoefte
        }
    }

    bool IsGrounded()
    {
        // Controleer of de auto de grond raakt
        return Physics.Raycast(transform.position, -transform.up, 1.5f); // 1.5f is de afstand tot de grond
    }

    void FrontLightsHighbeam(){
        if (Input.GetKeyDown(KeyCode.H)){ //Met de knop H kan het dimlicht of grootlicht getoggled worden
        isHighBeamOn = !isHighBeamOn;

            Light[] allLights = Headlights.GetComponentsInChildren<Light>();

            foreach (Light lights in allLights){
                lights.intensity = isHighBeamOn ? 5 : 1;
            } 
        }
    }

    void BrakeLights(){
        Light[] allLights = Brakelights.GetComponentsInChildren<Light>();
            foreach (Light lights in allLights){
            lights.intensity = Input.GetKey(KeyCode.S) ? 5: 1;
        }
    }

    void AccelerateOrBrake (){
        if (Input.GetKeyDown(KeyCode.W)){
            if (speed < maxSpeed) //Als de snelheid kleiner is dan de maxSpeed kan je gas blijven geven
            {
               translation = speed += addSpeed; // 10 km steeds harder 
               rotationSpeed -= 17; //Hoe sneller je gaat des te langzamer de rotatie wordt
               Debug.Log(rotationSpeed);
            }
            Debug.Log(speed);
        }
        if (Input.GetKeyDown(KeyCode.S)){
            if (speed > 0){ //Als de snelheid groter is dan 0, kan je remmen
               translation = speed -= addSpeed;
               rotationSpeed += 17;
               Debug.Log(rotationSpeed); 
            }
            Debug.Log(speed);
            BrakeLights(); //Als de auto wordt geremd, gaan de remlichten aan
        } 
        transform.Translate(0, 0, translation * Time.deltaTime); // Pas de positie aan 
    }

    void Steering(){
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