using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoBall : MonoBehaviour
{

    private float horizontalIndput, verticalIndput;
    private float moveSpeed = .8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void FixedUpdate(){
        horizontalIndput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalIndput, verticalIndput,0) * moveSpeed * Time.deltaTime);
    }
}
