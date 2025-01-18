using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public float laptime;
    public float besttime;
    private bool TimeStarted = false;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    public TextMeshProUGUI Ltime;
    public TextMeshProUGUI Btime;

    
    void Update(){
        if (TimeStarted == true){
            laptime = laptime + Time.deltaTime;
            Ltime.text = "Laptime: " + laptime.ToString("F2");  
        }
    }
    public void OnTriggerEnter(Collider other) {

        if (other.gameObject.name == "Start/Finish"){ // De Tijd is gestart als de finish wordt getriggered

            if (TimeStarted == false){ //Als de tijd voor het eerst van start gaat
                TimeStarted = true;
                checkpoint1 = false;  
                checkpoint2 = false;
            }   
            
            if(checkpoint1 == true && checkpoint2 == true){
                if(besttime == 0){

                    besttime = laptime;
                }    
                if (laptime < besttime){

                    besttime = laptime;
                }
                Btime.text = "Best: " + besttime.ToString("F2");
                laptime = 0;
            }
        } 

        if (other.gameObject.name == "Checkpoint1"){
        checkpoint1 = true; 
        Debug.Log("Checkpoint 1");
        } 

        if (other.gameObject.name == "Checkpoint2"){ 
        checkpoint2 = true; 
        Debug.Log("Checkpoint 2");
        }  
    }
}
