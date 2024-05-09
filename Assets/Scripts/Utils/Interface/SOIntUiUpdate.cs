using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SOIntUiUpdate : MonoBehaviour
{
    public SOInt SOInt;
    
    public TextMeshProUGUI UiCoinsUpdate;

    // Start is called before the first frame update
    void Start()
    {
        UiCoinsUpdate.text = SOInt.value.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        UiCoinsUpdate.text = SOInt.value.ToString();
        
    }
}
