using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionTipoElementosFacultad.Mapeadores
{
    public class MapeadorTipoElementoGUI : MapeadorBaseGUI<TipoElementoDTO, ModeloTipoElementoGUI>
    {
        public override ModeloTipoElementoGUI MapearTipo1Tipo2(TipoElementoDTO entrada)
        {
            return new ModeloTipoElementoGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<ModeloTipoElementoGUI> MapearTipo1Tipo2(IEnumerable<TipoElementoDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override TipoElementoDTO MapearTipo2Tipo1(ModeloTipoElementoGUI entrada)
        {
            return new TipoElementoDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre
            };
        }

        public override IEnumerable<TipoElementoDTO> MapearTipo2Tipo1(IEnumerable<ModeloTipoElementoGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}