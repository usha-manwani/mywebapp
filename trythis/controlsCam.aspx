<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="controlsCam.aspx.cs" Inherits="trythis.controlsCam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap-grid.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <title></title>
    <style>
        html {
  box-sizing: border-box;
}
@media  (max-width: 700px){
div{
    width:100%;
}
}
*, *::before, *::after {
  box-sizing: inherit;
}
        .wrapper > div {
            border: black;
            border-radius: 1px;
            background-color: #1d2129;
            padding: 1em;
            border-radius:10px 10px;
            color: white;
            justify-content:center;
            -moz-box-shadow:    0px 0px 5px 5px #000;
            -webkit-box-shadow: 0px 0px 5px 5px #000;
            box-shadow:         0px 0px 5px 5px #000;
            border-width:0 20px 20px 0;
        }
        .wrapper {
            display: grid;
            display:  -ms-grid;
            -ms-grid-columns: repeat(1fr 20px)[14];
            width:70%;
            grid-template-columns: repeat(14, 1fr);
            grid-gap: 13px;
            grid-auto-rows: minmax(100px, auto);           
            background-color:#262d3c;
            -moz-box-shadow:    inset 0 0 10px #000000;
            -webkit-box-shadow: inset 0 0 10px #000000;
            box-shadow:         inset 0 0 10px #000000;
            padding: 1em 1em 1em 1em;
        }
        .one {
            grid-column: 1 /span 2;
            grid-row: 1/ span 6;
            -ms-grid-column:1 ;
            -ms-grid-column-span:2;
            -ms-grid-row: 1;
            -ms-grid-row-span:6;   
             border-width: 0 20px 20px 0;
        }
        .two { 
            grid-column: 3/ span 2 ;
            grid-row: 1/ span 4;
            -ms-grid-column:3 ;
            -ms-grid-row: 1;
            -ms-grid-column-span:2;
            -ms-grid-row-span:4;
             border-width: 0 20px 20px 0;
        }
        .three {
            grid-column: 5/ span 7;
            grid-row: 1/ span 4;
            -ms-grid-column: 5;
            -ms-grid-row: 1;
            -ms-grid-column-span:7;
            -ms-grid-row-span:4;
             border-width: 0 20px 20px 0;
        }
        .four {
            grid-column: 12 / span 3;
            grid-row: 1/ span 4;
            -ms-grid-column: 12 ;
            -ms-grid-row: 1;
            -ms-grid-column-span:3;
            -ms-grid-row-span:4;
             border-width: 0 20px 20px 0;
        }
        .five {
            grid-column: 3/ span 6;
            grid-row:5/ span 2;
            -ms-grid-column: 3;
            -ms-grid-row: 5;
            -ms-grid-column-span:6;
            -ms-grid-row-span:2;
             border-width: 0 20px 20px 0;
        }
        .six {
            grid-column: 9/ span 6;
            grid-row: 5/ span 2;
            -ms-grid-column: 9;
            -ms-grid-row: 5;
            -ms-grid-column-span:6;
            -ms-grid-row-span:2;
             border-width: 0 20px 20px 0;
        }
 </style>
</head>
<body>
    <form id="form1" runat="server"> 
        <div class="container-fluid">
            <div class="wrapper" >
             <div class="one " ><p>this is a test paragraph one</p></div>
             <div class="two "><p>this is a test paragraph two</p></div>
             <div class="three " style="-moz-box-shadow:inset 0 0 15px #000000;
                -webkit-box-shadow: inset 0 0 15px #000000;
                box-shadow:inset 0 0 15px #000000;" >
                 <p>this is a test paragraph three</p></div>
             <div class="four" ><p>this is a test paragraph four</p></div>
             <div class="five "><p>this is a test paragraph five</p></div>
             <div class="six " id="accordion" >
                 <div class="custom-accordion">
                    <div class="item">
                         <div class="title">
                             <div class="text">section 1</div>
                         </div>
                     
                 <div class="content">
                 <div class="togglebale">
                 <p >this is a test paragraph six</p>
                     <ul>
                        <li>Item 1</li>
                        <li>Item 2</li>
                        <li>Item 3</li>
                    </ul>
                 </div>
                     </div>
                        </div>
                  <div class="item">
                         <div class="title">
                             <div class="text">section 2</div>
                         </div>                     
                 <div class="content">
                 <div><p class="togglebale">this is a test paragraph six</p></div>
                 <h3>section1 </h3><div><p class="togglebale">this is a test paragraph six</p></div>
                <h3>section1 </h3><div><p class="togglebale">this is a test paragraph six</p></div>
                <h3>section1 </h3> <div><p class="togglebale">this is a test paragraph six</p></div>
                <h3>section1 </h3> <div><p class="togglebale">this is a test paragraph six</p></div>
                 <h3>Section 3</h3><div><p>this is a test paragraph SEVEN</p></div>
                     </div>
             </div>  
           </div>
            </div>
    </form>
    <script type="text/javascript">
       $( function() {
    $( "#accordion" ).accordion();
  } );
    </script>
</body>
    
</html>
