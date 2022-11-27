using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AccesoDeDatos.ModeloDeDatos;
using AccesoDeDatos.DbModel;

namespace AccesoDeDatos.Mapeadores
{
    public class MapeadorAuxiliarDatos : MapeadorBaseDatos<tb_auxiliar, AuxiliarDbModel>
    {
        public override AuxiliarDbModel MapearTipo1Tipo2(tb_auxiliar entrada)
        {
            return new AuxiliarDbModel()
            {
                Id = entrada.id,
                IdPersona=entrada.id_persona,
                Funcion=entrada.funcion
            };
        }

        public override IEnumerable<AuxiliarDbModel> MapearTipo1Tipo2(IEnumerable<tb_auxiliar> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override tb_auxiliar MapearTipo2Tipo1(AuxiliarDbModel entrada)
        {
            return new tb_auxiliar()
            {
                id = entrada.Id,
                id_persona=entrada.IdPersona,
                funcion=entrada.Funcion
            };
        }

        public override IEnumerable<tb_auxiliar> MapearTipo2Tipo1(IEnumerable<AuxiliarDbModel> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}