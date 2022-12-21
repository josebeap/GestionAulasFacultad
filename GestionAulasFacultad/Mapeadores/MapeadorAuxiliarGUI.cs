using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionAuxiliarsFacultad.Mapeadores
{
    public class MapeadorAuxiliarGUI : MapeadorBaseGUI<AuxiliarDTO, ModeloAuxiliarGUI>
    {
        public override ModeloAuxiliarGUI MapearTipo1Tipo2(AuxiliarDTO entrada)
        {
            return new ModeloAuxiliarGUI()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                Funcion = entrada.Funcion,
                NombrePersona=entrada.NombrePersona
            };
        }

        public override IEnumerable<ModeloAuxiliarGUI> MapearTipo1Tipo2(IEnumerable<AuxiliarDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override AuxiliarDTO MapearTipo2Tipo1(ModeloAuxiliarGUI entrada)
        {
            return new AuxiliarDTO()
            {
                Id = entrada.Id,
                IdPersona = entrada.IdPersona,
                Funcion = entrada.Funcion
            };
        }

        public override IEnumerable<AuxiliarDTO> MapearTipo2Tipo1(IEnumerable<ModeloAuxiliarGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}