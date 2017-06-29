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
using System.IO;
using Gtk;

namespace Maxixie {
    class MainClass {
        static String homePath;
        public static void Main(string[] args) {

            homePath = (Environment.OSVersion.Platform.ToString() == "Unix")
                ? Environment.GetEnvironmentVariable("HOME") : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%/Documents/smbshare.txt");
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
		public static void writeFile(String shareName, bool readOnly, bool guests, bool printable, bool browsable, String desc, String sharePath, String users) {
            
			String read = (readOnly) ? "no" : "yes";
			String guest = (guests) ? "yes" : "no";
			String print = (printable) ? "yes" : "no";
			String browse = (browsable) ? "yes" : "no";
            if (Environment.OSVersion.Platform.ToString() == "Unix") { //I could not initalize homePath to the correct variable, so now I have to do it on write, 
                if (!File.Exists(homePath + "/smbshare.txt")) {
                    using (StreamWriter sw = File.CreateText(homePath + "/smbshare.txt")) {
                        sw.WriteLine("# Append the following lines to your smb.conf located in /etc/samba for Linux\r\n");
                        sw.WriteLine("[" + shareName + "]" + "\r\n\tcomment = " + desc + "\r\n\tpath = " + sharePath + "\r\n\tguest ok = " + guest + "\r\n\tvalid users = " + users + "\r\n\tprintable = " + print + "\r\n\twritable = " + read + "\r\n\tbrowseable = " + browse);
                    }
                } else {
                    using (StreamWriter sw = File.AppendText(homePath + "/smbshare.txt")) {
                        sw.WriteLine("[" + shareName + "]" + "\r\n\tcomment = " + desc + "\r\n\tpath = " + sharePath + "\r\n\tguest ok = " + guest + "\r\n\tvalid users = " + users + "\r\n\tprintable = " + print + "\r\n\twritable = " + read + "\r\n\tbrowseable = " + browse);
                    }
                }
            } else {
				if (!File.Exists(homePath)) {
					using (StreamWriter sw = File.CreateText(homePath + "/smbshare.txt")) {
						sw.WriteLine("# Append the following lines to your smb.conf located in /etc/samba for Linux\r\n");
						sw.WriteLine("[" + shareName + "]" + "\r\n\tcomment = " + desc + "\r\n\tpath = " + sharePath + "\r\n\tguest ok = " + guest + "\r\n\tvalid users = " + users + "\r\n\tprintable = " + print + "\r\n\twritable = " + read + "\r\n\tbrowseable = " + browse);
					}
				} else {
					using (StreamWriter sw = File.AppendText(homePath)) {
						sw.WriteLine("[" + shareName + "]" + "\r\n\tcomment = " + desc + "\r\n\tpath = " + sharePath + "\r\n\tguest ok = " + guest + "\r\n\tvalid users = " + users + "\r\n\tprintable = " + print + "\r\n\twritable = " + read + "\r\n\tbrowseable = " + browse);
					}
				}
            }
		}
    }
}
