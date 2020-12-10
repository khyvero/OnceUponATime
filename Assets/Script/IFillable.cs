using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFillable 
{
    void Fill();

    void Throw();

    bool IsEmpty();
}
