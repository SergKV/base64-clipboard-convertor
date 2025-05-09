﻿using System.Runtime.InteropServices;
using System.Windows.Forms;
using Base64ClipboardDecoder;
using decoder.Events;

namespace decoder
{
    public partial class ucHistoryListView : BaseUserControl
    {
        private UcVisibilityStatusEvent UcVisibilityStatusEvent;

        private const string convertToTxt = "Convert to txt";
        private const string convertToBase64 = "Convert to base64";
        private const string disabled = "Disable";
        private const string enabled = "Enable";

        public ClipBoardViewer ParentForm { get; set; }

        private ClipBoardItems clipboardHistory;

        private Format currentFormat = Format.Base54;

        private enum Format
        {
            Base54,
            Txt
        }

        private bool isDisabled = true;

        public bool IsDisabled
        {
            get => isDisabled;

            set
            {
                if (isDisabled != value)
                {
                    isDisabled = value;
                    disableMenuItem.Text = isDisabled ? enabled : disabled;
                }
            }
        }

        public ucHistoryListView()
        {
            InitializeComponent();
            InitializeUI();

            clipboardHistory = new ClipBoardItems();

            history.MeasureItem += History_MeasureItem;
            history.DrawItem += History_DrawItem;

            UcVisibilityStatusEvent = new UcVisibilityStatusEvent();
            UcVisibilityStatusEvent.ucVisibilityStatusEvent -= UcVisibilityStatusEvent_UcVisibilityStatusChanged;
            UcVisibilityStatusEvent.ucVisibilityStatusEvent += UcVisibilityStatusEvent_UcVisibilityStatusChanged;
        }

        private void History_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || history.Items.Count == 0)
                return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            string text = history.Items[e.Index]?.ToString() ?? string.Empty;
            e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        private void History_MeasureItem(object? sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(history.Items[e.Index].ToString(), history.Font, history.Width).Height;
        }

        public ToolStripMenuItem toTxtMenuItem
        {
            get { return convertToTxtToolStripMenuItem; }
        }

        public ToolStripMenuItem disableMenuItem
        {
            get { return disableToolStripMenuItem; }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        private void ClipboardViewer_Load(object sender, EventArgs e)
        {
            SetClipboardViewer(this.Handle);
        }

        private void AppTimer_TimerStopped(object? sender, EventArgs e)
        {
            IsDisabled = true;
        }

        private void UcVisibilityStatusEvent_UcVisibilityStatusChanged(object? sender, UcVisibilityStatusEvent e)
        {
            this.Visible = true;

            UpdateClipboardList();
        }

        private void DisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsDisabled = !IsDisabled;
            ParentForm.IsDisabled = !ParentForm.IsDisabled;
        }

        private void ExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            SaveFileDialog sfd = new();

