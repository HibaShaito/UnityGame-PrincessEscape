using UnityEngine.Rendering.PostProcessing;
using UnityEngine.XR; // Add this for XRSettings

namespace UnityEditor.Rendering.PostProcessing
{
    [PostProcessEditor(typeof(MotionBlur))]
    internal sealed class MotionBlurEditor : DefaultPostProcessEffectEditor
    {
        public override void OnInspectorGUI()
        {
            if (XRSettings.enabled)
                EditorGUILayout.HelpBox("Motion Blur is available only for non-stereo cameras.", MessageType.Warning);

            base.OnInspectorGUI();
        }
    }
}
