<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reader.aspx.cs" Inherits="trythis.Reader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .modal1 {
    display: none; /* Hidden by default */
    position: fixed; /* Stay in place */
    z-index: 1; /* Sit on top */
    padding-top: 100px; /* Location of the box */
    left: 0;
    top: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
}
        .modal1-content {
    background-color: #fefefe;
    margin: auto;
    padding: 20px;
    border: 1px solid #888;
    width: 80%;
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <div>
         <button id="myBtn" >Open Modal</button>
         <div id="myModal" class="modal1">

  <!-- Modal content -->
  <div class="modal1-content">
    <span class="close">&times;</span>
    <p>Some text in the Modal..</p>
  </div>

</div>
             </div>
        </div>
    </form>
</body>
</html>
