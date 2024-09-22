using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TableData;

[ExcelAsset]
public class CharExcel : ScriptableObject
{
    public List<CharSheet> CharSheet;
    public List<CharUpgradeSheet> CharUpgradeSheet; 
    public List<LevelExpSheet> LevelExpSheet; 
}
