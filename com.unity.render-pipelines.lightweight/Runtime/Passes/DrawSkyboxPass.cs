namespace UnityEngine.Rendering.LWRP
{
    /// <summary>
    /// Draw the skybox into the given color buffer using the given depth buffer for depth testing.
    ///
    /// This pass renders the standard Unity skybox.
    /// </summary>
    internal class DrawSkyboxPass : ScriptableRenderPass
    {
        public DrawSkyboxPass(RenderPassEvent evt)
        {
            renderPassEvent = evt;
        }

        public override bool ShouldExecute(ref RenderingData renderingData)
        {
            return renderingData.cameraData.camera.clearFlags == CameraClearFlags.Skybox && RenderSettings.skybox != null;
        }

        /// <inheritdoc/>
        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            context.DrawSkybox(renderingData.cameraData.camera);
        }
    }
}
