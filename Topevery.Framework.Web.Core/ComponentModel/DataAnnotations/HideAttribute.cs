using System;
using Topevery.Framework.Interface;

namespace Topevery.Framework.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class HideAttribute : Attribute, IDataAnnotations
    {
        public HideAttribute()
        {
            IsHiddenOnCreate = true;
            IsHiddenOnDetail = true;
            IsHiddenOnView = true;
            IsHiddenOnEdit = true;
        }

        public bool IsHiddenOnView { get; set; }
        public bool IsHiddenOnEdit { get; set; }
        public bool IsHiddenOnCreate { get; set; }
        public bool IsHiddenOnDetail { get; set; }

        public void SetRuntimeProperty(IEntityPropertyMetadata runtimeProperty)
        {
            if (runtimeProperty == null)
                throw new ArgumentNullException(nameof(runtimeProperty));
            runtimeProperty.IsHiddenOnCreate = IsHiddenOnCreate;
            runtimeProperty.IsHiddenOnDetail = IsHiddenOnDetail;
            runtimeProperty.IsHiddenOnView = IsHiddenOnView;
            runtimeProperty.IsHiddenOnEdit = IsHiddenOnEdit;
        }
    }
}