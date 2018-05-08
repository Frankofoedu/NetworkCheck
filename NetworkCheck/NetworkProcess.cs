using NetworkCheck.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NetworkCheck
{
    class NetworkProcess : IDisposable
    {
        private readonly NotifyIcon _ni;

        public NetworkProcess()
        {
            _ni = new NotifyIcon();
        }

        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            _ni.MouseClick += ni_MouseClick;
            _ni.Icon = Resources.SystemTrayApp;
            _ni.Text = @"Internet Check App";
            _ni.Visible = true;

            // Attach a context menu.
            _ni.ContextMenuStrip = new ContextMenus().Create();
        }

        /// <inheritdoc />
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        public void Dispose()
        {
            // When the application closes, this will remove the icon from the system tray immediately.
            _ni.Dispose();
        }

        /// <summary>
        /// Handles the MouseClick event of the ni control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Start Windows Explorer.
               // Process.Start("explorer", null);
               _ni.ContextMenuStrip.Show(Control.MousePosition);
            }
            
        }

    }
}
