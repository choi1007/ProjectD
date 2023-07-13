using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class FontType
{
    public SystemLanguage Language;
    public Font LegacyFont;
    public TMP_FontAsset TextMeshFont;
}

public class TextData
{
    public string Text;
    public FontType FontType = new FontType();
}

public class TextManager : Singleton<TextManager>
{
    [SerializeField] private List<FontType> LanguageFontTypeList;

    public SystemLanguage Language { get; private set; }

    private FontType LanguageFontType;
    private TextData TextData = new TextData();
    private List<TextBinding> TextBindList;

    private void Awake() { }

    public void OnInitialized()
    {
        TextBindList = new List<TextBinding>();
        Language = Application.systemLanguage;
        LanguageFontType = LanguageFontTypeList.Find(x => x.Language == Language);
        if (LanguageFontType == null) LanguageFontType = LanguageFontTypeList.Find(x => x.Language == SystemLanguage.English);
    }

    public void LanguageChange(SystemLanguage _language)
    {
        var findLanguageFont = LanguageFontTypeList.Find(x => x.Language == _language);
        if (findLanguageFont == null) { Debug.LogError("Null Language"); return; }
        else LanguageFontType = findLanguageFont;

        for(int i = 0; i < TextBindList.Count; i++)
        {
            TextBindList[i].TextLoad();
        }
    }

    public TextData TextChange(string _key)
    {
        TextData.Text = _key;
        TextData.FontType.LegacyFont = LanguageFontType.LegacyFont;
        TextData.FontType.TextMeshFont = LanguageFontType.TextMeshFont;
        TextData.FontType.Language = Language;
        return TextData;
    }

    public void AddBind(TextBinding _bind) => TextBindList.Add(_bind);
    public void RemoveBind(TextBinding _bind) => TextBindList.Remove(_bind);
}
