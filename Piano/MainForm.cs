using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piano
{
    
    public partial class Form1 : Form
    {
        private int count = -1; 
        private Melody melody = new Melody();
        public Form1()
        {
            
            InitializeComponent();
        }

        private RadioButton get_duration()
        {
            RadioButton[] radio = new RadioButton[5];
            RadioButton[] one_button = new RadioButton[1];
            radio[0] = Whole;
            radio[1] = Half;
            radio[2] = Quarter;
            radio[3] = Eighth;
            radio[4] = Sixteenth;

            for (int i = 0; i < radio.Length; i++)
            {
                if (radio[i].Checked)
                {
                    one_button[0] = radio[i];
                }
            }

            return one_button[0];
            
            
            // RadioButton tmp = new RadioButton();
            // if (Whole.Checked)
            // {
            //     tmp = Whole;
            // } 
            // if (Half.Checked)
            // {
            //     tmp = Half;
            // }  
            // if (Quater.Checked)
            // {
            //     tmp = Quater;
            // } 
            // else if (Eighth.Checked)
            // {
            //     tmp = Eighth;
            // } 
            // else if (Sixteenth.Checked)
            // {
            //     tmp = Sixteenth;
            // }
            // return tmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void C_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void С_key_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void btn_key_Click(object sender, EventArgs e)
        {
            count++;
            
            Button btn_key = new Button();
            btn_key = (Button)sender;

            Note note = new Note(btn_key.Name,get_duration().Name);
            note.Sound();
            
            melody.AddNote(btn_key.Name,get_duration().Name);

            Button btn_note = new Button();
            btn_note.Size = new Size(100,20);
            // btn_note.Name = btn_key.Name;
            btn_note.Name = count.ToString();
            btn_note.Text = btn_key.Text;



            btn_note.Click += btn_note_Click;
            
            panel_melody.Controls.Add(btn_note);

            // throw new System.NotImplementedException();
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            
            
            Button btn_key;
            btn_key = (Button)sender;

           
            

            int idx = Int32.Parse(btn_key.Name);
            
            melody.RemoveNote(idx);
            
            panel_melody.Controls.Remove(btn_key);

            foreach (Button b in panel_melody.Controls)
            {
                
                if (Int32.Parse(b.Name) > idx)
                {
                    int tmp = Int32.Parse(b.Name) - 1;
                    b.Name = tmp.ToString();
                }
            }
                
            
            
        }
        

        private void btn_play_Click(object sender, EventArgs e)
        {
            melody.OnPlayMelody();
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            panel_melody.Controls.Clear();

            melody = new Melody();

            count = -1;

        }
    }
}