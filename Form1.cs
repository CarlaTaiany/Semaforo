using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Semaforo
{
    public partial class Semafaro : Form
    {
        // Variável para controlar o estado atual do semáforo
        private int estadoSemafaro = 0; // 0: Desligado, 1: Vermelho, 2: Verde, 3: Amarelo

        public Semafaro()
        {
            InitializeComponent();
            // Garante que a imagem inicial seja a desligada
            pibSemafaro.Image = Properties.Resources.semafDesligado;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Começa no vermelho quando inicia
            estadoSemafaro = 1;
            pibSemafaro.Image = Properties.Resources.semafVermelho;
            tmrTempo.Start(); // Inicia o Timer

        }

        private void btnParar_Click(object sender, EventArgs e)
        {
            tmrTempo.Stop(); // Para o Timer
            estadoSemafaro = 0; // Volta para o estado desligado
            pibSemafaro.Image = Properties.Resources.semafDesligado;
        }

        private void tmrTempo_Tick(object sender, EventArgs e)
        {
            // Lógica para trocar as cores do semáforo
            estadoSemafaro++; // Avança para o próximo estado

            // Se o estado for maior que 3 (amarelo), volta para 1 (vermelho)
            if (estadoSemafaro > 3)
            {
                estadoSemafaro = 1;
            }

            // Define a imagem com base no estado atual
            switch (estadoSemafaro)
            {
                case 1: // Vermelho
                    pibSemafaro.Image = Properties.Resources.semafVermelho;
                    break;
                case 2: // Amarelo
                    pibSemafaro.Image = Properties.Resources.semafVerde;
                    break;
                case 3: // Verde
                    pibSemafaro.Image = Properties.Resources.semafAmarelo;
                    break;
            }
        }
    }
}
