using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequiredField : MonoBehaviour
{
    InputField thisField;
    [SerializeField]
    Text errorMessage;
    // Start is called before the first frame update
    void Start()
    {
        thisField = gameObject.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
