using UnityEngine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine.Rendering;

public class StartingTheCar : MonoBehaviour
{

    private void Start() {
        ChargingBoost();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            Ignition();
       }
    }

    private void ChargingBoost() { //De boost wordt opgeladen

        float boostLimiet = 10;
        float boost = -1;

        while (boost < boostLimiet){
            boost++;
            Debug.Log("Boost level = " + boost);
        }
    }

    private void Ignition() {
        FuelPumping();
        TurnOnVentilation();
    }

    private void FuelPumping() { //Brandstof vloeit naar de motor
        float brandstofToevoer = -1;
        float brandstofLimiet = 10;
        do { 
            brandstofToevoer++;
            Debug.Log("brandstoflimiet = " + brandstofToevoer);
        } while (brandstofToevoer < brandstofLimiet);   
    }

    private void TurnOnVentilation() { //Contact aan, ventilatie gaat aan
        for (float ventilatie = 0; ventilatie <= 10; ventilatie++){
            Debug.Log("Ventilatie = " + ventilatie);
        }
    }
}
