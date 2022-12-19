using GestionAulasFacultad.Mapeadores;
using GestionAulasFacultad.Models;
using Logica.DTO;
using System.Collections.Generic;

namespace GestionMateriasFacultad.Mapeadores
{
    public class MapeadorMateriaGUI : MapeadorBaseGUI<MateriaDTO, ModeloMateriaGUI>
    {
        public override ModeloMateriaGUI MapearTipo1Tipo2(MateriaDTO entrada)
        {
            return new ModeloMateriaGUI()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdPrograma = entrada.IdPrograma,

                NombrePrograma = entrada.NombrePrograma
            };
        }

        public override IEnumerable<ModeloMateriaGUI> MapearTipo1Tipo2(IEnumerable<MateriaDTO> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo1Tipo2(item);
            }
        }

        public override MateriaDTO MapearTipo2Tipo1(ModeloMateriaGUI entrada)
        {
            return new MateriaDTO()
            {
                Id = entrada.Id,
                Nombre = entrada.Nombre,
                IdPrograma = entrada.IdPrograma
            };
        }

        public override IEnumerable<MateriaDTO> MapearTipo2Tipo1(IEnumerable<ModeloMateriaGUI> entrada)
        {
            foreach (var item in entrada)
            {
                yield return MapearTipo2Tipo1(item);
            }
        }
    }
}