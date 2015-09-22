namespace Jdmveira.aTareado.Data.Design
{
    using Jdmveira.aTareado.Entities;
    using System;

    internal sealed class DesignTimeGtdActionCreator
    {
        #region Constructor

        internal DesignTimeGtdActionCreator(GtdActionRepository rep)
        {
            _rep = rep;
        }

        #endregion Constructor

        #region Miembros Internos

        internal void CreateDesignInformation(int number = 10)
        {
            for (int i = 0; i < number; i++)
            {
                var action = new GtdAction(Guid.NewGuid(), string.Format(TITLE, i), string.Format(DESCRIPTION, i));

                action.IsImportant = i % 2 == 0;
                action.PercentageCompleted = i % 100;
                action.Schedule = CreateScheduleInfo(i);

                _rep.Insert(action);
            }
        }

        #endregion Miembros Internos

        #region Miembros Privados

        private static ActionScheduleInfo CreateScheduleInfo(int seed)
        {
            ActionScheduleInfo asi = new ActionScheduleInfo();

            if (seed % 2 == 0)
                asi.StartDate = DateTime.Now;

            if (seed % 3 == 0)
                asi.DueDate = DateTime.Now.AddDays(seed % 7);

            return asi;
        }

        private GtdActionRepository _rep;
        private static readonly string TITLE = "Title [{0}]";

        private static readonly string DESCRIPTION = "[{0}] Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras at arcu non neque gravida commodo. Nunc placerat libero sodales arcu consequat vehicula. Nunc et venenatis sem, id faucibus mauris. Sed tincidunt, nisl vel laoreet lacinia, libero erat hendrerit ante, at venenatis massa ligula quis diam. Integer congue elit in sapien ornare, semper vehicula purus porta. Donec nulla risus, pellentesque ac nibh eget, commodo rutrum sapien. Etiam facilisis diam ac est faucibus tincidunt. Maecenas quis tincidunt justo. Ut rutrum elit vulputate tortor dignissim rhoncus. Donec elementum ligula vitae nisl rhoncus rhoncus. Pellentesque placerat lectus non dui malesuada viverra a id arcu. Morbi odio nisl, sollicitudin quis eros at, condimentum efficitur magna. \n" +
                                                     "Nunc neque justo, posuere quis massa a, dignissim bibendum diam.In vel tortor interdum ante feugiat ornare vitae faucibus ipsum.Integer nec odio sit amet nibh aliquam sodales nec mattis arcu.Curabitur mauris orci, eleifend in consectetur at, ultricies sed risus.Donec bibendum, dolor in dignissim faucibus, felis turpis aliquam ligula, sed rhoncus quam diam vitae tortor. Proin tempor erat eget libero auctor, at ultricies lorem suscipit. Proin quis feugiat elit, sed gravida nulla.Phasellus laoreet ultrices arcu eu scelerisque. Phasellus condimentum arcu nec faucibus varius. ";
        #endregion Miembros Privados
    }
}