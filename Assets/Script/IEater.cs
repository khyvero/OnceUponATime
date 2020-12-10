using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEater : IDentifiable
{

    List<IFood> GetFoodList();

    bool CheckHasFood(string foodId);

    List<IFood> EatFood(List<IFood> food);

    void RemoveFood(IFood food);

}