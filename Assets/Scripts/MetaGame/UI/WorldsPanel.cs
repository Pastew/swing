using System.Collections.Generic;
using MetaGame;
using UnityEngine;

public class WorldsPanel : UIPanel
{
    [SerializeField] private List<WorldButton> _worldButtons;
    
    public void Setup(List<int> unlockedWorlds)
    {
        for (int i = 0; i < _worldButtons.Count; i++)
        {
            bool locked = !unlockedWorlds.Contains(i);
            _worldButtons[i].SetLocked(locked);
        }
    }
}
