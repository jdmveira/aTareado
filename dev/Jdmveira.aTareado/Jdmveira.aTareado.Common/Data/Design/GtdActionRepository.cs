namespace Jdmveira.aTareado.Data.Design
{
	using Jdmveira.aTareado.Entities;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Collections;

	public sealed class GtdActionRepository : Jdmveira.aTareado.Data.GtdActionRepository
    {
        #region Constructor

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public GtdActionRepository(): base ()
        {
            var filler = new DesignTimeGtdActionCreator(this);
            filler.CreateDesignInformation(7);
        }

        #endregion Constructor

        #region Miembros Públicos

		public override void Save()
		{
			return;
		}

		public override void Load()
		{
			return;
		}

        #endregion Miembros Públicos
    }
}