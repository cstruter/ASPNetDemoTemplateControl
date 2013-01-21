using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CustomControls
{
    [ParseChildren(ChildrenAsProperties = true)]
    [Designer(typeof(CustomTemplateDesigner))]
    public class CustomTemplateControl : CompositeControl, INamingContainer
    {
        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(CustomTemplateControl))]
        public ITemplate FirstTemplate
        {
            get;
            set;
        }

        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateContainer(typeof(CustomTemplateControl))]
        public ITemplate SecondTemplate
        {
            get;
            set;
        }

        protected override void CreateChildControls()
        {
            if (FirstTemplate != null)
            {
                FirstTemplate.InstantiateIn(this);
            }
            if (SecondTemplate != null)
            {
                SecondTemplate.InstantiateIn(this);
            }

            base.CreateChildControls();
        }
    }
}
