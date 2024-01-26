using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationController
{
    public void Jump(float jumpSpeed);

    public void Run(float runSpeed);

    public void Wall(bool wallBool);
}
