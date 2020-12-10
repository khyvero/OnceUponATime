using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPickable : IDentifiable
{ 
    void PickUp(IHolder holder);

    void PutDown(IHolder holder);

    IHolder GetHolder();

    int EnergyRequired();
}
