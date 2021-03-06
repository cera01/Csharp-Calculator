﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace kalk
{
	public partial class Znanstveni : Form
	{
		double jednako, radian, ZadnjiRezultat;
		double rezultat1, rezultat2 = 0d;
		int i, fact = 1, number;
		readonly string decimala = ".";

		public Znanstveni()
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
//----------------
//brojevi
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
//----------------
//tip kalkulatora
		private void Standard_Click(object sender, EventArgs e)
		{
			OpenChildForm(new Standardni());
			this.Hide();
			//vraća na Standardni i sakriva Znanstveni tip kalkulatora
		}
//----------------
//funkcije koje nisu u switch komandi
		private void DecimalniZarez_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
				//neće dopustiti da se unese više od jedne decimale
			}
			else
			{
				if (rezultat.Text == "")
				{
					rezultat.Text += 0 + DecimalniZarez.Text;
					//dodaje nulu iza decimale ako korisnik pritisne decimalu bez ikakvog broja
				}
				else
				{
					rezultat.Text += DecimalniZarez.Text;
					//dodaje decimalnu točku
				}
			}
		}

		private void PlusMinus_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.StartsWith("-"))
			{
				rezultat.Text = rezultat.Text.Substring(1);
				//ako rezultat već ima - u sebi onda će se on izbrisati
			}
			else if (!string.IsNullOrEmpty(rezultat.Text) && decimal.Parse(rezultat.Text) != 0)
			{
				rezultat.Text = "-" + rezultat.Text;
				//rezultat se negira
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
					//briše broj po broj
				}
				else
				{
					rezultat.Text = 0.ToString();
				}
			}
		}

		private void ProsliRezultat_Click(object sender, EventArgs e)
		{
			rezultat.Text = Convert.ToString(ZadnjiRezultat);
		}

		private void Pi_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
				/*ne dopušta da se pi unese više puta zato što bi rezultat onda imao više decimala 
				tj. došlo bi do greške*/
			}
			else
			{
					rezultat.Text += 3.14159265359;
					/* unosi pi */
			}
		}

		private void Tao_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
			}
			else
			{
				rezultat.Text += 6.28318530717;
			}
		}

		private void Phi_Click(object sender, EventArgs e)
		{
			if (rezultat.Text.Contains(decimala))
			{
				return;
			}
			else
			{
				rezultat.Text += 1.61803398874;
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
				rezultat.Text += 2.71828182845;
			}
		}

		private void Resetiranje_Click(object sender, EventArgs e)
		{
			rezultat.Clear();
			PraviRezultat.Text = "";
			//obriše cijeli rezultat
		}
