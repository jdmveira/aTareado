namespace Jdmveira.aTareado.Entities
{
    using Jdmveira.aTareado.Common;
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class EntityBase : BindableBase, IEquatable<EntityBase>, IEquatable<Guid>
    {
        #region Constructor

        public EntityBase (): this (Guid.NewGuid(), string.Empty, string.Empty) { }

        public EntityBase(Guid uniqueId, string title, string description)
        {
            UniqueId = uniqueId;
            Title = title;
            Description = description;
        }

		#endregion Constructor

		#region Miembros Públicos

		public static implicit operator Guid(EntityBase eb)
		{
			return eb.UniqueId;
		}

		public static explicit operator EntityBase(Guid id)
		{
			return new EntityBase(id, string.Empty, string.Empty);
		}

        [DataMember(Name = "id", IsRequired = true)]
        public Guid UniqueId
        {
            get { return _uniqueId; }
            set { SetProperty(ref _uniqueId, value); }
        }

        [DataMember(Name = "title", IsRequired = true)]
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        [DataMember(Name = "description", IsRequired = false)]
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public bool Equals(EntityBase other)
        {
            if (other == null)
                return false;

            return this.UniqueId == other.UniqueId;
        }

		public bool Equals(Guid other)
		{
			return this.UniqueId == other;
		}

        public override bool Equals(object obj)
        {
            EntityBase theOther = obj as EntityBase;

            if (theOther == null)
                return false;
            else
                return this.Equals(theOther);
        }

        public override int GetHashCode()
        {
            return UniqueId.GetHashCode();
        }

        #endregion Miembros Públicos

        #region Miembros Privados

        private Guid _uniqueId;
        private string _title;
        private string _description;

        #endregion Miembros Privados
    }
}