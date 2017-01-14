using UnityEngine;


public class UserInput : MonoBehaviour
{
    private CarControl m_Car; 

    float h;
    float accel=1;
    float brake;
    float handbrake;
    float revears;
    bool toggleDriftSystem;


   const string Horizontal_KEY = "Horizontal";
    const string Vertical_KEY = "Vertical";
    const string NITRO_KEY = "Fire2";
    const string HANDBRAKE_KEY = "Fire1";
    //const string DRIFT_SYSTEM_KEY = KeyCode.A;
    bool activeNitro;
   
    int nodrift = 0;

    void Start()
    {
    
        m_Car = GetComponent<CarControl>();

    }

    void Update()
    {

        
        if (nodrift == 0) { m_Car.deactivateDriftSystem(); nodrift = 1; }



        if (h <0.1 && h>-0.1 ) { }else { 
            h = h - (h / 10);
            Update();
        }

        var touch = Input.GetTouch(0);
        if (touch.position.x < Screen.width / 2)
        {
            if (h > -1.1)
            { h = h - (float)0.2; }
        }
        else if (touch.position.x > Screen.width / 2)
        {
            if (h < 1.1)
            { h = h + (float)0.2; }
        }


        handbrake = Input.GetAxis(HANDBRAKE_KEY);

        m_Car.Move(h, accel, brake, handbrake); // pass the input to the car!
                                                // activeNitro = Input.GetButton(NITRO_KEY);
        m_Car.nitro(activeNitro);

    }



    void FixedUpdate()
    {


       
       
    }
   
}

