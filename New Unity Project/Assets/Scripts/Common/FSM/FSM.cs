using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Common.FSM
{

public class FSM
{


    private readonly string name;

    public string Name
    {
        get
        {
            return name;
        }
    }

    public FSM(string name)
    {
        this.name = name;
    }

    public void Start()
    {
    }    

    public void ChangeToState()
    {
    }

    public void EnterState()
    {
    }

    private void ExitState()
    {
    }

    public void Update()
    {
    }

    public void SendEvent()
    {
    }








    }
