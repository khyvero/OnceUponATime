using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFood : IPickable 
{
    bool IsFor(IEater eater);

    IEater GetEater();

    void EatenBy(IEater eater);

    int GetEnergy();
}
