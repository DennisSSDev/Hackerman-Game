using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    enum ButtonPress
    {
        None,
        TopLeft,
        ButtomLeft,
        Center,
        TopRight,
        ButtomRight
    };
    public partial class externalEditor : Form
    {

        ButtonPress stateCheck = ButtonPress.None;
        string[] coordinateFile;

        public externalEditor()
        {
            InitializeComponent();
        }

        private void externalEditor_Load(object sender, EventArgs e)
        {
            coordinateFile = Directory.GetFiles(@"Coordinate", "coordinate*");
            string nothing = "";
            File.WriteAllText(coordinateFile[0], nothing);         
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            try
            {
                
                        using (Stream streamer2 = File.OpenWrite(coordinateFile[0]))
                        {
                            var writer = new BinaryWriter(streamer2);
                            switch (stateCheck)
                            {
                                case ButtonPress.None:
                                    break;
                                case ButtonPress.TopLeft:
                                    writer.Write(100);
                                    writer.Write(100);
                                    break;
                                case ButtonPress.ButtomLeft:
                                    writer.Write(100);
                                    writer.Write(500);
                                    break;
                                case ButtonPress.Center:
                                    writer.Write(300);
                                    writer.Write(300);
                                    break;
                                case ButtonPress.TopRight:
                                    writer.Write(500);
                                    writer.Write(100);
                                    break;
                                case ButtonPress.ButtomRight:
                                    writer.Write(500);
                                    writer.Write(500);
                                    break;
                                default:
                                    break;
                            }
                        }
                using (Stream filer = File.OpenRead(coordinateFile[0]))
                {
                    var reader = new BinaryReader(filer);
                    int someNum = reader.ReadInt32();
                    int someNum2 = reader.ReadInt32();
                    MessageBox.Show(someNum.ToString() + " " + someNum2);
                }
                    
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        private void TopLeft_CheckedChanged(object sender, EventArgs e)
        {
            stateCheck = ButtonPress.TopLeft;
        }

        private void BottomLeft_CheckedChanged(object sender, EventArgs e)
        {
            stateCheck = ButtonPress.ButtomLeft;
        }

        private void Center_CheckedChanged(object sender, EventArgs e)
        {
            stateCheck = ButtonPress.Center;
        }

        private void TopRight_CheckedChanged(object sender, EventArgs e)
        {
            stateCheck = ButtonPress.TopRight;
        }

        private void BottomRight_CheckedChanged(object sender, EventArgs e)
        {
            stateCheck = ButtonPress.ButtomRight;
        }

        private void Exit_Clicked(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
