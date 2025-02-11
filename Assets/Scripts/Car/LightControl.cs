using UnityEngine;

public class LightControl : MonoBehaviour
{
    private bool isHighBeamOn = false;
    public GameObject Headlights;
    public GameObject Brakelights;
    void Update()
    {
        FrontLightsHighbeam();
        BrakeLights();
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

    public void BrakeLights(){
        Light[] allLights = Brakelights.GetComponentsInChildren<Light>();

            foreach (Light lights in allLights){
            lights.intensity = Input.GetKey(KeyCode.S) ? 5: 1;
        }
    }
}
