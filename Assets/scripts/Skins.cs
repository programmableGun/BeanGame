using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    [Header("Player Skins")]
    public GameObject[] playerSkins; public static int playerSkinSelected = 0;
    /*
    [Header("Obsticle Skins")]
    public GameObject[] obsticleSkins; public int obsticleSkinSelected = 0;
    [Header("pointCube Skins")]
    public GameObject[] pointCubeSkins; public int pointCubeSkinSelected = 0; //aka bean can skin
    [Header("Floor Skins")]     
    public GameObject[] floorSkins; public int floorSkinSelected;  
    */

    public void setSkins(GameObject[] skins) {
        playerSkins = skins;
    }
    public GameObject getSkin(int index) {
        return playerSkins[index];
    }
    
}
