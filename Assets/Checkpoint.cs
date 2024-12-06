using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    

    [SerializeField] GameObject Auto;
    private void OnTriggerEnter (Collider Auto){
        if (Auto){
            Debug.Log("Checkpoint!!");
            //Starttimer
        }

    }
}
