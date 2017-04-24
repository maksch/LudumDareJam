using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace TextImport{
    public class TextImporter : MonoBehaviour{

        public List<string> ImportTextSplit(TextAsset text_Asset){
            string textStart = text_Asset.text;
            List<string> lines = new List<string>(0);
            lines.AddRange(textStart.Split("\n"[0]));
            return lines;
        }

    }
}
