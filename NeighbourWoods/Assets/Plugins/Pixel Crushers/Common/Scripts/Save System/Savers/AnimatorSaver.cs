using UnityEngine;
using System;

namespace PixelCrushers
{

    /// <summary>
    /// Saves an animator's state.
    /// </summary>
    [AddComponentMenu("")] // Use wrapper.
    public class AnimatorSaver : Saver
    {

        [Serializable]
        public class LayerData
        {
            public int hash;
            public float time;
        }

        [Serializable]
        public class Data
        {
            public LayerData[] layers = null;
        }

        private Data m_data = new Data();
        private Animator m_animator;
        private Animator animator
        {
            get
            {
                if (m_animator == null) m_animator = GetComponent<Animator>();
                return m_animator;
            }
        }

        private void CheckLayers()
        {
            if (animator == null) return;
            if (m_data == null) m_data = new Data();
            if (m_data.layers == null || m_data.layers.Length != animator.layerCount)
            {
                m_data.layers = new LayerData[animator.layerCount];
                for (int i = 0; i < animator.layerCount; i++)
                {
                    m_data.layers[i] = new LayerData();
                }
            }
        }

        public override string RecordData()
        {
            if (animator == null) return string.Empty;
            CheckLayers();
            for (int i = 0; i < animator.layerCount; i++)
            {
                var state = animator.GetCurrentAnimatorStateInfo(i);
                m_data.layers[i].hash = state.fullPathHash;
                m_data.layers[i].time = state.normalizedTime;
            }
            return SaveSystem.Serialize(m_data);
        }

        public override void ApplyData(string s)
        {
            if (string.IsNullOrEmpty(s) || animator == null) return;
            SaveSystem.Deserialize<Data>(s, m_data);
            if (m_data == null)
            {
                m_data = new Data();
            }
            else if (m_data.layers != null)
            {
                for (int i = 0; i < animator.layerCount; i++)
                {
                    if (i < m_data.layers.Length)
                    {
                        animator.Play(m_data.layers[i].hash, 0, m_data.layers[i].time);
                    }
                }
            }
        }

    }
}
