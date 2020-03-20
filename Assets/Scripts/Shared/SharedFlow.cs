using CoreGame;
using MetaGame;
using UnityEngine;

namespace Shared
{
    public class SharedFlow : MonoBehaviour
    {
        private CoreFlow _coreFlow;
        private MetaFlow _metaFlow;

        private void Start()
        {
            _coreFlow = FindObjectOfType<CoreFlow>();
            _metaFlow = FindObjectOfType<MetaFlow>();
        }

        public void LoadLevel(int levelIndex)
        {
            _coreFlow.LoadLevel(levelIndex);
        }

        public void LevelFinished(LevelScore levelScore)
        {
            _metaFlow.OnLevelFinished(levelScore);
        }
    }
}