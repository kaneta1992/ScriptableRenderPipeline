using UnityEngine.Graphing;

namespace UnityEngine.MaterialGraph
{
    interface IMayRequireWorldPosition
    {
        bool RequiresWorldPosition();
    }

    [Title("Input/World Pos Node")]
    public class WorldPosNode : AbstractMaterialNode, IMayRequireWorldPosition
    {
        private const int kOutputSlotId = 0;
        private const string kOutputSlotName = "WorldPos";

        public override bool hasPreview { get { return true; } }

        public override PreviewMode previewMode
        {
            get { return PreviewMode.Preview3D; }
        }

        public WorldPosNode()
        {
            name = "WorldPos";
            UpdateNodeAfterDeserialization();
        }

        public sealed override void UpdateNodeAfterDeserialization()
        {
            AddSlot(new MaterialSlot(kOutputSlotId, kOutputSlotName, kOutputSlotName, SlotType.Output, SlotValueType.Vector3, Vector4.zero));
            RemoveSlotsNameNotMatching(new[] { kOutputSlotId });
        }

        public override string GetVariableNameForSlot(int slotId)
        {
            return "IN.worldPos";
        }

        public bool RequiresWorldPosition()
        {
            return true;
        }
    }
}
