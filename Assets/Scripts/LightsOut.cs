using UnityEngine;
using UnityEngine.Events;

public class LightsOut : MonoBehaviour
{
    public GameObject [] lights;
    public UnityEvent solved;
    public UnityEvent unsolved;

    void Awake(){
        for(int i = 0; i < lights.Length; i++){
            lights[i].GetComponent<LightsOutLight>().index = i;
        }
    }

    void Start()
    {
        Scrabmle();
    }

    public void LightClicked(int index){
        lights[index].GetComponent<LightsOutLight>().Toggle();

        if(index != 0 && index != 5 && index != 10 && index != 15 && index != 20){
            lights[index - 1].GetComponent<LightsOutLight>().Toggle();
        }

        if(index != 4 && index != 9 && index != 14 && index != 19 && index != 24){
            lights[index + 1].GetComponent<LightsOutLight>().Toggle();
        }

        if(index != 0 && index != 1 && index != 2 && index != 3 && index != 4){
            lights[index - 5].GetComponent<LightsOutLight>().Toggle();
        }

        if(index != 20 && index != 21 && index != 22 && index != 23 && index != 24){
            lights[index + 5].GetComponent<LightsOutLight>().Toggle();
        }
        Check();
    }

    void Scrabmle(){
        for(int i = 0; i < 50; i++){
            int rand = Random.Range(0, 25);
            LightClicked(rand);
        }
    }

    void Check(){
        foreach (var light in lights)
        {
            if(light.GetComponent<LightsOutLight>().isOn){
                unsolved.Invoke();
                return;
            }
            solved.Invoke();
        }
    }
}
