using System.Windows.Input;

namespace TabL
{
    public class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand
        (
            "NewTab",
            "NewTab",
            typeof(CustomCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            }
        );
    }
}