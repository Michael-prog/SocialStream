﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SocialStream.ConfigTool.Command;
using SocialStream.ConfigTool.VO;

namespace SocialStream.ConfigTool.Controls
{
    /// <summary>
    /// Interaction logic for FlickrEditor.xaml
    /// </summary>
    public partial class FlickrEditor : UserControl
    {
        /// <summary>
        /// Whether an add filter button was just clicked.
        /// </summary>
        private bool _JustAdded;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlickrEditor"/> class.
        /// </summary>
        public FlickrEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Delete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void DeleteQuery_Click(object sender, RoutedEventArgs e)
        {
            RemoveFlickrQueryCommand.Execute((sender as Button).DataContext as BindableStringVO);
        }

        /// <summary>
        /// Handles the Click event of the Delete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void DeleteBan_Click(object sender, RoutedEventArgs e)
        {
            RemoveFlickrBanCommand.Execute((sender as Button).DataContext as BindableStringVO);
        }

        /// <summary>
        /// Handles the Click event of the Add control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void AddQuery_Click(object sender, RoutedEventArgs e)
        {
            _JustAdded = true;
            AddFlickrQueryCommand.Execute();
        }

        /// <summary>
        /// Handles the Click event of the Add control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void AddBan_Click(object sender, RoutedEventArgs e)
        {
            _JustAdded = true;
            AddFlickrBanCommand.Execute();
        }

        /// <summary>
        /// Handles the Loaded event of the TextBox control. Refresh the binding to show the error immediately.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            BindingExpression binding = textBox.GetBindingExpression(TextBox.TextProperty);
            if (binding != null)
            {
                binding.UpdateSource();
            }

            if (_JustAdded)
            {
                textBox.Focus();
                _JustAdded = false;
            }
        }
    }
}
