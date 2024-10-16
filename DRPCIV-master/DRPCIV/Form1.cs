/**************************************************************************
 *                                                                        *
 *  File:        Form.cs                                                  *
 *  Copyright:   (c) 2023, grupa 1310A, echipa 17                         *    
 *  Description: This file contains the form implemtation                 *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GenereazaIntrebari;
using InitVariabile;
using IntrebareNmSpc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace DRPCIV
{
	public partial class Form1 : Form
	{
		//initialization of the variables
		string s1;
		private string _pathIntrebari = @"..\..\Resources\intrebari.json";
		private string _json;
		private List<Intrebare> _intrebari;
		private Queue<Intrebare> _coadaIntrebari;
		private int _intrebariLength;
		private int _nrIntrebare;

		private Color _buttonColorDark = Color.CornflowerBlue; 
		private Color _buttonColorLight = Color.WhiteSmoke;
		private Color _buttonForeDark = Color.Black;
		private Color _buttonForeLight = Color.White;
		private int _pagina = 0; //0 - pagina de acasa, 1 - pagina cu chestionar, 2 - pagina de respins, 3 - pagina de acceptat

		private static int _minuteTimer;
		private TimeSpan _timp;
		private Timer _timer = new Timer();
		private Random random;

		public int _nrIntrebariInitiale;
		private int _nrIntrebariRamase;
		private int _nrRaspunsuriCorecte = 0;
		private int _nrRaspunsuriGresite = 0;

		private int _nrMaxRaspCorecte;
		private int _nrMinRaspCorecte;
		private int _nrDiferentaRaspCorecte;
		private int _nrMaxRaspGresite;

		private int _PaginaStart = 0;
		private int _PaginaChestionar = 1;
		private int _PaginaRespins = 2;
		private int _PaginaAdmis = 3;

		public Form1()
		{
			InitializeComponent();
			try
			{
				_json = File.ReadAllText(_pathIntrebari);
				try
				{
					_intrebari = JsonConvert.DeserializeObject<List<Intrebare>>(_json);
					_coadaIntrebari = new Queue<Intrebare>(_nrIntrebariInitiale);
					_intrebariLength = _intrebari.Count;
				}
				catch (JsonReaderException ex)
				{
					MessageBox.Show("Error deserializing JSON: " + ex.Message);
				}
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show("File not found: " + ex.FileName);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Error reading file: " + ex.Message);
			}


			
			// configurare Timer
			_timer.Interval = 1000; // emite un eveniment la fiecare secundă
			_timer.Tick += Timer_Tick; // se leagă de evenimentul Timer.Tick
		}

        /// <summary>
        /// Function of the select the category button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectCategory_Click(object sender, EventArgs e)
		{
			_pagina =_PaginaChestionar;
			buttonSelectCategory.BackColor = _buttonColorDark;
			buttonSelectCategory.ForeColor = _buttonColorLight;

			
		}
		
		/// <summary>
		/// Function of the start button 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonStart_Click(object sender, EventArgs e)
		{
			try
			{
				if (_pagina == _PaginaStart)
				{
					throw new MyException("Nu ati selectat categoria!");
				}
				else
				{
					IVariableContainer variableContainer = new VariableContainer();
					InitVar.InitializeazaVariabile(variableContainer, _intrebariLength);

					_coadaIntrebari = Intrebari.GenereazaIntrebarile(random, variableContainer.NrIntrebariInitiale, _intrebariLength, _intrebari).getItems();

					_nrIntrebariInitiale = variableContainer.NrIntrebariInitiale;
					_nrIntrebariRamase = variableContainer.NrIntrebariRamase;
					_minuteTimer = variableContainer.MinuteTimer;
					_nrMaxRaspCorecte = variableContainer.NrMaxRaspCorecte;
					_nrDiferentaRaspCorecte = variableContainer.NrDiferentaRaspCorecte;
					_nrMinRaspCorecte = variableContainer.NrMinRaspCorecte;
					_nrMaxRaspGresite = variableContainer.NrMaxRaspGresite;
					ActualizareLabelChestionar();

					buttonSelectCategory.BackColor = _buttonColorLight;
					buttonSelectCategory.ForeColor = _buttonColorDark;
					if (_pagina == _PaginaChestionar)
					{
						_timp = new TimeSpan(0, _minuteTimer, 0);
						labelTimpRamas.ForeColor = Color.Black;
						tabControlPagini.SelectedIndex = _PaginaChestionar;
					}
					_timer.Start();
					labelTimpRamas.Text = _timp.ToString(@"mm\:ss");
				}
			}
            catch(MyException ex) {
				MessageBox.Show(ex.Message);
			}
			// apelez functia care genereaza 
			genereazaOIntrebare();
		}

		/// <summary>
		/// Function of question generator
		/// </summary>
		private void genereazaOIntrebare()
		{
			//MessageBox.Show(_coadaIntrebari.Count.ToString());
			if(_coadaIntrebari.Count > 0)
			{
				Intrebare intrebareCurenta = _coadaIntrebari.Peek();
				if (intrebareCurenta.src_imagine == "null")
				{
					tabControlChestionar.SelectedIndex = 0;
					labelIntrebareFaraPoza.Text =/* (_nrIntrebariInitiale+1-_nrIntrebariRamase)+". "+*/intrebareCurenta.intrebare;
					buttonRaspFaraPozaA.Text = intrebareCurenta.variante[0];
					buttonRaspFaraPozaB.Text = intrebareCurenta.variante[1];
					buttonRaspFaraPozaC.Text = intrebareCurenta.variante[2];
				}
				else
				{

					tabControlChestionar.SelectedIndex = 1;
					labelIntrebareCuPoza.Text =/* (_nrIntrebariInitiale + 1 - _nrIntrebariRamase) + ". " +*/ intrebareCurenta.intrebare;
					buttonRaspCuPozaA.Text = intrebareCurenta.variante[0];
					buttonRaspCuPozaB.Text = intrebareCurenta.variante[1];
					buttonRaspCuPozaC.Text = intrebareCurenta.variante[2];
					pictureBoxChestionar.Image = Image.FromFile(intrebareCurenta.src_imagine);
				}
			}
			buttonModificaRaspunsul.Enabled = false;
			buttonTrimiteRaspunsul.Enabled = false;
		}

		/// <summary>
		/// Function of the timer
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e)
		{
			// scade o secundă din timp
			_timp = _timp.Subtract(new TimeSpan(0, 0, 1));

			// daca timpul scade sub 5 minute, textul se face rosu
			if (_timp.TotalMinutes < 5)
			{
				labelTimpRamas.ForeColor = Color.Red;
			}

			// actualizează textul din Label
			labelTimpRamas.Text = _timp.ToString(@"mm\:ss");
		}

		/// <summary>
		/// Function of the reset
		/// </summary>
		private void Resetare()
		{
			_timer.Stop();
			_pagina = _PaginaStart;
			_nrIntrebariRamase = _nrIntrebariInitiale;
			_nrRaspunsuriGresite = 0;
			_nrRaspunsuriCorecte = 0;
			ActualizareLabelChestionar();
		}

		private void ActualizareLabelChestionar()
		{
			labelNrIntrebariInitiale.Text=_nrIntrebariInitiale.ToString();
			labelNrIntrebariRamase.Text = _nrIntrebariRamase.ToString();
			labelNrRaspCorecte.Text = _nrRaspunsuriCorecte.ToString();
			labelNrRaspGresite.Text = _nrRaspunsuriGresite.ToString();
		}

		/// <summary>
		/// Function of home button1
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRevinoAcasa_Click(object sender, EventArgs e)
		{
			_pagina = _PaginaStart;
			_timp = new TimeSpan(0, _minuteTimer, 0);
			labelTimpRamas.ForeColor = Color.Black;
			tabControlPagini.SelectedIndex = _PaginaStart;
		}

		/// <summary>
		/// Function of home button2
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRevinoAcasa2_Click(object sender, EventArgs e)
		{
			_pagina = _PaginaStart;
			_timp = new TimeSpan(0, _minuteTimer, 0);
			labelTimpRamas.ForeColor = Color.Black;
			tabControlPagini.SelectedIndex = _PaginaStart;
		}


		/// <summary>
		/// Function of answer later button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRaspundeMaiTarziu_Click(object sender, EventArgs e)
		{
			resetButoane();
			Intrebare intrebare=_coadaIntrebari.Dequeue();
			_coadaIntrebari.Enqueue(intrebare);
			genereazaOIntrebare();
		}


		/// <summary>
		/// Function of modify answer button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonModificaRaspunsul_Click(object sender, EventArgs e)
		{
			//_nrRaspunsuriGresite++;
			//_nrIntrebariRamase--;
			ActualizareLabelChestionar();
			resetButoane();
			//tabControlChestionar.SelectedIndex = 0;
		}


		/// <summary>
		/// Function of send answer button
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonTrimiteRaspunsul_Click(object sender, EventArgs e)
		{
			_nrIntrebariRamase--;
			//tabControlChestionar.SelectedIndex = 1;
			bool corect;
			bool[] raspunsUtilizator = new bool[] { _raspA, _raspB, _raspC };
			string raspunsUtilizatorString = new string(raspunsUtilizator.Select(b => b ? '1' : '0').ToArray());
			corect= _coadaIntrebari.Peek().raspunsuri_corecte.SequenceEqual(raspunsUtilizatorString);
			if (corect == true)
			{
				_nrRaspunsuriCorecte++;
			}
			else
			{
				_nrRaspunsuriGresite++;
			}
			ActualizareLabelChestionar();
			resetButoane();
			if(_coadaIntrebari.Count > 0)
			{
				_coadaIntrebari.Dequeue();
				genereazaOIntrebare();
			}

			if (_timp.TotalSeconds == 0 || _nrRaspunsuriGresite >= _nrMaxRaspGresite)
			{
				// Respins
				_pagina = _PaginaRespins;
				tabControlPagini.SelectedIndex = _PaginaRespins;
				Resetare();
			}
			if (_nrIntrebariRamase == 0 && _nrRaspunsuriCorecte >= _nrMinRaspCorecte && _nrRaspunsuriCorecte <= _nrMaxRaspCorecte)
			{
				// Admis
				_pagina = _PaginaAdmis;
				tabControlPagini.SelectedIndex = _PaginaAdmis;
				_timer.Stop();
				Resetare();
			}
		}

		private bool _raspA = false;
		private bool _raspB = false;
		private bool _raspC = false;
		private Color _raspColorDark = Color.Gold;
		private Color _raspColorLight = Color.White;


		/// <summary>
		/// Function of reset buttons
		/// </summary>
		private void resetButoane()
		{
			_raspA = false;
			_raspB = false;
			_raspC = false;
			buttonRaspCuPozaA.BackColor = _raspColorLight;
			buttonRaspCuPozaB.BackColor = _raspColorLight;
			buttonRaspCuPozaC.BackColor = _raspColorLight;
			buttonRaspFaraPozaA.BackColor = _raspColorLight;
			buttonRaspFaraPozaB.BackColor = _raspColorLight;
			buttonRaspFaraPozaC.BackColor = _raspColorLight;

			buttonModificaRaspunsul.Enabled= false;
			buttonTrimiteRaspunsul.Enabled = false;
		}


		/// <summary>
		/// Function of enable buttons
		/// </summary>
		private void enableButoaneChestionar()
		{
			buttonModificaRaspunsul.Enabled = true;
			buttonTrimiteRaspunsul.Enabled = true;
		}
		private void buttonRaspFaraPozaA_Click(object sender, EventArgs e)
		{
			_raspA = true;
			buttonRaspFaraPozaA.BackColor = _raspColorDark;
			enableButoaneChestionar();
		}

		private void buttonRaspFaraPozaB_Click(object sender, EventArgs e)
		{
			_raspB = true;
			buttonRaspFaraPozaB.BackColor = _raspColorDark;
			enableButoaneChestionar();
		}

		private void buttonRaspFaraPozaC_Click(object sender, EventArgs e)
		{
			_raspC = true;
			buttonRaspFaraPozaC.BackColor = _raspColorDark;
			enableButoaneChestionar();
		}

		private void buttonRaspCuPozaA_Click(object sender, EventArgs e)
		{
			_raspA = true;
			buttonRaspCuPozaA.BackColor = _raspColorDark;
			enableButoaneChestionar();
		}

		private void buttonRaspCuPozaB_Click(object sender, EventArgs e)
		{
			_raspB = true;
			buttonRaspCuPozaB.BackColor = _raspColorDark;
			enableButoaneChestionar();
		}

		private void buttonRaspCuPozaC_Click(object sender, EventArgs e)
		{
			_raspC = true;
			buttonRaspCuPozaC.BackColor = _raspColorDark;
			enableButoaneChestionar();
		}
	}
}
