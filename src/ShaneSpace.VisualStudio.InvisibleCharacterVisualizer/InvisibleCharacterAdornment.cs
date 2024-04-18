using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ShaneSpace.VisualStudio.InvisibleCharacterVisualizer
{
    internal sealed class InvisibleCharacterAdornment : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvisibleCharacterAdornment"/> class.
        /// </summary>
        internal InvisibleCharacterAdornment(InvisibleCharacterTag invisibleCharacterTag)
        {
            var text = invisibleCharacterTag.Text.ToHex();

            Content = new TextBlock
            {
                Text = text,
                Background = Brushes.Red,
                Foreground = Brushes.White,
                Padding = new Thickness(2),
            };
        }
    }
}