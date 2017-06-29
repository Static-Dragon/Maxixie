/*
  Maxixie

  Author:
       static-dragon <Justin T. Doyle>

  Copyright (c) 2017 

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using System;
using Gtk;

public partial class MainWindow : Gtk.Window{
	String userMsg = "Valid Types: \n(username): a specific user \n@(group): a specific group \nYou can specify multiple of each by separating with a space.";
	String aboutMsg = "Maxixie is free software licensed under the GNU GPL\n\nTo use this software, input the values required, and it will output the correctly formatted share to ~/Documents/smb_share";
	public MainWindow() : base(Gtk.WindowType.Toplevel){
		Build();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a){
		Application.Quit();
		a.RetVal = true;
	}

	protected void OnBtnQuitClicked(object sender, EventArgs e){
		Application.Quit();
	}

	protected void OnQuitActionActivated(object sender, EventArgs e){
		Application.Quit();
	}

	protected void OnBtnWriteClicked(object sender, EventArgs e){
        if (txtbx_path.Text != "" | txtBx_desc.Text != "" | txtBx_shareName.Text != "" | txtBx_validUsers.Text != ""){
            Maxixie.MainClass.writeFile(txtBx_shareName.Text, chkBx_readOnly.Active, chkBx_guests.Active, chkBx_printable.Active, chkBx_browseable.Active, txtBx_desc.Text, txtbx_path.Text, txtBx_validUsers.Text);
		}else{
			messagebox("One or more text boxes are empty, please insert a value.");
		}
	}
	protected void OnBtnClearClicked(object sender, EventArgs e){
		chkBx_guests.Active = false;
		chkBx_readOnly.Active = false;
		chkBx_printable.Active = false;
		chkBx_browseable.Active = false;
		txtbx_path.Text = "";
		txtBx_desc.Text = "";
		txtBx_validUsers.Text = "";
		txtBx_shareName.Text = "";
	}
	protected void messagebox(String msg){
		MessageDialog md = new MessageDialog(this, DialogFlags.DestroyWithParent, MessageType.Info, ButtonsType.Ok, msg);
		md.Run();
		md.Destroy();
	}

    protected void OnHelpAction1Activated(object sender, EventArgs e)
    {
        messagebox(userMsg);
    }

    protected void OnAboutActionActivated(object sender, EventArgs e)
    {
        messagebox(aboutMsg);
    }

    protected void OnBtnUserHelpActivated(object sender, EventArgs e)
    {
        messagebox(userMsg);
    }
}
