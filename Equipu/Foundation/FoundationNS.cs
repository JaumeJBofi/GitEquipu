using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

//Preg d
namespace PA120130698_G6.Foundation
{
    [Serializable]
   public enum ESTADOPROF
   {
       ACTIVO,
       NOACTIVO
   }

    [Serializable]
    public enum GENERO
    {
        MASCULINO,
        FEMENINO
    }
    [Serializable]
    public enum TDEDICACION
    {
        TOTAL,
        PARCIAL
    }
    

    [Serializable]
    static public class CategoriaMethods
    {
        static public List<CATEGORIA> GetCategorias()
        {
            List<CATEGORIA> ret = new List<CATEGORIA>();
            ret.Add(CATEGORIA.TECNOLOGIA);
            ret.Add(CATEGORIA.MANUALIDADES);
            ret.Add(CATEGORIA.SERVICIO_SOCIAL);
            ret.Add(CATEGORIA.EDUCACION);
            return ret;
        }

        static public CATEGORIA Parse(this CATEGORIA a,string categoria)
        {
            if (categoria.Equals("Tecnología")||(categoria.Equals("TECNOLOGIA"))) a = CATEGORIA.TECNOLOGIA;
            if (categoria.Equals("Manualidades")||(categoria.Equals("MANUALIDADES"))) a = CATEGORIA.MANUALIDADES;
            if (categoria.Equals("Servicio Social")||(categoria.Equals("SERVICIO SOCIAL"))) a = CATEGORIA.SERVICIO_SOCIAL;
            if (categoria.Equals("Educacion")|| (categoria.Equals("EDUCACION"))) a = CATEGORIA.EDUCACION;
            return a;
        }

        static public GENERO Parse(this GENERO a,string g)
        {
            if(g.Equals("Masculino")|| g.Equals("MASCULINO"))
            {
                a = GENERO.MASCULINO;
            }else
            {
                a = GENERO.FEMENINO;
            }
            return a;
        }

        static public TDEDICACION Parse(this TDEDICACION a, string g)
        {
            if (g.Equals("Total")|| g.Equals("TOTAL"))
            {
                a = TDEDICACION.TOTAL;
            }
            else
            {
                a = TDEDICACION.PARCIAL;
            }
            return a;
        }

        static public ESTADOPROF Parse(this ESTADOPROF a, string g)
        {
            if (g.Equals("Activo")|| g.Equals("ACTIVO"))
            {
                a = ESTADOPROF.ACTIVO;
            }
            else
            {
                a = ESTADOPROF.NOACTIVO;
            }
            return a;
        }
    }

    [Serializable]
    //# Preg a
    public enum CATEGORIA
    {
        TECNOLOGIA,SERVICIO_SOCIAL,
        EDUCACION,MANUALIDADES
    }
}
