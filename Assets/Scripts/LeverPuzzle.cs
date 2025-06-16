using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.Events;
public class LeverPuzzle : MonoBehaviour
{
    public GameObject[] lamps;
    public GameObject[] levers;

    public UnityEvent solved;
    public UnityEvent unsolved;

    void Start()
    {
        shuffle();
    }

    void shuffle() {
        foreach (var lever in levers){
            Lever leverScript = lever.GetComponent<Lever>();
            for(int i = 0; i < 3; i++){
                int rand = Random.Range(0,5);
                leverScript.clicked.AddListener(lamps[rand].GetComponent<Lamp>().toggle);
            }
            leverScript.clicked.AddListener(check);
        }

        foreach(var lamp in lamps){
            Lamp lampScript = lamp.GetComponent<Lamp>();
            lampScript.turnOn();
        }

        for(int i = 0; i < 15; i++){
            int rand = Random.Range(0,5);
            levers[rand].GetComponent<Lever>().clicked.Invoke();
        }

    }

    public void check(){
        foreach (var lamp in lamps)
        {
            if(lamp.GetComponent<Lamp>().isOn == false){
                unsolved.Invoke();
                return;
            }
        }
        solved.Invoke();
    }
}
