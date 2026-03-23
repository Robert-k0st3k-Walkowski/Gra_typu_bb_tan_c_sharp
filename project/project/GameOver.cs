using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace project
{
    // Klasa "GameOver" odpowiadająca (tak naprawdę tylko) za sprawdzanie czy gra powinna się zakończyć.

    class GameOver
    {
        // Deklaracja (oraz ewentalna definicja) pól tej klasy.

        bool isGameOverAlready = false;

        List<PictureBox> playerHeartsList;

        Form2 GameWindow;

        int score;

        // Konstruktor klasy "GameOver", który jako argumenty przyjmuje:
        // Listę obiektów klasy "PictureBox" (serduszka gracza),
        // Zmienną typu "bool" (czy gra powinna się zakończyć - dla wyświetlania pojedynczego okna "MessageBox")
        // Obiekt klasy "Form2" (okienko gry).
        // Przypisuje dane wartości odpowiednim polom tejże klasy.

        public GameOver(List<PictureBox> givenHearts, bool givenGameOver, Form2 GivenGameWindow)
        {
            isGameOverAlready = givenGameOver;
            playerHeartsList = givenHearts;
            GameWindow = GivenGameWindow;
        }

        // Metoda "isGameOver", która nie przyjmuje żadnych argumentów i sprawdza, czy gra się zakończyła i
        // jeżeli tak, to zostaje wyświetlony odpowiedni komunikat oraz po jego zamknięciu gracz zostaje automatcznie
        // przekierowany do głównego menu.

        public void isGameOver(int finalScore)
        {
            if (playerHeartsList.Count <= 0 && !isGameOverAlready)
            {
                isGameOverAlready = true;

                this.score = finalScore;

                MessageBox.Show($"Your score is: {score}!\n" +
                                "After clicking \'Ok\' button you will get back to main menu.\n" +
                                "Good luck in the next time!",
                                "GAME OVER!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);

                GameWindow.Close();
            }
        }
    }
}
