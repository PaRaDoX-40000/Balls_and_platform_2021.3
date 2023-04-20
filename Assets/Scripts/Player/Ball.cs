using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : Entity
{    
    private BallSticking _ballSticking;
   
    public BallSticking BallSticking => _ballSticking;

    private void Start()
    {       
        _ballSticking = GetComponent<BallSticking>();

    }
}
