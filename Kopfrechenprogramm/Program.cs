/*
 * Author:          Sven Ebensen und Leon Jockschies
 * Datum:           21.November 2014
 * Fach:            Programmieren
 * Dozent:          Herr Schönland
 * Aufgabe:         Erstelle ein Programm welches dem Benutzer zufällige Rechenaufgaben 
 *                  stellt welche dann vom Benutzer errechnet werden und das 
 *                  Ergebnis vom Programm überprüft wird. 
 *          
 * Funktionsweise:  Zufällige Zahlen zum Rechnen und zufällige Rechenoperatoren.
 *                  Ergebnis wird vom Programm überprüft.
 *                  Bei richtiger Lösung gibt es 1 Punkt.
 *                  Bei falscher Lösung hat man insgesamt 3 Versuche diese richtig zuerrechnen 
 *                  ansonsten gibt es einen halben Punkt abzug.
 *                  
 * Geplant:         Ein Highscore System.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kopfrechenprogramm
{
    class Program
    {

        static Random zufall = new Random();
        static Random zeichen = new Random();
        static void Main(string[] args)
        {
            //Initialisierung und Deklaration von Variablen außerhalb der Endlosschleife
            string username;                                        //Speicher "username" als String
            double punkte = 0;                                      //Punkte können auch dezimalzahlen sein
            const double halberpunkt = 0.5;                         //halbe punkte gibt es für Falsche lösungen

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("           ___________________________________________________            ");
            Console.WriteLine("          |                                                   |           ");
            Console.WriteLine("          |                    Willkommen!                    |           ");
            Console.WriteLine("          |              Bei der Rechen-Maschine!             |           ");
            Console.WriteLine("          |           Du erhälst Zufällige Aufgaben           |           ");    //Willkommenskasten mit Infos
            Console.WriteLine("          |      du hast pro Aufgabe jeweils 3 Versuche!      |           ");
            Console.WriteLine("          |    Lösung: Richtig = 1 Pkt., Falsch = -0,5 Pkt.   |           ");
            Console.WriteLine("          |                                                   |           ");
            Console.WriteLine("          |        von Sven Ebensen & Leon Jockschies         |           ");
            Console.WriteLine("          |___________________________________________________|           ");

            Console.WriteLine("");
            Console.Write("Bitte gebe einen Username an: ");        //Eingabe von "username" verlangen
            username = Convert.ToString(Console.ReadLine());        //Konvertiere den Eingegeben "username" zu einem String

            Anfang:                                                 //Ankerpunkt "Anfang"

            while (true)                                             //Beginne eine Endlosschleife
            {
                //Initialisierung und Deklaration von Variablen innerhalb der Endlosschleife
                char rechenzeichen = '?';                           //rechenzeichen wird als character deklariert und "?" als platzhalter genutzt
                double zahl1, zahl2;                                //zahl1, zahl2 und mein_ergebnis können dezimalzahlen sein
                double meine_eingabe;

                double ergebnis = 0;                                //ergebnis darf eine dezimalzahl sein >>>> momentan noch auf keine nachkommastellen begrenzt WIP <<<<<<

                zahl1 = zufall.Next(1, 100 + 1);                    //Generiere Zufallswert für zahl1
                zahl2 = zufall.Next(1, 100 + 1);                    //Generiere Zuffalswert für zahl2
                int caseswitch = 0;                                 //varibale caseswitch ist am Anfang immer "0"
                caseswitch = zufall.Next(1, 4 + 1);                 //Zufallswert wird generiert von 1 bis 4 
                switch (caseswitch)
                {
                    case 1:                                         //Fall 1 tritt ein wenn der Zufallswert in Zeile 67 "1" ergibt.
                        ergebnis = zahl1 + zahl2;
                        rechenzeichen = '+';                        //In diesem Fall wird dann "plus" gerechnet.
                        break;
                    case 2:                                         //Fall 2 tritt ein wenn der Zufallswert in Zeile 67 "2" ergibt.
                        ergebnis = zahl1 - zahl2;
                        rechenzeichen = '-';                        //In diesem Fall wird dann "minus" gerechnet.
                        break;
                    case 3:                                         //Fall 3 tritt ein wenn der Zufallswert in Zeile 67 "3" ergibt.
                        ergebnis = zahl1 * zahl2;
                        rechenzeichen = '*';                        //In diesem Fall wird dann "mal" gerechnet.
                        break;
                    case 4:                                         //Fall 4 tritt ein wenn der Zufallswert in Zeile 67 "4" ergibt.
                        ergebnis = zahl1 / zahl2;
                        rechenzeichen = '/';                        //In diesem Fall wird dann "geteilt" gerechnet.
                        break;
                }

                int versuche = 1;                                   //Hier werden die Versuche die man brauchte gezählt
                int versuch = 1;                                    //Hier wird gezählt beim wie vielten Versuch man sich grade befindet
                double mein_ergebnis = 0;              

                Console.WriteLine("");
                Console.WriteLine("          =============> Spieler: " + username + " | Punkte: " + punkte + " <=============          ");  //Ausgabe von "username" und "punkte"
                Console.WriteLine("Versuch " + versuch + " von 3!");                                                                        //Ausgabe von "versuch"
                Console.Write("****> " + zahl1 + " " + rechenzeichen + " " + zahl2 + " = ");                                                //Zufällige Zahlen und Rechenzeichen Ausgegeben
                if (double.TryParse(Console.ReadLine(), out meine_eingabe))
                    mein_ergebnis = meine_eingabe;                                                                                           //Warte auf Eingabe und Konvertiere zu double
                else
                    Console.WriteLine("Gebe bitte eine Zahl ein!", Console.ReadLine());
                versuch++;                                                                                                                  //Erhöhe versuch=0:int; um 1

            Richtig:                                                                                                                        //Auf diesen Ankerpunkt wird verwiesen wenn die Lösung Richtig war
                if (mein_ergebnis == ergebnis)                                                                                              //Abfrage wenn mein_ergebnis gleich ergebnis
                {
                    Console.WriteLine("Dein Ergebnis " + mein_ergebnis + " ist Richtig!");                                                  //Ausgabe
                    Console.WriteLine("          ========== >NEUE AUFGABE< ==========           ");                                         //Ausgabe
                    Console.Beep(2500, 200);                                    //Spiele einen Ton ab
                    punkte++;                                                   //Erhöhe punkte=0:int; um 1
                    goto Anfang;                                                //Gehe zum Anker "Anfang"
                }
                else
                {
                Wiederholen:                                                    //Auf diesen Ankerpunkt wird verwiesen wenn die Lösung Falsch war und versuche übrig sind
                    while (versuche <= 2)                                                                                       
                    {
                        if (mein_ergebnis == ergebnis)
                        {
                            goto Richtig;
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Dein Ergebnis " + mein_ergebnis + " ist Falsch!");
                            punkte -= halberpunkt;
                            Console.Beep(500, 800);
                            Console.WriteLine("          =============> Spieler: " + username + " | Punkte: " + punkte + " <=============          ");
                            Console.WriteLine("Versuch " + versuch + " von 3!");
                            Console.Write("****> " + zahl1 + " " + rechenzeichen + " " + zahl2 + " = ");
                            if (double.TryParse(Console.ReadLine(), out meine_eingabe))
                                mein_ergebnis = meine_eingabe;                                                                                           //Warte auf Eingabe und Konvertiere zu double
                            else
                                Console.WriteLine("Gebe bitte eine Zahl ein!", Console.ReadLine());
                            versuche++;
                            versuch++;

                        }
                        if (mein_ergebnis == ergebnis)
                        {
                            goto Richtig;
                        }
                        if (versuch == 4)
                        {
                            Console.WriteLine("\nDu hast 3 mal das Falsche Ergebnis eingegeben das Richtige Ergebnis für \ndie Aufgabe " + zahl1 + " " + rechenzeichen + " " + zahl2 + " lautet: " + ergebnis);
                            Console.WriteLine("          ========== >NEUE AUFGABE< ==========           ");
                            Console.Beep(500, 800);
                            punkte -= halberpunkt;

                        }
                        else
                        {
                            goto Wiederholen;
                        }

                    }

                    versuche = 1;
                    versuch = 1;
                }

                Console.ReadKey();
            }
        }
    }
}

