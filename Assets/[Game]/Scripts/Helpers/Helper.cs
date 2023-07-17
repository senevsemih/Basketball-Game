using UnityEditor;
using UnityEngine;

namespace _Game_.Scripts.Helpers
{
    public class Helper : MonoBehaviour
    {
    }

    public class EnumFlagsAttribute : PropertyAttribute
    {
    }

    [CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
    public class EnumFlagsAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.intValue = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);
        }
    }
}