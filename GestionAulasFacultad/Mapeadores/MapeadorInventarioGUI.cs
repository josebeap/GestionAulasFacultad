using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionInventariosFacultad.Mapeadores
{
    public class MapeadorInventarioGUI : MapeadorBaseGUI<InventarioDTO, ModeloInventarioGUI>
    {
        public override ModeloInventarioGUI MapearTipo1Tipo2(InventarioDTO entrada)
        {
            return new ModeloInventarioGUI()
            {
                Id = entrada.Id,
                CodigoIdentificacion = entrada.CodigoIdentificacion,
                IdTipoElemento = entrada.IdTipoElemento,
                Estado = entrada.Estado
            };
        }

        public override IEnumerable<ModeloInventarioGUI> MapearTipo1Tipo2(IEnumerable<InventarioDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override InventarioDTO MapearTipo2Tipo1(ModeloInventarioGUI entrada)
        {
            return new InventarioDTO()
            {
                Id = entrada.Id,
                CodigoIdentificacion = entrada.CodigoIdentificacion,
                IdTipoElemento = entrada.IdTipoElemento,
                Estado = entrada.Estado
            };
        }

        public override IEnumerable<InventarioDTO> MapearTipo2Tipo1(IEnumerable<ModeloInventarioGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}