<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="CustomControls" namespace="CustomControls" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <cc1:CustomTemplateControl ID="CustomTemplateControl1" runat="server">
            <SecondTemplate>
                2
            </SecondTemplate>
            <FirstTemplate>
                1
            </FirstTemplate>
        </cc1:CustomTemplateControl>
    
    </div>
    </form>
</body>
</html>
