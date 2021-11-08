using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildTowers : MonoBehaviour
{
    public static BuildTowers Instance { get; private set; }

    public List<Vector3Int> takenTiles = new List<Vector3Int>();
    [SerializeField] private SelectedTile selectedTile;
    [SerializeField] private GameObject Buttons;
    public List<GameObject> towers;

    private void Start()
    {
        Instance = this;

        takenTiles = FindObjectOfType<PathGenerator>().Path;
    }

    private void Update()
    {
        if (!IsOverNextWaveButton() && !PauseGame.IsPaused && Input.GetMouseButtonDown(0))
        {
            Vector3Int select = selectedTile.GetSelectedTile();
            Vector3 tileCenter = new Vector3(select.x + 0.5f, select.y + 0.5f);
            Buttons.transform.position = Camera.main.WorldToScreenPoint(tileCenter);
        }
        if (Input.GetMouseButtonUp(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            HideButtons();
        }
    }

    public void HideButtons()
    {
        Buttons.transform.position = Camera.main.WorldToScreenPoint(new Vector3(-8000.0f, -8000.0f, 0));
    }

    public void BuildTower(int index)
    {
        Vector3Int selected = selectedTile.GetSelectedTile();
        Debug.Log(selected.ToString());

        if (takenTiles.Contains(selected))
        {
            Debug.Log("Its TAKEN");
        }
        else if (GameManager.Instance.money >= towers[index].GetComponent<Tower>().costOfBuilding)
        {
            Instantiate(towers[index], new Vector3(selected.x + 0.5f, selected.y + 0.5f, 0), Quaternion.identity);
            takenTiles.Add(selected);
            GameManager.Instance.money -= towers[index].GetComponent<Tower>().costOfBuilding;
        }
        else
        {
            Debug.Log("Bieda");
            FindObjectOfType<Notificater>().MakeNotificationNotEnoughMoney(Input.mousePosition);
        }
    }

    public static bool IsOverNextWaveButton()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            return results.Find(r => r.gameObject == GameManager.Instance.Spawner.NextWave).gameObject != null;
        }

        return false;
    }

    public static bool IsOverSelectionWheel()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            return results.Find(r => r.gameObject.transform.IsChildOf(Instance.Buttons.transform)).gameObject != null;
        }

        return false;
    }
}
