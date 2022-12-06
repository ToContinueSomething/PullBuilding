using TMPro;
using UnityEngine;

public class TextPresenter : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;

   public void UpdateData(int value)
   {
      _text.text = value.ToString();
   }
}
