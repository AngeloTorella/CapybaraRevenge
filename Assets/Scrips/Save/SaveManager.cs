using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private Vector2 playerPosition;
    private float respawnHeight = 2.0f; // La altura adicional en la que el jugador reaparecerá

    public void SaveGame(Vector2 position)
    {
        playerPosition = position + Vector2.up * respawnHeight;
    }

    public Vector2 LoadGame()
    {
        return playerPosition;
    }
}
