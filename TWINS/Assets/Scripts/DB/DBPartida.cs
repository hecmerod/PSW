using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBPartida : MonoBehaviour
{    
    public void CallSaveData() { StartCoroutine(DBManager.getInstance().SavePlayerData()); }
}
