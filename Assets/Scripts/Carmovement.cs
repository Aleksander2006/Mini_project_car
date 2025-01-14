using UnityEngine;

public class Carmovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public GameObject lights;

    private bool isHighBeamOn = false;

    public void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

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
}
