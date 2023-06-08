using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextBinding : MonoBehaviour
{
    [SerializeField] private string TextKey;

    private Text LegacyText;
    private TextMeshProUGUI TextMeshText;

    private TextManager TextManager;
    private SystemLanguage Language;

    void Awake()
    {
        if (TextManager.HasInstance()) TextManager = TextManager.Instance;
        else
        {
            TextManager.Instance.OnInitialized();
            TextManager = TextManager.Instance;
        }
        Language = SystemLanguage.Unknown;

        LegacyText = GetComponent<Text>();
        if (LegacyText == null) TextMeshText = GetComponent<TextMeshProUGUI>();
    }

    void Start() => TextLoad();

    void OnEnable() => TextManager.AddBind(this);

    void OnDisable() => TextManager.RemoveBind(this);

    public void TextLoad()
    {
        if (LegacyText == null && TextMeshText == null)
        {
            Debug.LogError($"Text OR TextMeshProUGUI NULL {gameObject.name}");
            return;
        }

        if (Language == TextManager.Instance.Language) return;
        LocalizedText();
    }


    private void LocalizedText()
    {
        TextData _textData = TextManager.Instance.TextChange(TextKey);

        if (TextMeshText != null)
        {
            TextMeshText.text = _textData.Text;
            TextMeshText.font = _textData.FontType.TextMeshFont;
        }
        else
        {
            LegacyText.text = _textData.Text;
            LegacyText.font = _textData.FontType.LegacyFont;
        }
    }
}
