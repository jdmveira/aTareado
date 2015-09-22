namespace Jdmveira.aTareado.Entities
{
    using Jdmveira.aTareado.Common;
    using System;
    using System.Runtime.Serialization;

    public enum ActionScheduleState
    {
        Passed,
        Today,
        Todo
    }

    [DataContract]
    public sealed class ActionScheduleInfo : BindableBase, IEquatable<ActionScheduleInfo>
    {
        #region Constructores

        public ActionScheduleInfo() : this(default(DateTime?), default(DateTime?))
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="startDate">Fecha de inicio para la acción</param>
        /// <param name="dueDate">Fecha de finalización para la acción</param>
        public ActionScheduleInfo(DateTime? startDate, DateTime? dueDate)
            : this(startDate, dueDate, DateTime.UtcNow)
        {
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="startDate">Fecha de inicio para la acción</param>
        /// <param name="dueDate">Fecha de finalización para la acción</param>
        /// <param name="creationDate">Fecha de creación de la acción, útil cuando no hay fecha de inicio</param>
        public ActionScheduleInfo(DateTime? startDate, DateTime? dueDate, DateTime creationDate)
            //: this(startDate, dueDate, creationDate, true)
        {
            StartDate = startDate.HasValue ? startDate.Value: startDate;
            DueDate = dueDate.HasValue ? dueDate.Value : dueDate;
            CreationDate = creationDate;
                        
            CheckValidDates(StartDate, DueDate);
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="startDate">Fecha de inicio para la acción</param>
        /// <param name="dueDate">Fecha de finalización para la acción</param>
        /// <param name="creationDate">Fecha de creación de la acción, útil cuando no hay fecha de inicio</param>
        //public ActionScheduleInfo(DateTime? startDate, DateTime? dueDate, DateTime creationDate, bool fromUtc)
        //{
        //    StartDate = startDate.HasValue ? (fromUtc ? startDate.Value.ToUniversalTime() : startDate.Value) : startDate;
        //    DueDate = dueDate.HasValue ? (fromUtc ? dueDate.Value.ToUniversalTime() : dueDate.Value) : dueDate;
        //    CreationDate = creationDate.ToUniversalTime();
        //}

        #endregion Constructores

        #region Miembros Públicos

        /// <summary>
        /// Fecha de inicio de la planificación
        /// </summary>
        [DataMember(Name = "start_date", IsRequired = false)]
        public DateTime? StartDate
        {
            get
            {
                if (_startDate.HasValue)
                    return _startDate.Value;
                else
                    return default(DateTime?);
            }
            set
            {
                DateTime? v = ToUtc(value);

                CheckValidDates(v, DueDate);

                SetProperty<DateTime?>(ref _startDate, v);
            }
        }

        /// <summary>
        /// Fecha fin de la planificación
        /// </summary>
        [DataMember(Name = "due_date", IsRequired = false)]
        public DateTime? DueDate
        {
            get {
                if (_dueDate.HasValue)
                    return _dueDate.Value;
                else
                    return default(DateTime?);
            }
            set
            {
                DateTime? v = ToUtc(value);

                CheckValidDates(StartDate, v);

                SetProperty<DateTime?>(ref _dueDate, v);
            }
        }

        /// <summary>
        /// Fecha fin de la planificación
        /// </summary>
        [DataMember(Name = "creation_date", IsRequired = true)]
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set
            {
                DateTime v = ToUtc(value);
                SetProperty<DateTime>(ref _creationDate, v);
            }
        }

        #endregion Miembros Públicos

        #region Miembros Privados

        /// <summary>
        /// Devuelve la fecha en UTC
        /// </summary>
        /// <param name="date">Fecha de entrada</param>
        /// <returns>Fecha de entrada convertida a UTC</returns>
        private DateTime? ToUtc(DateTime? date)
        {
            return date.HasValue ? ToUtc(date.Value) : default(DateTime?);
        }

        /// <summary>
        /// Devuelve la fecha en UTC
        /// </summary>
        /// <param name="date">Fecha de entrada</param>
        /// <returns>Fecha de entrada convertida a UTC</returns>
        private DateTime ToUtc(DateTime date)
        {
            return date.ToUniversalTime();
        }

        public bool Equals(ActionScheduleInfo other)
        {
            return (this.StartDate == other.StartDate) && (this.DueDate == other.DueDate);
        }

        private static void CheckValidDates (DateTime? sd, DateTime? dd)
        {
            if (!sd.HasValue || !dd.HasValue)
                return;

            //TODO: Ver por qué los recursos no están funcionando bien
            if (sd.Value <= dd.Value)
                throw new ArgumentOutOfRangeException("DueDate");
        }

        private DateTime? _startDate;
        private DateTime? _dueDate;
        private DateTime _creationDate;

        #endregion Miembros Privados
    }
}