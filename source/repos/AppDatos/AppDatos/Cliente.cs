using System;
using System.Collections.Generic;
using System.Text;

namespace AppDatos
{
    class Cliente : Persona 
    {
        private string banco;
        private int numero;
        private int contraseña;

        public int CONTRASEÑA
        {
            set { this.contraseña = setContraseña(value); }
        }

        private int setContraseña(int password)
        {
            string pass = Convert.ToString(password);
            if (pass.Length != 4)
            {
                return 0;
            }
            else
            {
                return this.contraseña;
            }
        }

        public void setBanco(string bank)
        {
            this.banco = bank;
        }
        public string getBanco()
        {
            return this.banco;
        }

        public void setNumero(int number)
        {
            this.numero = number;
        }
        public int getNumero()
        {
            return this.numero;
        }

       
    }
}
