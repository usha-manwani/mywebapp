<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Control.aspx.cs" Inherits="CresijOnWeb.Control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
  <meta name="description" content=""/>
  <meta name="author" content="Dashboard"/>
    <title>Control Page</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.css" rel="stylesheet" />
    <link href="Content/style.css" rel="stylesheet" />
    <link href="Content/style-responsive.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div class="flipswitch">
    <input type="checkbox" name="flipswitch" class="flipswitch-cb" id="fs" checked>
    <label class="flipswitch-label" for="fs">
        <div class="flipswitch-inner"></div>
        <div class="flipswitch-switch"></div>
    </label>
</div>
        </div>
        <div>

            <section class="main">

				<div class="switch demo4">
					<input type="checkbox">
					<label><i class='icon-off'></i></label>
				</div>

				<div class="switch demo4">
					<input type="checkbox" checked>
					<label><i class='icon-off'></i></label>
				</div>

			</section>
        </div>
    </form>
</body>
</html>
