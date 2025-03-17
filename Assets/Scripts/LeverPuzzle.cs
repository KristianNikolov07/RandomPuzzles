using UnityEngine;
using System.Collections;
using System.Linq;
public class LeverPuzzle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] lamps;
    public GameObject[] levers;
    void Start()
    {
        for(int i = 0; i < 5; i++){
            lamps[i] = GameObject.Find("Lamp" + (i+1));
            levers[i] = GameObject.Find("Lever" + (i+1));

        }
        shuffle();

    }

    void shuffle() {
    for (int i = 0; i < 5; i++) {
        int previous_rand = 0;
        for(int j = 0; j < Random.Range(1,3); j++){
            int rand;
            do{
                rand = Random.Range(0, 5);   
            }while(rand == previous_rand);
            previous_rand = rand;
            levers[i].GetComponent<Lever>().clicked.AddListener(
                lamps[rand].GetComponent<Lamp>().toggle
            ); 
        }

        lamps[i].GetComponent<Lamp>().turnOn();

    }

    for(int i = 0; i < 15; i++){
        int rand = Random.Range(0,5);
        levers[rand].GetComponent<Lever>().clicked.Invoke();
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
