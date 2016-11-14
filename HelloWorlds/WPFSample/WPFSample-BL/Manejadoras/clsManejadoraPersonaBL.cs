﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFSample_DAL.Manejadoras;
using WPFSample_Ent;

namespace WPFSample_BL
{
    public class clsManejadoraPersonaBL
    {
        private clsManejadoraPersonaDAL cmpd;

        public clsManejadoraPersonaBL()
        {
             cmpd = new clsManejadoraPersonaDAL();
        }

        /// <summary>
        /// Inserta una persona
        /// </summary>
        /// <param name="p"></param>
        /// <returns>-1 en caso de que hubiera fallo
        ///         1 en caso de que todo fuera correcto</returns>
        public int insertPerson(clsPersona p)
        {
            

            int resultado = -1;
            resultado = cmpd.insertPersona(p);
            return resultado;
        }

        public int updatePerson(clsPersona p)
        {
            int resultado = -1;
            resultado = cmpd.updatePersona(p);

            return resultado;
        }
    }
}
