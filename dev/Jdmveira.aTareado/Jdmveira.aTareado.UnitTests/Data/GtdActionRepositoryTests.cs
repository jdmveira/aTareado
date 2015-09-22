namespace Jdmveira.aTareado.Data.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Jdmveira.aTareado.Data;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Jdmveira.aTareado.Entities;

	[TestClass()]
	public class GtdActionRepositoryTests
	{
		#region Auxiliares

		[TestInitialize]
		public void InitializeRepository()
		{
			_repository = new GtdActionRepository();

			var choose = DateTime.Now.Ticks % MAX;

			for (int i = 0; i < MAX; i++)
			{
				GtdAction act = new GtdAction(Guid.NewGuid(), String.Format(TITLE_TEMPLATE, i), String.Format(DESC_TEMPLATE, i));
				_repository.Insert(act);

				if (choose == i)
					_action2Find = act;
			}
		}

		[TestCleanup]
		public void CleanUpRepository()
		{
			_repository = null;
		}
		#endregion

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.IsNotNull(_repository);

			var title = String.Empty;
			var enumerator = _repository.GetEnumerator();
			int cont = 0;
			GtdAction actionToDelete = null;

			while (enumerator.MoveNext())
			{
				if (actionToDelete == null)
					actionToDelete = enumerator.Current;

				cont++;
			}

			Assert.IsTrue(cont > 0);
			Assert.IsNotNull(actionToDelete);

			_repository.Delete(actionToDelete);

			enumerator = _repository.GetEnumerator();

			int cont2 = 0;
			bool actionDeleted = true;

			while (enumerator.MoveNext())
			{
				actionDeleted = enumerator.Current != actionToDelete;
				cont2++;
			}

			Assert.IsTrue(cont2 == cont - 1);
			Assert.IsTrue(actionDeleted);
		}

		[TestMethod()]
		public void GetAllTest()
		{
			List<GtdAction> allItems = null;

			allItems = new List<GtdAction>(_repository.GetAll());

			Assert.IsTrue(allItems.Count == 10);

			var enumerator = _repository.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (!allItems.Contains(enumerator.Current))
					Assert.Fail();
			}
		}

		[TestMethod()]
		public void GetByIdTest()
		{
			var found = _repository.GetById(_action2Find.UniqueId);

			Assert.IsNotNull(found);
			Assert.AreEqual<GtdAction>(found, _action2Find);
		}

		public void GetByIdWhereActionDoesNotExistTest()
		{
			Guid guid = Guid.NewGuid();

			var found = _repository.GetById(guid);

			Assert.IsNull(found);
		}


		[TestMethod()]
		public void SearchForSingleActionTest()
		{
			var found = _repository.SearchFor(a => a.Title == _action2Find.Title);

			Assert.IsNotNull(found);
			Assert.AreEqual(found.Count(), 1);
		}

		public void SearchForMultipleActionsTest()
		{
			var found = _repository.SearchFor(a => a.Title.Contains("Title"));

			Assert.IsNotNull(found);
			Assert.AreEqual(found.Count(), MAX);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			string newTitle = "Updated";
			_action2Find.Title = newTitle;

			var result = _repository.Update(_action2Find);
			GtdAction found = null;
			var enumerator = _repository.GetEnumerator();

			while (enumerator.MoveNext())
			{
				if (enumerator.Current.UniqueId == _action2Find.UniqueId)
				{
					found = _action2Find;
					break;
				}
			}

			Assert.IsTrue(result);
			Assert.IsNotNull(found);
			Assert.AreEqual(found.Title, newTitle);
		}

		[TestMethod]
		public void UpdateNonExistingTest()
		{
			GtdAction action = new GtdAction (Guid.NewGuid(), "Title", "Descr");

			bool result = _repository.Update(action);

			Assert.IsFalse(result);
		}

		[TestMethod()]
		public void InsertTest()
		{
			GtdActionRepository repository = new GtdActionRepository();
			Guid actionId = Guid.NewGuid();
			string title = "Title";
			string description = "Description";

			GtdAction expectedAction = new GtdAction(actionId, title, description);
			GtdAction action = null;
			int cont = 0;

			repository.Insert(expectedAction);

			var enumerator = repository.GetEnumerator();
			while (enumerator.MoveNext())
			{
				action = enumerator.Current;
				cont++;
			}

			Assert.IsTrue(cont == 1);
			Assert.IsTrue(action.UniqueId == actionId);
		}

		#region Miembros Privados

		private GtdActionRepository _repository;

		private GtdAction _action2Find;

		static readonly int MAX = 10;
		static readonly string TITLE_TEMPLATE = "Title {0}";
		static readonly string DESC_TEMPLATE = "Description {0}";

		#endregion
	}
}