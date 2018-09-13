using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour
{
    public UnityEvent OnValueChanged = new UnityEvent();
    public int InitialQuantity;
    public string Name;

    [SerializeField] private int quantity;

    private void Start()
    {
        quantity = InitialQuantity;
        updateUI();
    }

    public void AddAmount(int value)
    {
        quantity += value;
        updateUI();
    }

    public void RemoveAmount(int value)
    {
        quantity -= value;
        updateUI();
    }

    public int GetQuantity()
    {
        return quantity;
    }

    void updateUI()
    {
        OnValueChanged.Invoke();
    }
}
