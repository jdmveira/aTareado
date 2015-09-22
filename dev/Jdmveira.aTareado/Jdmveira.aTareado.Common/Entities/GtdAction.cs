namespace Jdmveira.aTareado.Entities
{
    using System;
    using System.Runtime.Serialization;

    public enum KindOfGtdAction
    {
        Passed,
        Today,
        Todo
    }

    [DataContract]
    public sealed class GtdAction : EntityBase
    {
        #region Constructores

        public GtdAction() : this(Guid.NewGuid(), string.Empty, string.Empty) { }

        public GtdAction(Guid uniqueId, string title, string description) : base(uniqueId, title, description)
        {
        }

        #endregion Constructores

        #region Miembros Públicos

        [DataMember(Name = "schedule_info", IsRequired = true)]
        public ActionScheduleInfo Schedule
        {
            get { return _schedule; }
            set { SetProperty<ActionScheduleInfo>(ref _schedule, value); }
        }

        [DataMember(Name = "important", IsRequired = true)]
        public bool IsImportant
        {
            get { return _isImportant; }
            set { SetProperty<bool>(ref _isImportant, value); }
        }

        [DataMember(Name = "percentage_completed", IsRequired = false)]
        public double? PercentageCompleted
        {
            get { return _percentageCompleted; }
            set { SetProperty<double?>(ref _percentageCompleted, value); }
        }

        public static KindOfGtdAction KindOf(GtdAction a)
        {
            if (a.Schedule == null)
                return KindOfGtdAction.Todo;

            if (!a.Schedule.DueDate.HasValue)
                return KindOfGtdAction.Todo;

            DateTime beginOfDayNow = new DateTime (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0,0,0);
            DateTime endOfDayNow = beginOfDayNow.AddDays (1);

            if (a.Schedule.DueDate < beginOfDayNow)
                return KindOfGtdAction.Passed;

            if (a.Schedule.DueDate >= beginOfDayNow && a.Schedule.DueDate < endOfDayNow)
                return KindOfGtdAction.Today;

            if (a.Schedule.DueDate > endOfDayNow)
                return KindOfGtdAction.Todo;

            return KindOfGtdAction.Todo;
        }

        public KindOfGtdAction KindOf()
        {
            return this.KindOf();
        }
        #endregion Miembros Públicos

        #region Miembros Privados

        private ActionScheduleInfo _schedule;
        private bool _isImportant;
        private double? _percentageCompleted;
        #endregion Miembros Privados

    }
}