//----------------
//funckije u switch komandi
		private void Plus_Click(object sender, EventArgs e)
		{
			{
				if (rezultat.Text == "" && PraviRezultat.Text == "") //provjerava ima li broja u poljima za unos teksta
				{
					//ako nema brojeva
					return;
					//u rezultatu mora postojati broj prije pritiska gumba ili će doći do greške
				}
				else if (rezultat.Text == "" && PraviRezultat.Text != "")
				{
					//ako broja ima samu u polju gdje se unose brojevi
					rezultat.Text = PraviRezultat.Text;
					jednako = 1;
					rezultat1 = Convert.ToDouble(rezultat.Text); //uzima rezultat i pretvara ga iz string u double
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

		private void EksponencijalnaFunkcija_Click(object sender, EventArgs e)
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

		private void Sinus_Click(object sender, EventArgs e)
		{
				if (Sinus.Text == "sin")
				{
					if (rezultat.Text == "" && PraviRezultat.Text == "")
					{
						return;
					}
					else if (rezultat.Text == "" && PraviRezultat.Text != "")
					{
						rezultat.Text = PraviRezultat.Text;
						jednako = 10;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
					else
					{
						jednako = 10;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
				}
				else
				{
					if (rezultat.Text == "" && PraviRezultat.Text == "")
					{
						return;
					}
					else if (rezultat.Text == "" && PraviRezultat.Text != "")
					{
						rezultat.Text = PraviRezultat.Text;
						jednako = 17;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
					else
					{
						jednako = 17;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
				}
		} 

		private void Kosinus_Click(object sender, EventArgs e)
		{
				if (Kosinus.Text == "cos")
				{
					if (rezultat.Text == "" && PraviRezultat.Text == "")
					{
						return;
					}
					else if (rezultat.Text == "" && PraviRezultat.Text != "")
					{
						rezultat.Text = PraviRezultat.Text;
						jednako = 11;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
					else
					{
						jednako = 11;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
				}
				else
				{
					if (rezultat.Text == "" && PraviRezultat.Text == "")
					{
						return;
					}
					else if (rezultat.Text == "" && PraviRezultat.Text != "")
					{
						rezultat.Text = PraviRezultat.Text;
						jednako = 18;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
					else
					{
						jednako = 18;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
				}
		} 

		private void Tangens_Click(object sender, EventArgs e)
		{
				if (Tangens.Text == "tan")
				{
					if (rezultat.Text == "" && PraviRezultat.Text == "")
					{
						return;
					}
					else if (rezultat.Text == "" && PraviRezultat.Text != "")
					{
						rezultat.Text = PraviRezultat.Text;
						jednako = 12;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
					else
					{
						jednako = 12;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
				}
				else
				{
					if (rezultat.Text == "" && PraviRezultat.Text == "")
					{
						return;
					}
					else if (rezultat.Text == "" && PraviRezultat.Text != "")
					{
						rezultat.Text = PraviRezultat.Text;
						jednako = 19;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
					else
					{
						jednako = 19;
						rezultat1 = Convert.ToDouble(rezultat.Text);
						rezultat.Clear();
					}
				}
		} 

		private void Logoritam_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 13;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 13;
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
			else if(rezultat.Text.Contains(decimala))
			{
				return;
				//faktorijela sa decimalom bi uzrokovala grešku
			}
			else
			{
				number = Convert.ToInt32(rezultat.Text);
				for (i = 1; i <= number; i++)
				{
					fact *= i; //fact * i
					rezultat.Text = fact.ToString();
				}
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
				PraviRezultat.Text = rezultat1.ToString();
				ZadnjiRezultat = rezultat1;
				number = 1;			//
				fact = 1;			//vraća varijable natrag u njihovo početno stanje kako bi se 
				i = 1;			    //i dalje mogle koristiti više puta
				rezultat1 = 0;		//
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
				jednako = 15;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 15;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void DesetNaX_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 16;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 16;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void NaturalLog_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 20;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 20;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		private void Absolute_Click(object sender, EventArgs e)
		{
			if (rezultat.Text == "" && PraviRezultat.Text == "")
			{
				return;
			}
			else if (rezultat.Text == "" && PraviRezultat.Text != "")
			{
				rezultat.Text = PraviRezultat.Text;
				jednako = 21;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
			else
			{
				jednako = 21;
				rezultat1 = Convert.ToDouble(rezultat.Text);
				rezultat.Clear();
			}
		}

		//----------------
		//2nd funkcija
		private void PrvaFunkcija_Click(object sender, EventArgs e)
		{
			PrvaFunkcija.BackColor = Color.Black;
			PrvaFunkcija.ForeColor = Color.White;
			DrugaFunkcija.BackColor = Color.White;
			DrugaFunkcija.ForeColor = Color.Black;
			Sinus.Text = "sin";
			Kosinus.Text = "cos";
			Tangens.Text = "tan";
		}
		private void DrugaFunkcija_Click(object sender, EventArgs e)	
		{
			PrvaFunkcija.BackColor = Color.White;
			PrvaFunkcija.ForeColor = Color.Black;
			DrugaFunkcija.BackColor = Color.Black;
			DrugaFunkcija.ForeColor = Color.White;
			Sinus.Text = "sin⁻¹";
			Kosinus.Text = "cos⁻¹";
			Tangens.Text = "tan⁻¹";
		}
//----------------
//jednako
		private void Jednako_Click(object sender, EventArgs e)
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
						rezultat2 = Math.Exp(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 10:
						rezultat2 = Math.Sin(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 11:
						rezultat2 = Math.Cos(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 12:
						rezultat2 = Math.Tan(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 13:
						rezultat2 = Math.Log10(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 15:
						rezultat2 = double.Parse(rezultat.Text);
						rezultat2 = Math.Sqrt(rezultat2);
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 16:
						rezultat2 = Math.Pow(10, rezultat1);
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 17:
						if (rezultat1 > 1 || rezultat1 < -1)
						{
							rezultat.Text = "0";
						}
						else
						{
							rezultat2 = Math.Asin(rezultat1);
							radian = rezultat2 * (180 / 3.14159265359);
							rezultat.Text = radian.ToString();
							PraviRezultat.Text = rezultat2.ToString();
							ZadnjiRezultat = rezultat2;
							rezultat1 = 0;
							radian = 0;
						}
						break;

					case 18:
						if (rezultat1 > 1 || rezultat1 < -1)
						{
							rezultat.Text = "0";
						}
						else
						{
							rezultat2 = Math.Acos(rezultat1);
							radian = rezultat2 * (180 / 3.14159265359);
							rezultat.Text = radian.ToString();
							PraviRezultat.Text = rezultat2.ToString();
							ZadnjiRezultat = rezultat2;
							rezultat1 = 0;
							radian = 0;
						}
						break;

					case 19:
						rezultat2 = Math.Atan(rezultat1);
						radian = rezultat2 * (180 / 3.14159265359);
						rezultat.Text = radian.ToString();
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						radian = 0;
						break;

					case 20:
						rezultat2 = Math.Log(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;

					case 21:
						rezultat2 = Math.Abs(rezultat1);
						rezultat.Text = rezultat2.ToString();
						rezultat.Text = "";
						PraviRezultat.Text = rezultat2.ToString();
						ZadnjiRezultat = rezultat2;
						rezultat1 = 0;
						break;
			}
		}
	}
}
