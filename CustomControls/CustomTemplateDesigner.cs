using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Web.UI.Design;
using System.Web.UI;
using System.Web.UI.Design.WebControls;
using System.ComponentModel;

namespace CustomControls
{
    public class CustomTemplateDesigner : CompositeControlDesigner
    {
        private CustomTemplateControl _Control;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            _Control = (CustomTemplateControl)component;

        }

        private EditableDesignerRegion GetEditableRegion(ITemplate template, string title, string index, StringBuilder sb)
        {
            IDesignerHost host = (IDesignerHost)GetService(typeof(IDesignerHost));

            sb.Append(String.Format(@"<tr>
                                        <td style=""font-family: Arial;background-color:#CCC"">
                                            {0}
                                        </td>
                                     </tr>
                                     <tr>
                                        <td {1}='{2}'>
                                            {3}
                                        </td>
                                     </tr>", title,
                            DesignerRegion.DesignerRegionAttributeName, index,
                            ControlPersister.PersistTemplate(template, host)));

            return new EditableDesignerRegion(this, String.Concat(DesignerRegion.DesignerRegionAttributeName, index), false);
        }

        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<table style=""border:1px solid #CCC"">");
            EditableDesignerRegion region = GetEditableRegion(_Control.FirstTemplate, "First", "0", sb);
            EditableDesignerRegion region2 = GetEditableRegion(_Control.SecondTemplate, "Second", "1", sb);
            sb.Append("</table>");
            regions.Add(region);
            regions.Add(region2);
            return sb.ToString();
        }

        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                ITemplate template = (region.Name == String.Concat(DesignerRegion.DesignerRegionAttributeName, "0")) ? _Control.FirstTemplate : _Control.SecondTemplate;
                if (template != null)
                    return ControlPersister.PersistTemplate(template, host);
            }
            return String.Empty;
        }

        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
                return;

            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                ITemplate template = ControlParser.ParseTemplate(host, content);
                if (region.Name == String.Concat(DesignerRegion.DesignerRegionAttributeName, "0"))
                    _Control.FirstTemplate = template;
                else
                    _Control.SecondTemplate = template;
            }
        }
    }
}