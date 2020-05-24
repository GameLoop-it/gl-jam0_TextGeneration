using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextGenerator : MonoBehaviour
{
    public Sprite[] Fontface;
    public string Text;
    public SpriteRenderer TextCharacter;

    // Start is called before the first frame update
    void Start()
    {
        GenerateText(Text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateText(string text)
    {
        if(text != null) {
            Text = text;
            int column = 0;
            foreach(char ch in Text) {
                if(Char.IsDigit(ch)) {
                    GenerateChar(Fontface[ch - '0'], column);
                } else if(char.IsLetter(ch)) {
                    char chu = char.ToUpper(ch);
                    GenerateChar(Fontface[chu - 'A' + 10], column);
                } else if(ch == '.' || ch == ',') {
                    GenerateChar(Fontface[36], column);
                } else if(ch == ':') {
                    GenerateChar(Fontface[37], column);
                }
                ++column;
            }
        }
    }

    void GenerateChar(Sprite sprite, int column) {
        GameObject o = Instantiate(TextCharacter.gameObject, transform);
        o.transform.localPosition = new Vector3(column*10, 0, 0);
        o.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
