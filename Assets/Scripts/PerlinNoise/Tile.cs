using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private List<Sprite> _tileSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int _x;
    private int _y;
    private FieldTilemap _tilemap;

    public void SetTile(int x, int y, FieldTilemap fieldTilemap)
    {
        _x = x;
        _y = y;
        _tilemap = fieldTilemap;
        _tilemap.onUp += UpdateState;
        UpdateState();
    }

    private void UpdateState()
    {
        transform.position = new Vector3(_x, _y, 0);

        float noicePerlinX = ((float)_x + _tilemap._offsetX) / _tilemap._noicePerlinScale;
        float noicePerlinY = ((float)_y + _tilemap._offsetY) / _tilemap._noicePerlinScale;

        float deapth = Mathf.PerlinNoise(noicePerlinX, noicePerlinY);
        int levelHeight = Mathf.FloorToInt(deapth * _tileSprite.Count);

        levelHeight = Mathf.Max(levelHeight, 0);
        levelHeight = Mathf.Min(levelHeight, _tileSprite.Count - 1);

        spriteRenderer.sprite = _tileSprite[levelHeight];
    }
}