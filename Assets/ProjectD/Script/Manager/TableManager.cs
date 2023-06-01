using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : Singleton<TableManager>
{
    public CharExcel CharTable;
    public ItemExcel ItemTable;
    public SkillExcel SkillTable;

    public void OnWake() { }
}
