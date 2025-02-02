using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player
{
    private string userName;
    private Character character;
    private CharacterInfo characterInfo;

    public string GetUserName()
    {
        return userName;
    }

    public virtual void SetUserName(string userName)
    {
        this.userName = userName;
    }
    public abstract PlayerMoveKey GetUserInput();

    public virtual MoveData GetMoveData(PlayerMoveKey m)
    {
        switch (m)
        {
            case(PlayerMoveKey.LightForward): return GetCharacter().ExecuteLightForward();
            case(PlayerMoveKey.LightDown): return GetCharacter().ExecuteLightDown();
            case(PlayerMoveKey.LightUp): return GetCharacter().ExecuteLightUp();
            case(PlayerMoveKey.HeavyForward): return GetCharacter().ExecuteHeavyForward();
            case(PlayerMoveKey.HeavyDown): return GetCharacter().ExecuteHeavyDown();
            case(PlayerMoveKey.HeavyUp): return GetCharacter().ExecuteHeavyUp();
            case(PlayerMoveKey.Block): return GetCharacter().ExecuteBlock();
        }
        return new MoveData();
    }
    public void SetCharacter(CharacterInfo c)
    {
        characterInfo = c;
        switch (c)
        {
            case CharacterInfo.Jon: { 
                this.character = new JohnMoscow();
                break;
            }
            case CharacterInfo.Sandie:
            {
                this.character = new Sandie();
                break;
            }
            case CharacterInfo.Tom:
                this.character = new Tom();
                break;
        }
    }
    public Character GetCharacter()
    {
        return character;
    }

    public virtual CharacterInfo GetCharacterInfo()
    {
        return characterInfo;
    }
}
