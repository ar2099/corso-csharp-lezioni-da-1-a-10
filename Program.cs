using System;
namespace Biblio
{
    public class Utente
    {
        //4 attributi (privati, non accessibili da fuori->incapsulamento)

        private string id;

        private string nome;

        private string cognome;

        private int annoIscrizione;

        //Costruttore
        public Utente(string id, string nome, string cognome, int annoIscrizione)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.annoIscrizione = annoIscrizione;
        }

        //Metodo di istanza
        public string Denominazione()
        {
            return this.nome + " " + this.cognome;
        }
    }

    public class Libro
    {

        private string id;

        private string autore;

        private string titolo;

        private Utente utente;

        //costruttore
        public Libro(string id, string autore, string titolo)
        {
            this.id = id;
            this.autore = autore;
            this.titolo = titolo;
            this.utente = null;
        }

        //metodo di istanza
        public string Descrizione()
        {
            return this.titolo + " " + this.autore;
        }

        //metodo di istanza
        //void perchè non ritorna niente
        public void Prestito(Utente utente)
        {
            if (this.utente != null)
            {
                Console.WriteLine($"Titolo già in prestito a {this.utente.Denominazione()}");
                return;
            } else
            {
                Console.WriteLine($"Titolo disponibile");
                this.utente = utente;
                Console.WriteLine($"Titolo prestato a {this.utente.Denominazione()}");
                return;
            }

        }

        public void Restituizione()
        {
            Console.WriteLine($"{this.utente.Denominazione()} ha restituito il libro");
            this.utente = null;
        }

    }

    public class Biblioteca
    {
        //metodo statico
        public static void Main(string[] args)
        {
            Utente utente1 = new Utente("ab12w", "Mario", "Rossi", 2021);
            Console.WriteLine($"Creazione utente: {utente1.Denominazione()}");

            Utente utente2 = new Utente("df765", "Ciccio", "Giallo", 2019);
            Console.WriteLine($"Creazione utente: {utente2.Denominazione()}");

            Libro libro1 = new Libro("pq01", "Ciccioni volanti", "Malgioglio");
            Console.WriteLine($"Creazione libro: {libro1.Descrizione()}");

            libro1.Prestito(utente1);
            libro1.Prestito(utente2);
            libro1.Restituizione();
            libro1.Prestito(utente2);
        }
    }
}