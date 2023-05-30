using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public int MaxHp { get; private set; }
    public int Hp { get; private set; }
    public bool FullHp { get; private set; }
    public bool Dead { get; private set; }
    public bool Revival { get; private set; }

    // todo. revival , maxhp �� id �޾ƿͼ� ó���ؾߵ�
    public void InitHp(uint _id)
    {
        MaxHp = 100;
        Hp = MaxHp;
        FullHp = true;
        Dead = false;
        Revival = false;
    }

    public void AddHp(int _hp)
    {
        if (Dead) return;

        if (Hp >= MaxHp)
        {
            FullHp = true;
            return;
        }

        if(Hp <= 0 )
        {
            Hp = 0;
            Dead = true;
            return;
        }

        Hp += _hp;
    }
}
