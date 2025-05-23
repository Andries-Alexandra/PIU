﻿using System;
using LibrarieModele.Enumerari;
using System.Globalization;

namespace LibrarieModele
{
    public class Produs
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';

        private const int ID = 0;
        private const int NUME = 1;
        private const int PRET = 2;
        private const int CATEGORIE = 3;
        private const int DISPONIBIL = 4;

        public int id { get; set; }
        public string nume { get; set; }
        public double pret { get; set; }
        public CategorieProdus categorie { get; set; }
        public bool disponibil { get; set; }

        public Produs()
        {
            id = 0;
            nume = string.Empty;
            pret = 0;
            disponibil = true;
        }

        public Produs(int id, string nume, double pret, bool disponibil = true)
        {
            this.id = id;
            this.nume = nume;
            this.pret = pret;
            this.disponibil = disponibil;
        }

        public Produs(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            this.id = Convert.ToInt32(dateFisier[ID]);
            this.nume = dateFisier[NUME];
            this.pret = Convert.ToDouble(dateFisier[PRET], CultureInfo.InvariantCulture);
            this.categorie = (CategorieProdus)Enum.Parse(typeof(CategorieProdus), dateFisier[CATEGORIE]);
            this.disponibil = dateFisier.Length > DISPONIBIL ? Convert.ToBoolean(dateFisier[DISPONIBIL]) : true;
        }

        public string Info()
        {
            return $"ID produs: {id}, denumire produs: {nume}, pret: {pret:F2} LEI, Categorie: {categorie}, Disponibil: {disponibil}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3},{4}", id, nume, pret, categorie, disponibil);
        }
    }
}