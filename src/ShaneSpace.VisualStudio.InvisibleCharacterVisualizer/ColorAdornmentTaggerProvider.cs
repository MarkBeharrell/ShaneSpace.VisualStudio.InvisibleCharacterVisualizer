using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace ShaneSpace.VisualStudio.InvisibleCharacterVisualizer
{
    [Export(typeof(IViewTaggerProvider))]
    [ContentType("text")]
    [ContentType("projection")]
    [TagType(typeof(IntraTextAdornmentTag))]
    internal sealed class ColorAdornmentTaggerProvider : IViewTaggerProvider
    {
#pragma warning disable CS0649 // something

        [Import]
        internal IBufferTagAggregatorFactoryService BufferTagAggregatorFactoryService;

#pragma warning restore CS0649

        public ITagger<T> CreateTagger<T>(ITextView textView, ITextBuffer buffer)
            where T : ITag
        {
            if (textView == null)
            {
                throw new ArgumentNullException(nameof(textView));
            }

            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer != textView.TextBuffer)
            {
                return null;
            }

            return InvisibleCharacterAdornmentTagger.GetTagger(
                    (IWpfTextView)textView,
                    new Lazy<ITagAggregator<InvisibleCharacterTag>>(() => BufferTagAggregatorFactoryService.CreateTagAggregator<InvisibleCharacterTag>(textView.TextBuffer)))
                as ITagger<T>;
        }
    }
}