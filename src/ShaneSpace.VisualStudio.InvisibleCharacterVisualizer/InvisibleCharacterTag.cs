using Microsoft.VisualStudio.Text.Tagging;

namespace ShaneSpace.VisualStudio.InvisibleCharacterVisualizer
{
    internal class InvisibleCharacterTag : ITag
    {
        internal readonly string Text;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvisibleCharacterTag"/> class.
        /// </summary>
        internal InvisibleCharacterTag(string text)
        {
            Text = text;
        }
    }
}
