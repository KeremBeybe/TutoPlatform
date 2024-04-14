using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterChange : MonoBehaviour
{
    public GameObject[] CharactersList; // Görünürlüğünü kontrol etmek istediğiniz game objectlerin dizisi
    public int currentObjectIndex; // Şu anda kontrol edilen game object'in dizideki dizini


     void Start()
    {
        ToggleGameObject(0, true);
    }

    void Update()
    {
        // Sol yön tuşuna basıldığında önceki game object'i kontrol et
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ToggleGameObject(currentObjectIndex, false); // Mevcut game object'in görünürlüğünü kapat
            currentObjectIndex = (currentObjectIndex - 1 + CharactersList.Length) % CharactersList.Length; // Dizi sınırlarını kontrol etmek için modulo operatörünü kullan
            ToggleGameObject(currentObjectIndex, true); // Yeni game object'in görünürlüğünü aç
        }
        // Sağ yön tuşuna basıldığında sonraki game object'i kontrol et
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ToggleGameObject(currentObjectIndex, false); // Mevcut game object'in görünürlüğünü kapat
            currentObjectIndex = (currentObjectIndex + 1) % CharactersList.Length; // Dizi sınırlarını kontrol etmek için modulo operatörünü kullan
            ToggleGameObject(currentObjectIndex, true); // Yeni game object'in görünürlüğünü aç
        }
        
    }

    // Belirli bir game object'in görünürlüğünü açıp kapatmak için yardımcı bir fonksiyon
    void ToggleGameObject(int index, bool isVisible)
    {
        CharactersList[index].SetActive(isVisible);
        PlayerPrefs.SetInt("CharacterIndex", index);
    }

    // sonscoreu LastScore olarak tekrar adlandırmam lazım
    // menüye dön menu
    // oyuniçimenüye dön gamemenu
    // oyuna dön Gobacktogame
}
