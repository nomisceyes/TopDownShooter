using UnityEngine;

public delegate void OnValidateField();

public class FieldTilemap : MonoBehaviour
{
    private const int  SIZE = 30;
    [SerializeField] private Tile _tile;

    public float _noicePerlinScale = 3f;
    public float _offsetX = 234523f;
    public float _offsetY = 234523f;

    public event OnValidateField onUp;

    private void Start()
    {
        for (int x = -SIZE; x < SIZE; x++)
        {
            for (int y = -SIZE; y < SIZE; y++)
            {
                Instantiate(_tile,transform).SetTile(x,y,this);
            }
        }
    }

    private void OnValidate()
    {
        onUp.Invoke();
    }
}