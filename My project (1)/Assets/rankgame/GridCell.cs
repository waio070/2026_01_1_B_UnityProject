using UnityEngine;

public class GridCell : MonoBehaviour
{
    public int x, y;
    public DraggableRank currentRank;
    public SpriteRenderer cellRenderers;

    private void Awake()
    {
        cellRenderers = GetComponent<SpriteRenderer>();                     //컴포넌트 참조 가져오기
    }
    public void Initialize(int gridX, int gridY)
    {
        x = gridX;
        y = gridY;
        name = "Cell_" + x + "," + y;
    }

    public bool isEmpty()
    {
        return currentRank == null;
    }


    public bool ContainsPosition(Vector3 position)                  //특정 위치가 이 칸에 있는지 확인
    {
        Bounds bounds = cellRenderers.bounds;                       //칸의 경계 영역 가져오기
        return bounds.Contains(position);                           //위치가 경계 안에 있는지 확인
    }

    public void SetRank(DraggableRank rank)
    {
        currentRank = rank;

        if(rank != null)
        {
            rank.currentCell = this;
        }

        rank.originalPosition = new Vector3(transform.position.x, transform.position.y, 0);
        rank.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
