<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
<script src="https://kit.fontawesome.com/0d10515950.js" crossorigin="anonymous"></script>
    <title>Jugadores</title>
</head>
<body>
    <form id="form1" runat="server">
        
        <i class="fa-solid fa-house bg-dark text-white">
            <a href="http://www.google.com">Link</a>
        </i>
        <<p class="display-1 bg-dark text-white min-width: 76px">Jugadores</p>
       
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        <div class="container-fluid">
          <div class="row">
            <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 bg-secondary text-white">
                <i class="fa-solid fa-user"></i>
                <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label>
                <asp:Panel ID="Panel2" runat="server"></asp:Panel>
                
            </div>
            <div class="col-sm-12 col-md-12 col-lg-6 col-xl-6 bg-primary text-white">
                 <i class="fa-solid fa-star"></i>
                 <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                 <asp:Panel ID="Panel3" runat="server"></asp:Panel>
     
             </div>
          </div>
        </div>
            
       
    </form>
</body>

</html>
