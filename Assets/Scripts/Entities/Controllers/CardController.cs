using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour {

    [Header("Entities")]
    [SerializeField] private List<KeyCode> _combination;

    [Header("Properties")]
    [SerializeField] private int _priority;
    [SerializeField] private bool _isHighlighted = false;
    [SerializeField] private KeyCode _nextKey;

    [Header("Graphic Elements")]
    [SerializeField] private int _thing;

    void Start() {
        _nextKey = _combination[0];
        SetGraphics();
    }

    private void SetGraphics() {

    }

    void Update() {
        if (_combination.Count == 0) {
            MoveToNextColumn();
        }
    }

    private void MoveToNextColumn() {
        Debug.Log("done");
        gameObject.SetActive(false);
    }

    public void OnGUI() {
        Event keyEvent = Event.current;
        if (AKeyHasBeenPressed(keyEvent)) {
            CheckNextKeyIsEqualTo(keyEvent.keyCode);
        }
    }

    public void CheckNextKeyIsEqualTo(KeyCode inputKeyCode) {
        if (BothKeysAreEqual(inputKeyCode)) {
            _combination.Remove(_nextKey);
            if (_combination.Count > 0) {
                _nextKey = _combination[0];
            }
        }
    }

    public void SetCombinationForCard(List<KeyCode> combination) {
        _combination = combination;
        _nextKey = combination[0];
    }

    //Subrutina control del estilo de la carta
    private IEnumerator CardUIControl() {
        return null;
    }

    //Subrutina de control del temporizador local
    private IEnumerator CardUITimer() {
        return null;
    }

    //AUXILIARY METHODS
    private bool AKeyHasBeenPressed(Event keyEvent) {
        return _isHighlighted && 
            keyEvent.type.Equals(EventType.KeyDown) && 
            keyEvent.isKey && 
            _combination.Count > 0;
    }

    private bool BothKeysAreEqual(KeyCode inputKeyCode) {
        return _nextKey == inputKeyCode;
    }
}
