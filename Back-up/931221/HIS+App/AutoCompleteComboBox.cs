using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HISPlus
{
    public partial class AutoCompleteComboBox: TextBox
    {
        DropDownManager _dropDownManager;

        public event EventHandler ItemsRequested;

        public string DisplayMember 
        {
            get
            {
                return _dropDownManager.DropDownListBox.DisplayMember;
            }
            set
            {
                _dropDownManager.DropDownListBox.DisplayMember = value;
            } 
        }

        public string ValueMember
        {
            get
            {
                return _dropDownManager.DropDownListBox.ValueMember;
            }
            set
            {
                _dropDownManager.DropDownListBox.ValueMember = value;
            }
        }

        public object DataSource
        {
            get
            {
                return _dropDownManager.DropDownListBox.DataSource;
            }
            set
            {
                _dropDownManager.DropDownListBox.DataSource = value;
            }
        }

        public object SelectedValue
        {
            get
            {
                return _dropDownManager.DropDownListBox.SelectedValue;
            }
            set
            {
                _dropDownManager.DropDownListBox.SelectedValue = value;
            }
        }

        public AutoCompleteComboBox()
        {
            _dropDownManager = new DropDownManager(this);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _dropDownManager.Dispose();
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            if (!_dropDownManager.DropDownIsFocused)
                _dropDownManager.CloseDropDown();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            _dropDownManager.OpenDropDown();
            OnItemsRequested();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Down)
            {
                if (!_dropDownManager.DropDownIsOpen)
                    _dropDownManager.OpenDropDown();
                _dropDownManager.DropDownListBox.Focus();
            }
            else if (this.Focused)
            {
                if (e.KeyCode == Keys.Enter)
                    return;

                if (!_dropDownManager.DropDownIsOpen)
                    _dropDownManager.OpenDropDown();
                OnItemsRequested();
            }
        }

        private void OnItemsRequested()
        {
            if (ItemsRequested != null)
                ItemsRequested(this, null);
        }

        private class DropDownManager : IDisposable
        {
            private const int SW_SHOWNOACTIVATE = 4;
            private const int HWND_TOPMOST = -1;
            private const uint SWP_NOACTIVATE = 0x0010;

            [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
            static extern bool SetWindowPos(
                 int hWnd,             // Window handle
                 int hWndInsertAfter,  // Placement-order handle
                 int X,                // Horizontal position
                 int Y,                // Vertical position
                 int cx,               // Width
                 int cy,               // Height
                 uint uFlags);         // Window positioning flags

            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            static void ShowInactiveTopmost(Form frm, int x, int y)
            {
                ShowWindow(frm.Handle, SW_SHOWNOACTIVATE);
                SetWindowPos(frm.Handle.ToInt32(), HWND_TOPMOST,
                x, y, frm.Width, frm.Height,
                SWP_NOACTIVATE);
            }

            private Form _dropDownForm;

            private ListBox _DropDownListBox;
            public ListBox DropDownListBox
            {
                get
                {
                    if (_DropDownListBox == null)
                    {
                        _dropDownForm = new Form();
                        _dropDownForm.FormBorderStyle = FormBorderStyle.None;
                        _dropDownForm.ShowInTaskbar = false;
                        _DropDownListBox = new ListBox();
                        _dropDownForm.Controls.Add(DropDownListBox);
                        _DropDownListBox.Dock = DockStyle.Fill;
                        _DropDownListBox.KeyUp += _DropDownListBox_KeyUp;
                        _DropDownListBox.Click += _DropDownListBox_Click;
                    }

                    return _DropDownListBox;
                }
            }

            private AutoCompleteComboBox _ownerComboBox;

            public DropDownManager(AutoCompleteComboBox ownerComboBox)
            {
                _ownerComboBox = ownerComboBox;
            }

            ~DropDownManager()
            {
                Dispose(false);
            }

            void _DropDownListBox_Click(object sender, EventArgs e)
            {
                SelectDropDownValue();
            }

            private void SelectDropDownValue()
            {
                _ownerComboBox.SelectedValue = DropDownListBox.SelectedValue;
                _ownerComboBox.Text = DropDownListBox.Text;
                CloseDropDown();
            }

            void _DropDownListBox_KeyUp(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Escape)
                {
                    CloseDropDown();
                }

                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
                {
                    SelectDropDownValue();
                }
            }

            public bool DropDownIsOpen
            {
                get
                {
                    return _dropDownForm != null && _dropDownForm.IsHandleCreated && _dropDownForm.Visible;
                }
            }

            public void OpenDropDown()
            {
                var comboPossitionInScreen = _ownerComboBox.PointToScreen(Point.Empty);

                _dropDownForm.Font = _ownerComboBox.Font;
                _dropDownForm.RightToLeft = _ownerComboBox.RightToLeft;

                int dropDownX = 0;
                int dropDownY = comboPossitionInScreen.Y + _ownerComboBox.Height;

                if (_ownerComboBox.RightToLeft == RightToLeft.Yes)
                    dropDownX = comboPossitionInScreen.X - (_dropDownForm.Width - _ownerComboBox.Width);
                else
                    dropDownX = comboPossitionInScreen.X;

                ShowInactiveTopmost(_dropDownForm, dropDownX, dropDownY);
            }

            public bool DropDownIsFocused
            {
                get 
                {
                    return DropDownIsOpen && DropDownListBox.Focused;
                }
            }

            internal void CloseDropDown()
            {
                _dropDownForm.Visible = false;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (_dropDownForm != null) 
                        _dropDownForm.Dispose();
                }
            }
        }
    }
}
