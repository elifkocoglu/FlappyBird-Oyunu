using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 9;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            // Kuşun aşağıya düşmesini sağlamak için yerçekimi etkisini uygula
            FlappyBird.Top += gravity;

            // Her borunun sola hareket etmesini sağla
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            pipeBottom2.Left -= pipeSpeed;
            pipeBottom3.Left -= pipeSpeed;
            pipeTop2.Left -= pipeSpeed;
            pipeTop3.Left -= pipeSpeed;

            // Skoru ekranda güncelle
            scoreText.Text = "Score: " + score;
            // İlk boru seti ekranın solundan çıkarsa, pozisyonunu sıfırla ve skoru artır
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 500;  // İlk boru setinin alt borusunu başlangıç pozisyonuna getir
                score++; // Skoru artır
            }
            if (pipeTop.Left < -150)
            {
                pipeTop.Left = 500;  // İlk boru setinin üst borusunu başlangıç pozisyonuna getir
            }

            // İkinci boru seti ekranın solundan çıkarsa, pozisyonunu sıfırla ve skoru artır
            if (pipeBottom2.Left < -150)
            {
                pipeBottom2.Left = 700;  // İkinci boru setinin alt borusunu başlangıç pozisyonuna getir
                score++; // Skoru artır
            }
            if (pipeTop2.Left < -150)
            {
                pipeTop2.Left = 700;  // İkinci boru setinin üst borusunu başlangıç pozisyonuna getir
            }

            // Üçüncü boru seti ekranın solundan çıkarsa, pozisyonunu sıfırla ve skoru artır
            if (pipeBottom3.Left < -150)
            {
                pipeBottom3.Left = 900;  // Üçüncü boru setinin alt borusunu başlangıç pozisyonuna getir
                score++; // Skoru artır
            }
            if (pipeTop3.Left < -150)
            {
                pipeTop3.Left = 900;  // Üçüncü boru setinin üst borusunu başlangıç pozisyonuna getir
            }

            // Kuşun herhangi bir boruya veya zemine çarpıp çarpmadığını kontrol et
            if (FlappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
        FlappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
        FlappyBird.Bounds.IntersectsWith(pipeBottom2.Bounds) ||
        FlappyBird.Bounds.IntersectsWith(pipeTop2.Bounds) ||
        FlappyBird.Bounds.IntersectsWith(pipeBottom3.Bounds) ||
        FlappyBird.Bounds.IntersectsWith(pipeTop3.Bounds) ||
        FlappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();   // Oyun bitirme fonksiyonunu çağır
            }
            //skor belirli bir değere ulaşınca hızı arttır
            if (score > 25)
            {
                pipeSpeed = 13   ;
            }
            else if(score > 17)
            {
                pipeSpeed = 12 ;
            }
            else if (score > 10)
            {
                pipeSpeed = 11;
            }

            // Kuş ekranın üst sınırına çarparsa oyunu bitir
            if (FlappyBird.Top < -25)
            {
                endGame();
            }
        }

        

        private void gameKeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -9;
            }


        }

        private void gameKeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 9 ;
            }

        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += "Game Over";

        }

        private void FlappyBird_Click(object sender, EventArgs e)
        {

        }

        private void pipeTop2_Click(object sender, EventArgs e)
        {

        }

        private void pipeBottom2_Click(object sender, EventArgs e)
        {

        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }
    }
}
