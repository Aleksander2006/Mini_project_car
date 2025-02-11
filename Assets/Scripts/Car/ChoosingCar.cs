using UnityEngine;

public class ChoosingCar : MonoBehaviour
{
    [SerializeField] int car = 2;

    void Start()
    {
        ChooseCar();
    }

    private void ChooseCar(){
        switch (car){
            case 1:
                Debug.Log("SUV");
            break;

            case 2:
                Debug.Log("SEDAN");
            break;

            case 3:
                Debug.Log("HATCHBACK");
            break;

            default:
                Debug.Log("SPORTSCAR");
            break;
        }
    }
}
