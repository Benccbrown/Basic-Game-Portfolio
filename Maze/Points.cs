using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{   
    public static int eggs = 0;
    Text egg;
    
    // Start is called before the first frame update
    void Start()
    {
        egg = GetComponent<Text> ();
    }
    

    // Update is called once per frame
    void Update()
    { //this is what the text will say on the screen saying how many easter eggs have been found
        egg.text = ("Easter eggs: " + eggs);
    }
}
