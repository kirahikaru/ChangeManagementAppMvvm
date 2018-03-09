using System.Windows;

namespace ChangeManagementAppModern.Extensions
{
    /// <summary>
    /// MVVM TextBox Focus
    /// Help with MVVM focus because we don't have access to control
    /// <para>
    /// Source Url: http://csharpbestpractices.blogspot.com/2011/09/mvvm-textbox-focus.html
    /// </para>
    /// </summary>
    public static class FocusExtension
    {
        public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached("IsFocused", typeof(bool), typeof(FocusExtension), new UIPropertyMetadata(false, OnIsFocusedPropertyChanged));

        private static void OnIsFocusedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uie = (UIElement)d;
            if ((bool)e.NewValue) uie.Focus();
        }

        public static bool GetIsFocused(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFocusedProperty);
        }

        public static void SetIsFocused(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFocusedProperty, value);
        }
    }
}