            if (history.SelectedItem is null)
            {
                MessageBox.Show("Select item first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportAsFile(history.SelectedItem.ToString(), sfd.FileName);
                MessageBox.Show("File saved successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clipBoardViewer = this.Parent as ClipBoardViewer;

            clipBoardViewer?.Dispose();
        }

        private void ConvertToTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            if (history.Items.Count == 0)
            {
                MessageBox.Show("Select item first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ConvertHistoryItems();

            var menuItem = sender as ToolStripMenuItem;
            UpdateMenuItemText(menuItem, convertToTxt, convertToBase64);
        }

        private void ConvertHistoryItems()
        {
            history.Items.Clear();

            foreach (var item in clipboardHistory.List)
            {
                if (currentFormat == Format.Base54)
                {
                    history.Items.Add(item.Text);
                }
                else
                {
                    history.Items.Add(item.Base64);
                }
            }

            currentFormat = currentFormat == Format.Base54 ? Format.Txt : Format.Base54;
        }

        private void ucHistoryListView_Load(object sender, EventArgs e)
        {
            ParentForm.appTimer.TimerStopped += AppTimer_TimerStopped;

            disableMenuItem.Text = IsDisabled ? enabled : disabled;
        }

        private void UpdateMenuItemText(ToolStripMenuItem menuItem, string convertToTxt, string convertToBase64)
        {
            if (menuItem != null)
            {
                menuItem.Text = menuItem.Text == convertToTxt ? convertToBase64 : convertToTxt;
            }
        }

        private void EditSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            if (history.SelectedItem is null)
            {
                MessageBox.Show("Select item first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!string.IsNullOrEmpty(history.SelectedItem.ToString()))
            {
                this.Hide();

                var item = clipboardHistory.Get(history.SelectedItem.ToString());

                UcVisibilityStatusEvent.SendEventInfo(item);
            }
            else
            {
                MessageBox.Show("Select item first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void CopySelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            var selectedItem = history.SelectedItem;

            if (history.SelectedItem is null)
            {
                MessageBox.Show("Select item first.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Clipboard.SetText(selectedItem.ToString());
            }
        }

        private void ClearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            if (clipboardHistory.List.Count == 0)
            {
                MessageBox.Show("History is empty.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                clipboardHistory.List.Clear();
                UpdateClipboardList();
                MessageBox.Show("History cleared successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void UpdateClipboardList()
        {
            object selectedItem = new();

            if (history.SelectedItem != null)
            {
                selectedItem = history.SelectedItem;
            }

            history.Items.Clear();
            foreach (var item in clipboardHistory.List)
            {
                if (currentFormat == Format.Base54)
                {
                    history.Items.Add(item.Base64);
                }
                else
                {
                    history.Items.Add(item.Text);
                }
            }

            if (selectedItem != null && history.Items.Contains(selectedItem.ToString()))
            {
                history.SelectedItem = selectedItem;
            }
        }

        private void ClearClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            if (Clipboard.ContainsText())
            {
                MessageBox.Show("Clipboard was cleared successfully.", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clipboard.Clear();
            }
            else
            {
                MessageBox.Show("Clipboard is empty.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            AboutForm af = new();
            af.ShowDialog();
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            if (history.SelectedItem != null)
            {
                var item = clipboardHistory.Get(history.SelectedItem.ToString());

                clipboardHistory.Remove(item);
                UpdateClipboardList();
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParentForm.appTimer.Reset();

            var clipBoardViewer = this.Parent as ClipBoardViewer;

            clipBoardViewer.WindowState = FormWindowState.Minimized;
        }

        private void History_LostFocus(object sender, EventArgs e)
        {
            history.ClearSelected();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0308) // WM_DRAWCLIPBOARD
            {
                OnClipboardUpdate();
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void OnClipboardUpdate()
        {
            if (!IsDisabled && Clipboard.ContainsText() && !string.IsNullOrWhiteSpace(Clipboard.GetText()) && IsBase64String(Clipboard.GetText()))
            {
                ParentForm.appTimer.Reset();

                ClipBoardItem newItem = new(Clipboard.GetText());

                if (!string.IsNullOrEmpty(newItem.Text))
                {
                    Clipboard.SetText(newItem.Text);
                }

                AddClipboardTextToHistory(newItem);
            }
        }

        private void AddClipboardTextToHistory(ClipBoardItem item)
        {
            if (clipboardHistory.Contains(item))
            {
                return;
            }

            if (currentFormat == Format.Txt)
            {
                ConvertHistoryItems();

                clipboardHistory.Add(item);

                UpdateMenuItemText(toTxtMenuItem, convertToTxt, convertToBase64);
            }
            else
            {
                clipboardHistory.Add(item);
            }

            UpdateClipboardList();
        }

        private void InitializeUI()
        {
            exitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;

            saveAsToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

            copySelectedItemStripMenuItem.ShortcutKeyDisplayString = "Ctrl+C";
            copySelectedItemStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;

            editSelectedItemStripMenuItem.ShortcutKeyDisplayString = "Ctrl+E";
            editSelectedItemStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;

            deleteSelectedToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+D";
            deleteSelectedToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;

            deleteAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+D";
            deleteAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.D;

            disableToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F2";
            disableToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F2;

            minimizeToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F1";
            minimizeToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F1;
        }
    }
}
