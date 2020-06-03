<%@ Page Title="" Language="C#" MasterPageFile="~/Master.master" AutoEventWireup="true" CodeBehind="AcController.aspx.cs" Inherits="WebCresij.AcController" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterHead" runat="server">
    <style>
        .TableBorder {
            border: 1px solid #202838;
            border-radius: 5px;
            min-height: 150px;
            min-width: 300px;
            text-align: center;
            background-color: #aeb2b7;
        }
        .tdColumn {
            width: 33%;
            padding-top: 20px
        }
        .tableStyle {
            text-align: center;
            width: 100%;
            padding-right: 10px;
            
        }
        .headingStyle {
            color: white;
            background-color: #202838;
            margin-left: -10px;
            margin-top: -10px
        }
        .rowStyle {
            background-color: #dadada
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="masterBody" runat="server">
    <div class="row ">
        <div class="col-lg-4 col-md-6 col-sm-12">
            <div class="row ">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="TableBorder">
                        <h4 class="headingStyle"><img src="Images/icons/curtain1.png" height="25" width="25" />Curtain1</h4>
                        <table class="tableStyle">
                            <tr >
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainOpenWhite.png" id="c1open" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainStopWhite.png" id="c1stop" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainCloseWhite.png" id="c1close" height="70" width="70" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="TableBorder">
                        <h4 class="headingStyle"><img src="Images/icons/curtain1.png" height="25" width="25" />Curtain4</h4>
                        <table class="tableStyle">
                            <tr>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainOpenWhite.png" id="c4open" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainStopWhite.png" id="c4stop" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainCloseWhite.png" id="c4close" height="70" width="70" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="TableBorder">
                        <h4 class="headingStyle"><img src="Images/icons/curtain1.png" height="25" width="25" />Curtain2</h4>
                        <table class="tableStyle">
                            <tr>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainOpenWhite.png" id="c2open" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainStopWhite.png" id="c2stop" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainCloseWhite.png" id="c2close" height="70" width="70" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="TableBorder">
                        <h4 class="headingStyle"><img src="Images/icons/curtain1.png" height="25" width="25" />Curtain3</h4>
                        <table class="tableStyle">
                            <tr>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainOpenWhite.png" id="c3open" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainStopWhite.png" id="c3stop" height="70" width="70" /></td>
                                <td class="tdColumn">
                                    <img src="Images/icons/CurtainCloseWhite.png" id="c3close" height="70" width="70" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="TableBorder">
                        <h4 class="headingStyle"><img src="Images/icons/ACWhite.png" height="25" width="25" />AC Control</h4>
                        <table class="tableStyle">
                            <tr>
                                <td class="tdColumn" colspan="3">
                                    <img src="Images/icons/curtainOpenWhite.png" height="70" width="70" /></td>
                                <td class="tdColumn" colspan="3">
                                    <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                            </tr>
                            <tr>
                                <td class="tdColumn" colspan="2">
                                    <img src="Images/icons/curtainOpenWhite.png" height="70" width="70" /></td>
                                <td class="tdColumn" colspan="2">
                                    <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                                <td class="tdColumn" colspan="2">
                                    <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                            </tr>
                            <tr>
                                <td class="tdColumn" colspan="3">
                                    <img src="Images/icons/curtainOpenWhite.png" height="70" width="70" /></td>
                                <td class="tdColumn" colspan="3">
                                    <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row ">
        <div class="col-lg-4 col-md-6 col-sm-12">
            <div class="TableBorder">
                <h4 class="headingStyle"><img src="Images/icons/lightwhite.png" height="25" width="25" />Light Control 1</h4>
                <table class="tableStyle">
                    <tr>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                    </tr>
                    <tr >
                        <td class="tdColumn" style="font-size:small">Light1</td>
                        <td class="tdColumn" style="font-size:small">Light2</td>
                    </tr>
                    <tr>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                    </tr>
                    <tr >
                        <td class="tdColumn" style="font-size:small">Light3</td>
                        <td class="tdColumn" style="font-size:small">Light4</td>
                    </tr>
                    <tr>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                    </tr>
                    <tr >
                        <td class="tdColumn" style="font-size:small">Light5</td>
                        <td class="tdColumn" style="font-size:small">Light6</td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <div class="TableBorder">
                <h4 class="headingStyle"><img src="Images/icons/lightwhite.png" height="25" width="25" />Light Control 2</h4>
                <table class="tableStyle">
                    <tr>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                    </tr>
                    <tr >
                        <td class="tdColumn" style="font-size: small">Light7</td>
                        <td class="tdColumn" style="font-size: small">Light8</td>
                    </tr>
                    <tr>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                    </tr>
                    <tr >
                        <td class="tdColumn" style="font-size: small">Light9</td>
                        <td class="tdColumn" style="font-size: small">Light10</td>
                    </tr>
                    <tr>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                        <td class="tdColumn"><img src="Images/icons/lightwhite.png" height="60" width="60" /></td>
                    </tr>
                    <tr >
                        <td class="tdColumn" style="font-size: small">Light11</td>
                        <td class="tdColumn" style="font-size: small">Light12</td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-sm-12">
            <div class="TableBorder">
                <h4 class="headingStyle"><img src="Images/icons/AirWhite.png" height="25" width="25" />Fresh Air System</h4>
                <table class="tableStyle">
                    <tr>
                        <td class="tdColumn" colspan="3">
                            <img src="Images/icons/curtainOpenWhite.png" height="70" width="70" /></td>
                        <td class="tdColumn" colspan="3">
                            <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                    </tr>
                    <tr>
                        <td class="tdColumn" colspan="2">
                            <img src="Images/icons/curtainOpenWhite.png" height="70" width="70" /></td>
                        <td class="tdColumn" colspan="2">
                            <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                        <td class="tdColumn" colspan="2">
                            <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                    </tr>
                    <tr>
                        <td class="tdColumn" colspan="3">
                            <img src="Images/icons/curtainOpenWhite.png" height="70" width="70" /></td>
                        <td class="tdColumn" colspan="3">
                            <img src="Images/icons/curtainStopwhite.png" height="70" width="70" /></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
