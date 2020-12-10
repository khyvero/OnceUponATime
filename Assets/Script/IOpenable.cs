using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOpenable
{
     void OpenOrClose(IHolder holder);

     bool IsOpen();
}