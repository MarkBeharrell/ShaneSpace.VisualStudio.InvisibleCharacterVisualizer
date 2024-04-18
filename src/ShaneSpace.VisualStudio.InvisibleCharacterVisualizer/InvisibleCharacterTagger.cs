using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;

namespace ShaneSpace.VisualStudio.InvisibleCharacterVisualizer
{
    internal sealed class InvisibleCharacterTagger : RegexTagger<InvisibleCharacterTag>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvisibleCharacterTagger"/> class.
        /// </summary>
        /// <param name="buffer"></param>
        internal InvisibleCharacterTagger(ITextBuffer buffer)
            : base(buffer, new[] { new Regex($"[{string.Join(string.Empty, NonPrintableUnicodeCharacters.UnicodeRanges)}]", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase) })
        {
        }

        protected override InvisibleCharacterTag TryCreateTagForMatch(Match match)
        {
            return new InvisibleCharacterTag(match.Value);
        }
    }
}