using System;
using System.Windows.Forms;

namespace kalk
{
    public partial class Standardni : Form
    {
        public Standardni()
        {
            InitializeComponent();
        }
		private Form activateForm = null;
		private void OpenChildForm(Form childForm)
		{
			if (activateForm != null)
				activateForm.Close();
			activateForm = childForm;
			childForm.TopLevel = false;
			childForm.FormBorderStyle = FormBorderStyle.None;
			childForm.Dock = DockStyle.Fill;
			panel1.Controls.Add(childForm);
			panel1.Tag = childForm;
			childForm.BringToFront();
			childForm.Show();
		}

		double rezultat1, rezultat2 = 0;
		double jednako, ZadnjiRezultat;
		int i, fact = 1, number;
		readonly string decimala = ".";

		//Većina komentara se nalaze u Znanstveni.cs

		private void Znanstveni_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Znanstveni()); //otvara Znanstveni kalkulator
		}
		//---------------
		private void BrSedam_Click(object sender, EventArgs e)
		{
			rezultat.Text += 7;
		}

		private void BrOsam_Click(object sender, EventArgs e)
		{
			rezultat.Text += 8;
		}

		private void BrDevet_Click(object sender, EventArgs e)
		{
			rezultat.Text += 9;
		}

		private void BrCetiri_Click(object sender, EventArgs e)
		{
			rezultat.Text += 4;
		}

		private void BrPet_Click(object sender, EventArgs e)
		{
			rezultat.Text += 5;
		}

		private void BrSest_Click(object sender, EventArgs e)
		{
			rezultat.Text += 6;
		}

		private void BrJedan_Click(object sender, EventArgs e)
		{
			rezultat.Text += 1;
		}

		private void BrDva_Click(object sender, EventArgs e)
		{
			rezultat.Text += 2;
		}

		private void BrTri_Click(object sender, EventArgs e)
		{
			rezultat.Text += 3;
		}

		private void BrNula_Click(object sender, EventArgs e)
		{
			rezultat.Text += 0;
		}
		//---------------
		private void DecimalniZarez_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
			}
			else
			{
				if (rezultat.Text == "")
				{
					rezultat.Text += 0 + DecimalniZarez.Text;
				}
				else
				{
					rezultat.Text += DecimalniZarez.Text;
				}
			}
		}

		private void Brisanje_Click(object sender, EventArgs e)
		{
			if (rezultat.Text != string.Empty)
			{
				int duzina = rezultat.Text.Length;
				if (duzina != 1)
				{
					rezultat.Text = rezultat.Text.Remove(duzina - 1);
				}
				else
				{
					rezultat.Text = 0.ToString();
				}
			}
		}

		private void PlusMinus_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.StartsWith("-"))
			{
				rezultat.Text = rezultat.Text.Substring(1);
			}
			else if (!string.IsNullOrEmpty(rezultat.Text) && decimal.Parse(rezultat.Text) != 0)
			{
				rezultat.Text = "-" + rezultat.Text;
			}
		}

		private void Pi_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
			}
			else
			{
				rezultat.Text += 3.14159265359;
			}
		}

		private void Ebroj_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
			}
			else
			{
			rezultat.Text += 2.718281828;
			}
		}

		private void Reset_Click(object sender, EventArgs e)
		{
			rezultat.Clear();
			PraviRezultat.Text = "";
		}

		private void ProsliRezultat_Click(object sender, EventArgs e)
		{
			rezultat.Text = Convert.ToString(ZadnjiRezultat);
		}

		//---------------
		private void Plus_Click(object sender, EventArgs e)
		{
			{
				if (rezultat.Text == "" && PraviRezultat.Text == "")
				{
					return;
				}
				else if (rezultat.Text == "" && PraviRezultat.Text != "")
				{
					rezultat.Text = PraviRezultat.Text;
					jednako = 1;
					rezultat1 = Convert.ToDouble(rezultat.Text);
					rezultat.Clear();
				}
				else
				{
					jednako = 1;
					rezultat1 = Convert.ToDouble(rezultat.Text);
					rezultat.Clear();
				}

			}
		}

		private void Minus_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 2;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 2;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void Mnozenje_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 3;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 3;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void Djeljenje_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 4;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 4;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void Postotak_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 5;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 5;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void Korijen_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				jednako = 6;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
				rezultat2 = Math.Sqrt(rezultat1);
				rezultat.Text = "";
				PraviRezultat.Text = rezultat2.ToString();
				ZadnjiRezultat = rezultat2;
				rezultat1 = 0;
			}
			else
			{
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
				rezultat2 = Math.Sqrt(rezultat1);
				rezultat.Text = "";
				PraviRezultat.Text = rezultat2.ToString();
				ZadnjiRezultat = rezultat2;
				rezultat1 = 0;
			}
		}

		private void Kvadriranje_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				jednako = 7;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
				rezultat2 = Math.Pow(rezultat1, 2);
				rezultat.Text = "";
				PraviRezultat.Text = rezultat2.ToString();
				ZadnjiRezultat = rezultat2;
				rezultat1 = 0;
			}
			else
			{
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
				rezultat2 = Math.Pow(rezultat1, 2);
				rezultat.Text = "";
				PraviRezultat.Text = rezultat2.ToString();
				ZadnjiRezultat = rezultat2;
				rezultat1 = 0;
			}
		}

		private void Xna_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 8;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 8;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void Faktorijela_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text.Contains(decimala))
			{
				return;
			}
			else
			{
				number = Convert.ToInt32(rezultat.Text);
				for (i = 1; i <= number; i++)
				{
					fact *= i; 
					rezultat.Text = fact.ToString();
				}
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
				PraviRezultat.Text = rezultat1.ToString();
				ZadnjiRezultat = rezultat1;
				number = 1;         
				fact = 1;           
				i = 1;              
				rezultat1 = 0;      
			}
		}

		private void XkorijenY_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 9;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 9;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}
		//---------------
		private void Jednako_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "")
			{
				return;
			}
			else
			{
				switch (jednako)
				{
					case 1:
						rezultat2 = rezultat1 + Convert.ToDouble(rezultat.Text);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 2:
						rezultat2 = rezultat1 - Convert.ToDouble(rezultat.Text);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 3:
						rezultat2 = rezultat1 * Convert.ToDouble(rezultat.Text);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 4:
						rezultat2 = rezultat1 / Convert.ToDouble(rezultat.Text);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 5:
						rezultat2 = rezultat1 % Convert.ToDouble(rezultat.Text);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 6:
						rezultat2 = Math.Sqrt(rezultat1);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 7:
						rezultat2 = Math.Pow(rezultat1, 2);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 8:
						rezultat2 = double.Parse(rezultat.Text);
						rezultat.Text = "";
						rezultat2 = Math.Pow(rezultat1, rezultat2);
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 9:
						rezultat2 = double.Parse(rezultat.Text);
						rezultat2 = Math.Sqrt(rezultat2);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;
				}
			}
		}
	}
}
