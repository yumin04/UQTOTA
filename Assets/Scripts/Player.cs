using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour
{
    private string userName;

    public string GetUserName()
    {
        return userName;
    }

    public virtual void SetUserName(string userName)
    {
        this.userName = userName;
    }
    public abstract PlayerMoveKey? GetUserInput();
}
