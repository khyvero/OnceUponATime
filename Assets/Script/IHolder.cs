using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHolder
{
    
    List<IPickable> GetPickables();

    bool CheckHasPickable(string pickableId);

    void AddPickable(IPickable pickable);

    void RemovePickable(IPickable pickable);

    
} 